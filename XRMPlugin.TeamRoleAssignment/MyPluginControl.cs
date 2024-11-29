using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using XrmToolBox.Extensibility;
using Excel = Microsoft.Office.Interop.Excel;

namespace XRMPlugin.TeamManager
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;
        private Team SelectedTeam;
        private View SelectedView;
        private QueryExpression UserQuery;
        private ListViewItem SelectedListUser;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }

            LoadTeams();
            LoadRoles();
            LoadSavedViews();
            if (!string.IsNullOrEmpty(textBoxFileName.Text))
            {
                PopulateUserList(UserQuery);
            }
        }

        private void ResetForm(Control excludedControl)
        {
            if (excludedControl != comboBoxExistingTeam && comboBoxExistingTeam.SelectedIndex > 0) comboBoxExistingTeam.SelectedIndex = -1;
            if (excludedControl != comboBoxSavedView && comboBoxSavedView.SelectedIndex > 0) comboBoxSavedView.SelectedIndex = -1;
            if (excludedControl != textBoxFileName) textBoxFileName.Clear();
            if (listBoxTeams.SelectedIndices.Count > 0) listBoxTeams.SelectedItems.Clear();
            if (listBoxRoles.SelectedIndices.Count > 0) listBoxRoles.SelectedItems.Clear();
            if (radioButtonAdd.Checked) radioButtonAdd.Checked = false;
            if (radioButtonRemove.Checked) radioButtonRemove.Checked = false;
            if (checkBoxRemoveOthers.Checked) checkBoxRemoveOthers.Checked = false;
            listViewUsers.Items.Clear();
        }

        private void LoadTeams()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Work = (worker, args) =>
                {
                    var teamQuery = new QueryExpression("team");
                    teamQuery.ColumnSet.AddColumns("name");
                    teamQuery.Criteria.AddCondition("isdefault", ConditionOperator.Equal, false);
                    teamQuery.Criteria.AddCondition("teamtype", ConditionOperator.Equal, 0);
                    teamQuery.AddOrder("name", OrderType.Ascending);
                    var result = Service.RetrieveMultiple(teamQuery);

                    args.Result = result.Entities.Select(t => new Team(t));
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }

                    var teams = args.Result as IEnumerable<Team>;
                    if (teams != null && teams.Any())
                    {
                        comboBoxExistingTeam.Items.Clear();
                        comboBoxExistingTeam.Items.AddRange(teams.ToArray());
                        if (SelectedTeam != null) comboBoxExistingTeam.SelectedItem = comboBoxExistingTeam.Items.Cast<Team>().FirstOrDefault(t => t.Name == SelectedTeam.Name);
                        var selectedTeams = listBoxTeams.SelectedItems.Cast<Team>().Select(t => t.Name).ToArray();
                        listBoxTeams.Items.Clear();
                        listBoxTeams.Items.AddRange(teams.ToArray());
                        if (selectedTeams.Any())
                        {
                            foreach (var item in listBoxTeams.Items.Cast<Team>().Where(t => selectedTeams.Contains(t.Name)).ToArray())
                            {
                                listBoxTeams.SelectedItems.Add(item);
                            }
                        }
                    }
                }
            });
        }

        private void LoadRoles()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Work = (worker, args) =>
                {
                    var roleQuery = new QueryExpression("role");
                    roleQuery.ColumnSet.AddColumns("name");
                    roleQuery.AddOrder("name", OrderType.Ascending);
                    var result = Service.RetrieveMultiple(roleQuery);

                    args.Result = result.Entities.Select(t => new Role(t));
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }

                    var roles = args.Result as IEnumerable<Role>;
                    if (roles != null && roles.Any())
                    {
                        var selectedRoles = listBoxRoles.SelectedItems.Cast<Role>().Select(t => t.Name).ToArray();
                        listBoxRoles.Items.Clear();
                        listBoxRoles.Items.AddRange(roles.ToArray());
                        if (selectedRoles.Any())
                        {
                            foreach (var item in listBoxRoles.Items.Cast<Role>().Where(t => selectedRoles.Contains(t.Name)).ToArray())
                            {
                                listBoxRoles.SelectedItems.Add(item);
                            }
                        }
                    }
                }
            });
        }

        private void LoadSavedViews()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Work = (worker, args) =>
                {
                    var systemViewQuery = new QueryExpression("savedquery");
                    systemViewQuery.ColumnSet.AddColumns("name", "fetchxml");
                    systemViewQuery.Criteria.AddCondition("querytype", ConditionOperator.Equal, 0);
                    systemViewQuery.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                    systemViewQuery.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, "systemuser");
                    systemViewQuery.AddOrder("name", OrderType.Ascending);
                    var systemViewResults = Service.RetrieveMultiple(systemViewQuery);

                    var userViewQuery = new QueryExpression("userquery");
                    userViewQuery.ColumnSet.AddColumns("name", "fetchxml");
                    userViewQuery.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, "systemuser");
                    userViewQuery.AddOrder("name", OrderType.Ascending);
                    var userViewResults = Service.RetrieveMultiple(userViewQuery);

                    args.Result = systemViewResults.Entities.Concat(userViewResults.Entities).Select(v => new View(v));
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }

                    var views = args.Result as IEnumerable<View>;
                    if (args.Result != null && views.Any())
                    {
                        comboBoxSavedView.Items.Clear();
                        comboBoxSavedView.Items.AddRange(views.ToArray());
                        if (SelectedView != null) comboBoxSavedView.SelectedItem = comboBoxSavedView.Items.Cast<object>().FirstOrDefault(t => t.ToString() == SelectedView.ToString()) ?? "";
                    }
                }
            });
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            //var openFileDialog = new OpenFileDialog
            //{
            //    Title = "Select User List",
            //    Filter = "All supported files|*.csv;*.txt;*.xls;*.xlsx|csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|Excel files (*.xls; *.xlsx)|*.xls;*.xlsx",
            //    RestoreDirectory = true
            //};

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFileName.Text = openFileDialog.FileName;
                LoadUserListFromFiles(openFileDialog.FileNames);
            }
        }

        private void listViewUsers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                textBoxFileName.Text = files[0];
                LoadUserListFromFiles(files);
            }
        }

        private void listViewUsers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
        }

        private void LoadUserListFromFiles(string[] files)
        {
            ResetForm(textBoxFileName);
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading file",
                Work = (worker, args) =>
                {
                    var userList = new HashSet<string>();

                    var textExtensions = new string[] { ".csv", ".txt" };
                    foreach (var file in files.Where(f => textExtensions.Contains(Path.GetExtension(f))))
                    {
                        var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);

                        using (var reader = new StreamReader(fileStream))
                        {
                            while (!reader.EndOfStream)
                            {
                                var user = reader.ReadLine().Split(new[] { ',', '\t' }, 2)[0];
                                userList.Add(user);
                            }
                        }
                    }

                    var excelExtensions = new string[] { ".xls", ".xlsx" };
                    foreach (var file in files.Where(f => excelExtensions.Contains(Path.GetExtension(f))))
                    {
                        var xlApp = new Excel.Application();
                        var xlWorkbook = xlApp.Workbooks.Open(file);
                        var xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets[1];
                        var xlRange = xlWorksheet.UsedRange.Columns[1];

                        if (xlWorksheet.ListObjects.Count > 0)
                        {
                            var xlListObject = xlWorksheet.ListObjects[1];
                            var xlListColumn = xlListObject.ListColumns.Cast<Excel.ListColumn>().FirstOrDefault(lc => lc.Name == "User Name");
                            if (xlListColumn != null) xlRange = xlListColumn.Range;
                        }

                        foreach (object cell in (Array)xlRange.Value)
                        {
                            userList.Add(cell.ToString());
                        }
                    }

                    if (userList.Any())
                    {
                        var userQuery = new QueryExpression("systemuser");
                        userQuery.ColumnSet.AddColumns("domainname", "firstname", "lastname", "isdisabled");
                        userQuery.Criteria.AddCondition("domainname", ConditionOperator.In, userList.ToArray());
                        userQuery.AddOrder("domainname", OrderType.Ascending);
                        args.Result = userQuery;
                    }
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }
                    var query = args.Result as QueryExpression;
                    PopulateUserList(query);
                }
            });
        }

        private void comboBoxExistingTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxExistingTeam.SelectedItem != null && comboBoxExistingTeam.SelectedItem.ToString() != SelectedTeam?.ToString())
            {
                ResetForm(comboBoxExistingTeam);
            }

            SelectedTeam = comboBoxExistingTeam.SelectedItem as Team;

            if (SelectedTeam != null)
            {
                var userQuery = new QueryExpression("systemuser");
                userQuery.ColumnSet.AddColumns("domainname", "firstname", "lastname", "isdisabled");
                userQuery.AddOrder("domainname", OrderType.Ascending);
                var teamLink = userQuery.AddLink("teammembership", "systemuserid", "systemuserid");
                teamLink.LinkCriteria.AddCondition("teamid", ConditionOperator.Equal, SelectedTeam.Id);
                PopulateUserList(userQuery);
            }
            else
            {
                ToggleEnabled();
            }
        }

        private void comboBoxSavedView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSavedView.SelectedItem != null && comboBoxSavedView.SelectedItem.ToString() != SelectedView?.ToString())
            {
                ResetForm(comboBoxSavedView);
            }

            SelectedView = comboBoxSavedView.SelectedItem as View;

            if (SelectedView != null)
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading view",
                    Work = (worker, args) =>
                    {
                        FetchXmlToQueryExpressionRequest fetchXmlToQueryExpressionRequest = new FetchXmlToQueryExpressionRequest()
                        {
                            FetchXml = SelectedView.FetchXml
                        };
                        var fetchXmlToQueryExpressionResponse = Service.Execute(fetchXmlToQueryExpressionRequest) as FetchXmlToQueryExpressionResponse;
                        var viewQueryExpression = fetchXmlToQueryExpressionResponse.Query;
                        viewQueryExpression.ColumnSet = new ColumnSet("domainname", "firstname", "lastname", "isdisabled");
                        viewQueryExpression.Orders.Clear();
                        viewQueryExpression.AddOrder("domainname", OrderType.Ascending);
                        args.Result = viewQueryExpression;
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            ShowErrorDialog(args.Error);
                        }
                        var query = args.Result as QueryExpression;
                        PopulateUserList(query);
                    }
                });
            }
            else
            {
                ToggleEnabled();
            }
        }

        private void PopulateUserList(QueryExpression userQuery)
        {
            listViewUsers.Items.Clear();
            ToggleEnabled();

            if (userQuery != null)
            {
                UserQuery = userQuery;

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading users",
                    Work = (worker, args) =>
                    {
                        args.Result = Service.RetrieveMultiple(userQuery);
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            ShowErrorDialog(args.Error);
                        }

                        var results = args.Result as EntityCollection;

                        if (results.Entities.Any())
                        {
                            foreach (var userEntity in results.Entities)
                            {
                                var user = new User(userEntity);
                                listViewUsers.Items.Add(new ListViewItem
                                {
                                    Tag = user,
                                    Text = user.UserName,
                                    SubItems =  {
                                        user.LastName,
                                        user.FirstName,
                                        user.Status
                                    },
                                    ForeColor = user.Disabled ? Color.Gray : ForeColor
                                });
                            }
                            ToggleEnabled();
                        }
                    }
                });
            }
        }
        private void listViewUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listViewUsers.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    SelectedListUser = focusedItem;
                    contextMenuStripUsers.Show(Cursor.Position);
                }
            }
        }

        private void toolStripRemoveUser_Click(object sender, EventArgs e)
        {
            listViewUsers.Items.Remove(SelectedListUser);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            radioButtonAdd.Text = e.TabPage.Text.Replace("Select", "Add to");
            radioButtonRemove.Text = e.TabPage.Text.Replace("Select", "Remove from");

            ToggleEnabled();
        }

        private void ToggleEnabled(object sender = null, EventArgs e = null)
        {
            if (textBoxFileName.TextLength == 0 && comboBoxExistingTeam.SelectedIndex <= 0 && comboBoxSavedView.SelectedIndex <= 0)
            {
                listViewUsers.Items.Clear();
            }

            checkBoxRemoveOthers.Enabled = tabControl1.SelectedTab == tabTeams && radioButtonAdd.Checked;
            if (!checkBoxRemoveOthers.Enabled) checkBoxRemoveOthers.Checked = false;

            buttonProcessChanges.Enabled =
                (radioButtonAdd.Checked || radioButtonRemove.Checked) && listViewUsers.Enabled &&
                ((tabControl1.SelectedTab == tabTeams && listBoxTeams.SelectedIndices.Count > 0) ||
                (tabControl1.SelectedTab == tabRoles && listBoxRoles.SelectedIndices.Count > 0));
        }

        private void buttonProcessChanges_Click(object sender, EventArgs e)
        {
            var requests = new List<OrganizationRequest>();

            var selectedUserIds = listViewUsers.Items.Cast<ListViewItem>().Select(i => (User)i.Tag).Where(u => !u.Disabled).Select(u => u.Id).ToArray();
            var selectedEntity = tabControl1.SelectedTab.Tag.ToString();
            Guid[] selectedIds;

            if (selectedEntity == "Team")
            {
                selectedIds = listBoxTeams.SelectedItems.Cast<Team>().Select(t => t.Id).ToArray();
            }
            else
            {
                selectedIds = listBoxRoles.SelectedItems.Cast<Role>().Select(t => t.Id).ToArray();
            }

            var isAdd = radioButtonAdd.Checked;
            var isRemove = radioButtonRemove.Checked;
            var removeOthers = checkBoxRemoveOthers.Checked;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Processing changes",
                Work = (worker, args) =>
                {
                    if (isRemove)
                    {
                        foreach (var selectedId in selectedIds)
                        {
                            requests.AddRange(CreateRemoveRequest(selectedEntity, selectedId, selectedUserIds));
                        }
                    }
                    if (isAdd)
                    {
                        foreach (var selectedId in selectedIds)
                        {
                            requests.AddRange(CreateAddRequest(selectedEntity, selectedId, selectedUserIds));
                        }
                        if (removeOthers)
                        {
                            requests.AddRange(CreateRemoveRequests(selectedUserIds, selectedIds));
                        }
                    }

                    if (requests.Any())
                    {
                        var successes = 0;
                        foreach (var request in requests)
                        {
                            try
                            {
                                Service.Execute(request);
                                successes++;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        args.Result = successes;
                    }
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }
                    else if (args.Result != null)
                    {
                        var successes = (int)args.Result;
                        if (successes > 0)
                        {
                            if (successes == requests.Count)
                            {
                                MessageBox.Show("Changes processed successfully.");
                            }
                            else
                            {
                                MessageBox.Show($"Change processing partially successfully.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Change processing failed!");
                        }
                    }
                    PopulateUserList(UserQuery);
                }
            });
        }

        private IEnumerable<OrganizationRequest> CreateAddRequest(string entity, Guid id, Guid[] users)
        {
            var requests = new List<OrganizationRequest>();
            var userQuery = new QueryExpression("systemuser");
            userQuery.Criteria.AddCondition(new ConditionExpression("systemuserid", ConditionOperator.In, users));

            if (entity == "Team")
            {
                var teamLink = userQuery.AddLink("teammembership", "systemuserid", "systemuserid", JoinOperator.NotAny);
                teamLink.LinkCriteria.AddCondition("teamid", ConditionOperator.Equal, id);
                var filteredUsers = Service.RetrieveMultiple(userQuery);

                if (filteredUsers.Entities.Any())
                {
                    for (int i = 0; i < filteredUsers.Entities.Count; i += 1000)
                    {
                        requests.Add(new AddMembersTeamRequest
                        {
                            TeamId = id,
                            MemberIds = filteredUsers.Entities.Skip(i).Take(1000).Select(u => u.Id).ToArray()
                        });
                    }
                }
            }
            else
            {
                var userRoleLink = userQuery.AddLink("systemuserroles", "systemuserid", "systemuserid", JoinOperator.NotAny);
                userRoleLink.LinkCriteria.AddCondition("roleid", ConditionOperator.Equal, id);
                var filteredUsers = Service.RetrieveMultiple(userQuery);

                if (filteredUsers.Entities.Any())
                {
                    for (int i = 0; i < filteredUsers.Entities.Count; i += 1000)
                    {
                        requests.Add(new AssociateRequest
                        {
                            Target = new EntityReference("role", id),
                            Relationship = new Relationship("systemuserroles_association"),
                            RelatedEntities = new EntityReferenceCollection(filteredUsers.Entities.Skip(i).Take(1000).Select(u => u.ToEntityReference()).ToArray())
                        });
                    }
                }
            }

            return requests;
        }

        private IEnumerable<OrganizationRequest> CreateRemoveRequest(string entity, Guid id, Guid[] users)
        {
            var requests = new List<OrganizationRequest>();
            var userQuery = new QueryExpression("systemuser");
            userQuery.Criteria.AddCondition(new ConditionExpression("systemuserid", ConditionOperator.In, users));

            if (entity == "Team")
            {
                var teamLink = userQuery.AddLink("teammembership", "systemuserid", "systemuserid", JoinOperator.Any);
                teamLink.LinkCriteria.AddCondition("teamid", ConditionOperator.Equal, id);
                var filteredUsers = Service.RetrieveMultiple(userQuery);

                if (filteredUsers.Entities.Any())
                {
                    for (int i = 0; i < filteredUsers.Entities.Count; i += 1000)
                    {
                        requests.Add(new RemoveMembersTeamRequest
                        {
                            TeamId = id,
                            MemberIds = filteredUsers.Entities.Skip(i).Take(1000).Select(u => u.Id).ToArray()
                        });
                    }
                }
            }
            else
            {
                var userRoleLink = userQuery.AddLink("systemuserroles", "systemuserid", "systemuserid", JoinOperator.Any);
                userRoleLink.LinkCriteria.AddCondition("roleid", ConditionOperator.Equal, id);
                var filteredUsers = Service.RetrieveMultiple(userQuery);

                if (filteredUsers.Entities.Any())
                {
                    for (int i = 0; i < filteredUsers.Entities.Count; i += 1000)
                    {
                        requests.Add(new DisassociateRequest
                        {
                            Target = new EntityReference("role", id),
                            Relationship = new Relationship("systemuserroles_association"),
                            RelatedEntities = new EntityReferenceCollection(filteredUsers.Entities.Skip(i).Take(1000).Select(u => u.ToEntityReference()).ToArray())
                        });
                    }
                }
            }

            return requests;
        }

        private IEnumerable<OrganizationRequest> CreateRemoveRequests(Guid[] users, Guid[] excludedTeamIds)
        {
            var membershipQuery = new QueryExpression("teammembership");
            membershipQuery.ColumnSet.AddColumns("teamid", "systemuserid");
            membershipQuery.Criteria.AddCondition(new ConditionExpression("systemuserid", ConditionOperator.In, users));
            membershipQuery.Criteria.AddCondition(new ConditionExpression("teamid", ConditionOperator.NotIn, excludedTeamIds));
            var teamLink = membershipQuery.AddLink("team", "teamid", "teamid");
            teamLink.LinkCriteria.AddCondition("isdefault", ConditionOperator.Equal, false);
            teamLink.LinkCriteria.AddCondition("teamtype", ConditionOperator.Equal, 0);

            var memberships = Service.RetrieveMultiple(membershipQuery);

            return memberships.Entities.GroupBy(m => m.GetAttributeValue<Guid>("teamid"), m => m.GetAttributeValue<Guid>("systemuserid"))
                .SelectMany(g => CreateRemoveRequest("Team", g.Key, g.ToArray()));
        }
    }
}
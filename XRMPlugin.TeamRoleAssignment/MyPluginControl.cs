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
            var openFileDialog = new OpenFileDialog
            {
                Title = "Select User List",
                Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|Excel files (*.xls; *.xlsx)|*.xls;*.xlsx",
                RestoreDirectory = true
            };

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
                        var xlWb = xlApp.Workbooks.Open(file);
                        var xlWs = (Excel._Worksheet)xlWb.Worksheets.Item[1];

                        foreach (object cell in (Array)xlWs.UsedRange.Columns[1].Value)
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
                ToggleEnabled(sender, e);
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
                ToggleEnabled(sender, e);
            }
        }

        private void PopulateUserList(QueryExpression userQuery)
        {
            listViewUsers.Items.Clear();
            listViewUsers.Enabled = false;

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
                            listViewUsers.Enabled = true;
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

            ToggleEnabled(sender, e);
        }

        private void ToggleEnabled(object sender, EventArgs e)
        {
            if (textBoxFileName.TextLength == 0 && comboBoxExistingTeam.SelectedIndex <= 0 && comboBoxSavedView.SelectedIndex <= 0)
            {
                listViewUsers.Items.Clear();
            }
            listViewUsers.Enabled = listViewUsers.Items.Count > 0;

            checkBoxRemoveOthers.Enabled = tabControl1.SelectedTab == tabTeams && radioButtonAdd.Checked;
            if (!checkBoxRemoveOthers.Enabled) checkBoxRemoveOthers.Checked = false;

            buttonProcessChanges.Enabled =
                (radioButtonAdd.Checked || radioButtonRemove.Checked) && listViewUsers.Enabled &&
                ((tabControl1.SelectedTab == tabTeams && listBoxTeams.SelectedIndices.Count > 0) ||
                (tabControl1.SelectedTab == tabRoles && listBoxRoles.SelectedIndices.Count > 0));
        }

        private void buttonProcessChanges_Click(object sender, EventArgs e)
        {
            var request = new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = true,
                    ReturnResponses = false
                },
                Requests = new OrganizationRequestCollection()
            };

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

            if (radioButtonRemove.Checked)
            {
                foreach (var selectedId in selectedIds)
                {
                    request.Requests.Add(CreateRemoveRequest(selectedEntity, selectedId, selectedUserIds));
                }
            }
            if (radioButtonAdd.Checked)
            {
                foreach (var selectedId in selectedIds)
                {
                    request.Requests.Add(CreateAddRequest(selectedEntity, selectedId, selectedUserIds));
                }
                if (checkBoxRemoveOthers.Checked)
                {
                    var requests = new OrganizationRequestCollection();
                    requests.AddRange(CreateRemoveRequests(selectedUserIds, selectedIds));
                    request.Requests.Add(new ExecuteTransactionRequest { Requests = requests });
                }
            }

            if (request.Requests.Any())
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Processing changes",
                    Work = (worker, args) =>
                    {
                        args.Result = Service.Execute(request);
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            ShowErrorDialog(args.Error);
                        }
                        else
                        {
                            MessageBox.Show("Changes processed successfully.");
                        }
                        PopulateUserList(UserQuery);
                    }
                });
            }
        }

        private OrganizationRequest CreateAddRequest(string entity, Guid id, Guid[] users)
        {
            if (entity == "Team")
            {
                return new AddMembersTeamRequest
                {
                    TeamId = id,
                    MemberIds = users
                };
            }
            else
            {
                return new AssociateRequest
                {
                    Target = new EntityReference("role", id),
                    Relationship = new Relationship("systemuserroles_association"),
                    RelatedEntities = new EntityReferenceCollection(users.Select(uid => new EntityReference("systemuser", uid)).ToList())
                };
            }
        }

        private OrganizationRequest CreateRemoveRequest(string entity, Guid id, Guid[] users)
        {
            if (entity == "Team")
            {
                return new RemoveMembersTeamRequest
                {
                    TeamId = id,
                    MemberIds = users
                };
            }
            else
            {
                return new DisassociateRequest
                {
                    Target = new EntityReference("role", id),
                    Relationship = new Relationship("systemuserroles_association"),
                    RelatedEntities = new EntityReferenceCollection(users.Select(uid => new EntityReference("systemuser", uid)).ToList())
                };
            }
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
                .Select(g => CreateRemoveRequest("Team", g.Key, g.ToArray()));
        }
    }
}
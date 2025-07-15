using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using XRMPlugin.TeamRoleAssignment.Properties;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;
using Excel = Microsoft.Office.Interop.Excel;

namespace XRMPlugin.TeamRoleAssignment
{
    public partial class PluginControl : PluginControlBase, IStatusBarMessenger, IGitHubPlugin, IMessageBusHost
    {
        private readonly double scrollMargin = SystemInformation.VerticalScrollBarWidth * 1.5;

        private readonly Settings userSettings;
        private XrmService xrmService;
        private EntityComboBox selectedComboBox;
        private EntityListView assignmentListView;

        private ListEntity SelectedEntity => selectedComboBox?.SelectedEntity;
        private HashSet<string> LoadedUserNames { get; set; }
        private string UserFetchXml { get; set; }

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;
        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        #region IGitHubPlugin implementation

        public string RepositoryName => "XRMPlugin.TeamRoleAssignment";

        public string UserName => "j-isaacs";

        #endregion IGitHubPlugin implementation

        public PluginControl()
        {
            InitializeComponent();

            assignmentListView = listViewTeams;

            if (!SettingsManager.Instance.TryLoad(GetType(), out userSettings))
            {
                userSettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
                toolStripButtonShowDisabled.Checked = userSettings.ShowDisabledUsers;
                checkBoxReview.Checked = userSettings.ReviewChanges;
                openFileDialog.InitialDirectory = userSettings.DefaultFilePath;
            }
        }

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            base.ClosingPlugin(info);
            if (!info.Cancel) SettingsManager.Instance.Save(GetType(), userSettings);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading org data",
                Work = (worker, args) =>
                {
                    xrmService = new XrmService(Service);

                    LoadLists<Team>(comboBoxTeams, listViewTeams);
                    LoadLists<Role>(comboBoxRoles, listViewRoles);
                    LoadLists<View>(comboBoxViews);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        OnError(args.Error);
                    else
                        PopulateUserList();
                }
            });
        }

        private void LoadLists<T>(EntityComboBox comboBox, EntityListView listView = null) where T : ListEntity
        {
            var entities = xrmService.GetList<T>();
            comboBox.Invoke(new Action(() => { comboBox.LoadItems(entities, true); }));
            listView?.Invoke(new Action(() => { listView.LoadItems(entities, true); }));
        }

        private void PopulateUserList(object sender = null, object source = null)
        {
            if (sender != null) ResetForm(sender);

            if (sender is EntityComboBox comboBox)
                selectedComboBox = comboBox;
            else if (source is HashSet<string> userList)
                LoadedUserNames = userList;
            else if (source is string fetchXml)
                UserFetchXml = fetchXml;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading users",
                Work = (worker, args) =>
                {
                    args.Result = xrmService?.GetUsers(SelectedEntity, LoadedUserNames, UserFetchXml, userSettings.ShowDisabledUsers);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        OnError(args.Error);
                    else if (args.Result is List<ListEntity> users)
                        listViewUsers.LoadItems(users, keepSort: sender == null);
                }
            });
        }

        private void ResetForm(object excluded = null)
        {
            //SelectedEntity = null;
            LoadedUserNames = null;
            UserFetchXml = null;
            if (excluded != textBoxFileName) textBoxFileName.Clear();
            if (excluded != comboBoxTeams) comboBoxTeams.SelectedItem = null;
            if (excluded != comboBoxRoles) comboBoxRoles.SelectedItem = null;
            if (excluded != comboBoxViews) comboBoxViews.SelectedItem = null;
            if (excluded != buttonFetchXML) buttonFetchXML.Font = buttonBrowse.Font;
            listViewTeams.SelectedIndices.Clear();
            listViewRoles.SelectedIndices.Clear();
            radioButtonAdd.Checked = false;
            radioButtonRemove.Checked = false;
            checkBoxRemoveOthers.Checked = false;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) LoadUserListFromFiles(openFileDialog.FileNames);
        }

        private void PluginControl_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) LoadUserListFromFiles((string[])e.Data.GetData(DataFormats.FileDrop));
        }

        private void PluginControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void LoadUserListFromFiles(string[] files)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading file(s)",
                Work = (worker, args) =>
                {
                    var userList = new HashSet<string>();

                    foreach (var file in files)
                    {
                        switch (Path.GetExtension(file))
                        {
                            case ".csv":
                            case ".txt":
                                var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);

                                using (var reader = new StreamReader(fileStream))
                                {
                                    while (!reader.EndOfStream)
                                    {
                                        var user = reader.ReadLine().Split(new[] { ',', '\t' }, 2)[0];
                                        if (!string.IsNullOrWhiteSpace(user)) userList.Add(user);
                                    }
                                }

                                break;

                            case ".xls":
                            case ".xlsb":
                            case ".xlsx":
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
                                    if (!string.IsNullOrWhiteSpace(cell.ToString())) userList.Add(cell.ToString());

                                break;
                        }
                    }

                    if (userList.Count > 0)
                        args.Result = userList;
                    else
                        ShowErrorNotification("File does not contain any users or is in an incorrect format.", null);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        OnError(args.Error);
                    else if (args.Result is HashSet<string> userList)
                    {
                        userSettings.DefaultFilePath = Path.GetDirectoryName(files[0]);
                        textBoxFileName.Text = string.Join(";", files);
                        PopulateUserList(textBoxFileName, userList);
                    }
                }
            });
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((EntityComboBox)sender).SelectedEntity != null)
                PopulateUserList(sender);
        }

        private void ButtonFetchXML_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading FetchXML",
                Work = (worker, args) =>
                {
                    args.Result = UserFetchXml ?? xrmService.GetUserFetchXml();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        OnError(args.Error);
                    else if (args.Result is string fetchXml)
                    {
                        using (var dialog = new FetchXMLDialog(fetchXml))
                        {
                            dialog.MaximumSize = Size;
                            var result = dialog.ShowDialog(this);

                            if (result == DialogResult.OK)
                                PopulateUserList(sender, fetchXml);
                            else if (result == DialogResult.Yes)
                                OnOutgoingMessage.Invoke(this, new MessageBusEventArgs("FetchXML Builder") { TargetArgument = dialog.FetchXml });
                        }
                    }
                }
            });
        }

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin == "FetchXML Builder") PopulateUserList(buttonFetchXML, message.TargetArgument);
        }

        private void ToolStripRemove_Click(object sender, EventArgs e)
        {
            if (sender == toolStripRemoveOthers)
                listViewUsers.LoadItems(listViewUsers.SelectedEntities);
            else
                listViewUsers.LoadItems(listViewUsers.Entities.Except(listViewUsers.SelectedEntities).ToList());
        }

        private void ToolStripButtonRefresh_Click(object sender, EventArgs e) => PopulateUserList();

        private void ToolStripButtonShowDisabled_CheckedChanged(object sender, EventArgs e)
        {
            toolStripButtonShowDisabled.Image = toolStripButtonShowDisabled.Checked ? Resources.Circle_Checked : Resources.Circle_Unchecked;
            userSettings.ShowDisabledUsers = toolStripButtonShowDisabled.Checked;
            PopulateUserList();
        }

        private void TabControlTeamsRoles_SelectionChanging(object sender, TabControlCancelEventArgs e)
        {
            if (buttonCancel.Visible)
                e.Cancel = true;
            else
            {
                assignmentListView = e.TabPage.Controls.OfType<EntityListView>().First();
                radioButtonAdd.Checked = radioButtonRemove.Checked = false;
                radioButtonAdd.Text = e.TabPage.Text.Replace("Select", "Add to");
                radioButtonRemove.Text = e.TabPage.Text.Replace("Select", "Remove from");
            }
        }

        private void CheckBoxReview_CheckedChanged(object sender, EventArgs e)
        {
            userSettings.ReviewChanges = checkBoxReview.Checked;
            buttonProcessChanges.Text = userSettings.ReviewChanges ? "Preview Changes" : "Process Changes";
        }

        private void ListView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender == listViewUsers)
            {
                switch (e.PropertyName)
                {
                    case nameof(EntityListView.Entities):
                        if (xrmService.HasUserQuery)
                            SendMessageToStatusBar.Invoke(this, new StatusBarMessageEventArgs($"{listViewUsers.VirtualListSize} Users"));
                        else
                            SendMessageToStatusBar.Invoke(this, new StatusBarMessageEventArgs(""));
                        break;
                    case nameof(EntityListView.SelectedEntities):
                        toolStripSplitButtonRemove.Visible = listViewUsers.SelectedEntities.Count > 0;
                        break;
                }
            }

            ToggleEnabled();
        }

        private void ToggleEnabled(object sender = null, EventArgs e = null)
        {
            listViewTeams.Selectable = listViewRoles.Selectable = listViewUsers.Selectable;

            if (treeViewChanges.Visible) ShowPreview(false);

            toolStripUserList.Enabled = buttonBrowse.Enabled = buttonFetchXML.Enabled = radioButtonRemove.Enabled = radioButtonAdd.Enabled =
                listViewTeams.VirtualListSize > 0 || listViewRoles.VirtualListSize > 0;

            checkBoxRemoveOthers.Checked &= checkBoxRemoveOthers.Enabled = radioButtonAdd.Checked;

            buttonProcessChanges.Enabled = (radioButtonAdd.Checked || radioButtonRemove.Checked) && assignmentListView.SelectedIndices.Count > 0;
        }

        private void ButtonProcessChanges_Click(object sender, EventArgs e)
        {
            if (treeViewChanges.Visible)
            {
                ProcessChanges(treeViewChanges.Nodes.Cast<TreeNode>().Select(n => (User)n.Tag).ToList());
                return;
            }

            listViewUsers.SelectedIndices.Clear();
            var users = listViewUsers.Entities.Cast<User>().Where(u => !u.Disabled).ToList();

            if (users.Count == 0)
            {
                MessageBox.Show("No active users in list.");
                return;
            }

            var selectedAdds = radioButtonAdd.Checked ? assignmentListView.SelectedEntities.Cast<AssignableEntity>().ToArray() : new AssignableEntity[0];
            var selectedRemoves = radioButtonRemove.Checked ? assignmentListView.SelectedEntities.Cast<AssignableEntity>().ToArray() :
                checkBoxRemoveOthers.Checked ? assignmentListView.Entities.Cast<AssignableEntity>().Except(selectedAdds).ToArray() : new AssignableEntity[0];

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Determining changes",
                Work = (worker, args) =>
                {
                    xrmService.CalculateAssignmentChanges(users, selectedAdds, selectedRemoves);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        OnError(args.Error);
                    else
                    {
                        if (!userSettings.ReviewChanges)
                            ProcessChanges(users);
                        else
                            PreviewChanges(users);
                    }
                }
            });
        }

        private void ShowPreview(bool showPreview)
        {
            toolStripUserList.Enabled = listViewUsers.Enabled = listViewUsers.Visible = !showPreview;
            buttonCancel.Enabled = buttonCancel.Visible = treeViewChanges.Enabled = treeViewChanges.Visible = showPreview;
            checkBoxReview.Enabled = checkBoxReview.Visible = groupBoxSelect.Enabled = groupBoxAction.Enabled = !showPreview;
            buttonProcessChanges.Text = userSettings.ReviewChanges && !showPreview ? "Preview Changes" : "Process Changes";
            buttonCancel.Text = "Cancel";
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (buttonCancel.Text == "Cancel")
                ShowPreview(false);
            else
                PopulateUserList();
        }

        private void PreviewChanges(List<User> users)
        {
            ShowPreview(true);

            var userFont = new Font(treeViewChanges.Font, FontStyle.Bold);
            treeViewChanges.BeginUpdate();
            treeViewChanges.Nodes.Clear();

            treeViewChanges.Nodes.AddRange(
                users.Select(u => new TreeNode(u.Name, u.AssignmentChanges.Count > 0 ? u.AssignmentChanges
                .Select(c => new TreeNode(c.ToString()) { Tag = c }).ToArray() : new TreeNode[] { new TreeNode("No changes") })
                {
                    Tag = u,
                    NodeFont = userFont
                }).ToArray());

            treeViewChanges.ExpandAll();
            treeViewChanges.EndUpdate();
        }

        private void ProcessChanges(List<User> users)
        {
            buttonCancel.Enabled = buttonProcessChanges.Enabled = false;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Processing changes",
                Work = (worker, args) =>
                {
                    var failures = 0;
                    var completed = 0;
                    SendMessageToStatusBar.Invoke(this, new StatusBarMessageEventArgs(0));

                    foreach (var user in xrmService.ExecuteAssignmentChanges(users))
                    {
                        completed++;
                        worker.ReportProgress((completed * 100) / users.Count);
                    }

                    listViewUsers.Invoke(new Action(() =>
                    {
                        treeViewChanges.BeginUpdate();

                        foreach (TreeNode userNode in treeViewChanges.Nodes)
                        {
                            var changes = 0;
                            var fails = 0;

                            foreach (TreeNode changeNode in userNode.Nodes)
                            {
                                if (changeNode.Tag is AssignmentChange change)
                                {
                                    changes++;
                                    changeNode.ForeColor = change.Failed ? Color.DarkRed : Color.DarkGreen;
                                    if (change.Failed) fails++;
                                }
                                else
                                    changeNode.ForeColor = Color.Gray;
                            }

                            userNode.ForeColor = changes == 0 ? Color.Gray : fails == changes ? Color.DarkRed : fails > 0 ? Color.Goldenrod : Color.DarkGreen;
                            if (fails > 0) failures++;
                        }

                        treeViewChanges.EndUpdate();
                    }));

                    args.Result = failures;
                },
                ProgressChanged = (args) =>
                {
                    SendMessageToStatusBar.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage));
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        OnError(args.Error);
                    else if (args.Result is int failures)
                    {
                        MessageBox.Show($"Change processing {(failures == users.Count ? "failed" : failures > 0 ? "partially successful" : "successful")}.");
                        buttonCancel.Text = "Done";
                        buttonCancel.Enabled = true;
                    }
                }
            });
        }

        public void OnError(Exception exception)
        {
            ResetForm();
            ShowErrorDialog(exception);
        }
    }
}
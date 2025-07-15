using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
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
    public partial class MyPluginControl : PluginControlBase, IStatusBarMessenger, IGitHubPlugin, IMessageBusHost
    {
        private readonly double scrollMargin = SystemInformation.VerticalScrollBarWidth * 1.5;

        private readonly Settings UserSettings;
        private XrmContext xrmContext;
        private ListEntity Selected;
        private HashSet<string> LoadedUserNames;
        private string UserFetchXml;
        private List<ListViewItem> Items = new List<ListViewItem>();

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;
        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        #region IGitHubPlugin implementation

        public string RepositoryName => "XRMPlugin.TeamRoleAssignment";

        public string UserName => "j-isaacs";

        #endregion IGitHubPlugin implementation

        public MyPluginControl()
        {
            InitializeComponent();

            if (!SettingsManager.Instance.TryLoad(GetType(), out UserSettings))
            {
                UserSettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
                userList1.ShowDisabled = UserSettings.ShowDisabledUsers;
                listSelector1.DefaultFilePath = UserSettings.DefaultFilePath;
                CheckBoxReview.Checked = UserSettings.ReviewChanges;
            }

            listSelector1.FilesSelected += ListSelector_FilesSelected;
            listSelector1.OpenFetchXmlDialog += ListSelector_OpenFetchXmlDialog;
        }

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            base.ClosingPlugin(info);
            if (!info.Cancel) SettingsManager.Instance.Save(GetType(), UserSettings);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading org data",
                Work = (worker, args) =>
                {
                    xrmContext = new XrmContext(Service, xrmContext);

                    SetWorkingMessage("Populating lists");
                    Thread.Sleep(10);

                    listSelector1.Invoke(new Action(() => { listSelector1.Context = xrmContext; }));
                    assignmentSelector1.Invoke(new Action(() => { assignmentSelector1.Context = xrmContext; }));

                    //if (xrmContext.LoadedUserNames != null) newContext.LoadedUserNames = LoadedUserNames;
                    //if (xrmContext.UserFetchXml != null) newContext.UserFetchXml = UserFetchXml;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                        //ToggleEnabled();
                    }
                    else
                    {
                        //ButtonBrowse.Enabled = true;
                        //ButtonFetchXML.Enabled = true;

                        //if (Selected == null) PopulateUserList();
                    }
                }
            });
        }

        private void LoadLists<T>(ComboBox comboBox, ListView listView, bool includeDisabled = false) where T : ListEntity
        {
            var entities = xrmContext.GetList<T>();
            comboBox?.Invoke(new Action(() =>
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange(entities.ToArray());
                if (Selected is T selected)
                {
                    Selected = null;
                    comboBox.SelectedItem = comboBox.Items.Cast<T>().FirstOrDefault(e => e.Name == selected.Name && e.Id != Guid.Empty);
                }
            }));

            listView?.Invoke(new Action(() =>
            {
                var checkedItems = listView.CheckedItems.Cast<ListViewItem>().Select(i => i.Text).ToHashSet();
                listView.Items.Clear();
                listView.Items.AddRange(
                    entities.Where(e => includeDisabled || !e.Disabled).Select(e => new ListViewItem(e.ListItems)
                    {
                        Tag = e,
                        Checked = checkedItems.Contains(e.Name),
                        ForeColor = e.Disabled ? Color.Gray : Color.Empty
                    }).ToArray());
            }));
        }

        private void ResetForm(Control excludedControl)
        {
            Selected = null;
            LoadedUserNames = null;
            UserFetchXml = null;
            if (excludedControl != ComboBoxTeams) ComboBoxTeams.SelectedItem = null;
            if (excludedControl != ComboBoxRoles) ComboBoxRoles.SelectedItem = null;
            if (excludedControl != ComboBoxViews) ComboBoxViews.SelectedItem = null;
            if (excludedControl != TextBoxFileName) TextBoxFileName.Clear();
            if (excludedControl != ButtonFetchXML) ButtonFetchXML.Font = ButtonBrowse.Font;
            while (ListViewTeams.CheckedItems.Count > 0) ListViewTeams.CheckedItems[0].Checked = false;
            while (ListViewRoles.CheckedItems.Count > 0) ListViewRoles.CheckedItems[0].Checked = false;
            RadioButtonAdd.Checked = false;
            RadioButtonRemove.Checked = false;
            CheckBoxRemoveOthers.Checked = false;
        }

        private void ListSelector_FilesSelected(object sender, EventArgs e)
        {
            LoadUserListFromFiles(listSelector1.SelectedFiles);
        }

        private void MyPluginControl_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) listSelector1.SelectedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
        }

        private void MyPluginControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void LoadUserListFromFiles(string[] files)
        {
            UserSettings.DefaultFilePath = Path.GetDirectoryName(files[0]);

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
                                if (!string.IsNullOrWhiteSpace(user)) userList.Add(user);
                            }
                        }
                    }

                    var excelExtensions = new string[] { ".xls", ".xlsb", ".xlsx" };
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
                            if (!string.IsNullOrWhiteSpace(cell.ToString())) userList.Add(cell.ToString());
                        }
                    }

                    if (userList.Count == 0) throw new Exception("File does not contain any users or is in an incorrect format.");
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }
                    else
                    {
                        xrmContext.SetUserQuery(LoadedUserNames);
                    }
                }
            });
        }

        private void ListSelector_OpenFetchXmlDialog(object sender, EventArgs e)
        {
            var fetchXml = xrmContext.UserFetchXml ?? xrmContext.GetUserFetchXml();

            using (var dialog = new FetchXMLDialog(fetchXml))
            {
                dialog.MaximumSize = Size;
                var result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    LoadQueryFromXml(dialog.FetchXml);
                }
                else if (result == DialogResult.Yes)
                {
                    OnOutgoingMessage(this, new MessageBusEventArgs("FetchXML Builder")
                    {
                        TargetArgument = dialog.FetchXml
                    });
                }
            }
        }

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin == "FetchXML Builder" && message.TargetArgument is string fetchXml)
            {
                LoadQueryFromXml(fetchXml);
            }
        }

        public void LoadQueryFromXml(string fetchXml)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading query",
                Work = (worker, args) =>
                {
                    xrmContext.SetUserQuery(fetchXml);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                        //ToggleEnabled();
                    }
                    else
                    {
                        //if (!ButtonFetchXML.Font.Bold) ButtonFetchXML.Font = new Font(ButtonFetchXML.Font, FontStyle.Bold);
                        //UserFetchXml = fetchXml;
                        //PopulateUserList();
                    }
                }
            });
        }

        internal void PopulateUserList()
        {
            ListViewUsers.Items.Clear();

            if (xrmContext?.HasUserQuery == true)
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading users",
                    Work = (worker, args) =>
                    {
                        xrmContext.LoadList<User>();

                        //SetWorkingMessage("Updating user list");
                        //Thread.Sleep(10);

                        //LoadLists<User>(null, ListViewUsers, UserSettings.ShowDisabledUsers);

                        args.Result = xrmContext.GetList<User>().Count;
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            ShowErrorDialog(args.Error);
                        }
                        else
                        {
                            ListViewUsers.VirtualListSize = (int)args.Result;
                            //SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs($"{ListViewUsers.Items.Count} Users"));
                            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs($"{ListViewUsers.VirtualListSize} Users"));
                        }

                        ToggleEnabled();
                    }
                });
            }
            else
            {
                ToggleEnabled();
            }
        }

        private void ListViewUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = ListViewUsers.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    ContextMenuStripUsers.Show(Cursor.Position);
                }
            }
        }

        private void ToolStripRemove_Click(object sender, EventArgs e)
        {
            var option = sender as ToolStripMenuItem;
            var users = xrmContext.GetList<User>();
            var selectedUsers = users.Where((u, i) => ListViewUsers.SelectedIndices.Contains(i)).ToList();
            ListViewUsers.BeginUpdate();
            if (option == ToolStripRemoveOthers)
            {
                //foreach (ListViewItem item in ListViewUsers.Items.Cast<ListViewItem>().Except(ListViewUsers.SelectedItems.Cast<ListViewItem>())) ListViewUsers.Items.Remove(item);
                ListViewUsers.VirtualListSize = ListViewUsers.SelectedIndices.Count;
                foreach (ListEntity user in users.Except(selectedUsers).ToList()) users.Remove(user);
            }
            else
            {
                //foreach (ListViewItem item in ListViewUsers.SelectedItems) ListViewUsers.Items.Remove(item);
                ListViewUsers.VirtualListSize -= ListViewUsers.SelectedIndices.Count;
                foreach (ListEntity user in selectedUsers) users.Remove(user);
            }

            ListViewUsers.EndUpdate();
            //if (ListViewUsers.Items.Count > 0) SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs($"{ListViewUsers.Items.Count} Users"));
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs($"{ListViewUsers.VirtualListSize} Users"));
            ToggleEnabled();
        }

        private void ToolStripRefresh_Click(object sender, EventArgs e)
        {
            PopulateUserList();
        }

        private void ToolStripButtonShowDisabled_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButtonShowDisabled.Image = ToolStripButtonShowDisabled.Checked ? Resources.Checkmark : null;
            UserSettings.ShowDisabledUsers = ToolStripButtonShowDisabled.Checked;
            PopulateUserList();
        }

        private void TabControlTeamsRoles_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (ButtonCancel.Visible)
            {
                e.Cancel = true;
            }
            else
            {
                RadioButtonAdd.Checked = RadioButtonRemove.Checked = false;
                RadioButtonAdd.Text = e.TabPage.Text.Replace("Select", "Add to");
                RadioButtonRemove.Text = e.TabPage.Text.Replace("Select", "Remove from");

                ToggleEnabled();
            }
        }

        private void ListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (ListViewUsers.Items.Count == 0 || ButtonCancel.Visible) e.NewValue = CheckState.Unchecked;
        }

        private void ListView_Resize(object sender, EventArgs e)
        {
            if (sender is ListView listView && listView.Visible && listView.Width != listView.Tag as int?)
            {
                listView.BeginUpdate();
                listView.Tag = listView.Width;
                var columnWidthUnit = (listView.Width - scrollMargin) / 10;

                if (listView == ListViewUsers)
                {
                    ListViewUsers.Columns[0].Width = (int)(columnWidthUnit * 3);
                    ListViewUsers.Columns[1].Width = (int)(columnWidthUnit * 2);
                    ListViewUsers.Columns[2].Width = (int)(columnWidthUnit * 2);
                    ListViewUsers.Columns[3].Width = (int)(columnWidthUnit * 2);
                    ListViewUsers.Columns[4].Width = (int)(columnWidthUnit * 1);
                }
                else
                {
                    ListViewTeams.Columns[0].Width = (int)(columnWidthUnit * 7);
                    ListViewTeams.Columns[1].Width = (int)(columnWidthUnit * 3);
                    ListViewRoles.Columns[0].Width = (int)(columnWidthUnit * 7);
                    ListViewRoles.Columns[1].Width = (int)(columnWidthUnit * 3);
                }
                listView.EndUpdate();
            }
        }

        private void CheckBoxReview_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.ReviewChanges = CheckBoxReview.Checked;
            ButtonProcessChanges.Text = UserSettings.ReviewChanges ? "Preview Changes" : "Process Changes";
        }

        private void ToggleEnabled(object sender = null, EventArgs e = null)
        {
            if (ListViewUsers.Items.Count == 0)
            {
                SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(""));
                while (ListViewTeams.CheckedItems.Count > 0) ListViewTeams.CheckedItems[0].Checked = false;
                while (ListViewRoles.CheckedItems.Count > 0) ListViewRoles.CheckedItems[0].Checked = false;
            }

            if (ButtonCancel.Visible) ButtonCancel.PerformClick();

            RadioButtonRemove.Enabled = RadioButtonAdd.Enabled = ListViewTeams.Items.Count > 0 || ListViewRoles.Items.Count > 0;

            CheckBoxRemoveOthers.Enabled = TabControlTeamsRoles.SelectedTab == TabTeams && RadioButtonAdd.Checked;
            if (!CheckBoxRemoveOthers.Enabled) CheckBoxRemoveOthers.Checked = false;

            ButtonProcessChanges.Enabled =
                (RadioButtonAdd.Checked || RadioButtonRemove.Checked) &&
                ((TabControlTeamsRoles.SelectedTab == TabTeams && ListViewTeams.CheckedItems.Count > 0) ||
                (TabControlTeamsRoles.SelectedTab == TabRoles && ListViewRoles.CheckedItems.Count > 0));
        }

        private void ButtonProcessChanges_Click(object sender, EventArgs e)
        {
            var selectedUsers = ListViewUsers.Items.Cast<ListViewItem>().Select(i => (User)i.Tag).Where(u => !u.Disabled).ToList();

            if (selectedUsers.Count == 0)
            {
                MessageBox.Show("No active users in list.");
                return;
            }

            var selectedAssignments = TabControlTeamsRoles.SelectedTab.Controls.OfType<ListView>().First().CheckedItems.Cast<ListViewItem>()
                .Select(i => (AssignableEntity)i.Tag).ToList();

            WorkAsync(new WorkAsyncInfo
            {
                IsCancelable = true,
                Message = "Determining changes",
                Work = (worker, args) =>
                {
                    args.Result = xrmContext.GetAssignmentChanges(selectedUsers, selectedAssignments, RadioButtonAdd.Checked, CheckBoxRemoveOthers.Checked);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }
                    else if (args.Result is List<(User, List<(AssignableEntity, bool)>)> changes)
                    {
                        if (!TreeViewChanges.Visible) PreviewChanges(changes);

                        if (!UserSettings.ReviewChanges || TreeViewChanges.Visible)
                        {
                            ProcessChanges(changes);
                        }
                    }
                }
            });
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            ToolStripUserList.Enabled = true;
            ListViewUsers.Enabled = ListViewUsers.Visible = true;
            TreeViewChanges.Enabled = TreeViewChanges.Visible = false;

            CheckBoxReview.Enabled = CheckBoxReview.Visible = true;
            ButtonCancel.Enabled = ButtonCancel.Visible = false;

            ButtonProcessChanges.Text = UserSettings.ReviewChanges ? "Preview Changes" : "Process Changes";

            GroupBoxSelect.Enabled = true;
            GroupBoxAction.Enabled = true;
        }

        private void PreviewChanges(List<(User user, List<(AssignableEntity assignment, bool isAdd)> userChanges)> changes)
        {
            TreeViewChanges.BeginUpdate();
            TreeViewChanges.Nodes.Clear();
            foreach (var (user, userChanges) in changes)
            {
                var userNode = TreeViewChanges.Nodes.Add(user.Name);
                foreach (var (assignment, isAdd) in userChanges)
                {
                    userNode.Nodes.Add($"{(isAdd ? "Add to" : "Remove from")} {assignment.GetType().Name} - {assignment.Name}");
                }
                if (userNode.Nodes.Count == 0) userNode.Nodes.Add("No changes");
            }
            TreeViewChanges.ExpandAll();
            TreeViewChanges.EndUpdate();

            ToolStripUserList.Enabled = false;
            ListViewUsers.Enabled = ListViewUsers.Visible = false;
            TreeViewChanges.Enabled = TreeViewChanges.Visible = true;

            CheckBoxReview.Enabled = CheckBoxReview.Visible = false;
            ButtonCancel.Enabled = ButtonCancel.Visible = true;

            ButtonProcessChanges.Text = "Process Changes";

            GroupBoxSelect.Enabled = false;
            GroupBoxAction.Enabled = false;
        }

        private void ProcessChanges(List<(User user, List<(AssignableEntity assignment, bool isAdd)> userChanges)> changes)
        {
            ButtonProcessChanges.Enabled = false;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Processing changes",
                Work = (worker, args) =>
                {
                    var failures = 0;
                    var results = new Dictionary<User, ProcessingResult>();
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(0));

                    foreach (var (user, result) in xrmContext.ExecuteAssignmentChanges(changes))
                    {
                        results.Add(user, result);
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs((results.Count * 100) / changes.Count));
                        if (result == ProcessingResult.Failure || result == ProcessingResult.Partial) failures++;
                    }

                    ListViewUsers.Invoke(new Action(() =>
                    {
                        foreach (var listUser in ListViewUsers.Items.Cast<ListViewItem>())
                        {
                            if (listUser.Tag is User user && !user.Disabled && results.TryGetValue(user, out var result) && result != ProcessingResult.NoChange)
                            {
                                listUser.ForeColor = result == ProcessingResult.Success ? Color.DarkGreen : result == ProcessingResult.Partial ? Color.Yellow : Color.DarkRed;
                            }
                        }
                    }));

                    args.Result = failures;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }
                    else if (args.Result is int failures)
                    {
                        ToggleEnabled();
                        MessageBox.Show($"Change processing {(failures == 0 ? "successful" : failures == changes.Count ? "failed" : "partially successful")}.");
                    }
                }
            });
        }

        private void ListViewUsers_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (Items.Count > e.ItemIndex)
            {
                e.Item = Items[e.ItemIndex];
            }
            else
            {
                var user = xrmContext.GetList<User>()[e.ItemIndex];
                e.Item = new ListViewItem(user.ListItems)
                {
                    ForeColor = user.Disabled ? Color.Gray : Color.Empty
                };
            }
        }

        private void ListViewUsers_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            if (Items != null && e.EndIndex < Items.Count) return;

            var users = xrmContext.GetList<User>();

            for (int i = Items.Count; i <= e.EndIndex; i++)
            {
                Items.Add(new ListViewItem(users[i].ListItems)
                {
                    ForeColor = users[i].Disabled ? Color.Gray : Color.Empty
                });
            }
        }
    }
}
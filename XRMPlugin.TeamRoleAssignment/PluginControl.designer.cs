
namespace XRMPlugin.TeamRoleAssignment
{
    partial class PluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelTeam = new System.Windows.Forms.Label();
            this.comboBoxTeams = new XRMPlugin.TeamRoleAssignment.EntityComboBox();
            this.labelView = new System.Windows.Forms.Label();
            this.comboBoxViews = new XRMPlugin.TeamRoleAssignment.EntityComboBox();
            this.groupBoxAction = new System.Windows.Forms.GroupBox();
            this.checkBoxRemoveOthers = new System.Windows.Forms.CheckBox();
            this.radioButtonRemove = new System.Windows.Forms.RadioButton();
            this.radioButtonAdd = new System.Windows.Forms.RadioButton();
            this.buttonProcessChanges = new System.Windows.Forms.Button();
            this.groupBoxSelect = new System.Windows.Forms.GroupBox();
            this.comboBoxRoles = new XRMPlugin.TeamRoleAssignment.EntityComboBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.buttonFetchXML = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.goupBoxUserList = new System.Windows.Forms.GroupBox();
            this.listViewUsers = new XRMPlugin.TeamRoleAssignment.EntityListView();
            this.columnHeaderUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFirst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripRemoveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripRemoveOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButtonRemove = new System.Windows.Forms.ToolStripSplitButton();
            this.treeViewChanges = new System.Windows.Forms.TreeView();
            this.toolStripUserList = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShowDisabled = new System.Windows.Forms.ToolStripButton();
            this.tabControlTeamsRoles = new System.Windows.Forms.TabControl();
            this.tabTeams = new System.Windows.Forms.TabPage();
            this.listViewTeams = new XRMPlugin.TeamRoleAssignment.EntityListView();
            this.columnHeaderTeamName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTeamBU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabRoles = new System.Windows.Forms.TabPage();
            this.listViewRoles = new XRMPlugin.TeamRoleAssignment.EntityListView();
            this.columnHeaderRoleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRoleBU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTipUsers = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxProcessChanges = new System.Windows.Forms.GroupBox();
            this.checkBoxReview = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxAction.SuspendLayout();
            this.groupBoxSelect.SuspendLayout();
            this.goupBoxUserList.SuspendLayout();
            this.contextMenuStripUsers.SuspendLayout();
            this.toolStripUserList.SuspendLayout();
            this.tabControlTeamsRoles.SuspendLayout();
            this.tabTeams.SuspendLayout();
            this.tabRoles.SuspendLayout();
            this.tableLayoutPanelForm.SuspendLayout();
            this.groupBoxProcessChanges.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Enabled = false;
            this.buttonBrowse.Location = new System.Drawing.Point(300, 23);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(70, 20);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse";
            this.toolTipUsers.SetToolTip(this.buttonBrowse, "Import a list of User Names");
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // labelFile
            // 
            this.labelFile.Location = new System.Drawing.Point(10, 23);
            this.labelFile.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(65, 20);
            this.labelFile.TabIndex = 0;
            this.labelFile.Text = "From File";
            this.labelFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTeam
            // 
            this.labelTeam.Location = new System.Drawing.Point(10, 53);
            this.labelTeam.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(65, 21);
            this.labelTeam.TabIndex = 1;
            this.labelTeam.Text = "From Team";
            this.labelTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxTeams
            // 
            this.comboBoxTeams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTeams.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxTeams.FormattingEnabled = true;
            this.comboBoxTeams.Location = new System.Drawing.Point(85, 53);
            this.comboBoxTeams.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxTeams.Name = "comboBoxTeams";
            this.comboBoxTeams.Size = new System.Drawing.Size(285, 21);
            this.comboBoxTeams.TabIndex = 3;
            this.comboBoxTeams.SelectedValueChanged += new System.EventHandler(this.ComboBox_SelectedValueChanged);
            // 
            // labelView
            // 
            this.labelView.Location = new System.Drawing.Point(10, 115);
            this.labelView.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.labelView.Name = "labelView";
            this.labelView.Size = new System.Drawing.Size(65, 21);
            this.labelView.TabIndex = 6;
            this.labelView.Text = "From View";
            this.labelView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxViews
            // 
            this.comboBoxViews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxViews.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxViews.FormattingEnabled = true;
            this.comboBoxViews.Location = new System.Drawing.Point(85, 115);
            this.comboBoxViews.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxViews.Name = "comboBoxViews";
            this.comboBoxViews.Size = new System.Drawing.Size(285, 21);
            this.comboBoxViews.TabIndex = 5;
            this.comboBoxViews.SelectedValueChanged += new System.EventHandler(this.ComboBox_SelectedValueChanged);
            // 
            // groupBoxAction
            // 
            this.groupBoxAction.Controls.Add(this.checkBoxRemoveOthers);
            this.groupBoxAction.Controls.Add(this.radioButtonRemove);
            this.groupBoxAction.Controls.Add(this.radioButtonAdd);
            this.groupBoxAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAction.Location = new System.Drawing.Point(10, 454);
            this.groupBoxAction.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.groupBoxAction.Name = "groupBoxAction";
            this.groupBoxAction.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxAction.Size = new System.Drawing.Size(380, 84);
            this.groupBoxAction.TabIndex = 8;
            this.groupBoxAction.TabStop = false;
            this.groupBoxAction.Text = "Select Action";
            // 
            // checkBoxRemoveOthers
            // 
            this.checkBoxRemoveOthers.Enabled = false;
            this.checkBoxRemoveOthers.Location = new System.Drawing.Point(155, 23);
            this.checkBoxRemoveOthers.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxRemoveOthers.Name = "checkBoxRemoveOthers";
            this.checkBoxRemoveOthers.Size = new System.Drawing.Size(135, 23);
            this.checkBoxRemoveOthers.TabIndex = 10;
            this.checkBoxRemoveOthers.Text = "Remove from all others";
            this.checkBoxRemoveOthers.UseVisualStyleBackColor = true;
            // 
            // radioButtonRemove
            // 
            this.radioButtonRemove.Enabled = false;
            this.radioButtonRemove.Location = new System.Drawing.Point(10, 51);
            this.radioButtonRemove.Margin = new System.Windows.Forms.Padding(5);
            this.radioButtonRemove.Name = "radioButtonRemove";
            this.radioButtonRemove.Size = new System.Drawing.Size(135, 23);
            this.radioButtonRemove.TabIndex = 11;
            this.radioButtonRemove.Text = "Remove from Team(s)";
            this.radioButtonRemove.UseVisualStyleBackColor = true;
            this.radioButtonRemove.CheckedChanged += new System.EventHandler(this.ToggleEnabled);
            // 
            // radioButtonAdd
            // 
            this.radioButtonAdd.Enabled = false;
            this.radioButtonAdd.Location = new System.Drawing.Point(10, 23);
            this.radioButtonAdd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.radioButtonAdd.Name = "radioButtonAdd";
            this.radioButtonAdd.Size = new System.Drawing.Size(135, 23);
            this.radioButtonAdd.TabIndex = 9;
            this.radioButtonAdd.Text = "Add to Team(s)";
            this.radioButtonAdd.UseVisualStyleBackColor = true;
            this.radioButtonAdd.CheckedChanged += new System.EventHandler(this.ToggleEnabled);
            // 
            // buttonProcessChanges
            // 
            this.buttonProcessChanges.AutoSize = true;
            this.buttonProcessChanges.Enabled = false;
            this.buttonProcessChanges.Location = new System.Drawing.Point(10, 16);
            this.buttonProcessChanges.Margin = new System.Windows.Forms.Padding(10);
            this.buttonProcessChanges.Name = "buttonProcessChanges";
            this.buttonProcessChanges.Size = new System.Drawing.Size(124, 26);
            this.buttonProcessChanges.TabIndex = 12;
            this.buttonProcessChanges.Text = "Process Changes";
            this.buttonProcessChanges.UseVisualStyleBackColor = true;
            this.buttonProcessChanges.Click += new System.EventHandler(this.ButtonProcessChanges_Click);
            // 
            // groupBoxSelect
            // 
            this.groupBoxSelect.Controls.Add(this.comboBoxRoles);
            this.groupBoxSelect.Controls.Add(this.labelRole);
            this.groupBoxSelect.Controls.Add(this.buttonFetchXML);
            this.groupBoxSelect.Controls.Add(this.textBoxFileName);
            this.groupBoxSelect.Controls.Add(this.comboBoxViews);
            this.groupBoxSelect.Controls.Add(this.labelView);
            this.groupBoxSelect.Controls.Add(this.labelFile);
            this.groupBoxSelect.Controls.Add(this.labelTeam);
            this.groupBoxSelect.Controls.Add(this.comboBoxTeams);
            this.groupBoxSelect.Controls.Add(this.buttonBrowse);
            this.groupBoxSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSelect.Location = new System.Drawing.Point(10, 10);
            this.groupBoxSelect.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.groupBoxSelect.Name = "groupBoxSelect";
            this.groupBoxSelect.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxSelect.Size = new System.Drawing.Size(380, 179);
            this.groupBoxSelect.TabIndex = 9;
            this.groupBoxSelect.TabStop = false;
            this.groupBoxSelect.Text = "Select Users";
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRoles.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(85, 84);
            this.comboBoxRoles.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(285, 21);
            this.comboBoxRoles.TabIndex = 4;
            this.comboBoxRoles.SelectedValueChanged += new System.EventHandler(this.ComboBox_SelectedValueChanged);
            // 
            // labelRole
            // 
            this.labelRole.Location = new System.Drawing.Point(10, 84);
            this.labelRole.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(65, 21);
            this.labelRole.TabIndex = 10;
            this.labelRole.Text = "From Role";
            this.labelRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonFetchXML
            // 
            this.buttonFetchXML.Enabled = false;
            this.buttonFetchXML.Location = new System.Drawing.Point(85, 146);
            this.buttonFetchXML.Margin = new System.Windows.Forms.Padding(5);
            this.buttonFetchXML.Name = "buttonFetchXML";
            this.buttonFetchXML.Size = new System.Drawing.Size(140, 23);
            this.buttonFetchXML.TabIndex = 6;
            this.buttonFetchXML.Text = "Edit FetchXML Query";
            this.buttonFetchXML.UseVisualStyleBackColor = true;
            this.buttonFetchXML.Click += new System.EventHandler(this.ButtonFetchXML_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.Location = new System.Drawing.Point(85, 23);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(210, 20);
            this.textBoxFileName.TabIndex = 1;
            // 
            // goupBoxUserList
            // 
            this.goupBoxUserList.Controls.Add(this.listViewUsers);
            this.goupBoxUserList.Controls.Add(this.treeViewChanges);
            this.goupBoxUserList.Controls.Add(this.toolStripUserList);
            this.goupBoxUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goupBoxUserList.Location = new System.Drawing.Point(410, 10);
            this.goupBoxUserList.Margin = new System.Windows.Forms.Padding(10);
            this.goupBoxUserList.Name = "goupBoxUserList";
            this.goupBoxUserList.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.tableLayoutPanelForm.SetRowSpan(this.goupBoxUserList, 4);
            this.goupBoxUserList.Size = new System.Drawing.Size(580, 580);
            this.goupBoxUserList.TabIndex = 10;
            this.goupBoxUserList.TabStop = false;
            this.goupBoxUserList.Text = "User List";
            // 
            // listViewUsers
            // 
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUser,
            this.columnHeaderLast,
            this.columnHeaderFirst,
            this.columnHeaderBU,
            this.columnHeaderStatus});
            this.listViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.ItemContextMenuStrip = this.contextMenuStripUsers;
            this.listViewUsers.Location = new System.Drawing.Point(10, 43);
            this.listViewUsers.Margin = new System.Windows.Forms.Padding(5);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(560, 527);
            this.listViewUsers.TabIndex = 13;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.ListView_PropertyChanged);
            // 
            // columnHeaderUser
            // 
            this.columnHeaderUser.Text = "User Name";
            this.columnHeaderUser.Width = 156;
            // 
            // columnHeaderLast
            // 
            this.columnHeaderLast.Text = "Last Name";
            this.columnHeaderLast.Width = 104;
            // 
            // columnHeaderFirst
            // 
            this.columnHeaderFirst.Text = "First Name";
            this.columnHeaderFirst.Width = 104;
            // 
            // columnHeaderBU
            // 
            this.columnHeaderBU.Text = "BUnit";
            this.columnHeaderBU.Width = 104;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 52;
            // 
            // contextMenuStripUsers
            // 
            this.contextMenuStripUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRemoveUser,
            this.toolStripRemoveOthers});
            this.contextMenuStripUsers.Name = "contextMenuStripUsers";
            //this.contextMenuStripUsers.OwnerItem = this.toolStripSplitButtonRemove;
            this.contextMenuStripUsers.ShowImageMargin = false;
            this.contextMenuStripUsers.Size = new System.Drawing.Size(182, 48);
            // 
            // toolStripRemoveUser
            // 
            this.toolStripRemoveUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripRemoveUser.Name = "toolStripRemoveUser";
            this.toolStripRemoveUser.Size = new System.Drawing.Size(181, 22);
            this.toolStripRemoveUser.Text = "Remove Selected User(s)";
            this.toolStripRemoveUser.Click += new System.EventHandler(this.ToolStripRemove_Click);
            // 
            // toolStripRemoveOthers
            // 
            this.toolStripRemoveOthers.Name = "toolStripRemoveOthers";
            this.toolStripRemoveOthers.Size = new System.Drawing.Size(181, 22);
            this.toolStripRemoveOthers.Text = "Remove All Other User(s)";
            this.toolStripRemoveOthers.Click += new System.EventHandler(this.ToolStripRemove_Click);
            // 
            // toolStripSplitButtonRemove
            // 
            this.toolStripSplitButtonRemove.DropDown = this.contextMenuStripUsers;
            this.toolStripSplitButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonRemove.Name = "toolStripSplitButtonRemove";
            this.toolStripSplitButtonRemove.Size = new System.Drawing.Size(152, 22);
            this.toolStripSplitButtonRemove.Text = "Remove Selected User(s)";
            this.toolStripSplitButtonRemove.Visible = false;
            // 
            // treeViewChanges
            // 
            this.treeViewChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewChanges.FullRowSelect = true;
            this.treeViewChanges.Location = new System.Drawing.Point(10, 43);
            this.treeViewChanges.Name = "treeViewChanges";
            this.treeViewChanges.ShowLines = false;
            this.treeViewChanges.Size = new System.Drawing.Size(560, 527);
            this.treeViewChanges.TabIndex = 15;
            this.treeViewChanges.Visible = false;
            // 
            // toolStripUserList
            // 
            this.toolStripUserList.Enabled = false;
            this.toolStripUserList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripUserList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripSeparator1,
            this.toolStripButtonShowDisabled,
            this.toolStripSplitButtonRemove});
            this.toolStripUserList.Location = new System.Drawing.Point(10, 18);
            this.toolStripUserList.Name = "toolStripUserList";
            this.toolStripUserList.Size = new System.Drawing.Size(560, 25);
            this.toolStripUserList.TabIndex = 14;
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonRefresh.Image = global::XRMPlugin.TeamRoleAssignment.Properties.Resources.Reload;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(63, 22);
            this.toolStripButtonRefresh.Text = "Reload";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.ToolStripButtonRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonShowDisabled
            // 
            this.toolStripButtonShowDisabled.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonShowDisabled.CheckOnClick = true;
            this.toolStripButtonShowDisabled.Image = global::XRMPlugin.TeamRoleAssignment.Properties.Resources.Circle_Unchecked;
            this.toolStripButtonShowDisabled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowDisabled.Name = "toolStripButtonShowDisabled";
            this.toolStripButtonShowDisabled.Size = new System.Drawing.Size(135, 22);
            this.toolStripButtonShowDisabled.Text = "Show Disabled Users";
            this.toolStripButtonShowDisabled.CheckedChanged += new System.EventHandler(this.ToolStripButtonShowDisabled_CheckedChanged);
            // 
            // tabControlTeamsRoles
            // 
            this.tabControlTeamsRoles.Controls.Add(this.tabTeams);
            this.tabControlTeamsRoles.Controls.Add(this.tabRoles);
            this.tabControlTeamsRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTeamsRoles.Location = new System.Drawing.Point(10, 199);
            this.tabControlTeamsRoles.Margin = new System.Windows.Forms.Padding(10, 10, 8, 0);
            this.tabControlTeamsRoles.Name = "tabControlTeamsRoles";
            this.tabControlTeamsRoles.Padding = new System.Drawing.Point(0, 0);
            this.tabControlTeamsRoles.SelectedIndex = 0;
            this.tabControlTeamsRoles.Size = new System.Drawing.Size(382, 245);
            this.tabControlTeamsRoles.TabIndex = 7;
            this.tabControlTeamsRoles.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControlTeamsRoles_SelectionChanging);
            // 
            // tabTeams
            // 
            this.tabTeams.BackColor = System.Drawing.SystemColors.Control;
            this.tabTeams.Controls.Add(this.listViewTeams);
            this.tabTeams.Location = new System.Drawing.Point(4, 22);
            this.tabTeams.Margin = new System.Windows.Forms.Padding(0);
            this.tabTeams.Name = "tabTeams";
            this.tabTeams.Padding = new System.Windows.Forms.Padding(8);
            this.tabTeams.Size = new System.Drawing.Size(374, 219);
            this.tabTeams.TabIndex = 0;
            this.tabTeams.Tag = "Team";
            this.tabTeams.Text = "Select Team(s)";
            // 
            // listViewTeams
            // 
            this.listViewTeams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTeamName,
            this.columnHeaderTeamBU});
            this.listViewTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTeams.FullRowSelect = true;
            this.listViewTeams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTeams.HideSelection = false;
            this.listViewTeams.ItemContextMenuStrip = null;
            this.listViewTeams.Location = new System.Drawing.Point(8, 8);
            this.listViewTeams.Margin = new System.Windows.Forms.Padding(5);
            this.listViewTeams.Name = "listViewTeams";
            this.listViewTeams.Size = new System.Drawing.Size(358, 203);
            this.listViewTeams.TabIndex = 8;
            this.listViewTeams.UseCompatibleStateImageBehavior = false;
            this.listViewTeams.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.ListView_PropertyChanged);
            // 
            // columnHeaderTeamName
            // 
            this.columnHeaderTeamName.Text = "Team Name";
            this.columnHeaderTeamName.Width = 220;
            // 
            // columnHeaderTeamBU
            // 
            this.columnHeaderTeamBU.Text = "BUnit";
            this.columnHeaderTeamBU.Width = 110;
            // 
            // tabRoles
            // 
            this.tabRoles.BackColor = System.Drawing.SystemColors.Control;
            this.tabRoles.Controls.Add(this.listViewRoles);
            this.tabRoles.Location = new System.Drawing.Point(4, 22);
            this.tabRoles.Margin = new System.Windows.Forms.Padding(0);
            this.tabRoles.Name = "tabRoles";
            this.tabRoles.Padding = new System.Windows.Forms.Padding(8);
            this.tabRoles.Size = new System.Drawing.Size(374, 219);
            this.tabRoles.TabIndex = 1;
            this.tabRoles.Tag = "Role";
            this.tabRoles.Text = "Select Role(s)";
            // 
            // listViewRoles
            // 
            this.listViewRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRoleName,
            this.columnHeaderRoleBU});
            this.listViewRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRoles.FullRowSelect = true;
            this.listViewRoles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewRoles.HideSelection = false;
            this.listViewRoles.ItemContextMenuStrip = null;
            this.listViewRoles.Location = new System.Drawing.Point(8, 8);
            this.listViewRoles.Name = "listViewRoles";
            this.listViewRoles.Size = new System.Drawing.Size(358, 203);
            this.listViewRoles.TabIndex = 7;
            this.listViewRoles.UseCompatibleStateImageBehavior = false;
            this.listViewRoles.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.ListView_PropertyChanged);
            // 
            // columnHeaderRoleName
            // 
            this.columnHeaderRoleName.Text = "Role Name";
            this.columnHeaderRoleName.Width = 220;
            // 
            // columnHeaderRoleBU
            // 
            this.columnHeaderRoleBU.Text = "BUnit";
            this.columnHeaderRoleBU.Width = 110;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All supported files|*.csv; *.txt; *.xls; *.xlsb; *.xlsx|Text files (comma or tab " +
    "delimited) (*.csv; *.txt)|*.csv;*.txt|Excel files (*.xls; *.xlsb; *.xlsx)|*.xls;" +
    "*.xlsb;*.xlsx";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Select User Name List";
            // 
            // toolTipUsers
            // 
            this.toolTipUsers.AutoPopDelay = 10000;
            this.toolTipUsers.InitialDelay = 200;
            this.toolTipUsers.ReshowDelay = 100;
            // 
            // tableLayoutPanelForm
            // 
            this.tableLayoutPanelForm.ColumnCount = 2;
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelForm.Controls.Add(this.groupBoxSelect, 0, 0);
            this.tableLayoutPanelForm.Controls.Add(this.tabControlTeamsRoles, 0, 1);
            this.tableLayoutPanelForm.Controls.Add(this.groupBoxAction, 0, 2);
            this.tableLayoutPanelForm.Controls.Add(this.groupBoxProcessChanges);
            this.tableLayoutPanelForm.Controls.Add(this.goupBoxUserList, 1, 0);
            this.tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForm.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelForm.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelForm.MinimumSize = new System.Drawing.Size(780, 450);
            this.tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            this.tableLayoutPanelForm.RowCount = 4;
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanelForm.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanelForm.TabIndex = 10;
            // 
            // groupBoxProcessChanges
            // 
            this.groupBoxProcessChanges.Controls.Add(this.checkBoxReview);
            this.groupBoxProcessChanges.Controls.Add(this.buttonCancel);
            this.groupBoxProcessChanges.Controls.Add(this.buttonProcessChanges);
            this.groupBoxProcessChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProcessChanges.Location = new System.Drawing.Point(10, 541);
            this.groupBoxProcessChanges.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.groupBoxProcessChanges.Name = "groupBoxProcessChanges";
            this.groupBoxProcessChanges.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxProcessChanges.Size = new System.Drawing.Size(380, 49);
            this.groupBoxProcessChanges.TabIndex = 14;
            this.groupBoxProcessChanges.TabStop = false;
            // 
            // checkBoxReview
            // 
            this.checkBoxReview.Location = new System.Drawing.Point(155, 16);
            this.checkBoxReview.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxReview.Name = "checkBoxReview";
            this.checkBoxReview.Size = new System.Drawing.Size(110, 23);
            this.checkBoxReview.TabIndex = 13;
            this.checkBoxReview.Text = "Review changes";
            this.checkBoxReview.UseVisualStyleBackColor = true;
            this.checkBoxReview.CheckedChanged += new System.EventHandler(this.CheckBoxReview_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Location = new System.Drawing.Point(155, 16);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(10);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(70, 26);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // PluginControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelForm);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(1000, 600);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PluginControl_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PluginControl_DragEnter);
            this.groupBoxAction.ResumeLayout(false);
            this.groupBoxSelect.ResumeLayout(false);
            this.groupBoxSelect.PerformLayout();
            this.goupBoxUserList.ResumeLayout(false);
            this.goupBoxUserList.PerformLayout();
            this.contextMenuStripUsers.ResumeLayout(false);
            this.toolStripUserList.ResumeLayout(false);
            this.toolStripUserList.PerformLayout();
            this.tabControlTeamsRoles.ResumeLayout(false);
            this.tabTeams.ResumeLayout(false);
            this.tabRoles.ResumeLayout(false);
            this.tableLayoutPanelForm.ResumeLayout(false);
            this.groupBoxProcessChanges.ResumeLayout(false);
            this.groupBoxProcessChanges.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelTeam;
        private EntityComboBox comboBoxTeams;
        private System.Windows.Forms.Label labelView;
        private EntityComboBox comboBoxViews;
        private System.Windows.Forms.GroupBox groupBoxAction;
        private System.Windows.Forms.RadioButton radioButtonRemove;
        private System.Windows.Forms.RadioButton radioButtonAdd;
        private System.Windows.Forms.GroupBox groupBoxSelect;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.GroupBox goupBoxUserList;
        private EntityListView listViewUsers;
        private System.Windows.Forms.ColumnHeader columnHeaderUser;
        private System.Windows.Forms.ColumnHeader columnHeaderLast;
        private System.Windows.Forms.ColumnHeader columnHeaderFirst;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.Button buttonProcessChanges;
        private System.Windows.Forms.TabControl tabControlTeamsRoles;
        private System.Windows.Forms.TabPage tabTeams;
        private System.Windows.Forms.TabPage tabRoles;
        private System.Windows.Forms.CheckBox checkBoxRemoveOthers;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripRemoveUser;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ColumnHeader columnHeaderBU;
        private EntityListView listViewTeams;
        private System.Windows.Forms.ColumnHeader columnHeaderTeamName;
        private System.Windows.Forms.ColumnHeader columnHeaderTeamBU;
        private EntityListView listViewRoles;
        private System.Windows.Forms.ColumnHeader columnHeaderRoleName;
        private System.Windows.Forms.ColumnHeader columnHeaderRoleBU;
        private System.Windows.Forms.Button buttonFetchXML;
        private EntityComboBox comboBoxRoles;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.ToolStripMenuItem toolStripRemoveOthers;
        private System.Windows.Forms.ToolTip toolTipUsers;
        private System.Windows.Forms.ToolStrip toolStripUserList;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowDisabled;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.CheckBox checkBoxReview;
        private System.Windows.Forms.GroupBox groupBoxProcessChanges;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TreeView treeViewChanges;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonRemove;
    }
}

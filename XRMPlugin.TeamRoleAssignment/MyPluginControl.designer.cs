
namespace XRMPlugin.TeamManager
{
    partial class MyPluginControl
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
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelExistingTeam = new System.Windows.Forms.Label();
            this.comboBoxExistingTeam = new System.Windows.Forms.ComboBox();
            this.labelSavedView = new System.Windows.Forms.Label();
            this.comboBoxSavedView = new System.Windows.Forms.ComboBox();
            this.groupBoxAction = new System.Windows.Forms.GroupBox();
            this.checkBoxRemoveOthers = new System.Windows.Forms.CheckBox();
            this.radioButtonRemove = new System.Windows.Forms.RadioButton();
            this.buttonProcessChanges = new System.Windows.Forms.Button();
            this.radioButtonAdd = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.groupBoxUserList = new System.Windows.Forms.GroupBox();
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.columnHeaderUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFirst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxTeams = new System.Windows.Forms.GroupBox();
            this.listBoxTeams = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTeams = new System.Windows.Forms.TabPage();
            this.tabRoles = new System.Windows.Forms.TabPage();
            this.listBoxRoles = new System.Windows.Forms.ListBox();
            this.contextMenuStripUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripRemoveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu.SuspendLayout();
            this.groupBoxAction.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxUserList.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTeams.SuspendLayout();
            this.tabRoles.SuspendLayout();
            this.contextMenuStripUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(800, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(40, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(270, 23);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(70, 20);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
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
            // labelExistingTeam
            // 
            this.labelExistingTeam.Location = new System.Drawing.Point(10, 53);
            this.labelExistingTeam.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.labelExistingTeam.Name = "labelExistingTeam";
            this.labelExistingTeam.Size = new System.Drawing.Size(65, 21);
            this.labelExistingTeam.TabIndex = 1;
            this.labelExistingTeam.Text = "From Team";
            this.labelExistingTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxExistingTeam
            // 
            this.comboBoxExistingTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExistingTeam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxExistingTeam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExistingTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExistingTeam.FormattingEnabled = true;
            this.comboBoxExistingTeam.Location = new System.Drawing.Point(85, 53);
            this.comboBoxExistingTeam.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxExistingTeam.Name = "comboBoxExistingTeam";
            this.comboBoxExistingTeam.Size = new System.Drawing.Size(255, 21);
            this.comboBoxExistingTeam.TabIndex = 3;
            this.comboBoxExistingTeam.SelectedIndexChanged += new System.EventHandler(this.comboBoxExistingTeam_SelectedIndexChanged);
            // 
            // labelSavedView
            // 
            this.labelSavedView.Location = new System.Drawing.Point(10, 84);
            this.labelSavedView.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.labelSavedView.Name = "labelSavedView";
            this.labelSavedView.Size = new System.Drawing.Size(65, 21);
            this.labelSavedView.TabIndex = 6;
            this.labelSavedView.Text = "From View";
            this.labelSavedView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxSavedView
            // 
            this.comboBoxSavedView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSavedView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxSavedView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSavedView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSavedView.FormattingEnabled = true;
            this.comboBoxSavedView.Location = new System.Drawing.Point(85, 84);
            this.comboBoxSavedView.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxSavedView.Name = "comboBoxSavedView";
            this.comboBoxSavedView.Size = new System.Drawing.Size(255, 21);
            this.comboBoxSavedView.TabIndex = 4;
            this.comboBoxSavedView.SelectedIndexChanged += new System.EventHandler(this.comboBoxSavedView_SelectedIndexChanged);
            // 
            // groupBoxAction
            // 
            this.groupBoxAction.Controls.Add(this.checkBoxRemoveOthers);
            this.groupBoxAction.Controls.Add(this.radioButtonRemove);
            this.groupBoxAction.Controls.Add(this.buttonProcessChanges);
            this.groupBoxAction.Controls.Add(this.radioButtonAdd);
            this.groupBoxAction.Location = new System.Drawing.Point(5, 419);
            this.groupBoxAction.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxAction.Name = "groupBoxAction";
            this.groupBoxAction.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxAction.Size = new System.Drawing.Size(350, 111);
            this.groupBoxAction.TabIndex = 8;
            this.groupBoxAction.TabStop = false;
            this.groupBoxAction.Text = "Select Action";
            // 
            // checkBoxRemoveOthers
            // 
            this.checkBoxRemoveOthers.Location = new System.Drawing.Point(163, 23);
            this.checkBoxRemoveOthers.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxRemoveOthers.Name = "checkBoxRemoveOthers";
            this.checkBoxRemoveOthers.Size = new System.Drawing.Size(150, 20);
            this.checkBoxRemoveOthers.TabIndex = 9;
            this.checkBoxRemoveOthers.Text = "Remove from all others";
            this.checkBoxRemoveOthers.UseVisualStyleBackColor = true;
            // 
            // radioButtonRemove
            // 
            this.radioButtonRemove.Location = new System.Drawing.Point(13, 48);
            this.radioButtonRemove.Margin = new System.Windows.Forms.Padding(5);
            this.radioButtonRemove.Name = "radioButtonRemove";
            this.radioButtonRemove.Size = new System.Drawing.Size(140, 20);
            this.radioButtonRemove.TabIndex = 7;
            this.radioButtonRemove.TabStop = true;
            this.radioButtonRemove.Text = "Remove from Team(s)";
            this.radioButtonRemove.UseVisualStyleBackColor = true;
            this.radioButtonRemove.CheckedChanged += new System.EventHandler(this.ToggleEnabled);
            // 
            // buttonProcessChanges
            // 
            this.buttonProcessChanges.AutoSize = true;
            this.buttonProcessChanges.Enabled = false;
            this.buttonProcessChanges.Location = new System.Drawing.Point(125, 78);
            this.buttonProcessChanges.Margin = new System.Windows.Forms.Padding(5);
            this.buttonProcessChanges.Name = "buttonProcessChanges";
            this.buttonProcessChanges.Size = new System.Drawing.Size(100, 23);
            this.buttonProcessChanges.TabIndex = 8;
            this.buttonProcessChanges.Text = "Process Changes";
            this.buttonProcessChanges.UseVisualStyleBackColor = true;
            this.buttonProcessChanges.Click += new System.EventHandler(this.buttonProcessChanges_Click);
            // 
            // radioButtonAdd
            // 
            this.radioButtonAdd.Location = new System.Drawing.Point(13, 23);
            this.radioButtonAdd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.radioButtonAdd.Name = "radioButtonAdd";
            this.radioButtonAdd.Size = new System.Drawing.Size(140, 20);
            this.radioButtonAdd.TabIndex = 6;
            this.radioButtonAdd.TabStop = true;
            this.radioButtonAdd.Text = "Add to Team(s)";
            this.radioButtonAdd.UseVisualStyleBackColor = true;
            this.radioButtonAdd.CheckedChanged += new System.EventHandler(this.ToggleEnabled);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFileName);
            this.groupBox1.Controls.Add(this.comboBoxSavedView);
            this.groupBox1.Controls.Add(this.labelSavedView);
            this.groupBox1.Controls.Add(this.labelFile);
            this.groupBox1.Controls.Add(this.labelExistingTeam);
            this.groupBox1.Controls.Add(this.comboBoxExistingTeam);
            this.groupBox1.Controls.Add(this.buttonBrowse);
            this.groupBox1.Location = new System.Drawing.Point(5, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(350, 120);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Users";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.Location = new System.Drawing.Point(85, 23);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(180, 20);
            this.textBoxFileName.TabIndex = 1;
            // 
            // groupBoxUserList
            // 
            this.groupBoxUserList.Controls.Add(this.listViewUsers);
            this.groupBoxUserList.Location = new System.Drawing.Point(380, 30);
            this.groupBoxUserList.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxUserList.Name = "groupBoxUserList";
            this.groupBoxUserList.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxUserList.Size = new System.Drawing.Size(380, 500);
            this.groupBoxUserList.TabIndex = 10;
            this.groupBoxUserList.TabStop = false;
            this.groupBoxUserList.Text = "User List";
            // 
            // listViewUsers
            // 
            this.listViewUsers.AllowDrop = true;
            this.listViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUser,
            this.columnHeaderLast,
            this.columnHeaderFirst,
            this.columnHeaderStatus});
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.Location = new System.Drawing.Point(10, 23);
            this.listViewUsers.Margin = new System.Windows.Forms.Padding(5);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(360, 467);
            this.listViewUsers.TabIndex = 0;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            this.listViewUsers.EnabledChanged += new System.EventHandler(this.ToggleEnabled);
            this.listViewUsers.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewUsers_DragDrop);
            this.listViewUsers.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewUsers_DragEnter);
            this.listViewUsers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewUsers_MouseClick);
            // 
            // columnHeaderUser
            // 
            this.columnHeaderUser.Text = "User Name";
            this.columnHeaderUser.Width = 125;
            // 
            // columnHeaderLast
            // 
            this.columnHeaderLast.Text = "Last Name";
            this.columnHeaderLast.Width = 75;
            // 
            // columnHeaderFirst
            // 
            this.columnHeaderFirst.Text = "First Name";
            this.columnHeaderFirst.Width = 75;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            // 
            // groupBoxTeams
            // 
            this.groupBoxTeams.Location = new System.Drawing.Point(5, 160);
            this.groupBoxTeams.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxTeams.Name = "groupBoxTeams";
            this.groupBoxTeams.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxTeams.Size = new System.Drawing.Size(350, 249);
            this.groupBoxTeams.TabIndex = 12;
            this.groupBoxTeams.TabStop = false;
            this.groupBoxTeams.Text = "Select Team(s)";
            this.groupBoxTeams.Visible = false;
            // 
            // listBoxTeams
            // 
            this.listBoxTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTeams.FormattingEnabled = true;
            this.listBoxTeams.Location = new System.Drawing.Point(8, 8);
            this.listBoxTeams.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxTeams.Name = "listBoxTeams";
            this.listBoxTeams.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxTeams.Size = new System.Drawing.Size(328, 207);
            this.listBoxTeams.TabIndex = 5;
            this.listBoxTeams.SelectedIndexChanged += new System.EventHandler(this.ToggleEnabled);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTeams);
            this.tabControl1.Controls.Add(this.tabRoles);
            this.tabControl1.Location = new System.Drawing.Point(5, 160);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(352, 249);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.ToggleEnabled);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabTeams
            // 
            this.tabTeams.BackColor = System.Drawing.SystemColors.Control;
            this.tabTeams.Controls.Add(this.listBoxTeams);
            this.tabTeams.Location = new System.Drawing.Point(4, 22);
            this.tabTeams.Margin = new System.Windows.Forms.Padding(0);
            this.tabTeams.Name = "tabTeams";
            this.tabTeams.Padding = new System.Windows.Forms.Padding(8);
            this.tabTeams.Size = new System.Drawing.Size(344, 223);
            this.tabTeams.TabIndex = 0;
            this.tabTeams.Tag = "Team";
            this.tabTeams.Text = "Select Team(s)";
            // 
            // tabRoles
            // 
            this.tabRoles.BackColor = System.Drawing.SystemColors.Control;
            this.tabRoles.Controls.Add(this.listBoxRoles);
            this.tabRoles.Location = new System.Drawing.Point(4, 22);
            this.tabRoles.Margin = new System.Windows.Forms.Padding(0);
            this.tabRoles.Name = "tabRoles";
            this.tabRoles.Padding = new System.Windows.Forms.Padding(8);
            this.tabRoles.Size = new System.Drawing.Size(344, 223);
            this.tabRoles.TabIndex = 1;
            this.tabRoles.Tag = "Role";
            this.tabRoles.Text = "Select Role(s)";
            // 
            // listBoxRoles
            // 
            this.listBoxRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxRoles.FormattingEnabled = true;
            this.listBoxRoles.Location = new System.Drawing.Point(8, 8);
            this.listBoxRoles.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxRoles.Name = "listBoxRoles";
            this.listBoxRoles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxRoles.Size = new System.Drawing.Size(328, 207);
            this.listBoxRoles.TabIndex = 5;
            this.listBoxRoles.SelectedIndexChanged += new System.EventHandler(this.ToggleEnabled);
            // 
            // contextMenuStripUsers
            // 
            this.contextMenuStripUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRemoveUser});
            this.contextMenuStripUsers.Name = "contextMenuStripUsers";
            this.contextMenuStripUsers.ShowImageMargin = false;
            this.contextMenuStripUsers.Size = new System.Drawing.Size(119, 26);
            // 
            // toolStripRemoveUser
            // 
            this.toolStripRemoveUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripRemoveUser.Name = "toolStripRemoveUser";
            this.toolStripRemoveUser.Size = new System.Drawing.Size(118, 22);
            this.toolStripRemoveUser.Text = "Remove User";
            this.toolStripRemoveUser.Click += new System.EventHandler(this.toolStripRemoveUser_Click);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxUserList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAction);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBoxTeams);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBoxAction.ResumeLayout(false);
            this.groupBoxAction.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxUserList.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabTeams.ResumeLayout(false);
            this.tabRoles.ResumeLayout(false);
            this.contextMenuStripUsers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelExistingTeam;
        private System.Windows.Forms.ComboBox comboBoxExistingTeam;
        private System.Windows.Forms.Label labelSavedView;
        private System.Windows.Forms.ComboBox comboBoxSavedView;
        private System.Windows.Forms.GroupBox groupBoxAction;
        private System.Windows.Forms.RadioButton radioButtonRemove;
        private System.Windows.Forms.RadioButton radioButtonAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.GroupBox groupBoxUserList;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ColumnHeader columnHeaderUser;
        private System.Windows.Forms.ColumnHeader columnHeaderLast;
        private System.Windows.Forms.ColumnHeader columnHeaderFirst;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.Button buttonProcessChanges;
        private System.Windows.Forms.GroupBox groupBoxTeams;
        private System.Windows.Forms.ListBox listBoxTeams;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTeams;
        private System.Windows.Forms.TabPage tabRoles;
        private System.Windows.Forms.ListBox listBoxRoles;
        private System.Windows.Forms.CheckBox checkBoxRemoveOthers;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripRemoveUser;
    }
}

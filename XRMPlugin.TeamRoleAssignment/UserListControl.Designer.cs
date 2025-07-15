namespace XRMPlugin.TeamRoleAssignment
{
    partial class UserListControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserListControl));
            this.GroupBoxUserList = new System.Windows.Forms.GroupBox();
            this.ListViewUsers = new System.Windows.Forms.ListView();
            this.ColumnHeaderUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderLast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderFirst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderBU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TreeViewChanges = new System.Windows.Forms.TreeView();
            this.ToolStripUserList = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButtonShowDisabled = new System.Windows.Forms.ToolStripButton();
            this.ContextMenuStripUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripRemoveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripRemoveOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBoxUserList.SuspendLayout();
            this.ToolStripUserList.SuspendLayout();
            this.ContextMenuStripUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxUserList
            // 
            this.GroupBoxUserList.Controls.Add(this.ListViewUsers);
            this.GroupBoxUserList.Controls.Add(this.TreeViewChanges);
            this.GroupBoxUserList.Controls.Add(this.ToolStripUserList);
            this.GroupBoxUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBoxUserList.Location = new System.Drawing.Point(0, 0);
            this.GroupBoxUserList.Margin = new System.Windows.Forms.Padding(10);
            this.GroupBoxUserList.Name = "GroupBoxUserList";
            this.GroupBoxUserList.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.GroupBoxUserList.Size = new System.Drawing.Size(551, 475);
            this.GroupBoxUserList.TabIndex = 11;
            this.GroupBoxUserList.TabStop = false;
            this.GroupBoxUserList.Text = "User List";
            // 
            // ListViewUsers
            // 
            this.ListViewUsers.AllowDrop = true;
            this.ListViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderUser,
            this.ColumnHeaderLast,
            this.ColumnHeaderFirst,
            this.ColumnHeaderBU,
            this.ColumnHeaderStatus});
            this.ListViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewUsers.FullRowSelect = true;
            this.ListViewUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewUsers.HideSelection = false;
            this.ListViewUsers.Location = new System.Drawing.Point(10, 43);
            this.ListViewUsers.Margin = new System.Windows.Forms.Padding(5);
            this.ListViewUsers.Name = "ListViewUsers";
            this.ListViewUsers.Size = new System.Drawing.Size(531, 422);
            this.ListViewUsers.TabIndex = 13;
            this.ListViewUsers.UseCompatibleStateImageBehavior = false;
            this.ListViewUsers.View = System.Windows.Forms.View.Details;
            this.ListViewUsers.VirtualMode = true;
            // 
            // ColumnHeaderUser
            // 
            this.ColumnHeaderUser.Text = "User Name";
            this.ColumnHeaderUser.Width = 150;
            // 
            // ColumnHeaderLast
            // 
            this.ColumnHeaderLast.Text = "Last Name";
            this.ColumnHeaderLast.Width = 100;
            // 
            // ColumnHeaderFirst
            // 
            this.ColumnHeaderFirst.Text = "First Name";
            this.ColumnHeaderFirst.Width = 100;
            // 
            // ColumnHeaderBU
            // 
            this.ColumnHeaderBU.Text = "BUnit";
            this.ColumnHeaderBU.Width = 100;
            // 
            // ColumnHeaderStatus
            // 
            this.ColumnHeaderStatus.Text = "Status";
            this.ColumnHeaderStatus.Width = 50;
            // 
            // TreeViewChanges
            // 
            this.TreeViewChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewChanges.Location = new System.Drawing.Point(10, 43);
            this.TreeViewChanges.Name = "TreeViewChanges";
            this.TreeViewChanges.Size = new System.Drawing.Size(531, 422);
            this.TreeViewChanges.TabIndex = 15;
            this.TreeViewChanges.Visible = false;
            // 
            // ToolStripUserList
            // 
            this.ToolStripUserList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStripUserList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonRefresh,
            this.ToolStripSeparator1,
            this.ToolStripButtonShowDisabled});
            this.ToolStripUserList.Location = new System.Drawing.Point(10, 18);
            this.ToolStripUserList.Name = "ToolStripUserList";
            this.ToolStripUserList.Size = new System.Drawing.Size(531, 25);
            this.ToolStripUserList.TabIndex = 14;
            this.ToolStripUserList.Text = "toolStrip1";
            // 
            // ToolStripButtonRefresh
            // 
            this.ToolStripButtonRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonRefresh.Image")));
            this.ToolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonRefresh.Name = "ToolStripButtonRefresh";
            this.ToolStripButtonRefresh.Size = new System.Drawing.Size(66, 22);
            this.ToolStripButtonRefresh.Text = "Refresh";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripButtonShowDisabled
            // 
            this.ToolStripButtonShowDisabled.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButtonShowDisabled.CheckOnClick = true;
            this.ToolStripButtonShowDisabled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonShowDisabled.Name = "ToolStripButtonShowDisabled";
            this.ToolStripButtonShowDisabled.Size = new System.Drawing.Size(119, 22);
            this.ToolStripButtonShowDisabled.Text = "Show Disabled Users";
            // 
            // ContextMenuStripUsers
            // 
            this.ContextMenuStripUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripRemoveUser,
            this.ToolStripRemoveOthers,
            this.ToolStripRefresh});
            this.ContextMenuStripUsers.Name = "contextMenuStripUsers";
            this.ContextMenuStripUsers.ShowImageMargin = false;
            this.ContextMenuStripUsers.Size = new System.Drawing.Size(182, 70);
            // 
            // ToolStripRemoveUser
            // 
            this.ToolStripRemoveUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripRemoveUser.Name = "ToolStripRemoveUser";
            this.ToolStripRemoveUser.Size = new System.Drawing.Size(181, 22);
            this.ToolStripRemoveUser.Text = "Remove Selected User(s)";
            // 
            // ToolStripRemoveOthers
            // 
            this.ToolStripRemoveOthers.Name = "ToolStripRemoveOthers";
            this.ToolStripRemoveOthers.Size = new System.Drawing.Size(181, 22);
            this.ToolStripRemoveOthers.Text = "Remove All Other User(s)";
            // 
            // ToolStripRefresh
            // 
            this.ToolStripRefresh.Name = "ToolStripRefresh";
            this.ToolStripRefresh.Size = new System.Drawing.Size(181, 22);
            this.ToolStripRefresh.Text = "Refresh";
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBoxUserList);
            this.Name = "UserList";
            this.Size = new System.Drawing.Size(551, 475);
            this.GroupBoxUserList.ResumeLayout(false);
            this.GroupBoxUserList.PerformLayout();
            this.ToolStripUserList.ResumeLayout(false);
            this.ToolStripUserList.PerformLayout();
            this.ContextMenuStripUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxUserList;
        private System.Windows.Forms.ListView ListViewUsers;
        private System.Windows.Forms.ColumnHeader ColumnHeaderUser;
        private System.Windows.Forms.ColumnHeader ColumnHeaderLast;
        private System.Windows.Forms.ColumnHeader ColumnHeaderFirst;
        private System.Windows.Forms.ColumnHeader ColumnHeaderBU;
        private System.Windows.Forms.ColumnHeader ColumnHeaderStatus;
        private System.Windows.Forms.TreeView TreeViewChanges;
        private System.Windows.Forms.ToolStrip ToolStripUserList;
        private System.Windows.Forms.ToolStripButton ToolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonShowDisabled;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripUsers;
        private System.Windows.Forms.ToolStripMenuItem ToolStripRemoveUser;
        private System.Windows.Forms.ToolStripMenuItem ToolStripRemoveOthers;
        private System.Windows.Forms.ToolStripMenuItem ToolStripRefresh;
    }
}

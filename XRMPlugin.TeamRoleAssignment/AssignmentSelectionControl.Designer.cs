namespace XRMPlugin.TeamRoleAssignment
{
    partial class AssignmentSelectionControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GroupBoxAction = new System.Windows.Forms.GroupBox();
            this.CheckBoxRemoveOthers = new System.Windows.Forms.CheckBox();
            this.RadioButtonRemove = new System.Windows.Forms.RadioButton();
            this.RadioButtonAdd = new System.Windows.Forms.RadioButton();
            this.TabControlTeamsRoles = new System.Windows.Forms.TabControl();
            this.TabTeams = new System.Windows.Forms.TabPage();
            this.ListViewTeams = new System.Windows.Forms.ListView();
            this.ColumnHeaderTeamName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderTeamBU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabRoles = new System.Windows.Forms.TabPage();
            this.ListViewRoles = new System.Windows.Forms.ListView();
            this.ColumnHeaderRoleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderRoleBU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.GroupBoxAction.SuspendLayout();
            this.TabControlTeamsRoles.SuspendLayout();
            this.TabTeams.SuspendLayout();
            this.TabRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.GroupBoxAction, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TabControlTeamsRoles, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 349);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // GroupBoxAction
            // 
            this.GroupBoxAction.Controls.Add(this.CheckBoxRemoveOthers);
            this.GroupBoxAction.Controls.Add(this.RadioButtonRemove);
            this.GroupBoxAction.Controls.Add(this.RadioButtonAdd);
            this.GroupBoxAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBoxAction.Location = new System.Drawing.Point(10, 265);
            this.GroupBoxAction.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.GroupBoxAction.Name = "GroupBoxAction";
            this.GroupBoxAction.Padding = new System.Windows.Forms.Padding(5);
            this.GroupBoxAction.Size = new System.Drawing.Size(380, 84);
            this.GroupBoxAction.TabIndex = 9;
            this.GroupBoxAction.TabStop = false;
            this.GroupBoxAction.Text = "Select Action";
            // 
            // CheckBoxRemoveOthers
            // 
            this.CheckBoxRemoveOthers.Enabled = false;
            this.CheckBoxRemoveOthers.Location = new System.Drawing.Point(155, 23);
            this.CheckBoxRemoveOthers.Margin = new System.Windows.Forms.Padding(5);
            this.CheckBoxRemoveOthers.Name = "CheckBoxRemoveOthers";
            this.CheckBoxRemoveOthers.Size = new System.Drawing.Size(135, 23);
            this.CheckBoxRemoveOthers.TabIndex = 10;
            this.CheckBoxRemoveOthers.Text = "Remove from all others";
            this.CheckBoxRemoveOthers.UseVisualStyleBackColor = true;
            // 
            // RadioButtonRemove
            // 
            this.RadioButtonRemove.Enabled = false;
            this.RadioButtonRemove.Location = new System.Drawing.Point(10, 51);
            this.RadioButtonRemove.Margin = new System.Windows.Forms.Padding(5);
            this.RadioButtonRemove.Name = "RadioButtonRemove";
            this.RadioButtonRemove.Size = new System.Drawing.Size(135, 23);
            this.RadioButtonRemove.TabIndex = 11;
            this.RadioButtonRemove.Text = "Remove from Team(s)";
            this.RadioButtonRemove.UseVisualStyleBackColor = true;
            // 
            // RadioButtonAdd
            // 
            this.RadioButtonAdd.Enabled = false;
            this.RadioButtonAdd.Location = new System.Drawing.Point(10, 23);
            this.RadioButtonAdd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.RadioButtonAdd.Name = "RadioButtonAdd";
            this.RadioButtonAdd.Size = new System.Drawing.Size(135, 23);
            this.RadioButtonAdd.TabIndex = 9;
            this.RadioButtonAdd.Text = "Add to Team(s)";
            this.RadioButtonAdd.UseVisualStyleBackColor = true;
            // 
            // TabControlTeamsRoles
            // 
            this.TabControlTeamsRoles.Controls.Add(this.TabTeams);
            this.TabControlTeamsRoles.Controls.Add(this.TabRoles);
            this.TabControlTeamsRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlTeamsRoles.Location = new System.Drawing.Point(10, 10);
            this.TabControlTeamsRoles.Margin = new System.Windows.Forms.Padding(10, 10, 8, 0);
            this.TabControlTeamsRoles.Name = "TabControlTeamsRoles";
            this.TabControlTeamsRoles.Padding = new System.Drawing.Point(0, 0);
            this.TabControlTeamsRoles.SelectedIndex = 0;
            this.TabControlTeamsRoles.Size = new System.Drawing.Size(382, 245);
            this.TabControlTeamsRoles.TabIndex = 8;
            // 
            // TabTeams
            // 
            this.TabTeams.BackColor = System.Drawing.SystemColors.Control;
            this.TabTeams.Controls.Add(this.ListViewTeams);
            this.TabTeams.Location = new System.Drawing.Point(4, 22);
            this.TabTeams.Margin = new System.Windows.Forms.Padding(0);
            this.TabTeams.Name = "TabTeams";
            this.TabTeams.Padding = new System.Windows.Forms.Padding(8);
            this.TabTeams.Size = new System.Drawing.Size(374, 219);
            this.TabTeams.TabIndex = 0;
            this.TabTeams.Tag = "Team";
            this.TabTeams.Text = "Select Team(s)";
            // 
            // ListViewTeams
            // 
            this.ListViewTeams.CheckBoxes = true;
            this.ListViewTeams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderTeamName,
            this.ColumnHeaderTeamBU});
            this.ListViewTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewTeams.FullRowSelect = true;
            this.ListViewTeams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewTeams.HideSelection = false;
            this.ListViewTeams.Location = new System.Drawing.Point(8, 8);
            this.ListViewTeams.Margin = new System.Windows.Forms.Padding(5);
            this.ListViewTeams.MultiSelect = false;
            this.ListViewTeams.Name = "ListViewTeams";
            this.ListViewTeams.Size = new System.Drawing.Size(358, 203);
            this.ListViewTeams.TabIndex = 8;
            this.ListViewTeams.UseCompatibleStateImageBehavior = false;
            this.ListViewTeams.View = System.Windows.Forms.View.Details;
            this.ListViewTeams.VirtualMode = true;
            // 
            // ColumnHeaderTeamName
            // 
            this.ColumnHeaderTeamName.Text = "Team Name";
            this.ColumnHeaderTeamName.Width = 210;
            // 
            // ColumnHeaderTeamBU
            // 
            this.ColumnHeaderTeamBU.Text = "BUnit";
            this.ColumnHeaderTeamBU.Width = 90;
            // 
            // TabRoles
            // 
            this.TabRoles.BackColor = System.Drawing.SystemColors.Control;
            this.TabRoles.Controls.Add(this.ListViewRoles);
            this.TabRoles.Location = new System.Drawing.Point(4, 22);
            this.TabRoles.Margin = new System.Windows.Forms.Padding(0);
            this.TabRoles.Name = "TabRoles";
            this.TabRoles.Padding = new System.Windows.Forms.Padding(8);
            this.TabRoles.Size = new System.Drawing.Size(374, 219);
            this.TabRoles.TabIndex = 1;
            this.TabRoles.Tag = "Role";
            this.TabRoles.Text = "Select Role(s)";
            // 
            // ListViewRoles
            // 
            this.ListViewRoles.CheckBoxes = true;
            this.ListViewRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderRoleName,
            this.ColumnHeaderRoleBU});
            this.ListViewRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewRoles.FullRowSelect = true;
            this.ListViewRoles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewRoles.HideSelection = false;
            this.ListViewRoles.Location = new System.Drawing.Point(8, 8);
            this.ListViewRoles.MultiSelect = false;
            this.ListViewRoles.Name = "ListViewRoles";
            this.ListViewRoles.Size = new System.Drawing.Size(358, 203);
            this.ListViewRoles.TabIndex = 7;
            this.ListViewRoles.UseCompatibleStateImageBehavior = false;
            this.ListViewRoles.View = System.Windows.Forms.View.Details;
            this.ListViewRoles.VirtualMode = true;
            this.ListViewRoles.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.ListViewRoles_CacheVirtualItems);
            this.ListViewRoles.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ListViewRoles_RetrieveVirtualItem);
            // 
            // ColumnHeaderRoleName
            // 
            this.ColumnHeaderRoleName.Text = "Role Name";
            this.ColumnHeaderRoleName.Width = 210;
            // 
            // ColumnHeaderRoleBU
            // 
            this.ColumnHeaderRoleBU.Text = "BUnit";
            this.ColumnHeaderRoleBU.Width = 90;
            // 
            // AssignmentSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AssignmentSelector";
            this.Size = new System.Drawing.Size(400, 349);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.GroupBoxAction.ResumeLayout(false);
            this.TabControlTeamsRoles.ResumeLayout(false);
            this.TabTeams.ResumeLayout(false);
            this.TabRoles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl TabControlTeamsRoles;
        private System.Windows.Forms.TabPage TabTeams;
        private System.Windows.Forms.ListView ListViewTeams;
        private System.Windows.Forms.ColumnHeader ColumnHeaderTeamName;
        private System.Windows.Forms.ColumnHeader ColumnHeaderTeamBU;
        private System.Windows.Forms.TabPage TabRoles;
        private System.Windows.Forms.ListView ListViewRoles;
        private System.Windows.Forms.ColumnHeader ColumnHeaderRoleName;
        private System.Windows.Forms.ColumnHeader ColumnHeaderRoleBU;
        private System.Windows.Forms.GroupBox GroupBoxAction;
        private System.Windows.Forms.CheckBox CheckBoxRemoveOthers;
        private System.Windows.Forms.RadioButton RadioButtonRemove;
        private System.Windows.Forms.RadioButton RadioButtonAdd;
    }
}

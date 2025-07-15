
namespace XRMPlugin.TeamRoleAssignment
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
            this.ButtonProcessChanges = new System.Windows.Forms.Button();
            this.ContextMenuStripUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripRemoveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripRemoveOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ToolTipUsers = new System.Windows.Forms.ToolTip(this.components);
            this.TableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.GroupBoxProcessChanges = new System.Windows.Forms.GroupBox();
            this.CheckBoxReview = new System.Windows.Forms.CheckBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.assignmentSelector1 = new XRMPlugin.TeamRoleAssignment.AssignmentSelectionControl();
            this.listSelector1 = new XRMPlugin.TeamRoleAssignment.ListSelectionControl();
            this.userList1 = new XRMPlugin.TeamRoleAssignment.UserListControl();
            this.ContextMenuStripUsers.SuspendLayout();
            this.TableLayoutPanelForm.SuspendLayout();
            this.GroupBoxProcessChanges.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonProcessChanges
            // 
            this.ButtonProcessChanges.AutoSize = true;
            this.ButtonProcessChanges.Enabled = false;
            this.ButtonProcessChanges.Location = new System.Drawing.Point(10, 16);
            this.ButtonProcessChanges.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonProcessChanges.Name = "ButtonProcessChanges";
            this.ButtonProcessChanges.Size = new System.Drawing.Size(120, 23);
            this.ButtonProcessChanges.TabIndex = 12;
            this.ButtonProcessChanges.Text = "Process Changes";
            this.ButtonProcessChanges.UseVisualStyleBackColor = true;
            this.ButtonProcessChanges.Click += new System.EventHandler(this.ButtonProcessChanges_Click);
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
            this.ToolStripRemoveUser.Click += new System.EventHandler(this.ToolStripRemove_Click);
            // 
            // ToolStripRemoveOthers
            // 
            this.ToolStripRemoveOthers.Name = "ToolStripRemoveOthers";
            this.ToolStripRemoveOthers.Size = new System.Drawing.Size(181, 22);
            this.ToolStripRemoveOthers.Text = "Remove All Other User(s)";
            this.ToolStripRemoveOthers.Click += new System.EventHandler(this.ToolStripRemove_Click);
            // 
            // ToolStripRefresh
            // 
            this.ToolStripRefresh.Name = "ToolStripRefresh";
            this.ToolStripRefresh.Size = new System.Drawing.Size(181, 22);
            this.ToolStripRefresh.Text = "Refresh";
            this.ToolStripRefresh.Click += new System.EventHandler(this.ToolStripRefresh_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "All supported files|*.csv; *.txt; *.xls; *.xlsb; *.xlsx|Text files (comma or tab " +
    "delimited) (*.csv; *.txt)|*.csv;*.txt|Excel files (*.xls; *.xlsb; *.xlsx)|*.xls;" +
    "*.xlsb;*.xlsx";
            this.OpenFileDialog.RestoreDirectory = true;
            this.OpenFileDialog.Title = "Select User Name List";
            // 
            // ToolTipUsers
            // 
            this.ToolTipUsers.AutoPopDelay = 10000;
            this.ToolTipUsers.InitialDelay = 200;
            this.ToolTipUsers.ReshowDelay = 100;
            // 
            // TableLayoutPanelForm
            // 
            this.TableLayoutPanelForm.ColumnCount = 2;
            this.TableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayoutPanelForm.Controls.Add(this.GroupBoxProcessChanges, 0, 2);
            this.TableLayoutPanelForm.Controls.Add(this.assignmentSelector1, 0, 1);
            this.TableLayoutPanelForm.Controls.Add(this.listSelector1, 0, 0);
            this.TableLayoutPanelForm.Controls.Add(this.userList1, 1, 0);
            this.TableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelForm.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelForm.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanelForm.MinimumSize = new System.Drawing.Size(780, 450);
            this.TableLayoutPanelForm.Name = "TableLayoutPanelForm";
            this.TableLayoutPanelForm.RowCount = 3;
            this.TableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.TableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.TableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelForm.Size = new System.Drawing.Size(1000, 600);
            this.TableLayoutPanelForm.TabIndex = 10;
            // 
            // GroupBoxProcessChanges
            // 
            this.GroupBoxProcessChanges.Controls.Add(this.CheckBoxReview);
            this.GroupBoxProcessChanges.Controls.Add(this.ButtonCancel);
            this.GroupBoxProcessChanges.Controls.Add(this.ButtonProcessChanges);
            this.GroupBoxProcessChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBoxProcessChanges.Location = new System.Drawing.Point(10, 541);
            this.GroupBoxProcessChanges.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.GroupBoxProcessChanges.Name = "GroupBoxProcessChanges";
            this.GroupBoxProcessChanges.Padding = new System.Windows.Forms.Padding(0);
            this.GroupBoxProcessChanges.Size = new System.Drawing.Size(380, 49);
            this.GroupBoxProcessChanges.TabIndex = 14;
            this.GroupBoxProcessChanges.TabStop = false;
            // 
            // CheckBoxReview
            // 
            this.CheckBoxReview.Location = new System.Drawing.Point(155, 16);
            this.CheckBoxReview.Margin = new System.Windows.Forms.Padding(5);
            this.CheckBoxReview.Name = "CheckBoxReview";
            this.CheckBoxReview.Size = new System.Drawing.Size(110, 23);
            this.CheckBoxReview.TabIndex = 13;
            this.CheckBoxReview.Text = "Review changes";
            this.CheckBoxReview.UseVisualStyleBackColor = true;
            this.CheckBoxReview.CheckedChanged += new System.EventHandler(this.CheckBoxReview_CheckedChanged);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.AutoSize = true;
            this.ButtonCancel.Location = new System.Drawing.Point(155, 16);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(70, 23);
            this.ButtonCancel.TabIndex = 14;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Visible = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // assignmentSelector1
            // 
            this.assignmentSelector1.Location = new System.Drawing.Point(0, 189);
            this.assignmentSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.assignmentSelector1.Name = "assignmentSelector1";
            this.assignmentSelector1.Size = new System.Drawing.Size(400, 349);
            this.assignmentSelector1.TabIndex = 15;
            // 
            // listSelector1
            // 
            this.listSelector1.Location = new System.Drawing.Point(0, 10);
            this.listSelector1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.listSelector1.Name = "listSelector1";
            this.listSelector1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.listSelector1.Size = new System.Drawing.Size(400, 179);
            this.listSelector1.TabIndex = 16;
            // 
            // userList1
            // 
            this.userList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userList1.Location = new System.Drawing.Point(410, 10);
            this.userList1.Margin = new System.Windows.Forms.Padding(10);
            this.userList1.Name = "userList1";
            this.TableLayoutPanelForm.SetRowSpan(this.userList1, 3);
            this.userList1.ShowDisabled = false;
            this.userList1.Size = new System.Drawing.Size(580, 580);
            this.userList1.TabIndex = 17;
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanelForm);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1000, 600);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyPluginControl_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyPluginControl_DragEnter);
            this.ContextMenuStripUsers.ResumeLayout(false);
            this.TableLayoutPanelForm.ResumeLayout(false);
            this.GroupBoxProcessChanges.ResumeLayout(false);
            this.GroupBoxProcessChanges.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonProcessChanges;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripUsers;
        private System.Windows.Forms.ToolStripMenuItem ToolStripRemoveUser;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.ToolStripMenuItem ToolStripRemoveOthers;
        private System.Windows.Forms.ToolTip ToolTipUsers;
        private System.Windows.Forms.ToolStripMenuItem ToolStripRefresh;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelForm;
        private System.Windows.Forms.CheckBox CheckBoxReview;
        private System.Windows.Forms.GroupBox GroupBoxProcessChanges;
        private System.Windows.Forms.Button ButtonCancel;
        private AssignmentSelectionControl assignmentSelector1;
        private ListSelectionControl listSelector1;
        private UserListControl userList1;
    }
}

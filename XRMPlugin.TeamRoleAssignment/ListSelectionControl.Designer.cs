namespace XRMPlugin.TeamRoleAssignment
{
    partial class ListSelectionControl
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
            this.GroupBoxSelect = new System.Windows.Forms.GroupBox();
            this.ComboBoxRoles = new System.Windows.Forms.ComboBox();
            this.LabelRole = new System.Windows.Forms.Label();
            this.ButtonFetchXML = new System.Windows.Forms.Button();
            this.TextBoxFileName = new System.Windows.Forms.TextBox();
            this.ComboBoxViews = new System.Windows.Forms.ComboBox();
            this.LabelView = new System.Windows.Forms.Label();
            this.LabelFile = new System.Windows.Forms.Label();
            this.LabelTeam = new System.Windows.Forms.Label();
            this.ComboBoxTeams = new System.Windows.Forms.ComboBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.GroupBoxSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxSelect
            // 
            this.GroupBoxSelect.Controls.Add(this.ComboBoxRoles);
            this.GroupBoxSelect.Controls.Add(this.LabelRole);
            this.GroupBoxSelect.Controls.Add(this.ButtonFetchXML);
            this.GroupBoxSelect.Controls.Add(this.TextBoxFileName);
            this.GroupBoxSelect.Controls.Add(this.ComboBoxViews);
            this.GroupBoxSelect.Controls.Add(this.LabelView);
            this.GroupBoxSelect.Controls.Add(this.LabelFile);
            this.GroupBoxSelect.Controls.Add(this.LabelTeam);
            this.GroupBoxSelect.Controls.Add(this.ComboBoxTeams);
            this.GroupBoxSelect.Controls.Add(this.ButtonBrowse);
            this.GroupBoxSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBoxSelect.Location = new System.Drawing.Point(10, 0);
            this.GroupBoxSelect.Margin = new System.Windows.Forms.Padding(0);
            this.GroupBoxSelect.Name = "GroupBoxSelect";
            this.GroupBoxSelect.Padding = new System.Windows.Forms.Padding(5);
            this.GroupBoxSelect.Size = new System.Drawing.Size(380, 179);
            this.GroupBoxSelect.TabIndex = 10;
            this.GroupBoxSelect.TabStop = false;
            this.GroupBoxSelect.Text = "Select Users";
            // 
            // ComboBoxRoles
            // 
            this.ComboBoxRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxRoles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxRoles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRoles.FormattingEnabled = true;
            this.ComboBoxRoles.Location = new System.Drawing.Point(85, 84);
            this.ComboBoxRoles.Margin = new System.Windows.Forms.Padding(5);
            this.ComboBoxRoles.Name = "ComboBoxRoles";
            this.ComboBoxRoles.Size = new System.Drawing.Size(285, 21);
            this.ComboBoxRoles.TabIndex = 4;
            // 
            // LabelRole
            // 
            this.LabelRole.Location = new System.Drawing.Point(10, 84);
            this.LabelRole.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.LabelRole.Name = "LabelRole";
            this.LabelRole.Size = new System.Drawing.Size(65, 21);
            this.LabelRole.TabIndex = 10;
            this.LabelRole.Text = "From Role";
            this.LabelRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonFetchXML
            // 
            this.ButtonFetchXML.Enabled = false;
            this.ButtonFetchXML.Location = new System.Drawing.Point(85, 146);
            this.ButtonFetchXML.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonFetchXML.Name = "ButtonFetchXML";
            this.ButtonFetchXML.Size = new System.Drawing.Size(140, 23);
            this.ButtonFetchXML.TabIndex = 6;
            this.ButtonFetchXML.Text = "Edit FetchXML Query";
            this.ButtonFetchXML.UseVisualStyleBackColor = true;
            // 
            // TextBoxFileName
            // 
            this.TextBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxFileName.Location = new System.Drawing.Point(85, 23);
            this.TextBoxFileName.Margin = new System.Windows.Forms.Padding(5);
            this.TextBoxFileName.Name = "TextBoxFileName";
            this.TextBoxFileName.ReadOnly = true;
            this.TextBoxFileName.Size = new System.Drawing.Size(210, 20);
            this.TextBoxFileName.TabIndex = 1;
            // 
            // ComboBoxViews
            // 
            this.ComboBoxViews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxViews.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxViews.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxViews.FormattingEnabled = true;
            this.ComboBoxViews.Location = new System.Drawing.Point(85, 115);
            this.ComboBoxViews.Margin = new System.Windows.Forms.Padding(5);
            this.ComboBoxViews.Name = "ComboBoxViews";
            this.ComboBoxViews.Size = new System.Drawing.Size(285, 21);
            this.ComboBoxViews.TabIndex = 5;
            // 
            // LabelView
            // 
            this.LabelView.Location = new System.Drawing.Point(10, 115);
            this.LabelView.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.LabelView.Name = "LabelView";
            this.LabelView.Size = new System.Drawing.Size(65, 21);
            this.LabelView.TabIndex = 6;
            this.LabelView.Text = "From View";
            this.LabelView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelFile
            // 
            this.LabelFile.Location = new System.Drawing.Point(10, 23);
            this.LabelFile.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.LabelFile.Name = "LabelFile";
            this.LabelFile.Size = new System.Drawing.Size(65, 20);
            this.LabelFile.TabIndex = 0;
            this.LabelFile.Text = "From File";
            this.LabelFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelTeam
            // 
            this.LabelTeam.Location = new System.Drawing.Point(10, 53);
            this.LabelTeam.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.LabelTeam.Name = "LabelTeam";
            this.LabelTeam.Size = new System.Drawing.Size(65, 21);
            this.LabelTeam.TabIndex = 1;
            this.LabelTeam.Text = "From Team";
            this.LabelTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBoxTeams
            // 
            this.ComboBoxTeams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxTeams.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxTeams.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTeams.FormattingEnabled = true;
            this.ComboBoxTeams.Location = new System.Drawing.Point(85, 53);
            this.ComboBoxTeams.Margin = new System.Windows.Forms.Padding(5);
            this.ComboBoxTeams.Name = "ComboBoxTeams";
            this.ComboBoxTeams.Size = new System.Drawing.Size(285, 21);
            this.ComboBoxTeams.TabIndex = 3;
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBrowse.Enabled = false;
            this.ButtonBrowse.Location = new System.Drawing.Point(300, 23);
            this.ButtonBrowse.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(70, 20);
            this.ButtonBrowse.TabIndex = 2;
            this.ButtonBrowse.Text = "Browse";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "All supported files|*.csv; *.txt; *.xls; *.xlsb; *.xlsx|Text files (comma or tab " +
    "delimited) (*.csv; *.txt)|*.csv;*.txt|Excel files (*.xls; *.xlsb; *.xlsx)|*.xls;" +
    "*.xlsb;*.xlsx";
            this.OpenFileDialog.RestoreDirectory = true;
            this.OpenFileDialog.Title = "Select User Name List";
            // 
            // ListSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBoxSelect);
            this.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Name = "ListSelector";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Size = new System.Drawing.Size(400, 179);
            this.GroupBoxSelect.ResumeLayout(false);
            this.GroupBoxSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxSelect;
        private System.Windows.Forms.ComboBox ComboBoxRoles;
        private System.Windows.Forms.Label LabelRole;
        private System.Windows.Forms.Button ButtonFetchXML;
        private System.Windows.Forms.TextBox TextBoxFileName;
        private System.Windows.Forms.ComboBox ComboBoxViews;
        private System.Windows.Forms.Label LabelView;
        private System.Windows.Forms.Label LabelFile;
        private System.Windows.Forms.Label LabelTeam;
        private System.Windows.Forms.ComboBox ComboBoxTeams;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}

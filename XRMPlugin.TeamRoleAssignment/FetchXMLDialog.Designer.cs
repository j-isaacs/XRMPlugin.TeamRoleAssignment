namespace XRMPlugin.TeamRoleAssignment
{
    partial class FetchXMLDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonBuilder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.scintillaFetchXML = new ScintillaNET.Scintilla();
            this.toolStripTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripTop
            // 
            this.toolStripTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSaveAndClose,
            this.toolStripSeparator1,
            this.toolStripButtonCancel,
            this.toolStripSeparator2,
            this.toolStripButtonBuilder,
            this.toolStripSeparator3});
            this.toolStripTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripTop.MinimumSize = new System.Drawing.Size(684, 25);
            this.toolStripTop.Name = "ToolStripTop";
            this.toolStripTop.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripTop.Size = new System.Drawing.Size(684, 25);
            this.toolStripTop.TabIndex = 0;
            // 
            // ToolStripButtonSaveAndClose
            // 
            this.toolStripButtonSaveAndClose.Name = "ToolStripButtonSaveAndClose";
            this.toolStripButtonSaveAndClose.Size = new System.Drawing.Size(80, 22);
            this.toolStripButtonSaveAndClose.Text = "Save && Close";
            this.toolStripButtonSaveAndClose.ToolTipText = "Save  & Close";
            this.toolStripButtonSaveAndClose.Click += new System.EventHandler(this.ToolStripButtonSaveAndClose_Click);
            // 
            // ToolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "ToolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripButtonCancel
            // 
            this.toolStripButtonCancel.Name = "ToolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(47, 22);
            this.toolStripButtonCancel.Text = "Cancel";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.ToolStripButtonCancel_Click);
            // 
            // ToolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "ToolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripButtonBuilder
            // 
            this.toolStripButtonBuilder.Name = "ToolStripButtonBuilder";
            this.toolStripButtonBuilder.Size = new System.Drawing.Size(149, 22);
            this.toolStripButtonBuilder.Text = "Open in FetchXML Builder";
            this.toolStripButtonBuilder.Click += new System.EventHandler(this.ToolStripButtonBuilder_Click);
            // 
            // ToolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "ToolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ScintillaFetchXML
            // 
            this.scintillaFetchXML.AutomaticFold = ((ScintillaNET.AutomaticFold)(((ScintillaNET.AutomaticFold.Show | ScintillaNET.AutomaticFold.Click) 
            | ScintillaNET.AutomaticFold.Change)));
            this.scintillaFetchXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintillaFetchXML.Lexer = ScintillaNET.Lexer.Xml;
            this.scintillaFetchXML.Location = new System.Drawing.Point(0, 25);
            this.scintillaFetchXML.Margin = new System.Windows.Forms.Padding(0);
            this.scintillaFetchXML.MinimumSize = new System.Drawing.Size(684, 436);
            this.scintillaFetchXML.Name = "ScintillaFetchXML";
            this.scintillaFetchXML.ScrollWidth = 1;
            this.scintillaFetchXML.Size = new System.Drawing.Size(684, 436);
            this.scintillaFetchXML.TabIndex = 2;
            // 
            // FetchXMLDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.scintillaFetchXML);
            this.Controls.Add(this.toolStripTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FetchXMLDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FetchXML";
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveAndClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonBuilder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ScintillaNET.Scintilla scintillaFetchXML;
    }
}
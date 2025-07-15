using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace XRMPlugin.TeamRoleAssignment
{
    public partial class ListSelectionControl : UserControl
    {
        private XrmContext context;

        internal XrmContext Context
        {
            set
            {
                context = value;

                ResetForm();

                LoadList<Team>(ComboBoxTeams);
                LoadList<Role>(ComboBoxRoles);
                LoadList<View>(ComboBoxViews);

                ButtonBrowse.Enabled = true;
                ButtonFetchXML.Enabled = true;
                if (context.FetchXml != null) ButtonFetchXML.Font = new Font(ButtonFetchXML.Font, FontStyle.Bold);

                context.PropertyChanged += Context_PropertyChanged;
            }
        }

        public string DefaultFilePath { set => OpenFileDialog.InitialDirectory = value; }

        public string[] SelectedFiles
        {
            get => OpenFileDialog.FileNames;
            set
            {
                var args = new CancelEventArgs();
                FilesSelected.Invoke(this, args);
                if (args.Cancel) return;
                TextBoxFileName.Text = string.Join(";", value);
                ResetForm(TextBoxFileName);
            }
        }

        public event CancelEventHandler FilesSelected;
        public event EventHandler OpenFetchXmlDialog;

        public ListSelectionControl()
        {
            InitializeComponent();
        }

        private void Context_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(context.FetchXml) && context.FetchXml != null) {
                ButtonFetchXML.Font = new Font(ButtonFetchXML.Font, FontStyle.Bold);
                ResetForm(ButtonFetchXML);
            }
        }

        private void LoadList<T>(ComboBox comboBox) where T : ListEntity
        {
            var entities = context.GetList<T>();
            comboBox.Items.Clear();
            comboBox.Items.AddRange(entities.ToArray());
            comboBox.SelectedItem = context.Entity as T;
        }

        private void ResetForm(Control excludedControl = null)
        {
            if (excludedControl != ComboBoxTeams) ComboBoxTeams.SelectedItem = null;
            if (excludedControl != ComboBoxRoles) ComboBoxRoles.SelectedItem = null;
            if (excludedControl != ComboBoxViews) ComboBoxViews.SelectedItem = null;
            if (excludedControl != TextBoxFileName) TextBoxFileName.Clear();
            if (excludedControl != ButtonFetchXML) ButtonFetchXML.Font = ButtonBrowse.Font;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK) SelectedFiles = OpenFileDialog.FileNames;
        }

        private void ComboBoxTeams_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxTeams.SelectedItem is Team selectedTeam)
            {
                ResetForm(ComboBoxTeams);
                context.SetUserQuery(selectedTeam);
            }
        }

        private void ComboBoxRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxRoles.SelectedItem is Role selectedRole)
            {
                ResetForm(ComboBoxRoles);
                context.SetUserQuery(selectedRole);
            }
        }

        private void ComboBoxViews_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxViews.SelectedItem is View selectedView && selectedView.Id != Guid.Empty)
            {
                ResetForm(ComboBoxViews);
                context.SetUserQuery(selectedView);
            }
            else if (ComboBoxViews.SelectedItem != null)
            {
                ComboBoxViews.SelectedItem = context.Entity as View;
            }
        }

        private void ButtonFetchXML_Click(object sender, EventArgs e)
        {
            OpenFetchXmlDialog.Invoke(this, new EventArgs());
        }
    }
}

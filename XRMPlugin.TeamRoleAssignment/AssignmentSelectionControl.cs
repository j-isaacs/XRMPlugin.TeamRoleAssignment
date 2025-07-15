using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace XRMPlugin.TeamRoleAssignment
{
    public partial class AssignmentSelectionControl : UserControl
    {
        private XrmContext context;

        internal XrmContext Context
        {
            set
            {
                context = value;

                ResetForm();

                teams = context.GetList<Team>();
                ListViewTeams.Tag = context.GetList<Team>();
                ListViewTeams.VirtualListSize = teams.Count;

                roles = context.GetList<Role>();
                ListViewRoles.Tag = context.GetList<Role>();
                ListViewRoles.VirtualListSize = roles.Count;

                context.PropertyChanged += Context_PropertyChanged;
            }
        }

        private List<ListEntity> teams;
        private readonly List<ListViewItem> teamItems = new List<ListViewItem>();
        private List<ListEntity> roles;
        private readonly List<ListViewItem> roleItems = new List<ListViewItem>();

        internal List<AssignableEntity> SelectedAssignments { get; set; } = new List<AssignableEntity>();

        public AssignmentSelectionControl()
        {
            InitializeComponent();
        }

        private void ResetForm(Control excludedControl = null)
        {
            while (ListViewTeams.CheckedItems.Count > 0) ListViewTeams.CheckedItems[0].Checked = false;
            while (ListViewRoles.CheckedItems.Count > 0) ListViewRoles.CheckedItems[0].Checked = false;
            RadioButtonAdd.Checked = false;
            RadioButtonRemove.Checked = false;
            CheckBoxRemoveOthers.Checked = false;
        }

        private void Context_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == nameof(context.UserFetchXml) && context.UserFetchXml != null) ButtonFetchXML.Font = new Font(ButtonFetchXML.Font, FontStyle.Bold);
        }

        private void ListViewRoles_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (roleItems.Count > e.ItemIndex)
            {
                e.Item = roleItems[e.ItemIndex];
            }
            else
            {
                var role = roles[e.ItemIndex];
                e.Item = new ListViewItem(role.ListItems) { Checked = SelectedAssignments.Contains(role) };
            }
        }

        private void ListViewRoles_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            if (roleItems != null && e.EndIndex < roleItems.Count) return;

            for (int i = roleItems.Count; i <= e.EndIndex; i++)
            {
                roleItems.Add(new ListViewItem(roles[i].ListItems));
            }
        }
    }
}

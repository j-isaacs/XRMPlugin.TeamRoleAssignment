using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility.Args;

namespace XRMPlugin.TeamRoleAssignment
{
    public partial class UserListControl : UserControl
    {
        public int Count { get; private set; }

        public bool ShowDisabled { get; set; }

        private PluginControl Plugin => Parent as PluginControl;

        private readonly List<ListViewItem> Items = new List<ListViewItem>();

        private XrmContext xrmService;

        public UserListControl()
        {
            InitializeComponent();
        }

        private void ListViewUsers_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (Items.Count > e.ItemIndex)
            {
                e.Item = Items[e.ItemIndex];
            }
            else
            {
                var user = xrmService.GetList<User>()[e.ItemIndex];
                e.Item = new ListViewItem(user.ListItems)
                {
                    ForeColor = user.Disabled ? Color.Gray : Color.Empty
                };
            }
        }

        private void ListViewUsers_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            if (Items != null && e.EndIndex < Items.Count) return;

            var users = xrmService.GetList<User>();

            for (int i = Items.Count; i <= e.EndIndex; i++)
            {
                Items.Add(new ListViewItem(users[i].ListItems)
                {
                    ForeColor = users[i].Disabled ? Color.Gray : Color.Empty
                });
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
            //var option = sender as ToolStripMenuItem;
            //var users = xrmService.GetList<User>();
            //var selectedUsers = users.Where((u, i) => ListViewUsers.SelectedIndices.Contains(i)).ToList();
            //ListViewUsers.BeginUpdate();
            //if (option == ToolStripRemoveOthers)
            //{
            //    ListViewUsers.VirtualListSize = ListViewUsers.SelectedIndices.Count;
            //    foreach (ListEntity user in users.Except(selectedUsers).ToList()) users.Remove(user);
            //}
            //else
            //{
            //    ListViewUsers.VirtualListSize -= ListViewUsers.SelectedIndices.Count;
            //    foreach (ListEntity user in selectedUsers) users.Remove(user);
            //}

            //ListViewUsers.EndUpdate();

            //SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs($"{ListViewUsers.VirtualListSize} Users"));
            //ToggleEnabled();
        }

        private void ToolStripRefresh_Click(object sender, EventArgs e)
        {
            Plugin.PopulateUserList();
        }

        private void ToolStripButtonShowDisabled_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButtonShowDisabled.Image = ToolStripButtonShowDisabled.Checked ? Properties.Resources.Checkmark : null;
            ShowDisabled = ToolStripButtonShowDisabled.Checked;
            Plugin.PopulateUserList();
        }
    }
}

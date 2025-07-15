using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace XRMPlugin.TeamRoleAssignment
{
    internal class EntityListView : ListView, INotifyPropertyChanged
    {
        const char ascArrow = '▲';
        const char descArrow = '▼';

        private readonly double scrollMargin = (int)(SystemInformation.VerticalScrollBarWidth * 1.5);
        private readonly List<ListViewItem> itemCache = new List<ListViewItem>();
        private readonly List<ListEntity> entityList = new List<ListEntity>();
        private bool selectable = false;
        private double prevWidth = 0;
        private int sortColumn = -1;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<ListEntity> Entities => entityList;

        public List<ListEntity> SelectedEntities => SelectedIndices.Cast<int>().Select(i => entityList[i]).ToList();

        public ContextMenuStrip ItemContextMenuStrip { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Selectable
        {
            get => selectable;
            set
            {
                if (selectable != value)
                {
                    selectable = value;
                    if (SelectedIndices.Count > 0) SelectedIndices.Clear();
                    HeaderStyle = selectable ? ColumnHeaderStyle.Clickable : ColumnHeaderStyle.Nonclickable;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int VirtualListSize => base.VirtualListSize;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool VirtualMode => base.VirtualMode;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new System.Windows.Forms.View View => base.View;

        public EntityListView() : base()
        {
            base.VirtualMode = true;
            base.View = System.Windows.Forms.View.Details;
        }

        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            if (Columns[e.ColumnIndex].Tag == null && !DesignMode)
            {
                prevWidth += Columns[e.ColumnIndex].Width;
                Columns[e.ColumnIndex].Tag = 0.0;

                if (!Columns.Cast<ColumnHeader>().Any(c => c.Tag == null))
                {
                    foreach (ColumnHeader column in Columns)
                    {
                        column.Tag = column.Width / prevWidth;
                    }
                    OnResize(e);
                }
            }

            base.OnColumnWidthChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (!Columns.Cast<ColumnHeader>().Any(c => c.Tag == null))
            {
                var availableWidth = Width - scrollMargin;

                if (Visible && availableWidth != prevWidth)
                {
                    BeginUpdate();
                    foreach (ColumnHeader column in Columns)
                    {
                        column.Width = (int)(availableWidth * (double)column.Tag);
                    }

                    prevWidth = availableWidth;
                    EndUpdate();
                }
            }

            base.OnResize(e);
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            if (selectable)
            {
                BeginUpdate();
                itemCache.Clear();
                Sort(e.Column, !e.Column.Equals(sortColumn) || Sorting.Equals(SortOrder.Descending) ? SortOrder.Ascending : SortOrder.Descending, SelectedEntities);
                EndUpdate();

                base.OnColumnClick(e);
            }
        }

        private void Sort(int columnIndex, SortOrder sortOrder, List<ListEntity> selected)
        {
            if (sortColumn >= 0) Columns[sortColumn].Text = Columns[sortColumn].Text.Remove(Columns[sortColumn].Text.Length - 2);
            sortColumn = columnIndex;
            Sorting = sortOrder;
            if (columnIndex >= 0)
            {
                entityList.Sort(ListEntityComparison);
                Columns[columnIndex].Text += $" {(Sorting == SortOrder.Ascending ? ascArrow : descArrow)}";
            }

            if (SelectedIndices.Count > 0) SelectedIndices.Clear();

            foreach (var index in selected.Select(e => entityList.IndexOf(e)))
            {
                SelectedIndices.Add(index);
            }
        }

        private int ListEntityComparison(ListEntity x, ListEntity y)
        {
            var comparison = x.ListItems[sortColumn].CompareTo(y.ListItems[sortColumn]);
            return Sorting.Equals(SortOrder.Ascending) ? comparison : comparison * -1;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (selectable)
            {
                if (e.Button == MouseButtons.Right && GetItemAt(e.X, e.Y) == FocusedItem) ItemContextMenuStrip?.Show(Cursor.Position);
                base.OnMouseClick(e);
            }
        }

        protected override void OnRetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
        {
            if (itemCache.Count > e.ItemIndex)
                e.Item = itemCache[e.ItemIndex];
            else
                e.Item = new ListViewItem(entityList[e.ItemIndex].ListItems) { ForeColor = entityList[e.ItemIndex].Disabled ? Color.Gray : Color.Empty };

            base.OnRetrieveVirtualItem(e);
        }

        protected override void OnCacheVirtualItems(CacheVirtualItemsEventArgs e)
        {
            if (e.EndIndex < itemCache.Count) return;

            for (int i = itemCache.Count; i <= e.EndIndex; i++)
                itemCache.Add(new ListViewItem(entityList[i].ListItems) { ForeColor = entityList[i].Disabled ? Color.Gray : Color.Empty });

            base.OnCacheVirtualItems(e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectionChanged()) base.OnSelectedIndexChanged(e);
        }

        protected override void OnVirtualItemsSelectionRangeChanged(ListViewVirtualItemsSelectionRangeChangedEventArgs e)
        {
            if (SelectionChanged()) base.OnVirtualItemsSelectionRangeChanged(e);
        }

        private bool SelectionChanged()
        {
            if (selectable)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedEntities)));
            else if (SelectedIndices.Count > 0)
                SelectedIndices.Clear();

            return selectable;
        }

        public void LoadItems(IEnumerable<ListEntity> entities, bool keepSelection = false, bool keepSort = true)
        {
            BeginUpdate();

            var selected = new List<ListEntity>();
            if (keepSelection)
            {
                var byName = entities.ToLookup(e => e.Name);
                selected.AddRange(SelectedEntities.Select(s => byName[s.Name].OrderByDescending(e => e.Id == s.Id).FirstOrDefault()).Where(e => e != null));
            }
            entityList.Clear();
            itemCache.Clear();
            entityList.AddRange(entities);
            base.VirtualListSize = entityList.Count;
            Sort(keepSort ? sortColumn : -1, keepSort ? Sorting : SortOrder.None, selected);
            Selectable = entityList.Count > 0;

            EndUpdate();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Entities)));
        }
    }
}

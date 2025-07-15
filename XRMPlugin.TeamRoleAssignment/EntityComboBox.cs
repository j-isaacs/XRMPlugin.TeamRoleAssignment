using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace XRMPlugin.TeamRoleAssignment
{
    internal class EntityComboBox : ComboBox
    {
        private readonly Font groupFont;
        private ListEntity selectedEntity;

        public ListEntity SelectedEntity => selectedEntity;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DrawMode DrawMode => base.DrawMode;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ComboBoxStyle DropDownStyle => base.DropDownStyle;

        public EntityComboBox() : base()
        {
            base.DrawMode = DrawMode.OwnerDrawFixed;
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            groupFont = new Font(Font, FontStyle.Bold);
        }

        public void LoadItems(List<ListEntity> entityList, bool keepSelection = false)
        {
            BeginUpdate();

            Items.Clear();
            string group = null;
            foreach (var entity in entityList)
            {
                if (entity.Group != group)
                {
                    Items.Add(entity.Group);
                    group = entity.Group;
                }
                Items.Add(entity);
            }

            if (keepSelection) SelectedItem = selectedEntity = entityList.FirstOrDefault(e => e.Name == selectedEntity?.Name);

            EndUpdate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (DroppedDown || (e.State & DrawItemState.Selected) != DrawItemState.Selected) e.DrawBackground();

            if (e.Index > -1)
            {
                if (Items[e.Index] is ListEntity entity)
                {
                    var rect = entity.Group != null ? new Rectangle(5, e.Bounds.Top, e.Bounds.Width - 5, e.Bounds.Height) : e.Bounds;
                    e.Graphics.DrawString(entity.ToString(), Font, new SolidBrush(ForeColor), rect);
                    e.DrawFocusRectangle();
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(e.Bounds.Left, e.Bounds.Top, ClientSize.Width - e.Bounds.Left, e.Bounds.Height));
                    e.Graphics.DrawString(Items[e.Index].ToString(), groupFont, new SolidBrush(ForeColor), e.Bounds);
                }
            }
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            if (SelectedIndex != -1 && !(SelectedItem is ListEntity))
            {
                SelectedItem = selectedEntity;
            }
            else if (SelectedItem != selectedEntity)
            {
                selectedEntity = SelectedItem as ListEntity;
                base.OnSelectedValueChanged(e);
            }
        }
    }
}

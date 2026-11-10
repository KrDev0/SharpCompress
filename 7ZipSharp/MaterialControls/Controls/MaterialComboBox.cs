using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MaterialSkin.Controls
{
    public class MaterialComboBox : ComboBox
    {
        public MaterialComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            ItemHeight = 25;
            FlatStyle = FlatStyle.Flat;
            DrawItem += PaintItem;
            Enter += (s, e) => Invalidate();
            Leave += (s, e) => Invalidate();
            DropDown += (s, e) => Invalidate();
            DropDownClosed += (s, e) => Invalidate();
        }

        private void PaintItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color back = selected ? Color.FromArgb(255, 239, 190) : BackColor;
            using (Brush brush = new SolidBrush(back)) e.Graphics.FillRectangle(brush, e.Bounds);
            TextRenderer.DrawText(e.Graphics, GetItemText(Items[e.Index]), Font, e.Bounds, ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.EndEllipsis);
            if (Focused && e.Index == SelectedIndex)
            {
                using (Pen pen = new Pen(Color.FromArgb(220, 185, 75), 2F))
                    e.Graphics.DrawLine(pen, e.Bounds.Left + 2, e.Bounds.Bottom - 2, e.Bounds.Right - 2, e.Bounds.Bottom - 2);
            }
        }
    }
}

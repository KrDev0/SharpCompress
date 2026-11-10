using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _7ZipSharp
{
    internal sealed class ThemePalette
    {
        internal Color Window { get; private set; }
        internal Color Surface { get; private set; }
        internal Color Input { get; private set; }
        internal Color Text { get; private set; }
        internal Color MutedText { get; private set; }
        internal Color Border { get; private set; }
        internal Color Accent { get { return Color.FromArgb(255, 215, 63); } }

        internal ThemePalette(bool dark)
        {
            Window = dark ? Color.FromArgb(31, 35, 40) : Color.FromArgb(255, 255, 255);
            Surface = dark ? Color.FromArgb(40, 45, 51) : Color.FromArgb(246, 248, 251);
            Input = dark ? Color.FromArgb(49, 55, 62) : Color.White;
            Text = dark ? Color.FromArgb(235, 238, 242) : Color.FromArgb(35, 47, 61);
            MutedText = dark ? Color.FromArgb(170, 179, 188) : Color.FromArgb(99, 112, 127);
            Border = dark ? Color.FromArgb(71, 79, 88) : Color.FromArgb(211, 220, 229);
        }
    }

    internal static class ThemeManager
    {
        internal static ThemePalette Current
        {
            get { return new ThemePalette(false); }
        }

        internal static void Apply(Form form)
        {
            if (form == null) return;
            ThemePalette palette = Current;
            form.Font = new Font("Segoe UI", form.Font.Size > 0 ? form.Font.Size : 9F, form.Font.Style);
            form.BackColor = palette.Window;
            form.ForeColor = palette.Text;
            ApplyControls(form.Controls, palette);
        }

        private static void ApplyControls(Control.ControlCollection controls, ThemePalette palette)
        {
            foreach (Control control in controls)
            {
                // MaterialSingleLineTextField owns a native TextBox that draws its own underline.
                // Styling that child as a regular TextBox adds the unwanted WinForms border.
                if (control.Parent is MaterialSkin.Controls.MaterialSingleLineTextField)
                    continue;

                if (!control.Font.FontFamily.Name.StartsWith("Segoe UI", System.StringComparison.OrdinalIgnoreCase))
                    control.Font = new Font("Segoe UI", control.Font.Size > 0 ? control.Font.Size : 9F, control.Font.Style);
                if (control is TextBoxBase || control is ComboBox || control is ListView || control is TreeView || control is DataGridView)
                {
                    control.BackColor = palette.Input;
                    control.ForeColor = palette.Text;
                    ComboBox combo = control as ComboBox;
                    if (combo != null)
                    {
                        combo.FlatStyle = FlatStyle.Flat;
                        combo.IntegralHeight = false;
                    }
                    TextBoxBase textBox = control as TextBoxBase;
                    if (textBox != null) textBox.BorderStyle = BorderStyle.FixedSingle;
                    ListView list = control as ListView;
                    if (list != null)
                    {
                        list.BorderStyle = BorderStyle.None;
                        list.FullRowSelect = true;
                        list.HideSelection = false;
                        list.GridLines = false;
                        list.OwnerDraw = true;
                        list.DrawColumnHeader -= DrawListColumnHeader;
                        list.DrawItem -= DrawListItem;
                        list.DrawSubItem -= DrawListSubItem;
                        list.DrawColumnHeader += DrawListColumnHeader;
                        list.DrawItem += DrawListItem;
                        list.DrawSubItem += DrawListSubItem;
                    }
                    TreeView tree = control as TreeView;
                    if (tree != null)
                    {
                        tree.BorderStyle = BorderStyle.None;
                        tree.HotTracking = true;
                        tree.ItemHeight = Math.Max(tree.ItemHeight, 30);
                    }
                    DataGridView grid = control as DataGridView;
                    if (grid != null)
                    {
                        grid.BorderStyle = BorderStyle.None;
                        grid.EnableHeadersVisualStyles = false;
                        grid.ColumnHeadersDefaultCellStyle.BackColor = palette.Surface;
                        grid.ColumnHeadersDefaultCellStyle.ForeColor = palette.Text;
                        grid.GridColor = palette.Border;
                    }
                }
                else if (control is Button)
                {
                    var button = (Button)control;
                    MaterialSkin.Controls.MaterialFlatButton material = button as MaterialSkin.Controls.MaterialFlatButton;
                    if (material != null) { material.Primary = IsPrimaryAction(button); material.AutoSize = false; }
                    button.UseVisualStyleBackColor = false;
                    button.BackColor = IsPrimaryAction(button) ? palette.Accent : palette.Surface;
                    button.ForeColor = palette.Text;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = palette.Border;
                }
                else if (control is TabPage)
                {
                    // ThemeManager runs at runtime only; keep the page surface opaque for custom painting.
                    control.BackColor = palette.Surface;
                    control.ForeColor = palette.Text;
                    ((TabPage)control).UseVisualStyleBackColor = false;
                }
                else if (control is GroupBox)
                {
                    control.BackColor = palette.Surface;
                    control.ForeColor = palette.Text;
                }
                else if (control is TabControl)
                {
                    control.BackColor = palette.Surface;
                    control.ForeColor = palette.Text;
                    TabControl tabs = (TabControl)control;
                    tabs.DrawMode = TabDrawMode.OwnerDrawFixed;
                    tabs.ItemSize = new Size(112, 34);
                    tabs.SizeMode = TabSizeMode.Fixed;
                    tabs.DrawItem -= DrawTab;
                    tabs.DrawItem += DrawTab;
                }
                else if (control.Name == "headerAccent")
                {
                    control.BackColor = palette.Accent;
                    control.ForeColor = palette.Accent;
                }
                else if (control is Panel || control is TableLayoutPanel || control is FlowLayoutPanel || control is SplitContainer)
                {
                    control.BackColor = palette.Surface;
                    control.ForeColor = palette.Text;
                }
                else if (control is CheckBox || control is RadioButton)
                {
                    control.BackColor = palette.Surface;
                    control.ForeColor = control.Enabled ? palette.Text : palette.MutedText;
                    CheckBox check = control as CheckBox;
                    if (check != null) check.FlatStyle = FlatStyle.Flat;
                }
                else if (control is Label || control is LinkLabel)
                {
                    control.ForeColor = control.Enabled ? palette.Text : palette.MutedText;
                    control.BackColor = GetSolidParentColor(control, palette);
                }
                else
                {
                    control.ForeColor = control.Enabled ? palette.Text : palette.MutedText;
                }

                if (control.ContextMenuStrip != null) ApplyToolStrip(control.ContextMenuStrip, palette);
                var strip = control as ToolStrip;
                if (strip != null) ApplyToolStrip(strip, palette);
                ApplyControls(control.Controls, palette);
            }
        }

        private static bool IsPrimaryAction(Button button)
        {
            return button.Name == "btnPrimary" || button.Name == "btnComprimir" || button.Name == "btnAccept" ||
                button.Name == "btnApply" || button.Name == "btnSave";
        }

        private static void DrawTab(object sender, DrawItemEventArgs e)
        {
            TabControl tabs = (TabControl)sender;
            ThemePalette palette = Current;
            bool selected = e.Index == tabs.SelectedIndex;
            Rectangle bounds = e.Bounds;
            using (Brush background = new SolidBrush(selected ? Color.White : palette.Surface))
                e.Graphics.FillRectangle(background, bounds);
            TextRenderer.DrawText(e.Graphics, tabs.TabPages[e.Index].Text, new Font("Segoe UI", 9F, selected ? FontStyle.Bold : FontStyle.Regular), bounds, palette.Text, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            if (selected)
                using (Pen accent = new Pen(palette.Accent, 3F))
                    e.Graphics.DrawLine(accent, bounds.Left + 8, bounds.Bottom - 2, bounds.Right - 8, bounds.Bottom - 2);
        }

        private static void DrawListColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ThemePalette palette = Current;
            using (Brush background = new SolidBrush(palette.Surface)) e.Graphics.FillRectangle(background, e.Bounds);
            TextRenderer.DrawText(e.Graphics, e.Header.Text, new Font("Segoe UI", 9F, FontStyle.Bold), e.Bounds, palette.Text, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.LeftAndRightPadding);
        }

        private static void DrawListItem(object sender, DrawListViewItemEventArgs e)
        {
            if (((ListView)sender).View != View.Details) e.DrawDefault = true;
        }

        private static void DrawListSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ThemePalette palette = Current;
            bool selected = e.Item.Selected;
            using (Brush background = new SolidBrush(selected ? Color.FromArgb(255, 248, 218) : Color.White)) e.Graphics.FillRectangle(background, e.Bounds);
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.Font, e.Bounds, palette.Text, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.LeftAndRightPadding);
        }


        private static Color GetSolidParentColor(Control control, ThemePalette palette)
        {
            if (control.Parent == null) return palette.Window;

            Color parentColor = control.Parent.BackColor;
            return parentColor.A == 255 ? parentColor : palette.Surface;
        }

        private static void ApplyToolStrip(ToolStrip strip, ThemePalette palette)
        {
            strip.BackColor = palette.Surface;
            strip.ForeColor = palette.Text;
            strip.RenderMode = ToolStripRenderMode.Professional;
            strip.Renderer = new ThemeToolStripRenderer(palette);
            foreach (ToolStripItem item in strip.Items) ApplyToolStripItem(item, palette);
        }

        private static void ApplyToolStripItem(ToolStripItem item, ThemePalette palette)
        {
            item.BackColor = palette.Surface;
            item.ForeColor = palette.Text;
            var dropDown = item as ToolStripDropDownItem;
            if (dropDown != null)
                foreach (ToolStripItem child in dropDown.DropDownItems) ApplyToolStripItem(child, palette);
        }

        private sealed class ThemeToolStripRenderer : ToolStripProfessionalRenderer
        {
            internal ThemeToolStripRenderer(ThemePalette palette) : base(new ThemeColorTable(palette)) { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected && !e.Item.Pressed) return;
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                bounds.Inflate(-2, -1);
                using (Brush brush = new SolidBrush(Color.FromArgb(255, 242, 229, 178)))
                using (GraphicsPath path = RoundedItem(bounds, 4))
                    e.Graphics.FillPath(brush, path);
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                using (Brush brush = new SolidBrush(Color.White)) e.Graphics.FillRectangle(brush, e.AffectedBounds);
            }

            private static GraphicsPath RoundedItem(Rectangle r, int radius)
            {
                GraphicsPath p = new GraphicsPath();
                int d = radius * 2;
                p.AddArc(r.Left, r.Top, d, d, 180, 90);
                p.AddArc(r.Right - d, r.Top, d, d, 270, 90);
                p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                p.AddArc(r.Left, r.Bottom - d, d, d, 90, 90);
                p.CloseFigure();
                return p;
            }
        }

        private sealed class ThemeColorTable : ProfessionalColorTable
        {
            private readonly ThemePalette palette;
            internal ThemeColorTable(ThemePalette theme) { palette = theme; }
            public override Color ToolStripGradientBegin { get { return palette.Surface; } }
            public override Color ToolStripGradientMiddle { get { return palette.Surface; } }
            public override Color ToolStripGradientEnd { get { return palette.Surface; } }
            public override Color MenuStripGradientBegin { get { return palette.Surface; } }
            public override Color MenuStripGradientEnd { get { return palette.Surface; } }
            public override Color ToolStripDropDownBackground { get { return palette.Surface; } }
            public override Color MenuItemSelected { get { return palette.Border; } }
            public override Color MenuItemBorder { get { return palette.Border; } }
            public override Color MenuBorder { get { return palette.Border; } }
            public override Color ImageMarginGradientBegin { get { return palette.Surface; } }
            public override Color ImageMarginGradientMiddle { get { return palette.Surface; } }
            public override Color ImageMarginGradientEnd { get { return palette.Surface; } }
        }
    }
}

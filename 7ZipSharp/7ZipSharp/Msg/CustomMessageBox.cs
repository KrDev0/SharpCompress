using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace _7ZipSharp.Msg
{
    public enum OverwriteChoice
    {
        Replace,
        ReplaceAll,
        Skip,
        Cancel
    }

    public partial class CustomMessageBox : Form
    {
        private enum ButtonAction
        {
            Accept,
            Cancel,
            Yes,
            No,
            Replace,
            ReplaceAll,
            Skip
        }

        private bool overwriteMode;
        private MessageBoxIcon messageIcon;
        private DialogResult selectedResult = DialogResult.Cancel;

        public DialogResult SelectedResult { get { return selectedResult; } }
        public OverwriteChoice SelectedOverwriteChoice { get; private set; } = OverwriteChoice.Cancel;

        public CustomMessageBox() : this("Mensaje") { }

        public CustomMessageBox(string mensaje, string titulo = "Mensaje", MessageBoxButtons botones = MessageBoxButtons.OK)
            : this(mensaje, titulo, botones, MessageBoxIcon.Information, false)
        {
        }

        internal CustomMessageBox(string mensaje, string titulo, MessageBoxIcon icono, bool overwritePrompt)
            : this(mensaje, titulo, MessageBoxButtons.OK, icono, overwritePrompt)
        {
        }

        internal CustomMessageBox(string mensaje, string titulo, MessageBoxButtons botones,
            MessageBoxIcon icono, bool overwritePrompt)
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            overwriteMode = overwritePrompt;
            messageIcon = icono;
            Text = Localization.TranslateText(titulo ?? "Mensaje");
            lblMensaje.Text = mensaje ?? string.Empty;
            ConfigureMessageLayout();
            ConfigureButtons(botones);
            iconPanel.Paint += iconPanel_Paint;
            WireButton(btnPrimary);
            WireButton(btnSecondary);
            WireButton(btnTertiary);
            WireButton(btnAll);

            Localization.Apply(this);
            ProductUi.Apply(this);
        }

        private void ConfigureMessageLayout()
        {
            int width = overwriteMode ? 620 : (lblMensaje.Text.Length > 700 ? 700 : 540);
            ClientSize = new Size(width, 220);
            iconPanel.Visible = messageIcon != MessageBoxIcon.None;
            int textLeft = iconPanel.Visible ? 58 : 8;
            int textWidth = Math.Max(200, width - 64 - textLeft);
            Size measured = TextRenderer.MeasureText(lblMensaje.Text, lblMensaje.Font,
                new Size(textWidth, 10000), TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl | TextFormatFlags.NoPrefix);
            int contentHeight = Math.Max(54, measured.Height + 4);
            int desiredHeight = Math.Min(680, Math.Max(200, contentHeight + 112));
            ClientSize = new Size(width, desiredHeight);

            lblMensaje.Location = new Point(textLeft, 4);
            lblMensaje.Size = new Size(textWidth, contentHeight);
            messagePanel.AutoScroll = contentHeight > desiredHeight - 116;
            messagePanel.AutoScrollMinSize = new Size(textWidth + textLeft, contentHeight + 8);
            iconPanel.Location = new Point(4, 5);

            StartPosition = FormStartPosition.CenterParent;
        }

        private void ConfigureButtons(MessageBoxButtons buttons)
        {
            actions.Controls.Clear();
            HideActionButtons();

            if (overwriteMode)
            {
                ConfigureButton(btnTertiary, Localization.TranslateText("Cancelar"), ButtonAction.Cancel, true);
                ConfigureButton(btnSecondary, Localization.TranslateText("Omitir"), ButtonAction.Skip, true);
                ConfigureButton(btnAll, Localization.TranslateText("Sí a todo"), ButtonAction.ReplaceAll, true);
                ConfigureButton(btnPrimary, Localization.TranslateText("Reemplazar"), ButtonAction.Replace, true);
            }
            else
            {
                switch (buttons)
                {
                    case MessageBoxButtons.OKCancel:
                        ConfigureButton(btnSecondary, Localization.TranslateText("Cancelar"), ButtonAction.Cancel, true);
                        ConfigureButton(btnPrimary, Localization.TranslateText("Aceptar"), ButtonAction.Accept, true);
                        break;
                    case MessageBoxButtons.YesNo:
                        ConfigureButton(btnSecondary, Localization.TranslateText("No"), ButtonAction.No, true);
                        ConfigureButton(btnPrimary, Localization.TranslateText("Sí"), ButtonAction.Yes, true);
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        ConfigureButton(btnTertiary, Localization.TranslateText("Cancelar"), ButtonAction.Cancel, true);
                        ConfigureButton(btnSecondary, Localization.TranslateText("No"), ButtonAction.No, true);
                        ConfigureButton(btnPrimary, Localization.TranslateText("Sí"), ButtonAction.Yes, true);
                        break;
                    default:
                        ConfigureButton(btnPrimary, Localization.TranslateText("Aceptar"), ButtonAction.Accept, true);
                        break;
                }
            }

            AddVisibleAction(btnTertiary);
            AddVisibleAction(btnSecondary);
            AddVisibleAction(btnAll);
            AddVisibleAction(btnPrimary);
            AcceptButton = btnPrimary;
            if (btnTertiary.Visible) CancelButton = btnTertiary;
            else if (btnSecondary.Visible) CancelButton = btnSecondary;
            else CancelButton = btnPrimary;
        }

        private void HideActionButtons()
        {
            btnPrimary.Visible = false;
            btnSecondary.Visible = false;
            btnTertiary.Visible = false;
            btnAll.Visible = false;
        }

        private static void ConfigureButton(MaterialSkin.Controls.MaterialFlatButton button,
            string text, ButtonAction action, bool visible)
        {
            button.Text = text;
            button.Tag = action;
            button.Primary = action == ButtonAction.Accept || action == ButtonAction.Yes || action == ButtonAction.Replace;
            button.Visible = visible;
        }

        private void AddVisibleAction(Control button)
        {
            if (button.Visible) actions.Controls.Add(button);
        }

        private void WireButton(Control button)
        {
            button.Click += actionButton_Click;
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            var button = sender as Control;
            if (button == null || !(button.Tag is ButtonAction)) return;
            ButtonAction action = (ButtonAction)button.Tag;
            switch (action)
            {
                case ButtonAction.Cancel:
                    selectedResult = DialogResult.Cancel;
                    SelectedOverwriteChoice = OverwriteChoice.Cancel;
                    break;
                case ButtonAction.Yes:
                case ButtonAction.Replace:
                    selectedResult = DialogResult.Yes;
                    SelectedOverwriteChoice = OverwriteChoice.Replace;
                    break;
                case ButtonAction.ReplaceAll:
                    selectedResult = DialogResult.Yes;
                    SelectedOverwriteChoice = OverwriteChoice.ReplaceAll;
                    break;
                case ButtonAction.Skip:
                case ButtonAction.No:
                    selectedResult = DialogResult.No;
                    SelectedOverwriteChoice = OverwriteChoice.Skip;
                    break;
                default:
                    selectedResult = DialogResult.OK;
                    break;
            }
            DialogResult = selectedResult;
            Close();
        }

        private void iconPanel_Paint(object sender, PaintEventArgs e)
        {
            Color accent = Color.FromArgb(213, 163, 0);
            Color fill = Color.FromArgb(255, 247, 214);
            string symbol = "i";
            if (messageIcon == MessageBoxIcon.Error || messageIcon == MessageBoxIcon.Hand || messageIcon == MessageBoxIcon.Stop)
            {
                accent = Color.FromArgb(190, 55, 55);
                fill = Color.FromArgb(253, 232, 232);
                symbol = "×";
            }
            else if (messageIcon == MessageBoxIcon.Warning || messageIcon == MessageBoxIcon.Exclamation)
            {
                symbol = "!";
            }
            else if (messageIcon == MessageBoxIcon.Question)
            {
                accent = Color.FromArgb(57, 105, 145);
                fill = Color.FromArgb(231, 241, 250);
                symbol = "?";
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle circle = new Rectangle(5, 5, Math.Max(1, iconPanel.Width - 10), Math.Max(1, iconPanel.Height - 10));
            using (var brush = new SolidBrush(fill)) e.Graphics.FillEllipse(brush, circle);
            using (var pen = new Pen(accent, 1.5f)) e.Graphics.DrawEllipse(pen, circle);
            using (var font = new Font("Segoe UI", 17f, FontStyle.Bold))
                TextRenderer.DrawText(e.Graphics, symbol, font, circle,
                    accent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }
    }

    internal static class AppMessage
    {
        internal static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(null, text, caption, buttons, icon);
        }

        internal static DialogResult Show(IWin32Window owner, string text, string caption,
            MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            using (var dialog = new CustomMessageBox(text, caption, buttons, icon, false))
                return owner == null ? dialog.ShowDialog() : dialog.ShowDialog(owner);
        }

        internal static OverwriteChoice ConfirmOverwrite(IWin32Window owner, string filePath)
        {
            string message = Localization.IsEnglish
                ? "A file already exists at this location:\r\n" + filePath + "\r\n\r\nChoose Replace to overwrite this file, Replace all to apply this choice to every conflict, or Skip to keep the existing file."
                : "Ya existe un archivo en esta ubicación:\r\n" + filePath + "\r\n\r\nElige Reemplazar para sobrescribir este archivo, Sí a todo para aplicar la decisión a todos los conflictos u Omitir para conservar el archivo existente.";
            using (var dialog = new CustomMessageBox(message, "Archivo existente", MessageBoxIcon.Question, true))
            {
                if (owner == null) dialog.ShowDialog();
                else dialog.ShowDialog(owner);
                return dialog.SelectedOverwriteChoice;
            }
        }
    }
}
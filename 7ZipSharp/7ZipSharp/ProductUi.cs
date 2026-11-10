using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;

namespace _7ZipSharp
{
    internal static class ProductUi
    {
        internal static void Apply(Form form)
        {
            if (form == null) return;
            MaterialSkinManager.Instance.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.Instance.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Yellow700, TextShade.BLACK);
            ThemeManager.Apply(form);
            ApplyAccessibility(form);
        }

        internal static void RefreshOpenForms()
        {
            foreach (Form form in Application.OpenForms)
                Apply(form);
        }

        private static void ApplyAccessibility(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.AccessibleName = AccessibleLabel(control);
                if (control is TextBox && string.IsNullOrWhiteSpace(control.AccessibleDescription))
                    control.AccessibleDescription = "Campo de entrada";

                var toolStrip = control as ToolStrip;
                if (toolStrip != null)
                    foreach (ToolStripItem item in toolStrip.Items)
                        ApplyAccessibility(item);
                ApplyAccessibility(control);
            }
        }

        private static void ApplyAccessibility(ToolStripItem item)
        {
            item.AccessibleName = string.IsNullOrWhiteSpace(item.Text) ? item.Name : item.Text;
            var dropDown = item as ToolStripDropDownItem;
            if (dropDown != null)
                foreach (ToolStripItem child in dropDown.DropDownItems)
                    ApplyAccessibility(child);
        }

        private static string AccessibleLabel(Control control)
        {
            bool english = Localization.IsEnglish;
            switch (control.Name)
            {
                case "backButton": return english ? "Back" : "Atrás";
                case "upButton": return english ? "Go up one folder" : "Subir una carpeta";
                case "refreshButton": return english ? "Refresh current location" : "Actualizar ubicación actual";
                case "addressBox": return english ? "Current path" : "Ruta actual";
                case "navigationTree": return english ? "Navigation locations" : "Ubicaciones de navegación";
                case "listViewArchivos": return english ? "Files and folders" : "Archivos y carpetas";
            }
            return string.IsNullOrWhiteSpace(control.Text) ? control.Name : control.Text;
        }
    }
}

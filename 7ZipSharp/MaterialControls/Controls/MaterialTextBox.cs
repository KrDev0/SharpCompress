using System.Drawing;

namespace MaterialSkin.Controls
{
    /// <summary>Designer-friendly name for the MaterialSkin single-line text field.</summary>
    public class MaterialTextBox : MaterialSingleLineTextField
    {
        public MaterialTextBox()
        {
            Hint = string.Empty;
            BackColor = Color.White;
            ForeColor = Color.FromArgb(35, 47, 61);
        }
    }
}

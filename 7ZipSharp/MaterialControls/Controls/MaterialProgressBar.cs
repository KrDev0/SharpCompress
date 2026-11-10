using System.ComponentModel;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    /// <summary>
    /// Material design-like progress bar
    /// </summary>
    public class MaterialProgressBar : ProgressBar, IMaterialControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialProgressBar"/> class.
        /// </summary>
        public MaterialProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        [Browsable(true)]
        public new int Value
        {
            get { return base.Value; }
            set { base.Value = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        [Browsable(false)]
        public int Depth { get; set; }

        /// <summary>
        /// Gets the skin manager.
        /// </summary>
        /// <value>
        /// The skin manager.
        /// </value>
        [Browsable(false)]
        public MaterialSkinManager SkinManager => MaterialSkinManager.Instance;

        /// <summary>
        /// Gets or sets the state of the mouse.
        /// </summary>
        /// <value>
        /// The state of the mouse.
        /// </value>
        [Browsable(false)]
        public MouseState MouseState { get; set; }

        /// <summary>
        /// Performs the work of setting the specified bounds of this control.
        /// </summary>
        /// <param name="x">The new <see cref="P:System.Windows.Forms.Control.Left" /> property value of the control.</param>
        /// <param name="y">The new <see cref="P:System.Windows.Forms.Control.Top" /> property value of the control.</param>
        /// <param name="width">The new <see cref="P:System.Windows.Forms.Control.Width" /> property value of the control.</param>
        /// <param name="height">The new <see cref="P:System.Windows.Forms.Control.Height" /> property value of the control.</param>
        /// <param name="specified">A bitwise combination of the <see cref="T:System.Windows.Forms.BoundsSpecified" /> values.</param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, 5, specified);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Maximum <= Minimum || Width <= 0 || Height <= 0) return;
            int doneProgress = (int)(ClientRectangle.Width * ((double)(Value - Minimum) / (Maximum - Minimum)));
            using (var background = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(235, 238, 242)))
                e.Graphics.FillRectangle(background, ClientRectangle);
            using (var progress = new System.Drawing.SolidBrush(SkinManager.ColorScheme.AccentColor))
                e.Graphics.FillRectangle(progress, 0, 0, doneProgress, ClientRectangle.Height);
        }
    }
}

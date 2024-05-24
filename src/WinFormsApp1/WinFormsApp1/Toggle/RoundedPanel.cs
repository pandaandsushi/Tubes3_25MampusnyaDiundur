using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class RoundedPanel : Panel
    {
        // Radius for rounded corners
        public int CornerRadius { get; set; } = 30;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a graphics path to define the shape of the panel
            GraphicsPath path = new GraphicsPath();
            int width = Width;
            int height = Height;
            int radius = CornerRadius;
            path.StartFigure();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, width - radius, 0);
            path.AddArc(width - 2 * radius, 0, 2 * radius, 2 * radius, 270, 90);
            path.AddLine(width, radius, width, height - radius);
            path.AddArc(width - 2 * radius, height - 2 * radius, 2 * radius, 2 * radius, 0, 90);
            path.AddLine(width - radius, height, radius, height);
            path.AddArc(0, height - 2 * radius, 2 * radius, 2 * radius, 90, 90);
            path.CloseFigure();

            // Set the panel's region to the rounded path
            this.Region = new Region(path);

            // Optionally, you can fill the panel with a background color
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Toggle
{
    public class Search : Button
    {
        private String ButtonText;
        public Search()
        {
            this.MinimumSize = new Size(65, 22);
            this.ButtonText = "Search";
        }

        public void setButtonText(String text)
        {
            this.ButtonText = text;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            SizeF textSize = pevent.Graphics.MeasureString(this.ButtonText, Font);
            float x = (this.Width - textSize.Width) / 2;
            float y = (this.Height - textSize.Height) / 2;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            pevent.Graphics.FillPath(Brushes.Gold, path);
            pevent.Graphics.DrawString(this.ButtonText, this.Font, Brushes.Black, x, y);
        }
    }
}

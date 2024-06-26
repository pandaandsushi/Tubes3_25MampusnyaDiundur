﻿using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1.Toggle
{
    public class ButtonOval : Button
    {
        private string buttonText;
        public ButtonOval()
        {
            this.MinimumSize = new System.Drawing.Size(65, 22);
            this.buttonText = "Select Image";
        }

        public void setButtonText(string text)
        {
            this.buttonText = text;
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
            SizeF textSize = pevent.Graphics.MeasureString(this.buttonText, Font);
            float x = (this.Width - textSize.Width) / 2;
            float y = (this.Height - textSize.Height) / 2;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            pevent.Graphics.FillPath(Brushes.Gold, path);
            pevent.Graphics.DrawString(this.buttonText, this.Font, Brushes.Black, x, y);
        }
    }
}

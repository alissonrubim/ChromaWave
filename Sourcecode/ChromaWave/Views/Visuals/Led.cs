using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromaWave.Views
{
    public class Led: Panel
    {
        public delegate Color PixelGetColorHandler();
        public PixelGetColorHandler OnGetColor;

        public Led() : base()
        {
            this.DoubleBuffered = true;
            this.Paint += Pixel_Paint;
            this.BackColor = Color.Transparent;
        }

        private void Pixel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Color? color = OnGetColor?.Invoke();
            if (color.HasValue)
            {
                Graphics g = e.Graphics;
                float centerX = this.Size.Width / 2;
                float centerY = this.Height / 2;
                float radius = 3;
                Brush brush = new SolidBrush(color.Value);
                Pen pen = new Pen(brush);
                g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
                g.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
            }
        }
        public new virtual void Update()
        {
            Invalidate();
        }
    }
}

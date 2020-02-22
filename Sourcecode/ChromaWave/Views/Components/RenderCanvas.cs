using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromaWave
{
    public partial class RenderCanvas : UserControl
    {
        private Bitmap renderedBitmap;

        public RenderCanvas()
        {
            InitializeComponent();
        }

        public void SetRenderedBitmapForPixelCalculation(Bitmap renderedBitmap)
        {
            this.renderedBitmap = renderedBitmap;
        }

        public Color GetColorAtPosition(Point position)
        {
            if (renderedBitmap != null)
            {
                int x = position.X < 0 ? 0 : position.X;
                x = x > this.Width ? this.Width - 1 : x;
                int y = position.Y < 0 ? 0 : position.Y;
                y = y > this.Height ? this.Height - 1 : y;
                return renderedBitmap.GetPixel(x, y);
            }
            return Color.Black;
        }
    }
}

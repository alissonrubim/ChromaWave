using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ChromaWave.Helpers
{
    public partial class ChromaVisualizer : UserControl
    {
        public ChromaVisualizer()
        {
            InitializeComponent();
        }

        private void ChromaVisualizer_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle drawRectangle = new Rectangle(new Point(0, 0), this.ClientSize);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(drawRectangle, Color.White, Color.Black, 0.0f);
            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Positions = new float[]
            {
                0,
                0.1f,
                0.2f,
                0.3f,
                0.4f,
                0.5f,
                0.6f,
                0.7f,
                0.8f,
                0.9f,
                1
            };
            colorBlend.Colors = new Color[colorBlend.Positions.Length];
            float nextColor = 0.27f;
            float colorOffset = 1f / colorBlend.Positions.Length;
            for (int i = 0; i < colorBlend.Positions.Length; i++)
            {
                colorBlend.Colors[i] = ColorHelper.HSLConvert(nextColor, 1, 0.5);
                nextColor += colorOffset;
                if (nextColor > 1)
                    nextColor = 0;
            }

            gradientBrush.InterpolationColors = colorBlend;
            graphics.FillRectangle(gradientBrush, drawRectangle);
        }
    }
}

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
    public enum ChromaVisualizerDirection { Forward, Backward }
    public enum ChromaVisualizerVelocity { SuperFast, Fast, Medium, Slow, SuperSlow };

    public partial class ChromaVisualizer : UserControl
    {
        private float pStep = 0.01f;
        private float pOffset = 0f;
        private ChromaVisualizerDirection pDirection = ChromaVisualizerDirection.Forward;
        private ChromaVisualizerVelocity pVelocity = ChromaVisualizerVelocity.Slow;

        #region Properties
        public float Offset
        {
            get
            {
                return this.pOffset;
            }
            set
            {
                this.pOffset = value;
            }
        }
        #endregion

        public ChromaVisualizer()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void ChromaVisualizer_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle drawRectangle = new Rectangle(new Point(0, 0), this.ClientSize);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(drawRectangle, Color.White, Color.Black, 0.0f);
            ColorBlend colorBlend = new ColorBlend();

            int numberOfColors = 128;
            List<float> positions = new List<float>();
            for (var i = 0; i < numberOfColors-1; i++)
                positions.Add(Convert.ToSingle(1f / (numberOfColors - 1)) * i);
            positions.Add(1f);
            colorBlend.Positions = positions.ToArray();

            colorBlend.Colors = new Color[colorBlend.Positions.Length];
            float startOffset = pOffset;
            float colorOffset = 1f / colorBlend.Positions.Length;
            for (int i = 0; i < colorBlend.Positions.Length; i++)
            {
                if (startOffset > 1)
                    startOffset = 0;
                colorBlend.Colors[i] = ColorHelper.ColorFromHSL(startOffset, 1, 0.5);
                startOffset += colorOffset;
            }
        
            if (pDirection == ChromaVisualizerDirection.Forward)
            {
                pOffset -= pStep;
                if (pOffset < 0)
                    pOffset = 1;
            }
            else
            {
                pOffset += pStep;
                if (pOffset > 1)
                    pOffset = 0;
            }

            gradientBrush.InterpolationColors = colorBlend;
            graphics.FillRectangle(gradientBrush, drawRectangle);
        }

        public new virtual void Update()
        {
            Invalidate();
        }
    }
}

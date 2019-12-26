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

namespace ChromaWave.Views
{
    public enum ChromaVisualizerDirection { Forward, Backward }
    public enum ChromaVisualizerVelocity { SuperFast, Fast, Medium, Slow, SuperSlow };

    public partial class ChromaVisualizer : UserControl
    {
        private DateTime pLastPaintDateTime;
        private float pStep = 0.01f;
        private int pSaturation = 50;
        private float pOffset = 0f;
        private ChromaVisualizerDirection pDirection = ChromaVisualizerDirection.Forward;
        private ChromaVisualizerVelocity pVelocity = ChromaVisualizerVelocity.Slow;
        private int pBrightness = 100;
        private ChromaVisualizer pSyncronizeTo;

        #region Properties
        /// <summary>
        /// When set, all the parameters as Velocity, Direction and OffSet will be copied from the parent ChromaVisualizer
        /// </summary>
        public ChromaVisualizer SyncronizeTo
        {
            get
            {
                return pSyncronizeTo;
            }
            set
            {
                this.pSyncronizeTo = value;
            }
        }

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

        public ChromaVisualizerDirection Direction
        {
            get
            {
                return this.pDirection;
            }
            set
            {
                this.pDirection = value;
            }
        }

        public ChromaVisualizerVelocity Velocity
        {
            get
            {
                return this.pVelocity;
            }
            set
            {
                this.pVelocity = value;
            }
        }

        public int Brightness
        {
            get
            {
                return this.pBrightness;
            }
            set
            {
                this.pBrightness = value;
            }
        }

        public int Saturation
        {
            get
            {
                return this.pSaturation;
            }
            set
            {
                this.pSaturation = value;
            }
        }
        #endregion

        public ChromaVisualizer()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.pLastPaintDateTime = DateTime.Now;
        }

        private float GetVelocityMultiplier()
        {
            switch (this.pVelocity)
            {
                case ChromaVisualizerVelocity.SuperSlow:
                    return 1/10f;
                case ChromaVisualizerVelocity.Slow:
                    return 1/5f;
                case ChromaVisualizerVelocity.Medium:
                    return 1/2f;
                case ChromaVisualizerVelocity.Fast:
                    return 1f;
                case ChromaVisualizerVelocity.SuperFast:
                    return 1/0.3f;
                default:
                    return 1f;
            }
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

            if (pSyncronizeTo != null) //Copy the OffSet of my parent
                pOffset = pSyncronizeTo.Offset;

            float startOffset = pOffset;
            float colorOffset = 1f / colorBlend.Positions.Length;
            for (int i = 0; i < colorBlend.Positions.Length; i++)
            {
                if (startOffset > 1)
                    startOffset = 0;
                colorBlend.Colors[i] = ColorHelper.ColorFromHSL(startOffset, pSaturation / 100f, pBrightness / 100f);
                startOffset += colorOffset;
            }

            if (pSyncronizeTo == null) //Calculate my offSet only if I don't have a parent
            {
                float velocity = GetVelocityMultiplier();
                TimeSpan timeDiff = DateTime.Now - pLastPaintDateTime;
                if (pDirection == ChromaVisualizerDirection.Forward)
                {
                    pOffset -= pStep * velocity * (timeDiff.Milliseconds / 10);
                    if (pOffset < 0)
                        pOffset = 1;
                }
                else
                {
                    pOffset += pStep * velocity * (timeDiff.Milliseconds / 10);
                    if (pOffset > 1)
                        pOffset = 0;
                }
            }
            
            gradientBrush.InterpolationColors = colorBlend;
            graphics.FillRectangle(gradientBrush, drawRectangle);

            pLastPaintDateTime = DateTime.Now;
        }

        public new virtual void Update()
        {
            Invalidate();
        }
    }
}

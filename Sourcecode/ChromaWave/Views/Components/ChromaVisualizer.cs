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
using System.Drawing.Imaging;

namespace ChromaWave.Views
{
    public enum SpectrumVisualizerDirection { Forward, Backward }
    public enum SpectrumVisualizerVelocity { Off, SuperFast, Fast, Medium, Slow, SuperSlow };

    public partial class SpectrumVisualizer : UserControl
    {
        private DateTime pLastPaintDateTime;
        private float pStep = 0.01f;
        private int pSaturation = 50;
        private float pOffset = 0f;
        private SpectrumVisualizerDirection pDirection = SpectrumVisualizerDirection.Forward;
        private SpectrumVisualizerVelocity pVelocity = SpectrumVisualizerVelocity.Slow;
        private int pBrightness = 100;
        private SpectrumVisualizer pSyncronizeTo;
        private float pOpacity = 1.0f;
        private Bitmap pCacheBitmap;

        #region Properties
        /// <summary>
        /// When set, all the parameters as Velocity, Direction and OffSet will be copied from the parent SpectrumVisualizer
        /// </summary>
        public SpectrumVisualizer SyncronizeTo
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

        public float Opactity
        {
            get
            {
                return this.pOpacity;
            }
            set
            {
                this.pOpacity = value;
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

        public SpectrumVisualizerDirection Direction
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

        public SpectrumVisualizerVelocity Velocity
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

        public SpectrumVisualizer()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.pLastPaintDateTime = DateTime.Now;
        }

        public Bitmap GetRenderedBitmap()
        {
            return this.pCacheBitmap;
        }

        public new virtual void Update()
        {
            Invalidate();
        }

        #region Private
        private float getVelocityMultiplier()
        {
            switch (this.pVelocity)
            {
                case SpectrumVisualizerVelocity.Off:
                    return 0;
                case SpectrumVisualizerVelocity.SuperSlow:
                    return 1/10f;
                case SpectrumVisualizerVelocity.Slow:
                    return 1/5f;
                case SpectrumVisualizerVelocity.Medium:
                    return 1/2f;
                case SpectrumVisualizerVelocity.Fast:
                    return 1f;
                case SpectrumVisualizerVelocity.SuperFast:
                    return 1/0.3f;
                default:
                    return 1f;
            }
        }

        private void generateScpectrum()
        {

        }

        private void ChromaVisualizer_Paint(object sender, PaintEventArgs e)
        {
            //Create a bitmap and a graphics to work on
            Bitmap canvasBitmap = new Bitmap(this.Width, this.Height);
            Graphics canvasGraphics = Graphics.FromImage(canvasBitmap);

            Rectangle drawRectangle = new Rectangle(new Point(0, 0), this.ClientSize);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(drawRectangle, Parent.BackColor, Parent.BackColor, 0.0f);

            //Create two colorBlend, one for a real HUE color, other with a opacity applied
            Dictionary<string, ColorBlend> colorBlends = new Dictionary<string, ColorBlend>();
            colorBlends.Add("NormalBlends", new ColorBlend());
            colorBlends.Add("OpacityBlends", new ColorBlend());

            //Calculate the position of each color, it's a number between 0 and 1.
            int numberOfColors = 128;
            List<float> positions = new List<float>();
            for (var i = 0; i < numberOfColors-1; i++)
                positions.Add(Convert.ToSingle(1f / (numberOfColors - 1)) * i);
            positions.Add(1f);
            colorBlends["NormalBlends"].Positions = positions.ToArray();
            colorBlends["OpacityBlends"].Positions = positions.ToArray();

            //Copy the OffSet of my parent   
            if (pSyncronizeTo != null) 
                pOffset = pSyncronizeTo.Offset;

            //Calculate the colors between each position
            colorBlends["NormalBlends"].Colors = new Color[colorBlends["NormalBlends"].Positions.Length];
            colorBlends["OpacityBlends"].Colors = new Color[colorBlends["OpacityBlends"].Positions.Length];
            float startOffset = pOffset;
            float colorOffset = 1f / colorBlends["NormalBlends"].Positions.Length;
            for (int i = 0; i < colorBlends["NormalBlends"].Positions.Length; i++)
            {
                if (startOffset > 1)
                    startOffset = 0;
                //Generate a color from HUE, using a offset
                Color currentColor = ColorHelper.ColorFromHSL(startOffset, pSaturation / 100f, pBrightness / 100f);
                colorBlends["NormalBlends"].Colors[i] = currentColor; //without opactity applyed
                colorBlends["OpacityBlends"].Colors[i] = ColorHelper.BlendColors(currentColor, Parent.BackColor, pOpacity); //with opacity applyed
                startOffset += colorOffset;
            }

            //Calculate my offSet only if I don't have a parent
            if (pSyncronizeTo == null) 
            {
                float velocity = getVelocityMultiplier();
                TimeSpan timeDiff = DateTime.Now - pLastPaintDateTime;
                if (pDirection == SpectrumVisualizerDirection.Forward)
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
            
            //Sign the colorBlend to the brush
            gradientBrush.InterpolationColors = colorBlends["NormalBlends"];
            canvasGraphics.FillRectangle(gradientBrush, drawRectangle);

            //Then cache the canvas
            pCacheBitmap = canvasBitmap;

            Graphics panelGraphics = e.Graphics;
            if (pOpacity < 100)
            {
                //Draw again but using opacity
                Bitmap newCanvasBitmap = new Bitmap(canvasBitmap);
                Graphics newCanvasGraphics = Graphics.FromImage(newCanvasBitmap);

                gradientBrush.InterpolationColors = colorBlends["OpacityBlends"];
                newCanvasGraphics.FillRectangle(gradientBrush, drawRectangle);
                panelGraphics.DrawImage(newCanvasBitmap, new Point(0, 0));
            }
            else
            {
                panelGraphics.DrawImage(canvasBitmap, new Point(0, 0));
            }

            pLastPaintDateTime = DateTime.Now;
        }
        #endregion
    }
}
namespace ChromaWave.Views.Forms.Visuals
{
    partial class TabDevices
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.chromaMusicVisualizer = new ChromaWave.Views.ChromaVisualizer();
            this.SuspendLayout();
            // 
            // chromaMusicVisualizer
            // 
            this.chromaMusicVisualizer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chromaMusicVisualizer.BackColor = System.Drawing.Color.White;
            this.chromaMusicVisualizer.Brightness = 100;
            this.chromaMusicVisualizer.Direction = ChromaWave.Views.ChromaVisualizerDirection.Forward;
            this.chromaMusicVisualizer.Location = new System.Drawing.Point(3, 3);
            this.chromaMusicVisualizer.Name = "chromaMusicVisualizer";
            this.chromaMusicVisualizer.Offset = 0.982F;
            this.chromaMusicVisualizer.Opactity = 0.1F;
            this.chromaMusicVisualizer.Saturation = 50;
            this.chromaMusicVisualizer.Size = new System.Drawing.Size(677, 497);
            this.chromaMusicVisualizer.SyncronizeTo = null;
            this.chromaMusicVisualizer.TabIndex = 33;
            this.chromaMusicVisualizer.Velocity = ChromaWave.Views.ChromaVisualizerVelocity.Slow;
            // 
            // TabDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.chromaMusicVisualizer);
            this.Name = "TabDevices";
            this.Size = new System.Drawing.Size(683, 503);
            this.ResumeLayout(false);

        }

        #endregion
        private ChromaVisualizer chromaMusicVisualizer;
    }
}

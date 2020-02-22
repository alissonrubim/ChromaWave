namespace ChromaWave
{
    partial class FormMain
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelRenderTab = new System.Windows.Forms.Panel();
            this.tabEffects = new ChromaWave.Views.Forms.Main.Visuals.TabEffects();
            this.tabDevices = new ChromaWave.Views.Forms.Visuals.TabDevices();
            this.timerUIUpdate = new System.Windows.Forms.Timer(this.components);
            this.buttonSave = new DarkUI.Controls.DarkButton();
            this.panelMainHeader = new System.Windows.Forms.Panel();
            this.buttonMenuEffects = new DarkUI.Controls.DarkButton();
            this.buttonMenuDevices = new DarkUI.Controls.DarkButton();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelRenderTab.SuspendLayout();
            this.panelMainHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRenderTab
            // 
            this.panelRenderTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRenderTab.Controls.Add(this.tabEffects);
            this.panelRenderTab.Controls.Add(this.tabDevices);
            this.panelRenderTab.Location = new System.Drawing.Point(-1, 43);
            this.panelRenderTab.Name = "panelRenderTab";
            this.panelRenderTab.Size = new System.Drawing.Size(974, 741);
            this.panelRenderTab.TabIndex = 29;
            // 
            // tabEffects
            // 
            this.tabEffects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEffects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabEffects.Location = new System.Drawing.Point(4, 3);
            this.tabEffects.Name = "tabEffects";
            this.tabEffects.Size = new System.Drawing.Size(966, 735);
            this.tabEffects.TabIndex = 36;
            // 
            // tabDevices
            // 
            this.tabDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabDevices.Location = new System.Drawing.Point(4, 3);
            this.tabDevices.Name = "tabDevices";
            this.tabDevices.Size = new System.Drawing.Size(967, 735);
            this.tabDevices.TabIndex = 35;
            // 
            // timerUIUpdate
            // 
            this.timerUIUpdate.Enabled = true;
            this.timerUIUpdate.Tick += new System.EventHandler(this.TimerUIUpdate_Tick);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSave.Location = new System.Drawing.Point(587, 7);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Padding = new System.Windows.Forms.Padding(5);
            this.buttonSave.Size = new System.Drawing.Size(85, 36);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "Save Settings";
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // panelMainHeader
            // 
            this.panelMainHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMainHeader.BackColor = System.Drawing.Color.DimGray;
            this.panelMainHeader.Controls.Add(this.buttonMenuEffects);
            this.panelMainHeader.Controls.Add(this.buttonSave);
            this.panelMainHeader.Controls.Add(this.buttonMenuDevices);
            this.panelMainHeader.Controls.Add(this.pictureBoxLogo);
            this.panelMainHeader.Location = new System.Drawing.Point(-4, -3);
            this.panelMainHeader.Name = "panelMainHeader";
            this.panelMainHeader.Size = new System.Drawing.Size(980, 47);
            this.panelMainHeader.TabIndex = 28;
            // 
            // buttonMenuEffects
            // 
            this.buttonMenuEffects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMenuEffects.Location = new System.Drawing.Point(149, 7);
            this.buttonMenuEffects.Name = "buttonMenuEffects";
            this.buttonMenuEffects.Padding = new System.Windows.Forms.Padding(5);
            this.buttonMenuEffects.Size = new System.Drawing.Size(75, 36);
            this.buttonMenuEffects.TabIndex = 6;
            this.buttonMenuEffects.Text = "Effects";
            this.buttonMenuEffects.Click += new System.EventHandler(this.buttonMenuEffects_Click);
            // 
            // buttonMenuDevices
            // 
            this.buttonMenuDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMenuDevices.Location = new System.Drawing.Point(68, 7);
            this.buttonMenuDevices.Name = "buttonMenuDevices";
            this.buttonMenuDevices.Padding = new System.Windows.Forms.Padding(5);
            this.buttonMenuDevices.Size = new System.Drawing.Size(75, 36);
            this.buttonMenuDevices.TabIndex = 5;
            this.buttonMenuDevices.Text = "Devices";
            this.buttonMenuDevices.Click += new System.EventHandler(this.buttonMenuDevices_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::ChromaWave.Resource.Icon;
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 7);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(39, 36);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(973, 783);
            this.Controls.Add(this.panelRenderTab);
            this.Controls.Add(this.panelMainHeader);
            this.Name = "FormMain";
            this.Text = "ChromaWave";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.panelRenderTab.ResumeLayout(false);
            this.panelMainHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerUIUpdate;
        private DarkUI.Controls.DarkButton buttonSave;
        private System.Windows.Forms.Panel panelMainHeader;
        private System.Windows.Forms.Panel panelRenderTab;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private DarkUI.Controls.DarkButton buttonMenuEffects;
        private DarkUI.Controls.DarkButton buttonMenuDevices;
        private Views.Forms.Visuals.TabDevices tabDevices;
        private Views.Forms.Main.Visuals.TabEffects tabEffects;
    }
}


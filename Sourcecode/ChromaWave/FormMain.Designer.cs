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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.comboBoxAudioDevices = new DarkUI.Controls.DarkComboBox();
            this.buttonReload = new DarkUI.Controls.DarkButton();
            this.labelSource = new DarkUI.Controls.DarkLabel();
            this.groupBoxVolume = new DarkUI.Controls.DarkGroupBox();
            this.trackBarAmplitudeRight = new System.Windows.Forms.TrackBar();
            this.labelAmplitude = new DarkUI.Controls.DarkLabel();
            this.trackBarAmplitudeLeft = new System.Windows.Forms.TrackBar();
            this.labelChannelRight = new DarkUI.Controls.DarkLabel();
            this.labelChannelLeft = new DarkUI.Controls.DarkLabel();
            this.darkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.labelFrequency500 = new DarkUI.Controls.DarkLabel();
            this.labelFrequency1k = new DarkUI.Controls.DarkLabel();
            this.checkBoxSync = new DarkUI.Controls.DarkCheckBox();
            this.volumeMeterFrequency500 = new ChromaWave.Helpers.VolumeMeter();
            this.volumeMeterFrequency1K = new ChromaWave.Helpers.VolumeMeter();
            this.volumeMeterRight = new ChromaWave.Helpers.VolumeMeter();
            this.volumeMeterLeft = new ChromaWave.Helpers.VolumeMeter();
            this.groupBoxVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmplitudeRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmplitudeLeft)).BeginInit();
            this.darkGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxAudioDevices
            // 
            this.comboBoxAudioDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.comboBoxAudioDevices.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.comboBoxAudioDevices.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.comboBoxAudioDevices.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.comboBoxAudioDevices.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("comboBoxAudioDevices.ButtonIcon")));
            this.comboBoxAudioDevices.DrawDropdownHoverOutline = false;
            this.comboBoxAudioDevices.DrawFocusRectangle = false;
            this.comboBoxAudioDevices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxAudioDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxAudioDevices.ForeColor = System.Drawing.Color.Gainsboro;
            this.comboBoxAudioDevices.FormattingEnabled = true;
            this.comboBoxAudioDevices.Location = new System.Drawing.Point(96, 19);
            this.comboBoxAudioDevices.Name = "comboBoxAudioDevices";
            this.comboBoxAudioDevices.Size = new System.Drawing.Size(462, 21);
            this.comboBoxAudioDevices.TabIndex = 16;
            this.comboBoxAudioDevices.Text = null;
            this.comboBoxAudioDevices.TextPadding = new System.Windows.Forms.Padding(2);
            this.comboBoxAudioDevices.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAudioDevices_SelectedIndexChanged);
            // 
            // buttonReload
            // 
            this.buttonReload.Location = new System.Drawing.Point(569, 19);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Padding = new System.Windows.Forms.Padding(5);
            this.buttonReload.Size = new System.Drawing.Size(75, 21);
            this.buttonReload.TabIndex = 17;
            this.buttonReload.Text = "Reload";
            this.buttonReload.Click += new System.EventHandler(this.ButtonReload_Click);
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelSource.Location = new System.Drawing.Point(12, 22);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(78, 13);
            this.labelSource.TabIndex = 18;
            this.labelSource.Text = "Sound Source:";
            // 
            // groupBoxVolume
            // 
            this.groupBoxVolume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.groupBoxVolume.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.groupBoxVolume.Controls.Add(this.checkBoxSync);
            this.groupBoxVolume.Controls.Add(this.volumeMeterRight);
            this.groupBoxVolume.Controls.Add(this.trackBarAmplitudeRight);
            this.groupBoxVolume.Controls.Add(this.labelAmplitude);
            this.groupBoxVolume.Controls.Add(this.trackBarAmplitudeLeft);
            this.groupBoxVolume.Controls.Add(this.labelChannelRight);
            this.groupBoxVolume.Controls.Add(this.labelChannelLeft);
            this.groupBoxVolume.Controls.Add(this.volumeMeterLeft);
            this.groupBoxVolume.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBoxVolume.Location = new System.Drawing.Point(15, 60);
            this.groupBoxVolume.Name = "groupBoxVolume";
            this.groupBoxVolume.Size = new System.Drawing.Size(166, 345);
            this.groupBoxVolume.TabIndex = 19;
            this.groupBoxVolume.TabStop = false;
            this.groupBoxVolume.Text = "Volume";
            // 
            // trackBarAmplitudeRight
            // 
            this.trackBarAmplitudeRight.LargeChange = 10;
            this.trackBarAmplitudeRight.Location = new System.Drawing.Point(81, 45);
            this.trackBarAmplitudeRight.Maximum = 100;
            this.trackBarAmplitudeRight.Minimum = -100;
            this.trackBarAmplitudeRight.Name = "trackBarAmplitudeRight";
            this.trackBarAmplitudeRight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAmplitudeRight.Size = new System.Drawing.Size(45, 256);
            this.trackBarAmplitudeRight.SmallChange = 10;
            this.trackBarAmplitudeRight.TabIndex = 22;
            this.trackBarAmplitudeRight.TickFrequency = 10;
            this.trackBarAmplitudeRight.Scroll += new System.EventHandler(this.TrackBarAmplitudeRight_Scroll);
            // 
            // labelAmplitude
            // 
            this.labelAmplitude.AutoSize = true;
            this.labelAmplitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmplitude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelAmplitude.Location = new System.Drawing.Point(60, 33);
            this.labelAmplitude.Name = "labelAmplitude";
            this.labelAmplitude.Size = new System.Drawing.Size(47, 12);
            this.labelAmplitude.TabIndex = 21;
            this.labelAmplitude.Text = "Amplitude";
            // 
            // trackBarAmplitudeLeft
            // 
            this.trackBarAmplitudeLeft.LargeChange = 10;
            this.trackBarAmplitudeLeft.Location = new System.Drawing.Point(53, 45);
            this.trackBarAmplitudeLeft.Maximum = 100;
            this.trackBarAmplitudeLeft.Minimum = -100;
            this.trackBarAmplitudeLeft.Name = "trackBarAmplitudeLeft";
            this.trackBarAmplitudeLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAmplitudeLeft.Size = new System.Drawing.Size(45, 256);
            this.trackBarAmplitudeLeft.SmallChange = 10;
            this.trackBarAmplitudeLeft.TabIndex = 20;
            this.trackBarAmplitudeLeft.TickFrequency = 10;
            this.trackBarAmplitudeLeft.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarAmplitudeLeft.Scroll += new System.EventHandler(this.TrackBarAmplitudeLeft_Scroll);
            // 
            // labelChannelRight
            // 
            this.labelChannelRight.AutoSize = true;
            this.labelChannelRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelChannelRight.Location = new System.Drawing.Point(120, 311);
            this.labelChannelRight.Name = "labelChannelRight";
            this.labelChannelRight.Size = new System.Drawing.Size(32, 13);
            this.labelChannelRight.TabIndex = 3;
            this.labelChannelRight.Text = "Right";
            // 
            // labelChannelLeft
            // 
            this.labelChannelLeft.AutoSize = true;
            this.labelChannelLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelChannelLeft.Location = new System.Drawing.Point(18, 311);
            this.labelChannelLeft.Name = "labelChannelLeft";
            this.labelChannelLeft.Size = new System.Drawing.Size(25, 13);
            this.labelChannelLeft.TabIndex = 1;
            this.labelChannelLeft.Text = "Left";
            // 
            // darkGroupBox1
            // 
            this.darkGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.darkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.darkGroupBox1.Controls.Add(this.volumeMeterFrequency500);
            this.darkGroupBox1.Controls.Add(this.labelFrequency500);
            this.darkGroupBox1.Controls.Add(this.labelFrequency1k);
            this.darkGroupBox1.Controls.Add(this.volumeMeterFrequency1K);
            this.darkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.darkGroupBox1.Location = new System.Drawing.Point(187, 60);
            this.darkGroupBox1.Name = "darkGroupBox1";
            this.darkGroupBox1.Size = new System.Drawing.Size(457, 345);
            this.darkGroupBox1.TabIndex = 23;
            this.darkGroupBox1.TabStop = false;
            this.darkGroupBox1.Text = "Frequencies";
            // 
            // labelFrequency500
            // 
            this.labelFrequency500.AutoSize = true;
            this.labelFrequency500.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrequency500.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelFrequency500.Location = new System.Drawing.Point(53, 311);
            this.labelFrequency500.Name = "labelFrequency500";
            this.labelFrequency500.Size = new System.Drawing.Size(32, 12);
            this.labelFrequency500.TabIndex = 3;
            this.labelFrequency500.Text = "500Hz";
            // 
            // labelFrequency1k
            // 
            this.labelFrequency1k.AutoSize = true;
            this.labelFrequency1k.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrequency1k.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelFrequency1k.Location = new System.Drawing.Point(17, 311);
            this.labelFrequency1k.Name = "labelFrequency1k";
            this.labelFrequency1k.Size = new System.Drawing.Size(28, 12);
            this.labelFrequency1k.TabIndex = 1;
            this.labelFrequency1k.Text = "1KHz";
            // 
            // checkBoxSync
            // 
            this.checkBoxSync.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSync.Location = new System.Drawing.Point(62, 298);
            this.checkBoxSync.Name = "checkBoxSync";
            this.checkBoxSync.Size = new System.Drawing.Size(47, 25);
            this.checkBoxSync.TabIndex = 23;
            this.checkBoxSync.Text = "Sync";
            // 
            // volumeMeterFrequency500
            // 
            this.volumeMeterFrequency500.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeterFrequency500.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeterFrequency500.BarColor = System.Drawing.Color.White;
            this.volumeMeterFrequency500.BorderColor = System.Drawing.Color.White;
            this.volumeMeterFrequency500.BorderWidth = 1;
            this.volumeMeterFrequency500.Location = new System.Drawing.Point(56, 32);
            this.volumeMeterFrequency500.Name = "volumeMeterFrequency500";
            this.volumeMeterFrequency500.Size = new System.Drawing.Size(24, 276);
            this.volumeMeterFrequency500.TabIndex = 2;
            this.volumeMeterFrequency500.Value = 0;
            // 
            // volumeMeterFrequency1K
            // 
            this.volumeMeterFrequency1K.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeterFrequency1K.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeterFrequency1K.BarColor = System.Drawing.Color.White;
            this.volumeMeterFrequency1K.BorderColor = System.Drawing.Color.White;
            this.volumeMeterFrequency1K.BorderWidth = 1;
            this.volumeMeterFrequency1K.Location = new System.Drawing.Point(19, 32);
            this.volumeMeterFrequency1K.Name = "volumeMeterFrequency1K";
            this.volumeMeterFrequency1K.Size = new System.Drawing.Size(24, 276);
            this.volumeMeterFrequency1K.TabIndex = 0;
            this.volumeMeterFrequency1K.Value = 0;
            // 
            // volumeMeterRight
            // 
            this.volumeMeterRight.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeterRight.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeterRight.BarColor = System.Drawing.Color.White;
            this.volumeMeterRight.BorderColor = System.Drawing.Color.White;
            this.volumeMeterRight.BorderWidth = 1;
            this.volumeMeterRight.Location = new System.Drawing.Point(121, 32);
            this.volumeMeterRight.Name = "volumeMeterRight";
            this.volumeMeterRight.Size = new System.Drawing.Size(24, 276);
            this.volumeMeterRight.TabIndex = 1;
            this.volumeMeterRight.Value = 50;
            // 
            // volumeMeterLeft
            // 
            this.volumeMeterLeft.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeterLeft.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeterLeft.BarColor = System.Drawing.Color.White;
            this.volumeMeterLeft.BorderColor = System.Drawing.Color.White;
            this.volumeMeterLeft.BorderWidth = 1;
            this.volumeMeterLeft.Location = new System.Drawing.Point(19, 32);
            this.volumeMeterLeft.Name = "volumeMeterLeft";
            this.volumeMeterLeft.Size = new System.Drawing.Size(24, 276);
            this.volumeMeterLeft.TabIndex = 0;
            this.volumeMeterLeft.Value = 50;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(661, 425);
            this.Controls.Add(this.darkGroupBox1);
            this.Controls.Add(this.groupBoxVolume);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.comboBoxAudioDevices);
            this.Name = "FormMain";
            this.Text = "ChromaWave";
            this.groupBoxVolume.ResumeLayout(false);
            this.groupBoxVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmplitudeRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmplitudeLeft)).EndInit();
            this.darkGroupBox1.ResumeLayout(false);
            this.darkGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkComboBox comboBoxAudioDevices;
        private DarkUI.Controls.DarkButton buttonReload;
        private DarkUI.Controls.DarkLabel labelSource;
        private DarkUI.Controls.DarkGroupBox groupBoxVolume;
        private Helpers.VolumeMeter volumeMeterLeft;
        private System.Windows.Forms.TrackBar trackBarAmplitudeLeft;
        private DarkUI.Controls.DarkLabel labelChannelRight;
        private Helpers.VolumeMeter volumeMeterRight;
        private DarkUI.Controls.DarkLabel labelChannelLeft;
        private DarkUI.Controls.DarkLabel labelAmplitude;
        private System.Windows.Forms.TrackBar trackBarAmplitudeRight;
        private DarkUI.Controls.DarkGroupBox darkGroupBox1;
        private Helpers.VolumeMeter volumeMeterFrequency500;
        private DarkUI.Controls.DarkLabel labelFrequency500;
        private DarkUI.Controls.DarkLabel labelFrequency1k;
        private Helpers.VolumeMeter volumeMeterFrequency1K;
        private DarkUI.Controls.DarkCheckBox checkBoxSync;
    }
}


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.comboBoxAudioDevices = new DarkUI.Controls.DarkComboBox();
            this.buttonReload = new DarkUI.Controls.DarkButton();
            this.labelSource = new DarkUI.Controls.DarkLabel();
            this.groupBoxVolume = new DarkUI.Controls.DarkGroupBox();
            this.checkBoxSync = new DarkUI.Controls.DarkCheckBox();
            this.volumeMeterRight = new ChromaWave.Helpers.VolumeMeter();
            this.trackBarAmplitudeRight = new System.Windows.Forms.TrackBar();
            this.labelAmplitude = new DarkUI.Controls.DarkLabel();
            this.trackBarAmplitudeLeft = new System.Windows.Forms.TrackBar();
            this.labelChannelRight = new DarkUI.Controls.DarkLabel();
            this.labelChannelLeft = new DarkUI.Controls.DarkLabel();
            this.volumeMeterLeft = new ChromaWave.Helpers.VolumeMeter();
            this.darkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.volumeMeter8 = new ChromaWave.Helpers.VolumeMeter();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.volumeMeter7 = new ChromaWave.Helpers.VolumeMeter();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.volumeMeter6 = new ChromaWave.Helpers.VolumeMeter();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.labelFrequency2k = new DarkUI.Controls.DarkLabel();
            this.volumeMeter5 = new ChromaWave.Helpers.VolumeMeter();
            this.volumeMeter4 = new ChromaWave.Helpers.VolumeMeter();
            this.volumeMeter3 = new ChromaWave.Helpers.VolumeMeter();
            this.volumeMeter2 = new ChromaWave.Helpers.VolumeMeter();
            this.volumeMeter1 = new ChromaWave.Helpers.VolumeMeter();
            this.volumeMeterFrequency500 = new ChromaWave.Helpers.VolumeMeter();
            this.labelFrequency500 = new DarkUI.Controls.DarkLabel();
            this.labelFrequency1k = new DarkUI.Controls.DarkLabel();
            this.volumeMeterFrequency1K = new ChromaWave.Helpers.VolumeMeter();
            this.timerUIUpdate = new System.Windows.Forms.Timer(this.components);
            this.chromaVisualizer1 = new ChromaWave.Helpers.ChromaVisualizer();
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
            // volumeMeterRight
            // 
            this.volumeMeterRight.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeterRight.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeterRight.BarColor = System.Drawing.Color.White;
            this.volumeMeterRight.BorderColor = System.Drawing.Color.White;
            this.volumeMeterRight.BorderWidth = 1;
            this.volumeMeterRight.Location = new System.Drawing.Point(121, 32);
            this.volumeMeterRight.Name = "volumeMeterRight";
            this.volumeMeterRight.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeterRight.Size = new System.Drawing.Size(24, 276);
            this.volumeMeterRight.TabIndex = 1;
            this.volumeMeterRight.Value = 50;
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
            this.labelChannelRight.Location = new System.Drawing.Point(118, 311);
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
            // volumeMeterLeft
            // 
            this.volumeMeterLeft.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeterLeft.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeterLeft.BarColor = System.Drawing.Color.White;
            this.volumeMeterLeft.BorderColor = System.Drawing.Color.White;
            this.volumeMeterLeft.BorderWidth = 1;
            this.volumeMeterLeft.Location = new System.Drawing.Point(19, 32);
            this.volumeMeterLeft.Name = "volumeMeterLeft";
            this.volumeMeterLeft.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Blocks;
            this.volumeMeterLeft.Size = new System.Drawing.Size(24, 276);
            this.volumeMeterLeft.TabIndex = 0;
            this.volumeMeterLeft.Value = 50;
            // 
            // darkGroupBox1
            // 
            this.darkGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.darkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.darkGroupBox1.Controls.Add(this.darkLabel7);
            this.darkGroupBox1.Controls.Add(this.volumeMeter8);
            this.darkGroupBox1.Controls.Add(this.darkLabel6);
            this.darkGroupBox1.Controls.Add(this.volumeMeter7);
            this.darkGroupBox1.Controls.Add(this.darkLabel5);
            this.darkGroupBox1.Controls.Add(this.volumeMeter6);
            this.darkGroupBox1.Controls.Add(this.darkLabel4);
            this.darkGroupBox1.Controls.Add(this.darkLabel3);
            this.darkGroupBox1.Controls.Add(this.darkLabel2);
            this.darkGroupBox1.Controls.Add(this.darkLabel1);
            this.darkGroupBox1.Controls.Add(this.labelFrequency2k);
            this.darkGroupBox1.Controls.Add(this.volumeMeter5);
            this.darkGroupBox1.Controls.Add(this.volumeMeter4);
            this.darkGroupBox1.Controls.Add(this.volumeMeter3);
            this.darkGroupBox1.Controls.Add(this.volumeMeter2);
            this.darkGroupBox1.Controls.Add(this.volumeMeter1);
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
            // darkLabel7
            // 
            this.darkLabel7.AutoSize = true;
            this.darkLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(412, 311);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(33, 12);
            this.darkLabel7.TabIndex = 19;
            this.darkLabel7.Text = "16KHz";
            // 
            // volumeMeter8
            // 
            this.volumeMeter8.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeter8.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeter8.BarColor = System.Drawing.Color.White;
            this.volumeMeter8.BorderColor = System.Drawing.Color.White;
            this.volumeMeter8.BorderWidth = 1;
            this.volumeMeter8.Location = new System.Drawing.Point(416, 32);
            this.volumeMeter8.Name = "volumeMeter8";
            this.volumeMeter8.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeter8.Size = new System.Drawing.Size(24, 276);
            this.volumeMeter8.TabIndex = 18;
            this.volumeMeter8.Value = 0;
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(371, 311);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(28, 12);
            this.darkLabel6.TabIndex = 17;
            this.darkLabel6.Text = "8KHz";
            // 
            // volumeMeter7
            // 
            this.volumeMeter7.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeter7.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeter7.BarColor = System.Drawing.Color.White;
            this.volumeMeter7.BorderColor = System.Drawing.Color.White;
            this.volumeMeter7.BorderWidth = 1;
            this.volumeMeter7.Location = new System.Drawing.Point(373, 32);
            this.volumeMeter7.Name = "volumeMeter7";
            this.volumeMeter7.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeter7.Size = new System.Drawing.Size(24, 276);
            this.volumeMeter7.TabIndex = 16;
            this.volumeMeter7.Value = 0;
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(329, 311);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(28, 12);
            this.darkLabel5.TabIndex = 15;
            this.darkLabel5.Text = "4KHz";
            // 
            // volumeMeter6
            // 
            this.volumeMeter6.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeter6.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeter6.BarColor = System.Drawing.Color.White;
            this.volumeMeter6.BorderColor = System.Drawing.Color.White;
            this.volumeMeter6.BorderWidth = 1;
            this.volumeMeter6.Location = new System.Drawing.Point(331, 32);
            this.volumeMeter6.Name = "volumeMeter6";
            this.volumeMeter6.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeter6.Size = new System.Drawing.Size(24, 276);
            this.volumeMeter6.TabIndex = 14;
            this.volumeMeter6.Value = 0;
            // 
            // darkLabel4
            // 
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(20, 311);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(27, 12);
            this.darkLabel4.TabIndex = 13;
            this.darkLabel4.Text = "32Hz";
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(59, 311);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(27, 12);
            this.darkLabel3.TabIndex = 12;
            this.darkLabel3.Text = "64Hz";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(100, 311);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(32, 12);
            this.darkLabel2.TabIndex = 11;
            this.darkLabel2.Text = "125Hz";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(146, 311);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(32, 12);
            this.darkLabel1.TabIndex = 10;
            this.darkLabel1.Text = "250Hz";
            // 
            // labelFrequency2k
            // 
            this.labelFrequency2k.AutoSize = true;
            this.labelFrequency2k.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrequency2k.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelFrequency2k.Location = new System.Drawing.Point(285, 311);
            this.labelFrequency2k.Name = "labelFrequency2k";
            this.labelFrequency2k.Size = new System.Drawing.Size(28, 12);
            this.labelFrequency2k.TabIndex = 9;
            this.labelFrequency2k.Text = "2KHz";
            // 
            // volumeMeter5
            // 
            this.volumeMeter5.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeter5.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeter5.BarColor = System.Drawing.Color.White;
            this.volumeMeter5.BorderColor = System.Drawing.Color.White;
            this.volumeMeter5.BorderWidth = 1;
            this.volumeMeter5.Location = new System.Drawing.Point(287, 32);
            this.volumeMeter5.Name = "volumeMeter5";
            this.volumeMeter5.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeter5.Size = new System.Drawing.Size(24, 276);
            this.volumeMeter5.TabIndex = 8;
            this.volumeMeter5.Value = 0;
            // 
            // volumeMeter4
            // 
            this.volumeMeter4.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeter4.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeter4.BarColor = System.Drawing.Color.White;
            this.volumeMeter4.BorderColor = System.Drawing.Color.White;
            this.volumeMeter4.BorderWidth = 1;
            this.volumeMeter4.Location = new System.Drawing.Point(148, 32);
            this.volumeMeter4.Name = "volumeMeter4";
            this.volumeMeter4.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeter4.Size = new System.Drawing.Size(24, 276);
            this.volumeMeter4.TabIndex = 7;
            this.volumeMeter4.Value = 0;
            // 
            // volumeMeter3
            // 
            this.volumeMeter3.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeter3.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeter3.BarColor = System.Drawing.Color.White;
            this.volumeMeter3.BorderColor = System.Drawing.Color.White;
            this.volumeMeter3.BorderWidth = 1;
            this.volumeMeter3.Location = new System.Drawing.Point(102, 32);
            this.volumeMeter3.Name = "volumeMeter3";
            this.volumeMeter3.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeter3.Size = new System.Drawing.Size(24, 276);
            this.volumeMeter3.TabIndex = 6;
            this.volumeMeter3.Value = 0;
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeter2.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeter2.BarColor = System.Drawing.Color.White;
            this.volumeMeter2.BorderColor = System.Drawing.Color.White;
            this.volumeMeter2.BorderWidth = 1;
            this.volumeMeter2.Location = new System.Drawing.Point(61, 32);
            this.volumeMeter2.Name = "volumeMeter2";
            this.volumeMeter2.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeter2.Size = new System.Drawing.Size(24, 276);
            this.volumeMeter2.TabIndex = 5;
            this.volumeMeter2.Value = 0;
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeter1.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeter1.BarColor = System.Drawing.Color.White;
            this.volumeMeter1.BorderColor = System.Drawing.Color.White;
            this.volumeMeter1.BorderWidth = 1;
            this.volumeMeter1.Location = new System.Drawing.Point(22, 32);
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeter1.Size = new System.Drawing.Size(24, 276);
            this.volumeMeter1.TabIndex = 4;
            this.volumeMeter1.Value = 0;
            // 
            // volumeMeterFrequency500
            // 
            this.volumeMeterFrequency500.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeterFrequency500.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeterFrequency500.BarColor = System.Drawing.Color.White;
            this.volumeMeterFrequency500.BorderColor = System.Drawing.Color.White;
            this.volumeMeterFrequency500.BorderWidth = 1;
            this.volumeMeterFrequency500.Location = new System.Drawing.Point(196, 32);
            this.volumeMeterFrequency500.Name = "volumeMeterFrequency500";
            this.volumeMeterFrequency500.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeterFrequency500.Size = new System.Drawing.Size(24, 276);
            this.volumeMeterFrequency500.TabIndex = 2;
            this.volumeMeterFrequency500.Value = 0;
            // 
            // labelFrequency500
            // 
            this.labelFrequency500.AutoSize = true;
            this.labelFrequency500.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrequency500.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelFrequency500.Location = new System.Drawing.Point(194, 311);
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
            this.labelFrequency1k.Location = new System.Drawing.Point(238, 311);
            this.labelFrequency1k.Name = "labelFrequency1k";
            this.labelFrequency1k.Size = new System.Drawing.Size(28, 12);
            this.labelFrequency1k.TabIndex = 1;
            this.labelFrequency1k.Text = "1KHz";
            // 
            // volumeMeterFrequency1K
            // 
            this.volumeMeterFrequency1K.BackColor = System.Drawing.Color.Transparent;
            this.volumeMeterFrequency1K.BackgroundColor = System.Drawing.Color.Transparent;
            this.volumeMeterFrequency1K.BarColor = System.Drawing.Color.White;
            this.volumeMeterFrequency1K.BorderColor = System.Drawing.Color.White;
            this.volumeMeterFrequency1K.BorderWidth = 1;
            this.volumeMeterFrequency1K.Location = new System.Drawing.Point(240, 32);
            this.volumeMeterFrequency1K.Name = "volumeMeterFrequency1K";
            this.volumeMeterFrequency1K.RenderMethod = ChromaWave.Helpers.VolumeMeterRenderMethod.Linear;
            this.volumeMeterFrequency1K.Size = new System.Drawing.Size(24, 276);
            this.volumeMeterFrequency1K.TabIndex = 0;
            this.volumeMeterFrequency1K.Value = 0;
            // 
            // timerUIUpdate
            // 
            this.timerUIUpdate.Enabled = true;
            this.timerUIUpdate.Tick += new System.EventHandler(this.TimerUIUpdate_Tick);
            // 
            // chromaVisualizer1
            // 
            this.chromaVisualizer1.BackColor = System.Drawing.Color.White;
            this.chromaVisualizer1.Location = new System.Drawing.Point(15, 425);
            this.chromaVisualizer1.Name = "chromaVisualizer1";
            this.chromaVisualizer1.Size = new System.Drawing.Size(629, 189);
            this.chromaVisualizer1.TabIndex = 24;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(659, 627);
            this.Controls.Add(this.chromaVisualizer1);
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
        private Helpers.ChromaVisualizer chromaVisualizer1;
        private DarkUI.Controls.DarkLabel darkLabel7;
        private Helpers.VolumeMeter volumeMeter8;
        private DarkUI.Controls.DarkLabel darkLabel6;
        private Helpers.VolumeMeter volumeMeter7;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private Helpers.VolumeMeter volumeMeter6;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel labelFrequency2k;
        private Helpers.VolumeMeter volumeMeter5;
        private Helpers.VolumeMeter volumeMeter4;
        private Helpers.VolumeMeter volumeMeter3;
        private Helpers.VolumeMeter volumeMeter2;
        private Helpers.VolumeMeter volumeMeter1;
        private System.Windows.Forms.Timer timerUIUpdate;
    }
}


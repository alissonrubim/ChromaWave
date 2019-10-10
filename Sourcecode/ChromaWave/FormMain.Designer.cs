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
            this.comboBoxSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarWave16k = new System.Windows.Forms.ProgressBar();
            this.progressBarWave1k = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarWave32 = new System.Windows.Forms.ProgressBar();
            this.progressBarWave250 = new System.Windows.Forms.ProgressBar();
            this.progressBarWave4k = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxDebug = new System.Windows.Forms.GroupBox();
            this.labelLoopbackStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonReload = new System.Windows.Forms.Button();
            this.groupBoxDetails.SuspendLayout();
            this.groupBoxDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSource
            // 
            this.comboBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSource.FormattingEnabled = true;
            this.comboBoxSource.Location = new System.Drawing.Point(96, 16);
            this.comboBoxSource.Name = "comboBoxSource";
            this.comboBoxSource.Size = new System.Drawing.Size(884, 21);
            this.comboBoxSource.TabIndex = 0;
            this.comboBoxSource.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSource_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sound Source:";
            // 
            // progressBarWave16k
            // 
            this.progressBarWave16k.Location = new System.Drawing.Point(52, 31);
            this.progressBarWave16k.Name = "progressBarWave16k";
            this.progressBarWave16k.Size = new System.Drawing.Size(974, 23);
            this.progressBarWave16k.TabIndex = 2;
            // 
            // progressBarWave1k
            // 
            this.progressBarWave1k.Location = new System.Drawing.Point(52, 92);
            this.progressBarWave1k.Name = "progressBarWave1k";
            this.progressBarWave1k.Size = new System.Drawing.Size(974, 23);
            this.progressBarWave1k.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "16k";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "1k";
            // 
            // progressBarWave32
            // 
            this.progressBarWave32.Location = new System.Drawing.Point(52, 150);
            this.progressBarWave32.Name = "progressBarWave32";
            this.progressBarWave32.Size = new System.Drawing.Size(974, 23);
            this.progressBarWave32.TabIndex = 6;
            // 
            // progressBarWave250
            // 
            this.progressBarWave250.Location = new System.Drawing.Point(52, 121);
            this.progressBarWave250.Name = "progressBarWave250";
            this.progressBarWave250.Size = new System.Drawing.Size(974, 23);
            this.progressBarWave250.TabIndex = 7;
            // 
            // progressBarWave4k
            // 
            this.progressBarWave4k.Location = new System.Drawing.Point(52, 60);
            this.progressBarWave4k.Name = "progressBarWave4k";
            this.progressBarWave4k.Size = new System.Drawing.Size(974, 23);
            this.progressBarWave4k.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "32";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "4K";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "250";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDetails.Controls.Add(this.progressBarWave32);
            this.groupBoxDetails.Controls.Add(this.label6);
            this.groupBoxDetails.Controls.Add(this.progressBarWave16k);
            this.groupBoxDetails.Controls.Add(this.label5);
            this.groupBoxDetails.Controls.Add(this.progressBarWave1k);
            this.groupBoxDetails.Controls.Add(this.label4);
            this.groupBoxDetails.Controls.Add(this.label2);
            this.groupBoxDetails.Controls.Add(this.progressBarWave4k);
            this.groupBoxDetails.Controls.Add(this.label3);
            this.groupBoxDetails.Controls.Add(this.progressBarWave250);
            this.groupBoxDetails.Location = new System.Drawing.Point(12, 43);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(1049, 200);
            this.groupBoxDetails.TabIndex = 12;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Details";
            // 
            // groupBoxDebug
            // 
            this.groupBoxDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDebug.Controls.Add(this.labelLoopbackStatus);
            this.groupBoxDebug.Controls.Add(this.label7);
            this.groupBoxDebug.Location = new System.Drawing.Point(12, 249);
            this.groupBoxDebug.Name = "groupBoxDebug";
            this.groupBoxDebug.Size = new System.Drawing.Size(1049, 271);
            this.groupBoxDebug.TabIndex = 12;
            this.groupBoxDebug.TabStop = false;
            this.groupBoxDebug.Text = "Debug";
            // 
            // labelLoopbackStatus
            // 
            this.labelLoopbackStatus.AutoSize = true;
            this.labelLoopbackStatus.Location = new System.Drawing.Point(160, 36);
            this.labelLoopbackStatus.Name = "labelLoopbackStatus";
            this.labelLoopbackStatus.Size = new System.Drawing.Size(10, 13);
            this.labelLoopbackStatus.TabIndex = 13;
            this.labelLoopbackStatus.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Lookback recording status:";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // buttonReload
            // 
            this.buttonReload.Location = new System.Drawing.Point(986, 14);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(75, 23);
            this.buttonReload.TabIndex = 13;
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.ButtonReload_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1073, 604);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.groupBoxDebug);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSource);
            this.Name = "FormMain";
            this.Text = "ChromaWave";
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBoxDebug.ResumeLayout(false);
            this.groupBoxDebug.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarWave16k;
        private System.Windows.Forms.ProgressBar progressBarWave1k;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBarWave32;
        private System.Windows.Forms.ProgressBar progressBarWave250;
        private System.Windows.Forms.ProgressBar progressBarWave4k;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.GroupBox groupBoxDebug;
        private System.Windows.Forms.Label labelLoopbackStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonReload;
    }
}


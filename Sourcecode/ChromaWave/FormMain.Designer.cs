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
            this.SuspendLayout();
            // 
            // comboBoxSource
            // 
            this.comboBoxSource.FormattingEnabled = true;
            this.comboBoxSource.Location = new System.Drawing.Point(63, 19);
            this.comboBoxSource.Name = "comboBoxSource";
            this.comboBoxSource.Size = new System.Drawing.Size(239, 21);
            this.comboBoxSource.TabIndex = 0;
            this.comboBoxSource.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSource_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source:";
            // 
            // progressBarWave16k
            // 
            this.progressBarWave16k.Location = new System.Drawing.Point(63, 93);
            this.progressBarWave16k.Name = "progressBarWave16k";
            this.progressBarWave16k.Size = new System.Drawing.Size(276, 23);
            this.progressBarWave16k.TabIndex = 2;
            // 
            // progressBarWave1k
            // 
            this.progressBarWave1k.Location = new System.Drawing.Point(63, 154);
            this.progressBarWave1k.Name = "progressBarWave1k";
            this.progressBarWave1k.Size = new System.Drawing.Size(276, 23);
            this.progressBarWave1k.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "16k";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "1k";
            // 
            // progressBarWave32
            // 
            this.progressBarWave32.Location = new System.Drawing.Point(63, 212);
            this.progressBarWave32.Name = "progressBarWave32";
            this.progressBarWave32.Size = new System.Drawing.Size(276, 23);
            this.progressBarWave32.TabIndex = 6;
            // 
            // progressBarWave250
            // 
            this.progressBarWave250.Location = new System.Drawing.Point(63, 183);
            this.progressBarWave250.Name = "progressBarWave250";
            this.progressBarWave250.Size = new System.Drawing.Size(276, 23);
            this.progressBarWave250.TabIndex = 7;
            // 
            // progressBarWave4k
            // 
            this.progressBarWave4k.Location = new System.Drawing.Point(63, 122);
            this.progressBarWave4k.Name = "progressBarWave4k";
            this.progressBarWave4k.Size = new System.Drawing.Size(276, 23);
            this.progressBarWave4k.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "32";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "4K";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "250";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 429);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBarWave4k);
            this.Controls.Add(this.progressBarWave250);
            this.Controls.Add(this.progressBarWave32);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBarWave1k);
            this.Controls.Add(this.progressBarWave16k);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSource);
            this.Name = "FormMain";
            this.Text = "Form1";
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
    }
}


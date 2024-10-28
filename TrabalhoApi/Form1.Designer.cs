namespace TrabalhoApi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ImagemAcerto = new PictureBox();
            textBox1 = new TextBox();
            button1 = new Button();
            painelTentativas = new Panel();
            vScrollBar1 = new VScrollBar();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)ImagemAcerto).BeginInit();
            painelTentativas.SuspendLayout();
            SuspendLayout();
            // 
            // ImagemAcerto
            // 
            ImagemAcerto.BackgroundImageLayout = ImageLayout.Stretch;
            ImagemAcerto.BorderStyle = BorderStyle.FixedSingle;
            ImagemAcerto.Image = Properties.Resources.Certo;
            ImagemAcerto.ImageLocation = "";
            ImagemAcerto.Location = new Point(324, -191);
            ImagemAcerto.Name = "ImagemAcerto";
            ImagemAcerto.Size = new Size(222, 176);
            ImagemAcerto.SizeMode = PictureBoxSizeMode.StretchImage;
            ImagemAcerto.TabIndex = 0;
            ImagemAcerto.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(224, 224, 224);
            textBox1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(308, 162);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(205, 45);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.ForestGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(546, 161);
            button1.Name = "button1";
            button1.Size = new Size(36, 47);
            button1.TabIndex = 2;
            button1.Text = "↵";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // painelTentativas
            // 
            painelTentativas.BackColor = SystemColors.ActiveCaption;
            painelTentativas.Controls.Add(vScrollBar1);
            painelTentativas.Location = new Point(326, 301);
            painelTentativas.Name = "painelTentativas";
            painelTentativas.Size = new Size(234, 0);
            painelTentativas.TabIndex = 4;
            // 
            // vScrollBar1
            // 
            vScrollBar1.LargeChange = 2;
            vScrollBar1.Location = new Point(211, 0);
            vScrollBar1.Maximum = 1;
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(23, 80);
            vScrollBar1.TabIndex = 0;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(946, 55);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 6;
            label1.Text = "label1";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // button2
            // 
            button2.BackColor = Color.SlateGray;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(512, 161);
            button2.Name = "button2";
            button2.Size = new Size(36, 47);
            button2.TabIndex = 7;
            button2.Text = "!";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.TrabalhoApi;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(898, 508);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(painelTentativas);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(ImagemAcerto);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Click += Form1_Click;
            MouseCaptureChanged += Form1_MouseCaptureChanged;
            ((System.ComponentModel.ISupportInitialize)ImagemAcerto).EndInit();
            painelTentativas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ImagemAcerto;
        private TextBox textBox1;
        private Button button1;
        private Panel painelTentativas;
        private VScrollBar vScrollBar1;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Button button2;
    }
}

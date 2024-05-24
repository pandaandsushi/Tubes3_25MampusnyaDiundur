using System.Windows.Forms;

namespace WinFormsApp1
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
            pictureBox2 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            toggle2 = new Toggle.Toggle();
            buttonOval2 = new Toggle.ButtonOval();
            search1 = new Toggle.Search();
            pictureBox3 = new PictureBox();
            label8 = new Label();
            panel2 = new Panel();
            label13 = new Label();
            label12 = new Label();
            label9 = new Label();
            pictureBox4 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox5 = new PictureBox();
            panel1 = new Panel();
            label10 = new Label();
            panel3 = new Panel();
            label11 = new Label();
            pictureBox6 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(72, 349);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(433, 389);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.BlanchedAlmond;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.WindowText;
            label3.Location = new Point(71, 324);
            label3.Name = "label3";
            label3.Size = new Size(147, 22);
            label3.TabIndex = 5;
            label3.Text = "Your Fingerprint";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.AntiqueWhite;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.WindowText;
            label4.Location = new Point(72, 183);
            label4.Name = "label4";
            label4.Size = new Size(110, 22);
            label4.TabIndex = 7;
            label4.Text = "How To Use";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.AntiqueWhite;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.WindowText;
            label5.Location = new Point(72, 205);
            label5.Name = "label5";
            label5.Size = new Size(318, 21);
            label5.TabIndex = 8;
            label5.Text = "1. Input your fingerprint image here";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.AntiqueWhite;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.WindowText;
            label6.Location = new Point(72, 230);
            label6.Name = "label6";
            label6.Size = new Size(697, 21);
            label6.TabIndex = 9;
            label6.Text = "2. Use the toggle button to choose the pattern matching algorithm as you like";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.AntiqueWhite;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.WindowText;
            label7.Location = new Point(71, 254);
            label7.Name = "label7";
            label7.Size = new Size(434, 21);
            label7.TabIndex = 10;
            label7.Text = "3. Press the search button and wait for the result!";
            // 
            // toggle2
            // 
            toggle2.AutoSize = true;
            toggle2.Location = new Point(537, 408);
            toggle2.MinimumSize = new Size(20, 10);
            toggle2.Name = "toggle2";
            toggle2.Size = new Size(100, 29);
            toggle2.TabIndex = 12;
            toggle2.Text = "toggle2";
            toggle2.UseVisualStyleBackColor = true;
            // 
            // buttonOval2
            // 
            buttonOval2.Location = new Point(154, 758);
            buttonOval2.MinimumSize = new Size(65, 22);
            buttonOval2.Name = "buttonOval2";
            buttonOval2.Size = new Size(267, 34);
            buttonOval2.TabIndex = 14;
            buttonOval2.Text = "buttonOval2";
            buttonOval2.UseVisualStyleBackColor = true;
            // 
            // search1
            // 
            search1.Location = new Point(710, 404);
            search1.MinimumSize = new Size(65, 22);
            search1.Name = "search1";
            search1.Size = new Size(146, 34);
            search1.TabIndex = 15;
            search1.Text = "search1";
            search1.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(657, 349);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(434, 389);
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Tan;
            label8.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.WindowText;
            label8.Location = new Point(39, 23);
            label8.Name = "label8";
            label8.Size = new Size(60, 22);
            label8.TabIndex = 17;
            label8.Text = "Result";
            label8.Click += label8_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Tan;
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(search1);
            panel2.Controls.Add(toggle2);
            panel2.Location = new Point(614, 301);
            panel2.Name = "panel2";
            panel2.Size = new Size(910, 491);
            panel2.TabIndex = 18;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Tan;
            label13.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.WindowText;
            label13.Location = new Point(710, 322);
            label13.Name = "label13";
            label13.Size = new Size(166, 21);
            label13.TabIndex = 24;
            label13.Text = "Tingkat kemiripan:";
            label13.Click += label13_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Tan;
            label12.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.WindowText;
            label12.Location = new Point(517, 322);
            label12.Name = "label12";
            label12.Size = new Size(144, 21);
            label12.TabIndex = 23;
            label12.Text = "Waktu Eksekusi:";
            label12.Click += label12_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Tan;
            label9.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.WindowText;
            label9.Location = new Point(517, 86);
            label9.Name = "label9";
            label9.Size = new Size(74, 21);
            label9.TabIndex = 22;
            label9.Text = "Name: ";
            label9.Click += label9_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Water_Scarcity_removebg_preview;
            pictureBox4.Location = new Point(1, 54);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(661, 136);
            pictureBox4.TabIndex = 19;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(219, 132, 90);
            label1.Font = new Font("STHupo", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(88, 54);
            label1.Name = "label1";
            label1.Size = new Size(190, 18);
            label1.TabIndex = 3;
            label1.Text = "25MampusnyaDiundur";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(219, 132, 90);
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.WindowText;
            label2.Location = new Point(1116, 50);
            label2.Name = "label2";
            label2.Size = new Size(408, 22);
            label2.TabIndex = 4;
            label2.Text = "Fingerprint Pattern Matching with KMP and BM\r\n";
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(219, 132, 90);
            pictureBox1.Image = Properties.Resources.Doodle_Skull;
            pictureBox1.Location = new Point(29, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(53, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.Water_Scarcity_removebg_preview;
            pictureBox5.Location = new Point(548, 54);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(661, 136);
            pictureBox5.TabIndex = 20;
            pictureBox5.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(219, 132, 90);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1577, 58);
            panel1.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(219, 132, 90);
            label10.Font = new Font("Century Gothic", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(70, 14);
            label10.Name = "label10";
            label10.Size = new Size(183, 17);
            label10.TabIndex = 22;
            label10.Text = "Made by: Thea, Kayla, Diana :)";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(219, 132, 90);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(1, 845);
            panel3.Name = "panel3";
            panel3.Size = new Size(1577, 52);
            panel3.TabIndex = 22;
            panel3.Paint += panel3_Paint;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(219, 132, 90);
            label11.Font = new Font("Century Gothic", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(1518, 14);
            label11.Name = "label11";
            label11.Size = new Size(46, 17);
            label11.TabIndex = 23;
            label11.Text = "@2024";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.Water_Scarcity_removebg_preview;
            pictureBox6.Location = new Point(1131, 16);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(661, 136);
            pictureBox6.TabIndex = 23;
            pictureBox6.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(746, 33);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(483, 258);
            textBox1.TabIndex = 24;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(125, 63);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(483, 258);
            textBox2.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(1577, 894);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(pictureBox6);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(pictureBox3);
            Controls.Add(buttonOval2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(panel2);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(panel3);
            ForeColor = Color.White;
            Name = "Form1";
            Text = "25MampusnyaDiundur presents...";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public PictureBox pictureBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Toggle.Toggle toggle2;
        private Toggle.ButtonOval buttonOval2;
        private Toggle.Search search1;
        private Label label8;
        private Panel panel2;
        private PictureBox pictureBox4;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private Panel panel1;
        private Label label9;
        private Label label10;
        private Panel panel3;
        private Label label11;
        private PictureBox pictureBox6;
        private Label label12;
        private Label label13;
        private TextBox textBox1;
        public PictureBox pictureBox3;
        private TextBox textBox2;
    }
}

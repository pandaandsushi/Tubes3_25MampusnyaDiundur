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
            label36 = new Label();
            label35 = new Label();
            labelEksekusi = new Label();
            labelKemiripan = new Label();
            labelKWN = new Label();
            labelPekerjaan = new Label();
            labelStatus = new Label();
            labelAgama = new Label();
            labelAlamat = new Label();
            labelGoldar = new Label();
            labelJenisKelamin = new Label();
            labelTanggalLahir = new Label();
            labelTempatLahir = new Label();
            labelNama = new Label();
            labelNIK = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label26 = new Label();
            label27 = new Label();
            label25 = new Label();
            label24 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
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
            toggle2.CheckedChanged += toggle2_CheckedChanged;
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
            // 
            // panel2
            // 
            panel2.BackColor = Color.Tan;
            panel2.Controls.Add(label36);
            panel2.Controls.Add(label35);
            panel2.Controls.Add(labelEksekusi);
            panel2.Controls.Add(labelKemiripan);
            panel2.Controls.Add(labelKWN);
            panel2.Controls.Add(labelPekerjaan);
            panel2.Controls.Add(labelStatus);
            panel2.Controls.Add(labelAgama);
            panel2.Controls.Add(labelAlamat);
            panel2.Controls.Add(labelGoldar);
            panel2.Controls.Add(labelJenisKelamin);
            panel2.Controls.Add(labelTanggalLahir);
            panel2.Controls.Add(labelTempatLahir);
            panel2.Controls.Add(labelNama);
            panel2.Controls.Add(labelNIK);
            panel2.Controls.Add(label32);
            panel2.Controls.Add(label33);
            panel2.Controls.Add(label34);
            panel2.Controls.Add(label28);
            panel2.Controls.Add(label29);
            panel2.Controls.Add(label30);
            panel2.Controls.Add(label31);
            panel2.Controls.Add(label26);
            panel2.Controls.Add(label27);
            panel2.Controls.Add(label25);
            panel2.Controls.Add(label24);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(label23);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label14);
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
            // label36
            // 
            label36.AutoSize = true;
            label36.BackColor = Color.Tan;
            label36.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label36.ForeColor = SystemColors.WindowText;
            label36.Location = new Point(470, 456);
            label36.Name = "label36";
            label36.Size = new Size(34, 21);
            label36.TabIndex = 60;
            label36.Text = "ms";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.BackColor = Color.Tan;
            label35.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label35.ForeColor = SystemColors.WindowText;
            label35.Location = new Point(250, 457);
            label35.Name = "label35";
            label35.Size = new Size(24, 21);
            label35.TabIndex = 59;
            label35.Text = "%";
            // 
            // labelEksekusi
            // 
            labelEksekusi.AutoSize = true;
            labelEksekusi.BackColor = Color.Tan;
            labelEksekusi.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEksekusi.ForeColor = SystemColors.WindowText;
            labelEksekusi.Location = new Point(440, 457);
            labelEksekusi.Name = "labelEksekusi";
            labelEksekusi.Size = new Size(20, 21);
            labelEksekusi.TabIndex = 58;
            labelEksekusi.Text = "0";
            // 
            // labelKemiripan
            // 
            labelKemiripan.AutoSize = true;
            labelKemiripan.BackColor = Color.Tan;
            labelKemiripan.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelKemiripan.ForeColor = SystemColors.WindowText;
            labelKemiripan.Location = new Point(215, 457);
            labelKemiripan.Name = "labelKemiripan";
            labelKemiripan.Size = new Size(20, 21);
            labelKemiripan.TabIndex = 57;
            labelKemiripan.Text = "0";
            // 
            // labelKWN
            // 
            labelKWN.AutoSize = true;
            labelKWN.BackColor = Color.Tan;
            labelKWN.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelKWN.ForeColor = SystemColors.WindowText;
            labelKWN.Location = new Point(731, 320);
            labelKWN.Name = "labelKWN";
            labelKWN.Size = new Size(58, 21);
            labelKWN.TabIndex = 56;
            labelKWN.Text = "None";
            // 
            // labelPekerjaan
            // 
            labelPekerjaan.AutoSize = true;
            labelPekerjaan.BackColor = Color.Tan;
            labelPekerjaan.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPekerjaan.ForeColor = SystemColors.WindowText;
            labelPekerjaan.Location = new Point(731, 293);
            labelPekerjaan.Name = "labelPekerjaan";
            labelPekerjaan.Size = new Size(58, 21);
            labelPekerjaan.TabIndex = 55;
            labelPekerjaan.Text = "None";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.BackColor = Color.Tan;
            labelStatus.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStatus.ForeColor = SystemColors.WindowText;
            labelStatus.Location = new Point(731, 264);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(58, 21);
            labelStatus.TabIndex = 54;
            labelStatus.Text = "None";
            // 
            // labelAgama
            // 
            labelAgama.AutoSize = true;
            labelAgama.BackColor = Color.Tan;
            labelAgama.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAgama.ForeColor = SystemColors.WindowText;
            labelAgama.Location = new Point(731, 242);
            labelAgama.Name = "labelAgama";
            labelAgama.Size = new Size(58, 21);
            labelAgama.TabIndex = 53;
            labelAgama.Text = "None";
            // 
            // labelAlamat
            // 
            labelAlamat.AutoSize = true;
            labelAlamat.BackColor = Color.Tan;
            labelAlamat.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAlamat.ForeColor = SystemColors.WindowText;
            labelAlamat.Location = new Point(731, 215);
            labelAlamat.Name = "labelAlamat";
            labelAlamat.Size = new Size(58, 21);
            labelAlamat.TabIndex = 52;
            labelAlamat.Text = "None";
            // 
            // labelGoldar
            // 
            labelGoldar.AutoSize = true;
            labelGoldar.BackColor = Color.Tan;
            labelGoldar.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelGoldar.ForeColor = SystemColors.WindowText;
            labelGoldar.Location = new Point(731, 186);
            labelGoldar.Name = "labelGoldar";
            labelGoldar.Size = new Size(58, 21);
            labelGoldar.TabIndex = 51;
            labelGoldar.Text = "None";
            // 
            // labelJenisKelamin
            // 
            labelJenisKelamin.AutoSize = true;
            labelJenisKelamin.BackColor = Color.Tan;
            labelJenisKelamin.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelJenisKelamin.ForeColor = SystemColors.WindowText;
            labelJenisKelamin.Location = new Point(731, 159);
            labelJenisKelamin.Name = "labelJenisKelamin";
            labelJenisKelamin.Size = new Size(58, 21);
            labelJenisKelamin.TabIndex = 50;
            labelJenisKelamin.Text = "None";
            // 
            // labelTanggalLahir
            // 
            labelTanggalLahir.AutoSize = true;
            labelTanggalLahir.BackColor = Color.Tan;
            labelTanggalLahir.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTanggalLahir.ForeColor = SystemColors.WindowText;
            labelTanggalLahir.Location = new Point(731, 131);
            labelTanggalLahir.Name = "labelTanggalLahir";
            labelTanggalLahir.Size = new Size(58, 21);
            labelTanggalLahir.TabIndex = 49;
            labelTanggalLahir.Text = "None";
            // 
            // labelTempatLahir
            // 
            labelTempatLahir.AutoSize = true;
            labelTempatLahir.BackColor = Color.Tan;
            labelTempatLahir.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTempatLahir.ForeColor = SystemColors.WindowText;
            labelTempatLahir.Location = new Point(731, 104);
            labelTempatLahir.Name = "labelTempatLahir";
            labelTempatLahir.Size = new Size(58, 21);
            labelTempatLahir.TabIndex = 48;
            labelTempatLahir.Text = "None";
            // 
            // labelNama
            // 
            labelNama.AutoSize = true;
            labelNama.BackColor = Color.Tan;
            labelNama.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelNama.ForeColor = SystemColors.WindowText;
            labelNama.Location = new Point(731, 75);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(58, 21);
            labelNama.TabIndex = 47;
            labelNama.Text = "None";
            // 
            // labelNIK
            // 
            labelNIK.AutoSize = true;
            labelNIK.BackColor = Color.Tan;
            labelNIK.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelNIK.ForeColor = SystemColors.WindowText;
            labelNIK.Location = new Point(731, 48);
            labelNIK.Name = "labelNIK";
            labelNIK.Size = new Size(58, 21);
            labelNIK.TabIndex = 46;
            labelNIK.Text = "None";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.BackColor = Color.Tan;
            label32.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label32.ForeColor = SystemColors.WindowText;
            label32.Location = new Point(710, 320);
            label32.Name = "label32";
            label32.Size = new Size(15, 21);
            label32.TabIndex = 45;
            label32.Text = ":";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.BackColor = Color.Tan;
            label33.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label33.ForeColor = SystemColors.WindowText;
            label33.Location = new Point(710, 293);
            label33.Name = "label33";
            label33.Size = new Size(15, 21);
            label33.TabIndex = 44;
            label33.Text = ":";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.BackColor = Color.Tan;
            label34.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label34.ForeColor = SystemColors.WindowText;
            label34.Location = new Point(710, 264);
            label34.Name = "label34";
            label34.Size = new Size(15, 21);
            label34.TabIndex = 43;
            label34.Text = ":";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.BackColor = Color.Tan;
            label28.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label28.ForeColor = SystemColors.WindowText;
            label28.Location = new Point(710, 242);
            label28.Name = "label28";
            label28.Size = new Size(15, 21);
            label28.TabIndex = 42;
            label28.Text = ":";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.BackColor = Color.Tan;
            label29.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label29.ForeColor = SystemColors.WindowText;
            label29.Location = new Point(710, 215);
            label29.Name = "label29";
            label29.Size = new Size(15, 21);
            label29.TabIndex = 41;
            label29.Text = ":";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.BackColor = Color.Tan;
            label30.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label30.ForeColor = SystemColors.WindowText;
            label30.Location = new Point(710, 186);
            label30.Name = "label30";
            label30.Size = new Size(15, 21);
            label30.TabIndex = 40;
            label30.Text = ":";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.BackColor = Color.Tan;
            label31.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label31.ForeColor = SystemColors.WindowText;
            label31.Location = new Point(710, 159);
            label31.Name = "label31";
            label31.Size = new Size(15, 21);
            label31.TabIndex = 39;
            label31.Text = ":";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.BackColor = Color.Tan;
            label26.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label26.ForeColor = SystemColors.WindowText;
            label26.Location = new Point(710, 131);
            label26.Name = "label26";
            label26.Size = new Size(15, 21);
            label26.TabIndex = 38;
            label26.Text = ":";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.BackColor = Color.Tan;
            label27.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label27.ForeColor = SystemColors.WindowText;
            label27.Location = new Point(710, 104);
            label27.Name = "label27";
            label27.Size = new Size(15, 21);
            label27.TabIndex = 37;
            label27.Text = ":";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = Color.Tan;
            label25.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label25.ForeColor = SystemColors.WindowText;
            label25.Location = new Point(710, 75);
            label25.Name = "label25";
            label25.Size = new Size(15, 21);
            label25.TabIndex = 36;
            label25.Text = ":";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = Color.Tan;
            label24.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label24.ForeColor = SystemColors.WindowText;
            label24.Location = new Point(710, 48);
            label24.Name = "label24";
            label24.Size = new Size(15, 21);
            label24.TabIndex = 35;
            label24.Text = ":";
            label24.Click += label24_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.Tan;
            label20.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.ForeColor = SystemColors.WindowText;
            label20.Location = new Point(517, 318);
            label20.Name = "label20";
            label20.Size = new Size(175, 21);
            label20.TabIndex = 34;
            label20.Text = "Kewarganegaraan";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Tan;
            label21.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = SystemColors.WindowText;
            label21.Location = new Point(517, 293);
            label21.Name = "label21";
            label21.Size = new Size(97, 21);
            label21.TabIndex = 33;
            label21.Text = "Pekerjaan";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.Tan;
            label22.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.WindowText;
            label22.Location = new Point(517, 266);
            label22.Name = "label22";
            label22.Size = new Size(63, 21);
            label22.TabIndex = 32;
            label22.Text = "Status";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = Color.Tan;
            label23.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label23.ForeColor = SystemColors.WindowText;
            label23.Location = new Point(517, 238);
            label23.Name = "label23";
            label23.Size = new Size(78, 21);
            label23.TabIndex = 31;
            label23.Text = "Agama";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.Tan;
            label19.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.WindowText;
            label19.Location = new Point(517, 211);
            label19.Name = "label19";
            label19.Size = new Size(76, 21);
            label19.TabIndex = 30;
            label19.Text = "Alamat";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Tan;
            label18.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = SystemColors.WindowText;
            label18.Location = new Point(517, 186);
            label18.Name = "label18";
            label18.Size = new Size(70, 21);
            label18.TabIndex = 29;
            label18.Text = "Goldar";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Tan;
            label17.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = SystemColors.WindowText;
            label17.Location = new Point(517, 159);
            label17.Name = "label17";
            label17.Size = new Size(121, 21);
            label17.TabIndex = 28;
            label17.Text = "JenisKelamin";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Tan;
            label16.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = SystemColors.WindowText;
            label16.Location = new Point(517, 131);
            label16.Name = "label16";
            label16.Size = new Size(114, 21);
            label16.TabIndex = 27;
            label16.Text = "Tanggallahir";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Tan;
            label15.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.WindowText;
            label15.Location = new Point(517, 104);
            label15.Name = "label15";
            label15.Size = new Size(112, 21);
            label15.TabIndex = 26;
            label15.Text = "Tempatlahir";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Tan;
            label14.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.WindowText;
            label14.Location = new Point(517, 75);
            label14.Name = "label14";
            label14.Size = new Size(64, 21);
            label14.TabIndex = 25;
            label14.Text = "Name";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Tan;
            label13.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.WindowText;
            label13.Location = new Point(43, 457);
            label13.Name = "label13";
            label13.Size = new Size(166, 21);
            label13.TabIndex = 24;
            label13.Text = "Tingkat kemiripan:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Tan;
            label12.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.WindowText;
            label12.Location = new Point(290, 457);
            label12.Name = "label12";
            label12.Size = new Size(144, 21);
            label12.TabIndex = 23;
            label12.Text = "Waktu Eksekusi:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Tan;
            label9.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.WindowText;
            label9.Location = new Point(517, 48);
            label9.Name = "label9";
            label9.Size = new Size(39, 21);
            label9.TabIndex = 22;
            label9.Text = "NIK";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(1577, 894);
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
        private Label label14;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label19;
        private Label label18;
        private Label label24;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label26;
        private Label label27;
        private Label label25;
        private Label labelKWN;
        private Label labelPekerjaan;
        private Label labelStatus;
        private Label labelAgama;
        private Label labelAlamat;
        private Label labelGoldar;
        private Label labelJenisKelamin;
        private Label labelTanggalLahir;
        private Label labelTempatLahir;
        private Label labelNama;
        private Label labelNIK;
        private Label labelKemiripan;
        private Label labelEksekusi;
        private Label label36;
        private Label label35;
    }
}

using System;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Threading.Tasks;


using WinFormsApp1.Algorithm;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool toggledon; //status toggle button
        private String asciibottom;   //ascii text image input yang sudah cropped 30px
        private String asciitop;   //ascii text image input yang sudah cropped 30px
        private String resultnama;  //hasil nama yang didapatkan (asli)
        private String resultpath;  //path fingerprint di db yang paling mirip
        private String fullascii;   //ascii image input fulltext dan tidak dicrop
        private readonly Fingerprints fingerprints; //data fingerprints yang paling mirip

        public Form1()
        {
            InitializeComponent();
            buttonOval2.Click += ButtonOval2_Click;
            search1.Click += ButtonSearch1_Click;
            // JANGAN LUPA SESUAIKAN CONNECTION STRING DENGAN DB KAMU
            string connectionString = "server=localhost;user id=root;password=password;database=fingerprint";
            Database db = new Database(connectionString);

            fingerprints = new Fingerprints(db);

            /// alter table 
            fingerprints.alterTable();
            Dummy.GenerateDummy(Path.Combine(GetProjectDirectory(), "test"), fingerprints);
        
            // Load the ascii representation, preprocessing ascii dan memasukkan ke tabel
            UpdateDatabaseWithAsciiRepresentation();
        }

        // getting the project dir for diff user
        private string GetProjectDirectory()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.Combine(Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName, "..", "..", "..");
            return projectDirectory;
        }


        private void UpdateDatabaseWithAsciiRepresentation()
        {
            string projectDirectory = GetProjectDirectory();

            (List<string> berkasDatabase, List<string> nameDatabase, List<string> asciiDatabase)  = fingerprints.GetAllFingerprintDataSeparated();
            int id = 0;
            foreach (var fingerprint in berkasDatabase)
            {
                string imagePath = Path.Combine(projectDirectory, fingerprint);
                if (File.Exists(imagePath))
                {
                    Image<Bgr, byte> image = new Image<Bgr, byte>(imagePath);
                    (string asciiRepresentation, string empty) = Preprocessing.ConvertImageToAscii(false,image);
                    fingerprints.insertAscii(nameDatabase[id], asciiRepresentation);
                }
                else
                {
                    Console.WriteLine($"Image file {imagePath} not found.");
                }
                id++;
            }
        }


        // to change toggle button state
        private void toggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (toggle2.Checked)
            {
                Debug.WriteLine("DEBUG :::::::::: Toggle ON");
                toggledon = true;
            }
            else
            {
                Debug.WriteLine("DEBUG :::::::::: Toggle OFF");
                toggledon = false;
            }
        }

        // mulai pencarian dengan algoritma KMP dan BM
        // jika gagal ditemukan maka akan menggunakan levensthein dist
        private void ButtonSearch1_Click(object sender, EventArgs e)
        {
            // Start the stopwatch for exec time
            Stopwatch stopwatch = Stopwatch.StartNew();
            float similarity = 0;
            // Regex find bio that match
            (resultnama, resultpath, similarity) = PerformPatternMatching();
            List<Biodata> bios = fingerprints.GetAllBiodataData();
            Debug.WriteLine("displaying results..................................");
            // Debug.WriteLine("PATH GAMBAR WOY: "+resultpath);
            bool found = false;
            if(resultpath != null)
            {
                Biodata resultbio = null;
                int mindist = int.MaxValue;
                foreach (var item in bios){
                    // KMP
                    if (toggledon){
                        found = KMPAlgorithm.KMPSearch(resultnama, item.Nama);
                    }
                    // BM
                    else{
                        found = BoyerMooreAlgorithm.BMSearch(resultnama, item.Nama);
                    }
                    if (found){
                        Debug.WriteLine("Berhasil nemu nama alay pakai KMP BM");
                        resultbio = item;
                    }
                }
                if(!found){
                    foreach (var item in bios)
                    {
                        Debug.WriteLine("Berhasil nemu nama alay pakai KMP BM");
                        string purified = AlayTranslator.translateAlay(item.Nama);
                        int caldist = Levenshtein.calculateSimilarity(resultnama, purified);
                        if (caldist < mindist)
                        {
                            mindist = caldist;
                            resultbio = item;
                        }
                    }
                }
                pictureBox3.Image = Image.FromFile(resultpath);
                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                labelNama.Text = resultbio.Nama;
                labelNIK.Text = resultbio.NIK;
                labelTempatLahir.Text = resultbio.TempatLahir;
                labelTanggalLahir.Text = resultbio.TanggalLahir.ToString("dd/MM/yyyy");
                labelJenisKelamin.Text = resultbio.JenisKelamin;
                labelGoldar.Text = resultbio.GolonganDarah;
                labelAlamat.Text = resultbio.Alamat;
                labelAgama.Text = resultbio.Agama;
                labelStatus.Text = resultbio.StatusPerkawinan;
                labelPekerjaan.Text = resultbio.Pekerjaan;
                labelKWN.Text = resultbio.Kewarganegaraan;
                labelKemiripan.Text = Math.Round((decimal)similarity,2).ToString() + "%";
            }
            // sidik jari not found, reset display
            else
            {
                Bitmap bitmap = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                pictureBox3.Image = bitmap;
                pictureBox3.Invalidate();
                labelNama.Text = "None :(";
                labelNIK.Text = "None :(";
                labelTempatLahir.Text = "None :(";
                labelTanggalLahir.Text = "None :(";
                labelJenisKelamin.Text = "None :(";
                labelGoldar.Text = "None :(";
                labelAlamat.Text = "None :(";
                labelAgama.Text = "None :(";
                labelStatus.Text = "None :(";
                labelPekerjaan.Text = "None :(";
                labelKWN.Text = "None :(";
                labelKemiripan.Text = "0 %";
            }

            stopwatch.Stop();

            // Format the elapsed time as a string
            labelEksekusi.Text = stopwatch.ElapsedMilliseconds.ToString() +" ms";

            Debug.WriteLine("DEBUG Execution Time: " + stopwatch.ElapsedMilliseconds.ToString());
        }

        private void ButtonOval2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fingerprint Imgs (*.BMP)|*.BMP";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine("DEBUG--------------------- GAMBAR DITERIMA DAN DI LOAD");
                // Get the selected file name
                string selectedFileName = openFileDialog.FileName;

                // Load the selected image into pictureBox2, display image input
                pictureBox2.Image = Image.FromFile(selectedFileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                // Load the image
                Image<Bgr, byte> image = new Image<Bgr, byte>(selectedFileName);
                (asciitop, asciibottom) = Preprocessing.ConvertImageToAscii(true,image);
                (fullascii, string empty) = Preprocessing.ConvertImageToAscii(false,image);

                Debug.WriteLine("DEBUG--------------------- PROGRAM SELESAI EKSEKUSI");
            }
        }


        // Will Perform patternmatching algo based on the toggle button
        // Will return the nama and image path attribute if found 
        private (string nama, string path, float similarity) PerformPatternMatching()
        {
            Debug.WriteLine("DEBUG--------------------- MULAI PATTERN MATCHING");
            (List<string> berkasDatabase, List<string> nameDatabase, List<string> asciiDatabase) = fingerprints.GetAllFingerprintDataSeparated();
            string projectDirectory = GetProjectDirectory();

            object lockObject = new object();
            bool found = false;
            string resultNama = null;
            string resultPath = null;

            // Parallel pattern matching with KMP and BM
            Parallel.For(0, asciiDatabase.Count, (i, state) =>
            {
                string nama = nameDatabase[i];
                string imagePath = berkasDatabase[i];
                bool localFound = false;

                if (toggledon)
                {
                    Debug.WriteLine("Ngecek pake KMP TOP bro");
                    localFound = KMPAlgorithm.KMPSearch(asciitop, asciiDatabase[i]);
                    if (!localFound)
                    {
                        Debug.WriteLine("Ngecek pake KMP BOTTOM bro");
                        localFound = KMPAlgorithm.KMPSearch(asciibottom, asciiDatabase[i]);
                    }
                }
                else
                {
                    Debug.WriteLine("Ngecek pake BM TOP bro");
                    localFound = BoyerMooreAlgorithm.BMSearch(asciitop, asciiDatabase[i]);
                    if (!localFound)
                    {
                        Debug.WriteLine("Ngecek pake BM BOTTOM bro");
                        localFound = BoyerMooreAlgorithm.BMSearch(asciibottom, asciiDatabase[i]);
                    }
                }

                if (localFound)
                {
                    lock (lockObject)
                    {
                        if (!found)
                        {
                            found = true;
                            resultNama = nama;
                            resultPath = Path.Combine(projectDirectory, imagePath);
                            state.Stop(); // Stop other parallel iterations since we found a match
                        }
                    }
                }
            });

            if (found)
            {
                return (resultNama, resultPath, 100);
            }

            // If no match is found, use Levenshtein distance
            int mindist = int.MaxValue;
            int idbest = -1;
            Debug.WriteLine("----------------------------------------------------");
            Debug.WriteLine("Jumlah element: " + asciiDatabase.Count);

            Parallel.For(0, asciiDatabase.Count, i =>
            {
                int leven = Levenshtein.calculateSimilarity(fullascii, asciiDatabase[i]);
                Debug.WriteLine("KAMU NGECEK LEVEN si: " + berkasDatabase[i] + ":" + leven);

                lock (lockObject)
                {
                    if (leven < mindist)
                    {
                        mindist = leven;
                        idbest = i;
                    }
                }
            });

            Debug.WriteLine("----------------------------------------------------");
            Debug.WriteLine("Ini pattern yang kamu pakai sebagai input");

            float converteddist = ((asciiDatabase[idbest].Length - mindist) / (float)asciiDatabase[idbest].Length) * 100;
            // Set threshold ke 70, kalau lebih kecil bakal ga ketemu hasilnya
            if (converteddist < 70)
            {
                return (null, null, 0);
            }

            string levenimagesDirectory = Path.Combine(projectDirectory, berkasDatabase[idbest]);
            return (nameDatabase[idbest], levenimagesDirectory, converteddist);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

    }
}

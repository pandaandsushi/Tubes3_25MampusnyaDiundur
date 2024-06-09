using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public class Fingerprints
    {
        private readonly Database db;

        public Fingerprints(Database database)
        {
            db = database;
        }
        
        // Method to check if the sidik_jari table is empty
        public bool IsFingerprintTableEmpty()
        {
            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM sidik_jari", db.GetConnection());
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            db.CloseConnection();
            return count == 0;
        }

        public void InsertFingerprint(string nama, string berkas_citra)
        {
            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO sidik_jari (berkas_citra, nama) VALUES (@berkas_citra, @nama)", db.GetConnection());
            cmd.Parameters.AddWithValue("@berkas_citra", berkas_citra);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.ExecuteNonQuery();
            db.CloseConnection();
        }

        public void InsertBiodata(string nik, string nama, string tempat_lahir, DateTime tanggal_lahir, string jenis_kelamin, string golongan_darah, string alamat, string agama, string status_perkawinan, string pekerjaan, string kewarganegaraan)
        {
            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO biodata (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan) " +
                "VALUES (@NIK, @nama, @tempat_lahir, @tanggal_lahir, @jenis_kelamin, @golongan_darah, @alamat, @agama, @status_perkawinan, @pekerjaan, @kewarganegaraan)", db.GetConnection());
            cmd.Parameters.AddWithValue("@NIK", nik);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.Parameters.AddWithValue("@tempat_lahir", tempat_lahir);
            cmd.Parameters.AddWithValue("@tanggal_lahir", tanggal_lahir);
            cmd.Parameters.AddWithValue("@jenis_kelamin", jenis_kelamin);
            cmd.Parameters.AddWithValue("@golongan_darah", golongan_darah);
            cmd.Parameters.AddWithValue("@alamat", alamat);
            cmd.Parameters.AddWithValue("@agama", agama);
            cmd.Parameters.AddWithValue("@status_perkawinan", status_perkawinan);
            cmd.Parameters.AddWithValue("@pekerjaan", pekerjaan);
            cmd.Parameters.AddWithValue("@kewarganegaraan", kewarganegaraan);
            cmd.ExecuteNonQuery();
            db.CloseConnection();
        }

        public Fingerprint GetFingerprintByName(string nama)
        {
            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sidik_jari WHERE nama = @nama", db.GetConnection());
            cmd.Parameters.AddWithValue("@nama", nama);
            MySqlDataReader reader = cmd.ExecuteReader();

             Fingerprint fingerprint = null;
            if (reader.Read())
            {
                fingerprint = new Fingerprint{
                    BerkasCitra = reader.GetString("berkas_citra"),
                    Nama = reader.GetString("nama"),
                    Ascii = reader.IsDBNull(reader.GetOrdinal("ascii")) ? null : reader.GetString("ascii")
                };
            }

            db.CloseConnection();
            return fingerprint;
        }

        public List<Fingerprint> GetAllFingerprintData()
        {
            List<Fingerprint> fingerprintList = new();

            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sidik_jari", db.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Fingerprint fingerprint = new Fingerprint{
                    BerkasCitra = reader.GetString("berkas_citra"),
                    Nama = reader.GetString("nama"),
                    Ascii = reader.IsDBNull(reader.GetOrdinal("ascii")) ? null : reader.GetString("ascii")
                };
                fingerprintList.Add(fingerprint);
            }

            db.CloseConnection();
            return fingerprintList;
        }

        public (List<string>, List<string>, List<string>) GetAllFingerprintDataSeparated()
        {
            List<string> fingerprintList_berkas = new();
            List<string> fingerprintList_nama = new();
            List<string> fingerprintList_ascii = new();

            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sidik_jari", db.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Fingerprint fingerprint = new Fingerprint{
                    BerkasCitra = reader.GetString("berkas_citra"),
                    Nama = reader.GetString("nama"),
                    Ascii = reader.IsDBNull(reader.GetOrdinal("ascii")) ? null : reader.GetString("ascii")
                };
                fingerprintList_berkas.Add(fingerprint.BerkasCitra);
                fingerprintList_nama.Add(fingerprint.Nama);
                fingerprintList_ascii.Add(fingerprint.Ascii);
            }

            db.CloseConnection();
            return (fingerprintList_berkas, fingerprintList_nama, fingerprintList_ascii);
        }

        public List<string> GetAllBerkasCitra()
        {
            List<string> fingerprintList = new();

            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT berkas_citra FROM sidik_jari", db.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string berkas_citra = reader.GetString("berkas_citra");
                fingerprintList.Add(berkas_citra);
            }

            db.CloseConnection();
            return fingerprintList;
        }

        public List<Biodata> GetBiodataByName(string nama)
        {
            List<Biodata> biodataList = new();

            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM biodata WHERE nama = @nama", db.GetConnection());
            cmd.Parameters.AddWithValue("@nama", nama);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Biodata biodata = new Biodata
                {
                    NIK = reader.GetString("NIK"),
                    Nama = reader.GetString("nama"),
                    TempatLahir = reader.GetString("tempat_lahir"),
                    TanggalLahir = reader.GetDateTime("tanggal_lahir"),
                    JenisKelamin = reader.GetString("jenis_kelamin"),
                    GolonganDarah = reader.GetString("golongan_darah"),
                    Alamat = reader.GetString("alamat"),
                    Agama = reader.GetString("agama"),
                    StatusPerkawinan = reader.GetString("status_perkawinan"),
                    Pekerjaan = reader.GetString("pekerjaan"),
                    Kewarganegaraan = reader.GetString("kewarganegaraan")
                };
                biodataList.Add(biodata);
            }

            db.CloseConnection();
            return biodataList;
        }

        public List<Biodata> GetAllBiodataData()
        {
            List<Biodata> biodataList = new();

            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM biodata", db.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Biodata biodata = new Biodata
                {
                    NIK = reader.GetString("NIK"),
                    Nama = reader.GetString("nama"),
                    TempatLahir = reader.GetString("tempat_lahir"),
                    TanggalLahir = reader.GetDateTime("tanggal_lahir"),
                    JenisKelamin = reader.GetString("jenis_kelamin"),
                    GolonganDarah = reader.GetString("golongan_darah"),
                    Alamat = reader.GetString("alamat"),
                    Agama = reader.GetString("agama"),
                    StatusPerkawinan = reader.GetString("status_perkawinan"),
                    Pekerjaan = reader.GetString("pekerjaan"),
                    Kewarganegaraan = reader.GetString("kewarganegaraan")
                };
                biodataList.Add(biodata);
            }

            db.CloseConnection();
            return biodataList;
        }

        // alterTable untuk preprocess database dengan menambah atribut baru ascii di tabel sidik_jari
        // jika sudah ada maka akan diskip
        // atribut ascii yang ada akan dikonversi ke tipe longtext supaya bisa menampung data fulltext ASCII 
        public void alterTable()
        {
            db.OpenConnection();

            MySqlCommand checkColumnCmd = new MySqlCommand(
                "SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_NAME = 'sidik_jari' AND COLUMN_NAME = 'ascii'", 
                db.GetConnection()
            );
            int columnExists = Convert.ToInt32(checkColumnCmd.ExecuteScalar());

            if (columnExists > 0)
            {
                // Check the data type of the 'ascii' column
                MySqlCommand checkColumnTypeCmd = new MySqlCommand(
                    "SELECT DATA_TYPE FROM information_schema.COLUMNS WHERE TABLE_NAME = 'sidik_jari' AND COLUMN_NAME = 'ascii'", 
                    db.GetConnection()
                );
                string dataType = checkColumnTypeCmd.ExecuteScalar().ToString();

                // If the data type is not LONGTEXT, alter the column to LONGTEXT
                if (dataType.ToUpper() != "LONGTEXT")
                {
                    MySqlCommand alterColumnCmd = new MySqlCommand(
                        "ALTER TABLE sidik_jari MODIFY COLUMN ascii LONGTEXT", 
                        db.GetConnection()
                    );
                    alterColumnCmd.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine("Column 'ascii' modified to LONGTEXT.");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Column 'ascii' is already LONGTEXT.");
                }
            }
            else
            {
                // Add the 'ascii' column as LONGTEXT if it doesn't exist
                MySqlCommand addColumnCmd = new MySqlCommand(
                    "ALTER TABLE sidik_jari ADD COLUMN ascii LONGTEXT", 
                    db.GetConnection()
                );
                addColumnCmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Column 'ascii' added as LONGTEXT.");
            }

            db.CloseConnection();
        }
        public void insertAscii(string nama, string ascii){
            db.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("UPDATE sidik_jari SET ascii = @ascii WHERE nama = @nama", db.GetConnection());
            cmd.Parameters.AddWithValue("@ascii", ascii);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.ExecuteNonQuery();
            db.CloseConnection();
        }
    }
}

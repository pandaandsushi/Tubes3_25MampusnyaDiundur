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
                };
            }

            db.CloseConnection();
            return fingerprint;
        }

        public List<Fingerprint> GetAllFingerprintData()
        {
            List<Fingerprint> fingerprintList = new List<Fingerprint>();

            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sidik_jari", db.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Fingerprint fingerprint = new Fingerprint{
                    BerkasCitra = reader.GetString("berkas_citra"),
                    Nama = reader.GetString("nama"),
                    AsciiRepresent = reader.GetString("ascii_represent"),
                };
                fingerprintList.Add(fingerprint);
            }

            db.CloseConnection();
            return fingerprintList;
        }

        

        public List<string> GetAllBerkasCitra()
        {
            List<string> fingerprintList = new List<string>();

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
            List<Biodata> biodataList = new List<Biodata>();

            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM biodata WHERE nama = @nama", db.GetConnection());
            cmd.Parameters.AddWithValue("@nama", nama);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Biodata biodata = new Biodata
                {
                    Id = reader.GetInt32("id"),
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
            List<Biodata> biodataList = new List<Biodata>();

            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM biodata", db.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Biodata biodata = new Biodata
                {
                    Id = reader.GetInt32("id"),
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
    }
}

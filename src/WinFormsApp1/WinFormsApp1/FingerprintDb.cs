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

        public string GetFingerprintByName(string nama)
        {
            db.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT berkas_citra FROM sidik_jari WHERE nama = @nama", db.GetConnection());
            cmd.Parameters.AddWithValue("@nama", nama);
            MySqlDataReader reader = cmd.ExecuteReader();

            string berkas_citra = null;
            if (reader.Read())
            {
                //string base64String = reader["berkas_citra"].ToString();
                berkas_citra = reader["berkas_citra"].ToString();
            }

            db.CloseConnection();
            return berkas_citra;
        }
    }
}


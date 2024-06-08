using Bogus;
using WinFormsApp1.Algorithm;
namespace WinFormsApp1{
    public static class Dummy{

        public static void GenerateDummy(string projectDirectory, Fingerprints fingerprints){
            string[] imageFiles = Directory.GetFiles(projectDirectory, "*.bmp");
            Console.WriteLine($"{projectDirectory}");
            var faker = new Faker();
            foreach (string imagePath in imageFiles)
            {
                string fileName = Path.Combine("test", Path.GetFileName(imagePath));
                Person person = new Faker().Person;
                string name = person.FullName;
                fingerprints.InsertFingerprint(name, fileName);
                Console.WriteLine($"{name}, {fileName}");
                
                string NIK = faker.Random.Number(100000000, 999999999).ToString();
                string Nama = AlayTranslator.ConvertToAlay(name);
                string TempatLahir = faker.Address.City();
                DateTime TanggalLahir = faker.Date.Past(30, DateTime.Now.AddYears(-20));
                string JenisKelamin = faker.PickRandom(new[] { "Laki-Laki", "Perempuan" });
                string GolonganDarah = faker.PickRandom(new[] { "A", "B", "AB", "O" });
                string Alamat = faker.Address.FullAddress();
                string Agama = faker.PickRandom(new[] { "Islam", "Kristen", "Katolik", "Hindu", "Buddha", "Konghucu" });
                string StatusPerkawinan = faker.PickRandom(new[] { "Belum Menikah","Menikah","Cerai"});
                string Pekerjaan = faker.Name.JobTitle();
                string Kewarganegaraan = "Indonesian";
                fingerprints.InsertBiodata(NIK, Nama, TempatLahir, TanggalLahir, JenisKelamin, GolonganDarah, Alamat, Agama, StatusPerkawinan, Pekerjaan, Kewarganegaraan);
                Console.WriteLine($"{NIK}, {Nama}, {TempatLahir}, {TanggalLahir}, {JenisKelamin}, {GolonganDarah}, {Alamat}, {Agama}, {StatusPerkawinan}, {Pekerjaan}, {Kewarganegaraan}");
            }
        }
    }
}
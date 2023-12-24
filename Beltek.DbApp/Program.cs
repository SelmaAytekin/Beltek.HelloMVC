using System.Data;
using System.Data.SqlClient;

namespace Beltek.DbApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                var ogr = new Ogrenci();
                Console.WriteLine("Öğrenci adı giriniz:");
                ogr.Ad = Console.ReadLine();
                Console.WriteLine("Soyad giriniz:");
                ogr.Soyad = Console.ReadLine();
                Console.WriteLine("Numara giriniz:");
                ogr.Numara = Console.ReadLine();

                using (cn = new SqlConnection(@"Data Source=.;Initial Catalog=OkulDB;Integrated Security=true"))
                {
                    using (cmd = new SqlCommand($"Insert into tblOgrenciler values('{ogr.Ad}','{ogr.Soyad}','{ogr.Numara}')", cn))
                    {
                        cn.Open();
                        int sonuc = cmd.ExecuteNonQuery();
                        Console.WriteLine(sonuc > 0 ? "Ekleme başarılı" : "Ekleme Başarısız");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hata oluştu!");
            }
            finally
            {
                //if (cn != null && cn.State != ConnectionState.Closed)
                //{
                //    cn.Close();
                //    cn.Dispose();
                //    cmd.Dispose();
                //}
            }
        }
    }

    class Ogrenci
    {
        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }
    }
}

//.NET
//ADO.NET
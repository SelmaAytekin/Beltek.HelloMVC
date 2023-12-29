using System.Data;

namespace Beltek.HelloMVC.Models
{
    public class Ogretmen
    {
        public Ogretmen() //bu counstructor metot yapıcı metto yanı default olarak yazılır.
        {

        }

        public string Tckimlik { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string Alan { get; set; }


        public Ogretmen(string id, string ad, String soyad, string alan)
        {
            this.Tckimlik = id;
            this.Ad = ad;
            this.Soyad = soyad;

            this.Alan = alan;
        }

        public override string ToString()
        {
            return $"{this.Tckimlik} {this.Ad} {this.Soyad}  {this.Alan}";
        }
    }
}

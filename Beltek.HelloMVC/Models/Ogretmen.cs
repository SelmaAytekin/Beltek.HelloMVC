namespace Beltek.HelloMVC.Models
{
    public class Ogretmen
    {
        public string Tckimlik { get; set; }//Id Primary Key- Fluent Api 
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateOnly Dtar { get; set; }
    }
}

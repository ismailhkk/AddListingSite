using System.ComponentModel.DataAnnotations;

namespace AdListingsSite.Models
{
    public class Satis
    {
        [Required]
        public string Ad { get; set; }
    }
    public class Urun
    {
        public string Ad { get; set; }

        public int Fiyat { get; set; }
        public string Img { get; set; }
        public DateTime EklenmeTarihi { get; set; }


    }
}

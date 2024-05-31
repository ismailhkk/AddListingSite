using AdListingsSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdListingsSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(UrunleriGetir());
        }
        public List<Urun> UrunleriGetir()
        {
            var urunler = new List<Urun>();
            using StreamReader reader = new("App_Data/urunler.txt");
            var txt = reader.ReadToEnd();
            var txtLines = txt.Split('\n');
            foreach (var line in txtLines)
            {
                urunler.Add(
                    new Urun
                    {
                        Ad = line.Split('|')[0],
                        Fiyat = int.Parse(line.Split('|')[1])
                        
                    }
                   );
            }
            return urunler;
        }

        [HttpGet]
        public IActionResult IlanEkle(Satis model)
        {
            return View();

        }
        [HttpPost]
        public IActionResult UrunEkle(Urun urun) 
        {
            using StreamReader reader = new("App_Data/urunler.txt");
            var urunlerTxt = reader.ReadToEnd();
            reader.Close();

            if (!string.IsNullOrEmpty(urunlerTxt))
            {
                urunlerTxt += "\n";
            }

            using StreamWriter writer = new("App_Data/urunler.txt");
            writer.Write($"{urunlerTxt}{urun.Ad}|{urun.Fiyat}");
            return View("Index");

        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


    
        public IActionResult Index(string txtSearch)
        {
            

            Practico3.ApiBooks apiBooks = new Practico3.ApiBooks();
            string resultado = apiBooks.getLibros("flores+inauthor:Mario", "AIzaSyAgdYKA0w2X9ao_UtyLJIj5t6aKoeFi6P0");
            var Listalibros = JsonConvert.DeserializeObject<Libros>(resultado);
            if (Listalibros != null)
            {
                var busqueda = from b in Listalibros.Items
                               where string.Equals(b.VolumeInfo.Subtitle, txtSearch, StringComparison.OrdinalIgnoreCase)
                               select b;
                ViewBag.busquedaRealizada = txtSearch!= null;
                return View(busqueda);
            }

            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
    }
}
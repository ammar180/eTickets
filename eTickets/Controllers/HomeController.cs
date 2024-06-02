using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Movie movie = new Movie()
            {
                Name = "Life",
                Description = "This Description..",
                StartDate = new DateTime(7, 1, 10),
                EndDate = new DateTime(24, 6, 2),
                ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQo2b9bAIyvAPL_ij4Dtl0BDNEdcCxiweWdbw&s",
                Price = 599,
            };
            List<Movie> list = new List<Movie>();
            list.Add(movie);
            return View(list);
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

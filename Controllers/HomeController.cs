using G_5_BMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace G_5_BMS.Controllers
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
            var cards = new List<IndexModel>
    {        
        new IndexModel
        {
            Id = 1,
            Title = "Barangay Clearance",
            Description = "Request for a clearance",
            ImageUrl = "/Images/Home/Index/Clearance.png",
            Link = Url.Action("Clearance", "Home") 
        },
        new IndexModel
        {
            Id = 2,
            Title = "Barangay Permit",
            Description = "Request for a permit",
            ImageUrl = "/Images/Home/Index/papers.png",
            Link = Url.Action("Permit", "Home")
        },
        new IndexModel
        {
            Id = 3,
            Title = "Barangay ID",
            Description = "Request for an ID",
            ImageUrl = "/Images/Home/Index/ID.png",
            Link = Url.Action("IdentificationCard", "Home") 
        },
        new IndexModel
        {
            Id = 4,
            Title = "File Complain",
            Description = "Request for a blotter",
            ImageUrl = "/Images/Home/Index/papers.png",
            Link = Url.Action("Blotter", "Home")
        }
       };

            return View(cards);
        }

        public IActionResult Announcement()
        {
            return View();
        }

        public IActionResult Blotter()
        {
            return View();
        }

        public IActionResult Clearance()
        {
            return View();
        }

        public IActionResult IdentificationCard()
        {
            return View();
        }

        public IActionResult Organization()
        {
            return View();
        }

        public IActionResult Permit()
        {
            return View();
        }

        public IActionResult Feedback()
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

using G_5_BMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_5_BMS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Applications()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            var applications = new List<DashboardModel>
        {
            new DashboardModel { Id = 1, User = "John Doe", Status = "Pending", Email = "johndoe@gmail.com",DateSubmitted = DateTime.Parse("2024-09-01") },
            new DashboardModel { Id = 2, User = "Jane Smith", Status = "Pending",Email = "janesmith@gmail.com",DateSubmitted = DateTime.Parse("2024-09-05") },
            new DashboardModel { Id = 3, User = "Emily Johnson", Status = "Pending",Email = "emilyjohnson@gmail.com", DateSubmitted = DateTime.Parse("2024-09-10") }
        };

            return View(applications);
        }

        public IActionResult HomeContents()
        {
            return View();
        }

        public IActionResult Organization()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }
    }
}

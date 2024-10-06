using G_5_BMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace G_5_BMS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Applications()
        {
            var applications = new List<Application>
        {
            new Application
            {
                Name = "John Doe",
                ContactInformation = "+1 234 567 890",
                EmailAddress = "john.doe@example.com"
            },
            new Application
            {
                Name = "Jane Smith",
                ContactInformation = "+1 987 654 321",
                EmailAddress = "jane.smith@example.com"
            },
        };

            return View(applications);
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult HomeContents()
        {
            return View();
        }

        public IActionResult Organization()
        {
            var officials = new List<Officials>
            {
                new Officials { Id = 1, Title = "Barangay Captain" },
                new Officials { Id = 2, Title = "Kagawad 1" },
                new Officials { Id = 3, Title = "Kagawad 2" },
                new Officials { Id = 4, Title = "Kagawad 3" },
                new Officials { Id = 5, Title = "Kagawad 4" },
                new Officials { Id = 6, Title = "Kagawad 5" },
                new Officials { Id = 7, Title = "Kagawad 6" },
                new Officials { Id = 8, Title = "Secretary" }
            };

            return View(officials);
        }
    

        public IActionResult FAQs()
        {
            return View();
        }
        public IActionResult Pinfo()
        {
            return View();
        }
        public IActionResult Announcement()
        {
            return View();
        }
    }
}

using G_5_BMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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

        public ActionResult Announcement()
        {
            var announcements = new List<Announcement>
            {
                new Announcement { Title = "Annual Company Meeting", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", EventDate = new DateTime(2024, 10, 14), EventTime = "3:00 PM - 6:00 PM", Location = "Main Conference Room", RsvpEmail = "rsvp@example.com" },
                new Announcement { Title = "Team Building Event", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", EventDate = new DateTime(2024, 11, 5), EventTime = "10:00 AM - 2:00 PM", Location = "Outdoor Park", RsvpEmail = "team@example.com" },
                new Announcement { Title = "Holiday Party", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", EventDate = new DateTime(2024, 12, 20), EventTime = "6:00 PM - 10:00 PM", Location = "Rooftop Lounge", RsvpEmail = "holidayparty@example.com" },
            };

            return View(announcements);
        }

        public IActionResult Blotter()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Clearance()
        {
            return View(new Clearance());
        }

        [HttpPost]
        public IActionResult Clearance(Clearance model)
        {
            if (ModelState.IsValid)
            {               
                return Json(new { success = true }); 
            }          
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        public IActionResult IdentificationCard()
        {
            return View();
        }

        public IActionResult Organization()
        {
            var orgChart1 = new List<Org>
            {
                new Org
                {
                    Name = "Name",
                    Position = "Barangay Captain",
                    Description = "Leader of the barangay",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for health.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for education.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for infrastructure.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for youth.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for senior citizens.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for environment.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Barangay Secretary",
                    Description = "Handles administrative tasks.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                }
            };
            var orgChart2 = new List<Org>
            {
                new Org
                {
                    Name = "Name",
                    Position = "Barangay Chairman",
                    Description = "Leader of the barangay",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for culture.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for sports.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for safety.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for tourism.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for trade.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Kagawad",
                    Description = "Kagawad responsible for finance.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                },
                new Org
                {
                    Name = "Name",
                    Position = "Barangay Secretary",
                    Description = "Handles administrative tasks for barangay 2.",
                    ImageUrl = "/Images/Home/Orgchart/blankpic.png"
                }
            };

            var model = new
            {
                OrgChart1 = orgChart1,
                OrgChart2 = orgChart2
            };

            return View(model);
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

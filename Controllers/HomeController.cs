using G_5_BMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace G_5_BMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context; 

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
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
            Title = "Barangay Certificate",
            Description = "Request for a permit",
            ImageUrl = "/Images/Home/Index/papers.png",
            Link = Url.Action("Certificate", "Home")
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

         public async Task<IActionResult> Announcement()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            var homeContents = await _context.Announcements.ToListAsync();

            var viewModel = new Announcement
            {
                Announcements = homeContents // Populate the list
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Blotter()
        {
            return View(new Complain());
        }

        [HttpPost]
        public IActionResult Blotter(Complain model)
        {
            if (ModelState.IsValid)
            {
                _context.Complains.Add(model);
                _context.SaveChanges(); 

                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
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
                _context.Clearances.Add(model);
                _context.SaveChanges(); 

                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        [HttpGet]
        public IActionResult IdentificationCard()
        {
            var model = new ID
            {
                Birthday = DateTime.Now 
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult IdentificationCard(ID model)
        {
            if (ModelState.IsValid)
            {
                _context.Ids.Add(model);
                _context.SaveChanges();

                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
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
        [HttpGet]
        public IActionResult Certificate()
        {
            return View(new Certificate());
        }

        [HttpPost]
        public IActionResult Certificate(Certificate model)
        {
            if (ModelState.IsValid)
            {
                _context.Certificates.Add(model);
                _context.SaveChanges(); 

                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        public async Task<IActionResult> Feedback()
        {
            var faqsModel = new FAQViewModel
            {
                FAQs = await _context.Faqs.ToListAsync()
            };

            return View(faqsModel); // Pass the model to the view
        }
        [HttpPost]
        public IActionResult SubmitFeedback(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Feedbacks.Add(feedback); // Assuming you have a Feedbacks DbSet in your AppDbContext
                    _context.SaveChanges();

                    ViewBag.Message = "Feedback submitted successfully!";
                    return RedirectToAction("Feedback"); // Redirect to a confirmation page or the same page
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Error saving feedback. Please try again.");
                }
            }
            return View(feedback); // Return with validation errors if any
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using G_5_BMS.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using G_5_BMS.Views.Admin;
using G_5_BMS.Migrations;
using faqs = G_5_BMS.Models.faqs;
using OfficeOpenXml;

namespace G_5_BMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult AdminAuth()
        {
            return View();
        }
        [Authorize]
        public IActionResult Dashboard()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;

            var clearanceCount = _context.Clearances.Count();
            var certificateCount = _context.Certificates.Count();
            var idCount = _context.Ids.Count();
            var complainCount = _context.Complains.Count();

            ViewBag.Data = new
            {
                Clearances = clearanceCount,
                Certificates = certificateCount,
                Ids = idCount,
                Complains = complainCount
            };
            ViewBag.Clearances = _context.Clearances.OrderByDescending(c => c.CLId) 
                                                 .Take(5)
                                                 .ToList();
            ViewBag.Certificates = _context.Certificates.OrderByDescending(c => c.CRId) 
                                                            .Take(5)
                                                            .ToList();
            ViewBag.Ids = _context.Ids.OrderByDescending(i => i.RId) 
                                          .Take(5)
                                          .ToList();
            ViewBag.Complains = _context.Complains.OrderByDescending(c => c.ComId) 
                                                      .Take(5)
                                                      .ToList();
            return View();
        }
        public IActionResult Dashboards()
        {
            return View(_context.UserAccounts.ToList());
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserAccount account = new UserAccount();
                account.Email = model.Email;
                account.FirstName = model.FirstName;
                account.LastName = model.LastName;
                account.Password = model.Password;
                account.UserName = model.UserName;

                try
                {
                    _context.UserAccounts.Add(account);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = $"{account.FirstName} {account.LastName} registered successfully. Please Login.";

                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Please Enter unique Email or Password.");
                    return View(model);
                }
                return View();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AdminAuth(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts.Where(x => (x.UserName == model.UserNameOrEmail || x.Email == model.UserNameOrEmail) && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.FirstName),
                        new Claim("Email", user.Email),
                        new Claim(ClaimTypes.Role, "User"),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Username/Email or Password is not correct");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("AdminAuth");
        }

        public async Task<IActionResult> Applications(string searchQuery = "")
        {
            var clearances = await _context.Clearances.ToListAsync();
            var permits = await _context.Certificates.ToListAsync();
            var ids = await _context.Ids.ToListAsync();
            var complains = await _context.Complains.ToListAsync();

            //search
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                clearances = clearances.Where(c => c.FirstName.Contains(searchQuery) ||
                                                    c.LastName.Contains(searchQuery) ||
                                                    c.ContactNumber.Contains(searchQuery))
                                       .ToList();

                permits = permits.Where(p => p.FirstName.Contains(searchQuery) ||
                                              p.LastName.Contains(searchQuery) ||
                                              p.ContactNumber.Contains(searchQuery))
                                 .ToList();

                ids = ids.Where(i => i.FirstName.Contains(searchQuery) ||
                                     i.LastName.Contains(searchQuery) ||
                                     i.ContactNumber.Contains(searchQuery))
                         .ToList();

                complains = complains.Where(c => c.FullName.Contains(searchQuery))
                                     .ToList();
            }
            else
            {
                var originalClearances = clearances.ToList();
                var originalPermits = permits.ToList();
                var originalIds = ids.ToList();
                var originalComplains = complains.ToList();
            }

            var applicationModel = new Application
            {
                Clearances = clearances,
                Permits = permits,
                Ids = ids,
                Complains = complains
            };

            ViewBag.Name = HttpContext.User.Identity.Name;
            ViewBag.SearchQuery = searchQuery;

            ViewBag.HasClearances = clearances.Any();
            ViewBag.HasPermits = permits.Any();
            ViewBag.HasIds = ids.Any();
            ViewBag.HasComplains = complains.Any();

            return View(applicationModel);
        }

        public async Task<IActionResult> HomeContents()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            var homeContents = await _context.Announcements.ToListAsync();

            var viewModel = new Announcement
            {
                Announcements = homeContents // Populate the list
            };

            return View(viewModel);
        }

        // POST: Add Announcement
        [HttpPost]
        public async Task<IActionResult> Create(HomeContents homeContents)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Announcements.Add(homeContents); // Use the Announcements DbSet
                    await _context.SaveChangesAsync();

                    ViewBag.Message = "Announcement added successfully!";
                    return RedirectToAction("Index"); // Redirect to an appropriate action
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Error saving announcement. Please try again.");
                    return View(homeContents); // Return to the view with the model data
                }
            }
            return View(homeContents); // Return with validation errors
        }
        public IActionResult Organization()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;

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

        public IActionResult Announcement()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }



        // GET: FAQs
        // GET: FAQs
        public async Task<IActionResult> FAQs()
        {
            var faqsModel = new FAQViewModel
            {
                FAQs = await _context.Faqs.ToListAsync(),
                Feedbacks = await _context.Feedbacks.ToListAsync()
            };

            return View(faqsModel); // Pass the model to the view
        }


        // POST: FAQs/Add
        [HttpPost]
        public IActionResult Add(faqs faq)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Faqs.Add(faq);
                    _context.SaveChanges();

                    ViewBag.Message = "FAQ added successfully!";
                    return RedirectToAction("FAQs"); // Redirect after successful add
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Error saving FAQ. Please try again.");
                    return View(faq);
                }
            }
            return View(faq); // Return with validation errors
        }

        public IActionResult Pinfo()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;

            var user = _context.UserAccounts.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user != null)
            {
                ViewBag.FirstName = user.FirstName;
                ViewBag.Email = user.Email;
                ViewBag.Password = user.Password;
            }

            return View();
        }

        //Excel of clearances

        public IActionResult ExportClearances()
        {
            var clearances = _context.Clearances.ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Clearances");

                worksheet.Cells[1, 1].Value = "Clearance ID";
                worksheet.Cells[1, 2].Value = "First Name";
                worksheet.Cells[1, 3].Value = "Middle Name";
                worksheet.Cells[1, 4].Value = "Last Name";
                worksheet.Cells[1, 5].Value = "Suffix";
                worksheet.Cells[1, 6].Value = "Address";
                worksheet.Cells[1, 7].Value = "Contact Number";
                worksheet.Cells[1, 8].Value = "Email Address";
                worksheet.Cells[1, 9].Value = "Business Name";

                for (int i = 0; i < clearances.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = clearances[i].CLId;
                    worksheet.Cells[i + 2, 2].Value = clearances[i].FirstName;
                    worksheet.Cells[i + 2, 3].Value = clearances[i].MiddleName;
                    worksheet.Cells[i + 2, 4].Value = clearances[i].LastName;
                    worksheet.Cells[i + 2, 5].Value = clearances[i].Suffix;
                    worksheet.Cells[i + 2, 6].Value = clearances[i].Address;
                    worksheet.Cells[i + 2, 7].Value = clearances[i].ContactNumber;
                    worksheet.Cells[i + 2, 8].Value = clearances[i].EmailAddress;
                    worksheet.Cells[i + 2, 9].Value = clearances[i].BusinessName;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                var fileName = "ClearancesReport.xlsx";
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
        
        public IActionResult ExportCertificates()
        {
            var certificates = _context.Certificates.ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Certificates");

                worksheet.Cells[1, 1].Value = "Clearance ID";
                worksheet.Cells[1, 2].Value = "First Name";
                worksheet.Cells[1, 3].Value = "Middle Name";
                worksheet.Cells[1, 4].Value = "Last Name";
                worksheet.Cells[1, 5].Value = "Suffix";
                worksheet.Cells[1, 6].Value = "Gender";
                worksheet.Cells[1, 7].Value = "Address";
                worksheet.Cells[1, 8].Value = "Contact Number";
                worksheet.Cells[1, 9].Value = "Email Address";
                worksheet.Cells[1, 10].Value = "Year of Residence";
                worksheet.Cells[1, 11].Value = "Purpose";

                for (int i = 0; i < certificates.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = certificates[i].CRId;
                    worksheet.Cells[i + 2, 2].Value = certificates[i].FirstName;
                    worksheet.Cells[i + 2, 3].Value = certificates[i].MiddleName;
                    worksheet.Cells[i + 2, 4].Value = certificates[i].LastName;
                    worksheet.Cells[i + 2, 5].Value = certificates[i].Suffix;
                    worksheet.Cells[i + 2, 6].Value = certificates[i].Gender;
                    worksheet.Cells[i + 2, 7].Value = certificates[i].Address;
                    worksheet.Cells[i + 2, 8].Value = certificates[i].ContactNumber;
                    worksheet.Cells[i + 2, 9].Value = certificates[i].EmailAddress;
                    worksheet.Cells[i + 2, 10].Value = certificates[i].Year;
                    worksheet.Cells[i + 2, 11].Value = certificates[i].Purpose;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                var fileName = "CertificatesReport.xlsx";
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        public IActionResult ExportIds()
        {
            var ids = _context.Ids.ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Identification Cards");

                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "First Name";
                worksheet.Cells[1, 3].Value = "Middle Name";
                worksheet.Cells[1, 4].Value = "Last Name";
                worksheet.Cells[1, 5].Value = "Suffix";
                worksheet.Cells[1, 6].Value = "Gender";
                worksheet.Cells[1, 7].Value = "Civil Status";
                worksheet.Cells[1, 8].Value = "Citizenship";
                worksheet.Cells[1, 9].Value = "Birthday";
                worksheet.Cells[1, 10].Value = "Age";
                worksheet.Cells[1, 11].Value = "Address";
                worksheet.Cells[1, 12].Value = "Contact Number";
                worksheet.Cells[1, 13].Value = "Email Address";

                for(int i = 0; i < ids.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = ids[i].RId;
                    worksheet.Cells[i + 2, 2].Value = ids[i].FirstName;
                    worksheet.Cells[i + 2, 3].Value = ids[i].MiddleName;
                    worksheet.Cells[i + 2, 4].Value = ids[i].LastName;
                    worksheet.Cells[i + 2, 5].Value = ids[i].Suffix;
                    worksheet.Cells[i + 2, 6].Value = ids[i].Gender;
                    worksheet.Cells[i + 2, 7].Value = ids[i].CivilStatus;
                    worksheet.Cells[i + 2, 8].Value = ids[i].Citizenship;
                    worksheet.Cells[i + 2, 9].Value = ids[i].Birthday;
                    worksheet.Cells[i + 2, 10].Value = ids[i].Age;
                    worksheet.Cells[i + 2, 11].Value = ids[i].Address;
                    worksheet.Cells[i + 2, 12].Value = ids[i].ContactNumber;
                    worksheet.Cells[i + 2, 13].Value = ids[i].EmailAddress;
                }
                var stream = new MemoryStream();
                package.SaveAs(stream);
                var fileName = "IDsReport.xlsx";
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        public IActionResult ExportComplains()
        {
            var complains = _context.Complains.ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Complains");

                worksheet.Cells[1, 1].Value = "Complains ID";
                worksheet.Cells[1, 2].Value = "Full Name";
                worksheet.Cells[1, 3].Value = "Address";
                worksheet.Cells[1, 4].Value = "Contact Number";
                worksheet.Cells[1, 5].Value = "Email Address";
                worksheet.Cells[1, 6].Value = "Description of Complaint";

                for(int i = 0; i < complains.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = complains[i].ComId;
                    worksheet.Cells[i + 2, 2].Value = complains[i].FullName;
                    worksheet.Cells[i + 2, 3].Value = complains[i].Address;
                    worksheet.Cells[i + 2, 4].Value = complains[i].ContactNumber;
                    worksheet.Cells[i + 2, 5].Value = complains[i].EmailAddress;
                    worksheet.Cells[i + 2, 6].Value = complains[i].Description;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                var fileName = "ComplainsReport.xlsx";
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

               
        }

    }


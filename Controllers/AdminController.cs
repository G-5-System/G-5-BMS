using G_5_BMS.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using G_5_BMS.Views.Admin;

namespace G_5_BMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult AdminAuth()
        {
            return View();
        }
        [Authorize]
        public IActionResult Dashboard()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
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
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts.Where(x => (x.UserName == model.UserNameOrEmail || x.Email == model.UserNameOrEmail) && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    //Success, create cookie
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

        public async Task<IActionResult> Applications()
        {
            var applicationModel = new Application
            {
                Clearances = await _context.Clearances.ToListAsync(),
                Permits = await _context.Certificates.ToListAsync(),
                Ids = await _context.Ids.ToListAsync(),
                Complains = await _context.Complains.ToListAsync()
            };

            ViewBag.Name = HttpContext.User.Identity.Name; // Store the user's name in ViewBag for use in the view
            return View(applicationModel);
        }

        public IActionResult HomeContents()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
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
    

        public IActionResult FAQs()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
        public IActionResult Pinfo()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
        public IActionResult Announcement()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace G_5_BMS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View(); 
        }
    }
}


using Microsoft.AspNetCore.Mvc;

namespace G_5_BMS.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult AdminAuth()
        {
            return View();
        }
    }
}

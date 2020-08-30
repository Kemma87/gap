using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Web.Controllers
{
    [AllowAnonymous]
    public class PrivacyPolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

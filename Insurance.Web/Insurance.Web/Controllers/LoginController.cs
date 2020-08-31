using Insurance.Web.Client;
using Insurance.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Insurance.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IAppClient _client;

        public LoginController(IConfiguration config, IAppClient client)
        {
            _config = config;
            _client = client;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var response = await _client.LoginAsync(login);

                var status = JsonConvert.DeserializeObject<ApiResponse>(response);
                int.TryParse(status.Status, out int statusCode);

                if (statusCode == 0 || statusCode == 200 || statusCode == 201)
                {
                    var user = JsonConvert.DeserializeObject<UserModel>(response);
                    HttpContext.Session.SetString("token", user.Token);
                    HttpContext.Session.SetString("name", $"{user.FirstName} {user.LastName}");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("roles");
            HttpContext.Session.Remove("name");
            ViewBag.Message = "User logged out successfully!";
            return View("Index");
        }

    }
}

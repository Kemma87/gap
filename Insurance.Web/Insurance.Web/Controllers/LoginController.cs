using Insurance.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
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
                using var httpClient = new HttpClient();
                var content = JsonConvert.SerializeObject(login);

                using var response = await httpClient.PostAsync($"{_config.GetSection("AppSettings:BaseUrl").Value}/api/auth/login", 
                    new StringContent(content, Encoding.UTF8, "application/json"));
                string apiResponse = await response.Content.ReadAsStringAsync();

                var status = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);
                int.TryParse(status.Status, out int statusCode);

                if (statusCode == 0 || statusCode == 200 || statusCode == 201)
                {
                    var user = JsonConvert.DeserializeObject<UserModel>(apiResponse);
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

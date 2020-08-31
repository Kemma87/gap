using Insurance.Web.Client;
using Insurance.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Insurance.Web.Controllers
{
    [Authorize(Roles = "Administrator, CustomerService")]
    public class HomeController : Controller
    {
        private readonly IAppClient _client;

        public HomeController(IAppClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var insurances = await _client.GetInsurancesAsync();
            return View(insurances);
        }

        public async Task<IActionResult> Edit()
        {
            var insurances = await _client.GetInsurancesAsync();
            return View(insurances);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteInsuranceAsync(id);
            var insurances = await _client.GetInsurancesAsync();

            return View("Index", insurances);
        }

        public async Task<IActionResult> Update()
        {
            var insurances = await _client.GetInsurancesAsync();
            return View(insurances);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

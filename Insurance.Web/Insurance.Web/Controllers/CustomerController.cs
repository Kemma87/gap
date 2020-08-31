using Insurance.Web.Client;
using Insurance.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Web.Controllers
{
    [Authorize(Roles = "Administrator, CustomerService")]
    public class CustomerController : Controller
    {
        private readonly IAppClient _client;

        public CustomerController(IAppClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var personList = await _client.GetAllPersonsAsync();

            if (personList.Count > 0)
            {
                ViewBag.Person = personList;
                var personId = personList.FirstOrDefault().Id;

                var model = new PersonInsuranceModel
                {
                    PersonId = personList.FirstOrDefault().Id,
                    Insurances = await _client.GetInsuranceByPersonAsync(personId)
                };

                return View(model);
            }

            return View();
        }
    }
}

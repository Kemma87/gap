using Insurance.Web.Client;
using Insurance.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
                    Insurances = await _client.GetInsuranceByPersonAsync(personId),
                    RiskTypes = await _client.GetAllRiskTypesAsync()
            };

                return View(model);
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Associate()
        {
            ViewBag.Person = await _client.GetAllPersonsAsync();
            ViewBag.Insurances = await _client.GetInsurancesAsync();

            return View();
        }

        public async Task<IActionResult> AddInsuranceToPerson(PersonInsuranceModel insurancePerson)
        {
            await _client.AddPersonInsuranceAsync(insurancePerson.PersonId, insurancePerson.InsuranceId);
            return RedirectToAction("Index", "Customer");
        }

        public async Task<IActionResult> DeleteInsurance(int insuranceId, int personId)
        {
            await _client.RemovePersonInsuranceAsync(personId, insuranceId);
            return RedirectToAction("Index", "Customer");
        }
    }
}

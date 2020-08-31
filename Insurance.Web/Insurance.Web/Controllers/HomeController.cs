using AutoMapper;
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
        private readonly IMapper _mapper;

        public HomeController(IAppClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var insurances = await _client.GetInsurancesAsync();
            return View(insurances);
        }

        public async Task<IActionResult> LoadAddData()
        {
            ViewBag.Locations = await _client.GetAllLocationsAsync();
            ViewBag.CoverTypes = await _client.GetAllCoverTypesAsync();
            ViewBag.RiskTypes = await _client.GetAllRiskTypesAsync();

            return View("Add");
        }

        public async Task<IActionResult> LoadEditData(int id)
        {
            ViewBag.Locations = await _client.GetAllLocationsAsync();
            ViewBag.CoverTypes = await _client.GetAllCoverTypesAsync();
            ViewBag.RiskTypes = await _client.GetAllRiskTypesAsync();

            var insurance = await _client.GetInsuranceByIdAsync(id);
            var insuranceToReturn = _mapper.Map<InsuranceNewEditModel>(insurance);

            return View("Edit", insuranceToReturn);
        }

        public async Task<IActionResult> Add(InsuranceNewEditModel insurance)
        {
            await _client.AddInsuranceAsync(insurance);
            var insurances = await _client.GetInsurancesAsync();

            return View("Index", insurances);
        }

        public async Task<IActionResult> Edit(InsuranceModel insurance)
        {
            await _client.UpdateInsuranceAsync(insurance);

            var insurances = await _client.GetInsurancesAsync();

            return View("Index", insurances);
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

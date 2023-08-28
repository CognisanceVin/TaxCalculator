using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.OpenApi.Validations;
using System.Diagnostics;
using System.Net.WebSockets;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Frontend.Models;
using TaxCalculator.WebApi.Controllers;

namespace TaxCalculator.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private ITaxService _taxService;
        private IReferenceListService _referenceListService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ITaxService taxService, IReferenceListService referenceListService)
        {
            _logger = logger;
            _taxService = taxService;
            _referenceListService = referenceListService;
        }

        public async Task<IActionResult> Index()
        {
            var taxController = new TaxCalculatorController(_taxService, _referenceListService);
            Models.TaxModel model = new Models.TaxModel();
                var response = await taxController.GetPostalCodes();
            model.Codes = new List<SelectListItem>();
            foreach (var item in response.postalCodes)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Code;
                selectListItem.Value = item.Code;
                model.Codes.Add(selectListItem);
            }

            return View(model);
        }

        public JsonResult SaveForm([FromBody] TaxModel data)
        {

            var taxController = new TaxCalculatorController(_taxService, _referenceListService);
           
            var response = taxController.CalculateTaxRate(data.PostalCode, data.AnnualIncome);
            return Json(response.Result.TaxAmount);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
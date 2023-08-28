using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Models;
using TaxCalculator.Domain.Entities.ReferenceData;
using TaxCalculator.Models;

namespace TaxCalculator.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private ITaxService _taxService;
        private IReferenceListService _referenceListService;

        //private readonly ILogger<TaxCalculatorController> _logger;

        public TaxCalculatorController(
            ITaxService taxService, 
            IReferenceListService referenceListService)
        {
            //_logger = logger;
            _taxService = taxService;
            _referenceListService = referenceListService;
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("getPostalCodes")]
        public async Task<PostalCodeDto> GetPostalCodes()
        {
            return await _referenceListService.GetPostalCodes();
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("getTaxRates")]
        public async Task<TaxBaseRateListDto> GetTaxRates()
        {
            return await _referenceListService.GetTaxRates();
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("calculateTax")]
        public async Task<CalculatedTaxDto> CalculateTaxRate(string postalCode, double income)
        {
            return await _taxService.SaveCalculatedTax(postalCode, income);
        }
    }


}
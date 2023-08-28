using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Models;
using TaxCalculator.Domain.Entities.ReferenceData;
using TaxCalculator.Domain.Interfaces;

namespace TaxCalculator.Application.Services
{
    public class ReferenceListService : IReferenceListService
    {

        private ICommonRepository _commonRepository;

        public ReferenceListService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }
        public async Task<PostalCodeDto> GetPostalCodes()
        {
            return new PostalCodeDto() {
                postalCodes = await  _commonRepository.GetCodes()
            };
        }

        public async Task<TaxBaseRateDto> GetTaxRate(string postalCode)
        {
            return new TaxBaseRateDto()
            {
                taxRate = await _commonRepository.GetRate()
            };
        }

        public async Task<TaxBaseRateListDto> GetTaxRates()
        {
            return new TaxBaseRateListDto()
            {
                taxRates = await _commonRepository.GetRates()
            };
        }
    }
}

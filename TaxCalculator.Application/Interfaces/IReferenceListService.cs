using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Models;
using TaxCalculator.Domain.Entities.ReferenceData;

namespace TaxCalculator.Application.Interfaces
{
    public interface IReferenceListService
    {
        Task<PostalCodeDto> GetPostalCodes();
        Task<TaxBaseRateListDto> GetTaxRates();
        Task<TaxBaseRateDto> GetTaxRate(string postalCode);
    }
}

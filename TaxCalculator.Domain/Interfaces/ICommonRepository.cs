using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Entities.ReferenceData;

namespace TaxCalculator.Domain.Interfaces
{
    public interface ICommonRepository
    {
        Task<IEnumerable<PostalCode>> GetCodes();
        Task<string> GetTaxType(string code);
        Task<IEnumerable<TaxBaseRate>> GetRates();
        Task<TaxBaseRate> GetRate();
    }
}

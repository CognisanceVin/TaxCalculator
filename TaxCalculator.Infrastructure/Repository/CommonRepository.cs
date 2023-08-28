using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Domain.Entities.ReferenceData;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Infrastructure.Persistence;

namespace TaxCalculator.Infrastructure.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private TaxCalculatorContext _context;

        public CommonRepository(TaxCalculatorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostalCode>> GetCodes()
        {
            return _context.PostalCodes;
        }

        public async Task<TaxBaseRate> GetRate()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaxBaseRate>> GetRates()
        { 
            return  _context.TaxBaseRates;
        }

        public async Task<string> GetTaxType(string code)
        {
            return await _context.PostalCodes.Where(i => i.Code == code)
            .Select(i => i.TaxType)
            .SingleOrDefaultAsync(); 
        }
    }
}

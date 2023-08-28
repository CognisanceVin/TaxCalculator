using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Infrastructure.Persistence;

namespace TaxCalculator.Infrastructure.Repository
{
    public class CalculatedTaxRepository : ICalculatedTaxRepository
    {
        private TaxCalculatorContext _context;
        public CalculatedTaxRepository(TaxCalculatorContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveCalculated(double tax, double income, string postalCode)
        {
            try
            {
                CalculatedTax newRecord = new CalculatedTax()
                {
                    AnnualIncome = income,
                    TaxAmount = tax,
                    PostalCode = postalCode,
                    DateCalculated = DateTime.UtcNow

                };
                await _context.AddAsync(newRecord);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}

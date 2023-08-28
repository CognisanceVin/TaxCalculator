using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Models;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Entities.ReferenceData;

namespace TaxCalculator.Application.Interfaces
{
    public interface ITaxService
    {
        Task<CalculatedTaxDto> SaveCalculatedTax (string postalCode, double income);
    }
}

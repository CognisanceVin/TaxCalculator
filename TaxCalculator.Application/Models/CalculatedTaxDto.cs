using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Application.Models
{
    public class CalculatedTaxDto
    {
        public double AnnualIncome { get; set; }
        public double TaxAmount { get; set; }
        public string? PostalCode { get; set; }
    }
}

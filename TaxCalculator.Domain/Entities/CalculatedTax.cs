using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Domain.Entities
{
    [Table("CalculatedTax", Schema = "dbo")]
    public class CalculatedTax : BaseEntity
    {
        public double AnnualIncome { get; set; }
        public string? PostalCode { get; set; }
        public double TaxAmount { get; set; }
        public double Rate { get; set; }
        public DateTime DateCalculated { get; set; }
    }
}

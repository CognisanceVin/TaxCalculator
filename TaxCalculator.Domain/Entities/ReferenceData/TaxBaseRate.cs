using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Domain.Entities.ReferenceData
{
    [Table("TaxRates", Schema = "lookup")]
    public class TaxBaseRate : BaseEntity
    {
        [Required]
        public int Rate { get; set; }
        public double FromAmount { get; set; }
        public double ToAmount { get; set; }
    }
}

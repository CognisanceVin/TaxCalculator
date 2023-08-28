using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Domain.Entities.ReferenceData
{
    [Table("PostalCodes", Schema ="lookup")]
    public class PostalCode: BaseEntity
    {
        [Required]
        [StringLength(4)]
        public string Code { get; set; }

        [StringLength(20)]
        [Description("Describes the tax calculation type")]
        public string TaxType { get; set; }



        
    }
}

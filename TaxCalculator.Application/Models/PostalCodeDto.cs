using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Domain.Entities.ReferenceData;

namespace TaxCalculator.Application.Models
{
    public class PostalCodeDto
    {
        public IEnumerable<PostalCode> postalCodes { get; set; }
    }
}

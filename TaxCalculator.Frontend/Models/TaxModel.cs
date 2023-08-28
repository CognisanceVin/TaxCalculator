using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.Application.Models;

namespace TaxCalculator.Frontend.Models
{
    public class TaxModel
    {

        [Required(ErrorMessage = "You must enter your annual income.")]        
        public double AnnualIncome { get; set; }
        [Required(ErrorMessage = "You must select a postal code.")]
        public string? PostalCode { get; set; }

        [Required(ErrorMessage = "You must select a postal code.")]
        public List<SelectListItem> Codes { get; set; }

    }
}

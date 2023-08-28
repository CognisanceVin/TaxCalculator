using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaxCalculator.Application.BusinessLogic
{
    public class MyTaxCalculator
    {
        public MyTaxCalculator( ) { 
        }

        public void CalculateTax(string postalType, decimal amount) { 
            
        }
        public double ProgressiveTax(double annualIncome)
        {
            double totalTax;
            if(annualIncome <= 8350)
            {
                totalTax = annualIncome * 0.10;
            }else if(annualIncome > 8350 & annualIncome <= 33950)
            {
                totalTax = 8350 * 0.10;

                totalTax += (annualIncome - 8350) * 0.15;

            }
            else if (annualIncome > 33950 & annualIncome <= 82250)
            {
                totalTax = 8350 * 0.10;

                totalTax += (33950 - 8350) * 0.15;

                totalTax += (annualIncome - 33950) * 0.25;

            }
            else if (annualIncome > 82250 & annualIncome <= 171550)
            {

                totalTax = 8350 * 0.10;

                totalTax += (33950 - 8350) * 0.15;

                totalTax += (82250 - 33950) * 0.25;

                totalTax += (annualIncome - 82250) * 0.28;
            }
            else if (annualIncome > 171550 & annualIncome <= 372950)
            {
                totalTax = 8350 * 0.10;

                totalTax += (33950 - 8350) * 0.15;

                totalTax += (82250 - 33950) * 0.25;

                totalTax += (171550 -82250) * 0.28;

                totalTax += (annualIncome - 171550) * 0.33;
            }
            else
            {
                totalTax = 8350 * 0.10;

                totalTax += (33950 - 8350) * 0.15;

                totalTax += (82250 - 33950) * 0.25;

                totalTax += (171550 - 82250) * 0.28;

                totalTax += (372950 - 171550) * 0.33;
                totalTax += (annualIncome - 372950) * 0.35;

            }
            return Math.Round(totalTax, 2);
        }
        public double FlatValueTax(double annualIncome)
        {
            if (annualIncome < 200000)
                return Math.Round(annualIncome * 0.05,2);

            else
                return 10000;

        }
        public double FlatRateTax(double annualIncome)
        {
            return Math.Round(annualIncome * 0.175, 2);
        }
    }
}

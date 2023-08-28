using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.BusinessLogic;

namespace TaxCalculator.Tests.Application
{
    [TestFixture]
    public class TaxCalculationTests : TestBase
    {
        [TestCase(4000, ExpectedResult = 400)]
        [TestCase(14000, ExpectedResult = 1682.50)]
        [TestCase(55000, ExpectedResult = 9937.50)]
        [TestCase(107500, ExpectedResult = 23820)]
        [TestCase(400000, ExpectedResult = 117683.5)]
        public double myTaxCalculatorProgressiveTax_ShouldReturnCorrectTaxAmount(double income)
        {
            double taxAmount = _myTaxCalculator.ProgressiveTax(income);
            return taxAmount;
        }

        [TestCase(30000, ExpectedResult = 5250)]
        [TestCase(60000, ExpectedResult = 10500)]
        [TestCase(70000, ExpectedResult = 12250)]
        [TestCase(100000, ExpectedResult = 17500)]
        public double myTaxCalculatorFlatRateTax_ShouldReturnCorrectTaxAmount(double income)
        {
            double taxAmount = _myTaxCalculator.FlatRateTax(income);
            return taxAmount;
        }


        [TestCase(30000, ExpectedResult = 1500)]
        [TestCase(60000, ExpectedResult = 3000)]
        [TestCase(70000, ExpectedResult = 3500)]
        [TestCase(100000, ExpectedResult = 5000)]
        public double myTaxCalculatorFlatValueTax_ShouldReturnCorrectTaxAmount(double income)
        {
            double taxAmount = _myTaxCalculator.FlatValueTax(income);
            return taxAmount;
        }
    }
}

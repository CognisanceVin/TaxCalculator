using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.BusinessLogic;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Models;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Entities.ReferenceData;
using TaxCalculator.Domain.Interfaces;

namespace TaxCalculator.Application.Services
{
    public class TaxService : ITaxService
    {

        private ICommonRepository _commonRepository;

        private ICalculatedTaxRepository _calculatedTaxRepository;
        public TaxService(ICommonRepository commonRepository, ICalculatedTaxRepository calculatedTaxRepository)
        {
            _commonRepository = commonRepository;
            _calculatedTaxRepository = calculatedTaxRepository;
        }
        public async Task<CalculatedTaxDto> SaveCalculatedTax(string postalCode, double income)
        {

            var taxType = await _commonRepository.GetTaxType(postalCode);
            double tax;

            MyTaxCalculator calculator = new MyTaxCalculator();
            switch (taxType)
            {
                case "Progressive":
                    tax = calculator.ProgressiveTax(income);
                    break;
                case "FlatValue":
                    tax = calculator.FlatValueTax(income);
                    break;
                default:
                    tax = calculator.FlatRateTax(income);
                    break;
            }

            if (await _calculatedTaxRepository.SaveCalculated(tax, income, postalCode))
            {
                return new CalculatedTaxDto()
                {
                    AnnualIncome = income,
                    TaxAmount = tax,
                    PostalCode = postalCode,
                };
            }
            else
            {

                throw new NotImplementedException();
            }

        }
    }
}

using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Models;
using TaxCalculator.Application.Services;
using TaxCalculator.Domain.Entities.ReferenceData;

namespace TaxCalculator.Tests.Application
{
    public class ReferenceListServiceTests : TestBase
    {
        [Test]
        public async Task GetPostalCodes_ShouldReturnPostalCodeDtoWithCodes()
        {
            // Arrange
            var expectedPostalCodes = new List<PostalCode>
        {
            new PostalCode { Code = "7441" , TaxType = "Progressive" },
            new PostalCode { Code = "A100", TaxType = "FlatValue" },
            new PostalCode { Code = "7000", TaxType = "FlatRate" },
            new PostalCode { Code = "1000", TaxType = "Progressive" }
        };
            _mockCommonRepository.Setup(repo => repo.GetCodes()).ReturnsAsync(expectedPostalCodes);

            var referenceListService = new ReferenceListService(_mockCommonRepository.Object);

            // Act
            var result = await referenceListService.GetPostalCodes();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedPostalCodes.Count, result.postalCodes.ToList().Count);
            Assert.AreEqual(expectedPostalCodes[1].Code, result.postalCodes.ToList()[1].Code);
            Assert.AreEqual(expectedPostalCodes[3].Code, result.postalCodes.ToList()[3].Code);
        }

        [Test]
        public async Task GetTaxRates_ShouldReturnTaxRateListDtoWithRates()
        {
            // Arrange
            var expectedTaxRates = new List<TaxBaseRate>
        {
            new TaxBaseRate { Rate = 10, FromAmount = 0.00, ToAmount = 8350.00},
            new TaxBaseRate { Rate = 10, FromAmount = 8351.00, ToAmount = 33950.00},
            new TaxBaseRate { Rate = 10, FromAmount = 33951.00, ToAmount = 82250.00},
            new TaxBaseRate { Rate = 10, FromAmount = 82251.00, ToAmount = 171550.00},
            new TaxBaseRate { Rate = 10, FromAmount = 171551.00, ToAmount = 372950.00},
            new TaxBaseRate { Rate = 10, FromAmount = 372951.00, ToAmount = 0.00}
        };
            _mockCommonRepository.Setup(repo => repo.GetRates()).ReturnsAsync(expectedTaxRates);

            var referenceListService = new ReferenceListService(_mockCommonRepository.Object);

            // Act
            var result = await referenceListService.GetTaxRates();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedTaxRates.Count, result.taxRates.ToList().Count);
            Assert.AreEqual(expectedTaxRates[3].ToAmount, result.taxRates.ToList()[3].ToAmount);
            Assert.AreEqual(expectedTaxRates[5].FromAmount, result.taxRates.ToList()[5].FromAmount);

        }

    }
}

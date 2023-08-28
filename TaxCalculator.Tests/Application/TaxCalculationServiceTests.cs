using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Services;
using TaxCalculator.Domain.Interfaces;

namespace TaxCalculator.Tests.Application
{
    [TestFixture]
    public class TaxCalculationServiceTests : TestBase
    {
        [Test]
        public async Task SaveCalculatedTax_ShouldCallRepositoryAndReturnDto()
        {
            // Arrange

            // Set up the mock repository to return a value
            _mockCalculatedTaxRepo.Setup(repo => repo.SaveCalculated(8750, 50000, "7441"))
                          .ReturnsAsync(true);

            var taxCalculationService = new TaxService(_mockCommonRepository.Object,_mockCalculatedTaxRepo.Object);

            // Act
            var result = await taxCalculationService.SaveCalculatedTax("7441", 50000.0);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("7441", result.PostalCode); // Assuming PostalCode is a property in CalculatedTaxDto
            Assert.AreEqual(50000.0, result.AnnualIncome); // Assuming Income is a property in CalculatedTaxDto
            _mockCalculatedTaxRepo.Verify(repo => repo.SaveCalculated(8750, 50000, "7441"), Times.Once);


        }
    }
}


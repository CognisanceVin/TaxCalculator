using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using TaxCalculator.Application.BusinessLogic;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Infrastructure.Persistence;

namespace TaxCalculator.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        protected MyTaxCalculator _myTaxCalculator;
        protected TaxCalculatorContext _context;
        protected Mock<ICommonRepository> _mockCommonRepository;
        protected Mock<ICalculatedTaxRepository> _mockCalculatedTaxRepo;
        protected Mock<ITaxService> _mockTaxService;

        [SetUp]
        public void BaseTestsInitializer()
        {
            _myTaxCalculator = new MyTaxCalculator();
            _context = new TaxCalculatorContext();
            _mockCommonRepository = new Mock<ICommonRepository>();
            _mockCalculatedTaxRepo = new Mock<ICalculatedTaxRepository>();
            _mockTaxService = new Mock<ITaxService>();
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Municipalities.Application.Municipalities;
using Municipalities.Contracts.Repositories;
using Municipalities.Data;
using Municipalities.Domain.Municipalities;
using Municipalities.Services.Municipalities;
using System;
using System.Linq;

namespace Municipalities.Tests
{
    [TestClass]
    public class MunicipalityTests : TestUtil
    {
        private IRepository<MunicipalityTax> _municipalityTaxesRepository;
        private IRepository<Municipality> _municipalitiesRepository;
        private MunicipalityTaxesService _municipalityTaxesService;

        public MunicipalityTests()
        {
            _municipalityTaxesRepository = new Repository<MunicipalityTax>(DbContext);
            _municipalitiesRepository = new Repository<Municipality>(DbContext);
            _municipalityTaxesService = new MunicipalityTaxesService(_municipalityTaxesRepository, _municipalitiesRepository);
        }

        [TestMethod]
        public void ShouldGetMunicipalityTaxByDateTimeNow()
        {
            // Arrange
            var municipality = _municipalitiesRepository.Query().First().Name;

            // Act
            var tax = _municipalityTaxesService.GetTax(municipality, DateTime.Now);

            // Assert
            Assert.IsNotNull(tax);
        }

        [TestMethod]
        public void ShouldAddMunicipalityTax()
        {
            // Arrange
            bool isMunicipalityTaxAdded;
            var municipalityTaxDto = new MunicipalityTaxDto()
            {
                EndDate = DateTime.Now.AddDays(2),
                StartDate = DateTime.Now,
                Value = 0.5M
            };
            var municipalityId = _municipalitiesRepository.Query().First().Id;

            // Act
            try
            {
                _municipalityTaxesService.AddOrUpdateTax(municipalityId, municipalityTaxDto);
                isMunicipalityTaxAdded = true;
            }
            catch (Exception)
            {
                isMunicipalityTaxAdded = false;
            }

            // Assert
            Assert.IsTrue(isMunicipalityTaxAdded);
        }
    }
}

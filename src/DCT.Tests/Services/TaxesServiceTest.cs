using DCT.Application.Models;
using DCT.Application.Services;
using DCT.Application.Services.TaxesCalculationService;
using DCT.Persistence.Entities;
using DCT.Persistence.Enums;
using DCT.Persistence.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DCT.Tests.Services
{
    public class TaxesServiceTest
    {
        private readonly ILogger<TaxesService> _logger;
        private readonly ILogger<TaxesCalculationService> _taxesCalculationLogger;

        public TaxesServiceTest()
        {
            _logger = new Mock<ILogger<TaxesService>>().Object;
            _taxesCalculationLogger = new Mock<ILogger<TaxesCalculationService>>().Object;
        }

        [Theory]
        [InlineData(0)]
        public async Task MunicipalityNotFound(int municipalityId)
        {
            var repositoryMock = new Mock<IMunicipalityRepository>();
            repositoryMock.Setup(x => x.GetById(municipalityId)).ReturnsAsync(() => null);

            var taxesCalculationServiceMock = new Mock<TaxesCalculationService>(_taxesCalculationLogger);

            var taxesServiceMock = new Mock<TaxesService>(repositoryMock.Object, taxesCalculationServiceMock.Object, _logger);

            await Assert.ThrowsAsync<Exception>(async () => await taxesServiceMock.Object.GetTaxes(new GetCalculatedTaxesDTO()));
        }

        [Theory]
        [InlineData(0)]
        public async Task InvalidRuleKeyProperty(int municipalityId)
        {
            var repositoryMock = new Mock<IMunicipalityRepository>();
            repositoryMock.Setup(x => x.GetById(municipalityId)).ReturnsAsync(() => new Municipality { RuleKey = 0 });

            var taxesCalculationServiceMock = new Mock<TaxesCalculationService>(_taxesCalculationLogger);

            var taxesServiceMock = new Mock<TaxesService>(repositoryMock.Object, taxesCalculationServiceMock.Object, _logger);

            await Assert.ThrowsAsync<ArgumentException>(async () => await taxesServiceMock.Object.GetTaxes(new GetCalculatedTaxesDTO()));
        }

        [Theory]
        [InlineData(0)]
        public async Task InvalidDate(int municipalityId)
        {
            var repositoryMock = new Mock<IMunicipalityRepository>();
            repositoryMock.Setup(x => x.GetById(municipalityId)).ReturnsAsync(() => new Municipality { RuleKey = RuleKeyEnum.One });

            var taxesCalculationServiceMock = new Mock<TaxesCalculationService>(_taxesCalculationLogger);

            var taxesServiceMock = new Mock<TaxesService>(repositoryMock.Object, taxesCalculationServiceMock.Object, _logger);

            await Assert.ThrowsAsync<SystemException>(async () => await taxesServiceMock.Object.GetTaxes(new GetCalculatedTaxesDTO { MunicipalityId = 0, Date = new DateTime() }));
        }
    }
}

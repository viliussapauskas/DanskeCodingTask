using DCT.Application.Models;
using DCT.Application.Services;
using DCT.Persistence.Entities;
using DCT.Persistence.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DCT.Tests.Services
{
    public class MunicipalityServiceTest
    {
        private readonly ILogger<MunicipalityService> _logger;

        public MunicipalityServiceTest()
        {
            _logger = new Mock<ILogger<MunicipalityService>>().Object;
        }

        [Fact]
        public async Task ReturnEmptyMunicipalitiesList()
        {
            IQueryable<Municipality> municipalities = new List<Municipality>().AsQueryable();

            var repositoryMock = new Mock<IMunicipalityRepository>();
            repositoryMock.Setup(x => x.GetAll()).ReturnsAsync(municipalities);

            var municipalityService = new MunicipalityService(repositoryMock.Object, _logger);

            IEnumerable<MunicipalityDTO> result = await municipalityService.GetAll();
            repositoryMock.Verify(x => x.GetAll(), Times.Once);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnMunicipalitiesListWithOneElement()
        {
            IQueryable<Municipality> municipalities = new List<Municipality> { new Municipality() }.AsQueryable();

            var repositoryMock = new Mock<IMunicipalityRepository>();
            repositoryMock.Setup(x => x.GetAll()).ReturnsAsync(municipalities);

            var municipalityService = new MunicipalityService(repositoryMock.Object, _logger);

            IEnumerable<MunicipalityDTO> result = await municipalityService.GetAll();

            repositoryMock.Verify(x => x.GetAll(), Times.Once);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task ReturnMunicipalitiesListWithMultipleElements()
        {
            IQueryable<Municipality> municipalities = new List<Municipality> {
                new Municipality(),
                new Municipality(),
                new Municipality()
            }.AsQueryable();

            var repositoryMock = new Mock<IMunicipalityRepository>();
            repositoryMock.Setup(x => x.GetAll()).ReturnsAsync(municipalities);

            var municipalityService = new MunicipalityService(repositoryMock.Object, _logger);

            IEnumerable<MunicipalityDTO> result = await municipalityService.GetAll();

            repositoryMock.Verify(x => x.GetAll(), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }
    }
}

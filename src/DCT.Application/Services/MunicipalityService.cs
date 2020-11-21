using DCT.Application.Models;
using DCT.Application.Services.Interfaces;
using DCT.Persistence.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCT.Application.Services
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly IMunicipalityRepository _municipalityRepository;
        private readonly ILogger<MunicipalityService> _logger;

        public MunicipalityService(IMunicipalityRepository municipalityRepository, ILogger<MunicipalityService> logger)
        {
            _municipalityRepository = municipalityRepository;
            _logger = logger;
        }

        public async Task<List<MunicipalityDTO>> GetAll()
        {
            var entities = await _municipalityRepository.GetAll();

            if (!entities.Any())
            {
                _logger.LogWarning("_municipalityRepository.GetAll() returns empty list");
            }

            return entities.Select(x => new MunicipalityDTO
            {
                Id = x.Id,
                Name = x.Name,
                RuleKey = x.RuleKey
            }).ToList();
        }
    }
}

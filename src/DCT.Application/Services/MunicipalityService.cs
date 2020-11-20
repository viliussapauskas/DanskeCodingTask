using DCT.Application.Models;
using DCT.Application.Services.Interfaces;
using DCT.Persistence.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCT.Application.Services
{
    public class MunicipalityService: IMunicipalityService
    {
        private readonly IMunicipalityRepository _municipalityRepository;

        public MunicipalityService(IMunicipalityRepository municipalityRepository)
        {
            _municipalityRepository = municipalityRepository;
        }

        public async Task<List<MunicipalityDTO>> GetAll()
        {
            var entities = await _municipalityRepository.GetAll();

            return entities.Select(x => new MunicipalityDTO
            {
                Id = x.Id,
                Name = x.Name,
                RuleKey = x.RuleKey
            }).ToList();
        }
    }
}

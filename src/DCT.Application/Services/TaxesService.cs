using DCT.Application.Services.Interfaces;
using DCT.Persistence.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace DCT.Application.Services
{
    public class TaxesService: ITaxesService
    {
        private readonly IMunicipalityRepository _municipalityRepository;

        public TaxesService(IMunicipalityRepository municipalityRepository)
        {
            _municipalityRepository = municipalityRepository;
        }

        public async Task<double> GetTaxes(int municipalityId, DateTime date)
        {
            var municipalities = await _municipalityRepository.GetAll();
            return municipalityId;
        }
    }
}

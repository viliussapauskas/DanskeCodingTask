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
            var municipality = await _municipalityRepository.GetById(municipalityId);

            if(municipality == null)
            {
                throw new Exception("System error: Municipality not found");
            }

            return municipalityId;
        }
    }
}

using DCT.Application.Services.Interfaces;
using DCT.Persistence.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace DCT.Application.Services
{
    public class TaxesService: ITaxesService
    {
        private readonly IMunicipalityRepository _municipalityRepository;
        private readonly ITaxesCalculationService _taxesCalculationService;

        public TaxesService(IMunicipalityRepository municipalityRepository, ITaxesCalculationService taxesCalculationService)
        {
            _municipalityRepository = municipalityRepository;
            _taxesCalculationService = taxesCalculationService;
        }

        public async Task<double> GetTaxes(int municipalityId, DateTime date)
        {
            var municipality = await _municipalityRepository.GetById(municipalityId);

            if(municipality == null)
            {
                throw new Exception("Municipality not found");
            }

            var result = _taxesCalculationService.CalculateTaxes(municipality.RuleKey, date);

            return result;
        }
    }
}

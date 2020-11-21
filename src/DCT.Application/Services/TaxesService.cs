using DCT.Application.Services.Interfaces;
using DCT.Persistence.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DCT.Application.Services
{
    public class TaxesService : ITaxesService
    {
        private readonly IMunicipalityRepository _municipalityRepository;
        private readonly ITaxesCalculationService _taxesCalculationService;
        private readonly ILogger<ITaxesService> _logger;

        public TaxesService(IMunicipalityRepository municipalityRepository, ITaxesCalculationService taxesCalculationService, ILogger<ITaxesService> logger)
        {
            _municipalityRepository = municipalityRepository;
            _taxesCalculationService = taxesCalculationService;
            _logger = logger;
        }

        public async Task<double> GetTaxes(int municipalityId, DateTime date)
        {
            var municipality = await _municipalityRepository.GetById(municipalityId);

            if (municipality == null)
            {
                _logger.LogError($"Municipality with id {municipalityId} not found");
                throw new Exception("Municipality not found");
            }

            var result = _taxesCalculationService.CalculateTaxes(municipality.RuleKey, date);

            return result;
        }
    }
}

﻿using DCT.Application.Models;
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

        public async Task<double> GetTaxes(GetCalculatedTaxesDTO request)
        {
            var municipality = await _municipalityRepository.GetById(request.MunicipalityId);

            if (municipality == null)
            {
                _logger.LogError($"Municipality with id {request.MunicipalityId} not found");
                throw new Exception("Municipality not found");
            }

            var result = _taxesCalculationService.CalculateTaxes(municipality.RuleKey, request.Date);

            return result;
        }
    }
}

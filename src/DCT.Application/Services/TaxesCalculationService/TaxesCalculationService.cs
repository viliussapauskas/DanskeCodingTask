using DCT.Application.Services.Interfaces;
using DCT.Application.Utils;
using DCT.Persistence.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DCT.Application.Services.TaxesCalculationService
{
    public class TaxesCalculationService : ITaxesCalculationService
    {
        private readonly ILogger<ITaxesCalculationService> _logger;
        public TaxesCalculationService(ILogger<ITaxesCalculationService> logger)
        {
            _logger = logger;
        }

        public double CalculateTaxes(RuleKeyEnum ruleKeyEnum, DateTime date)
        {
            return ruleKeyEnum switch
            {
                RuleKeyEnum.One => CalculateTaxesForRuleOne(date),
                RuleKeyEnum.Two => CalculateTaxesForRuleTwo(date),
                _ => throw new ArgumentException("Rule not found"),
            };
        }

        private double CalculateTaxesForRuleOne(DateTime date)
        {
            var taxSchedules = TaxSchedules.GetRuleOneTaxSchedules()
                .Where(x => x.PeriodFrom <= date && x.PeriodTo >= date)
                .ToList();

            if (!taxSchedules.Any())
            {
                _logger.LogInformation("Invalid date entered");
                throw new SystemException("Didn't find any taxes for this date, please try another date");
            }

            double result = 0;

            taxSchedules.ForEach(x =>
            {
                result += x.Value;
            });

            return result;
        }

        private double CalculateTaxesForRuleTwo(DateTime date)
        {
            var taxeSchedules = TaxSchedules.GetRuleTwoTaxSchedules()
                .Where(x => x.PeriodFrom <= date && x.PeriodTo >= date)
                .OrderBy(x => x.PeriodTo - x.PeriodFrom)
                .ToList();

            if (!taxeSchedules.Any())
            {
                _logger.LogInformation("Invalid date entered");
                throw new Exception("Didn't find any taxes for this date, please try another date");
            }

            return taxeSchedules.First().Value;
        }
    }
}

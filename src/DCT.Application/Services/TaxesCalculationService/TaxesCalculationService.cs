using DCT.Application.Services.Interfaces;
using DCT.Application.Utils;
using DCT.Persistence.Enums;
using System;
using System.Linq;

namespace DCT.Application.Services.TaxesCalculationService
{
    public class TaxesCalculationService : ITaxesCalculationService
    {
        public TaxesCalculationService()
        {
        }

        public double CalculateTaxes(RuleKeyEnum ruleKeyEnum, DateTime date)
        {
            return ruleKeyEnum switch
            {
                RuleKeyEnum.One => CalculateTaxesForRuleOne(date),
                RuleKeyEnum.Two => CalculateTaxesForRuleTwo(date),
                _ => throw new SystemException("System error, rule not found"),
            };
        }

        private double CalculateTaxesForRuleOne(DateTime date)
        {
            var taxSchedules = TaxSchedules.GetRuleOneTaxSchedules()
                .Where(x => x.PeriodFrom <= date && x.PeriodTo >= date)
                .ToList();

            if (!taxSchedules.Any())
            {
                throw new Exception("Didn't find any taxes for this date, please try another date");
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
                throw new Exception("Didn't find any taxes for this date, please try another date");
            }

            return taxeSchedules.First().Value;
        }
    }
}

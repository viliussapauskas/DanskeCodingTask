using DCT.Application.Services.TaxesCalculationService.Models;
using System;
using System.Collections.Generic;

namespace DCT.Application.Utils
{
    public static class TaxSchedules
    {
        public static List<TaxScheduleModel> GetRuleOneTaxSchedules()
        {
            return new List<TaxScheduleModel>
            {
                new TaxScheduleModel
                {
                    Value = 0.3,
                    PeriodFrom = new DateTime(2020, 01, 01),
                    PeriodTo = new DateTime(2020, 12, 31)
                },
                new TaxScheduleModel
                {
                    Value = 0.2,
                    PeriodFrom = new DateTime(2020, 01, 01),
                    PeriodTo = new DateTime(2020, 01, 31)
                },
                new TaxScheduleModel
                {
                    Value = 0.1,
                    PeriodFrom = new DateTime(2020, 01, 06),
                    PeriodTo = new DateTime(2020, 01, 12)
                }
            };
        }

        public static List<TaxScheduleModel> GetRuleTwoTaxSchedules()
        {
            return new List<TaxScheduleModel>
            {
                new TaxScheduleModel
                {
                    Value = 0.2,
                    PeriodFrom = new DateTime(2020, 01, 01),
                    PeriodTo = new DateTime(2020, 12, 31)
                },
                new TaxScheduleModel
                {
                    Value = 0.4,
                    PeriodFrom = new DateTime(2020, 05, 01),
                    PeriodTo = new DateTime(2020, 05, 31)
                },
                new TaxScheduleModel
                {
                    Value = 0.1,
                    PeriodFrom = new DateTime(2020, 01, 01),
                    PeriodTo = new DateTime(2020, 01, 01)
                },
                new TaxScheduleModel
                {
                    Value = 0.1,
                    PeriodFrom = new DateTime(2020, 12, 25),
                    PeriodTo = new DateTime(2020, 12, 25)
                },
            };
        }
    }
}

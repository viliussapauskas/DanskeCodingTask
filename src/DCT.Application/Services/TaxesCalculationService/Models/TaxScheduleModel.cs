using System;

namespace DCT.Application.Services.TaxesCalculationService.Models
{
    public class TaxScheduleModel
    {
        public double Value { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
    }
}

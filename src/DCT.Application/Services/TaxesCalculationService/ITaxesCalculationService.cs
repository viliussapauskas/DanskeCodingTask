using DCT.Persistence.Enums;
using System;

namespace DCT.Application.Services.Interfaces
{
    public interface ITaxesCalculationService
    {
        double CalculateTaxes(RuleKeyEnum ruleKeyEnum, DateTime date);
    }
}

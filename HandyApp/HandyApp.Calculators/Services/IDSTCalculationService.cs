using System;
using HandyApp.Calculators.Enums;
using HandyApp.Calculators.ViewModels;

namespace HandyApp.Calculators.Services
{
    public interface IDSTCalculationService
    {
        string Calculate(DSTCalculation data, DSTCalculationType type);
    }
}
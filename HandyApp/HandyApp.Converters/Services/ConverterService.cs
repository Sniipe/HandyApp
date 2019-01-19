using System;
using UnitsNet;
using UnitsNet.Units;

namespace HandyApp.Converters.Services
{
    public class ConverterService : IConverterService
    {
        public string CalculateDistance(string convertFrom, string value, string convertTo)
        {
            double.TryParse(value, out double quantity);
            Enum.TryParse(convertFrom, out MassUnit unitFrom);
            Enum.TryParse(convertTo, out MassUnit unitTo);
            var result = Mass.From(quantity, unitFrom).ToUnit(unitTo);
            return result.Value.ToString();

        }

        public string CalculateTempereture(string convertFrom, string value, string convertTo)
        {
            double.TryParse(value, out double quantity);
            Enum.TryParse(convertFrom, out TemperatureUnit unitFrom);
            Enum.TryParse(convertTo, out TemperatureUnit unitTo);
            var result = Temperature.From(quantity, unitFrom).ToUnit(unitTo);
            return result.Value.ToString();
        }
    }
}
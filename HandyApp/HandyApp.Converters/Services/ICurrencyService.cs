using System.Threading.Tasks;
using HandyApp.Core.Enums;

namespace HandyApp.Converters.Services
{
    public interface ICurrencyService
    {
        Task<double> GetConversionRate(string from, string to,string amount);
        
    }
}
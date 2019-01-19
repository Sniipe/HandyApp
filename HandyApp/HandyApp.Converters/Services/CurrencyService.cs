using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HandyApp.Core.Enums;
using Newtonsoft.Json;

namespace HandyApp.Converters.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _client;
        private const string apiKey = "f3f8e066190c108b6c0563ee3fe98778";
        public CurrencyService()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("http://data.fixer.io")
            };
        }
        public async Task<double> GetConversionRate(string from, string to, string amount)
        {
            var response = await _client.GetAsync($"api/latest?access_key={apiKey}&base={from}&symbols={to}");
            var responseData = await response.Content.ReadAsStringAsync();
            //var definition = new {rates};
            var responseObject = JsonConvert.DeserializeObject<CurrencyResult>(responseData);
            return responseObject.Rates.FirstOrDefault().Value;
        }
    }

    public partial class CurrencyResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }
    }
}
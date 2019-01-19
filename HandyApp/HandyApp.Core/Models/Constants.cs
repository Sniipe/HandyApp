using System.Collections.Generic;

namespace HandyApp.Core.Models
{
    public static class Constants
    {
        public static IEnumerable<App> Apps => new List<App>
        {
            new App
            {
                NavigationLink = "DistanceConverterPage",
                Name = "DistanceConverterPage"
            },
            new App
            {
                NavigationLink = "CurrencyConverterPage",
                Name = "CurrencyConverterPage"
            },
            new App
            {
                NavigationLink = "TempetureConverterPage",
                Name = "TempetureConverterPage"
            },
            
        };
    }
}
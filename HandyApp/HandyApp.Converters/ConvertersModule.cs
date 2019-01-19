using HandyApp.Converters.Services;
using Prism.Ioc;
using Prism.Modularity;
using HandyApp.Converters.Views;
using HandyApp.Converters.ViewModels;

namespace HandyApp.Converters
{
    public class ConvertersModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ConvertersHomePage>();
            containerRegistry.RegisterForNavigation<DistanceConverterPage>();
            containerRegistry.RegisterForNavigation<CurrencyConverterPage>();
            containerRegistry.RegisterForNavigation<TempetureConverterPage>();

            containerRegistry.Register<IConverterService, ConverterService>();
        }
    }
}

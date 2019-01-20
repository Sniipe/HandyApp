using HandyApp.Calculators.Services;
using Prism.Ioc;
using Prism.Modularity;
using HandyApp.Calculators.Views;
using HandyApp.Calculators.ViewModels;

namespace HandyApp.Calculators
{
    public class CalculatorsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CalculatorsHomePage, CalculatorsHomePageViewModel>();
            containerRegistry.RegisterForNavigation<DistanceSpeedTimeCalculatorPage, DistanceSpeedTimeCalculatorPageViewModel>();
            containerRegistry.Register<IDSTCalculationService,DSTCalculationService>();
        }
    }
}

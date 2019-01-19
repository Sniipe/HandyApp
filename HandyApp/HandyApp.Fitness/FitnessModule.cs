using Prism.Ioc;
using Prism.Modularity;
using HandyApp.Fitness.Views;
using HandyApp.Fitness.ViewModels;

namespace HandyApp.Fitness
{
    public class FitnessModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RunTrackerPage, RunTrackerPageViewModel>();
            containerRegistry.RegisterForNavigation<RunningSessionPage, RunningSessionPageViewModel>();
        }
    }
}

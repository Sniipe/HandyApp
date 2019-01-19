using System.Collections.Generic;
using HandyApp.Converters;
using HandyApp.Converters.Services;
using HandyApp.Converters.Views;
using HandyApp.Core;
using HandyApp.Fitness;
using HandyApp.Fitness.Views;
using Prism;
using Prism.Ioc;
using HandyApp.ViewModels;
using HandyApp.Views;
using Prism.Modularity;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HandyApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("HomePage/NavigationPage/StartPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
            
            containerRegistry.Register<ISecureStorage,SecureStorageImplementation>();
            containerRegistry.Register<ICurrencyService,CurrencyService>();

            //containerRegistry.RegisterInstance<IEnumerable<string>>(apps);
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<StartPage, StartPageViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<CoreModule>();
            moduleCatalog.AddModule<ConvertersModule>();
            moduleCatalog.AddModule<FitnessModule>();
        }
    }
}

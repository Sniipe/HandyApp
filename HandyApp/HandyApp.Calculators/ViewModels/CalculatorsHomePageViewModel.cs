using System.Collections.ObjectModel;
using HandyApp.Core.Models;
using Prism.Commands;
using HandyApp.Core.ViewModels;
using Prism.Navigation;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.Calculators.ViewModels
{
	public class CalculatorsHomePageViewModel : ViewModelBase
	{
        private ObservableCollection<App> _calculators;
        public ObservableCollection<App> Calculators
        {
            get { return _calculators; }
            set { SetProperty(ref _calculators, value); }
        }

        private App _selectedApp;
        public App SelectedApp
        {
            get { return _selectedApp; }
            set { SetProperty(ref _selectedApp, value); }
        }


        private DelegateCommand _navigateToCalculatorCommand;
        public DelegateCommand NavigateToCalculatorCommand =>
            _navigateToCalculatorCommand ?? (_navigateToCalculatorCommand = new DelegateCommand(ExecuteNavigateToCalculatorCommand));

        void ExecuteNavigateToCalculatorCommand()
        {
            NavigateCommand.Execute(SelectedApp.NavigationLink);
        }
	    public CalculatorsHomePageViewModel(INavigationService navigationService, ISecureStorage storage) : base(navigationService, storage)
	    {
	        Calculators = new ObservableCollection<App>
	        {
	            new App
	            {
	                Name = "Distance Speed Time Calculator",
	                NavigationLink = "DistanceSpeedTimeCalculatorPage"
	            }
	        };
	    }
	}
}

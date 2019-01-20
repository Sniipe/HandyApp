using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HandyApp.Core.Models;
using HandyApp.Core.ViewModels;
using Prism.Navigation;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.ViewModels
{
	public class StartPageViewModel : ViewModelBase
	{

        private bool _userHasRecentApps;
        public bool UserHasRecentApps
        {
            get { return _userHasRecentApps; }
            set { SetProperty(ref _userHasRecentApps, value); }
        }

        private ObservableCollection<Core.Models.App> _recentApps;
	    public ObservableCollection<Core.Models.App> RecentApps
	    {
	        get { return _recentApps; }
	        set { SetProperty(ref _recentApps, value); }
	    }

	    private ObservableCollection<Category> _categories;
	    public ObservableCollection<Category> Categories
	    {
	        get { return _categories; }
	        set { SetProperty(ref _categories, value); }
	    }
        public StartPageViewModel(INavigationService navigationService, ISecureStorage secure) : base(navigationService, secure)
	    {
	        Categories = new ObservableCollection<Category>();
	        RecentApps = new ObservableCollection<Core.Models.App>();
        }

	    public override async  void OnNavigatingTo(INavigationParameters parameters)
	    {
	        base.OnNavigatingTo(parameters);
	        Categories = new ObservableCollection<Category>()
	        {
	            new Category
	            {
	                Name = "Fitness",
	                NavigationLink = "FitnessHomePage",
                    Apps = new List<Core.Models.App>
                    {
                        new Core.Models.App
                        {
                            Name = "Run Tracker",
                            NavigationLink = "RunTrackerPage"
                        }
                    }
                    

	            },
	            new Category()
	            {
	                Name = "Converters",
	                NavigationLink = "ConvertersHomePage",
                    Apps = new List<Core.Models.App>
                    {
                        new Core.Models.App
                        {
                            Name = "Distance Converter",
                            NavigationLink = "DistanceConverterPage",
                        },
                        new Core.Models.App
                        {
                            Name = "Currency Converter",
                            NavigationLink = "CurrencyConverterPage",
                        },
                        new Core.Models.App
                        {
                            Name = "Tempereture Converter",
                            NavigationLink = "TempetureConverterPage",
                        }
                    }
	            }
	        };
            RaisePropertyChanged(nameof(Categories));
	        var apps = await GetApps();
	        UserHasRecentApps = apps?.Count() > 0;
            RecentApps.Clear();
	        foreach (var app in apps)
	        {
	            RecentApps.Add(app);
	        }
            //RecentApps = new ObservableCollection<Core.Models.App>();
	        
	    }
    }
}

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
	public class HomePageViewModel : ViewModelBase
	{
        public HomePageViewModel(INavigationService navigationService, ISecureStorage storage) : base(navigationService, storage)
	    {
            

	    }

	    
	}
}

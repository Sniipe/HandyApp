using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using HandyApp.Core.ViewModels;
using Prism.Navigation;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.ViewModels
{
	public class WelcomePageViewModel : ViewModelBase
	{
        
	    public WelcomePageViewModel(INavigationService navigationService, ISecureStorage storage) : base(navigationService, storage)
	    {
	    }
	}
}

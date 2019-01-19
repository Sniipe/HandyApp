using HandyApp.Core.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using HandyApp.Core.Models;
using Prism.Navigation;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.Converters.ViewModels
{
	public class ConvertersHomePageViewModel : ViewModelBase
	{
	    public ConvertersHomePageViewModel(INavigationService navigationService, ISecureStorage storage) : base(navigationService, storage)
	    {
	    }
	}
}

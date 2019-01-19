using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using HandyApp.Core.Models;
using HandyApp.Core.ViewModels;
using Prism.Navigation;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.Fitness.ViewModels
{
	public class RunTrackerPageViewModel : ViewModelBase
	{

        private RunningSession _runningSession;
        public RunningSession RunningSession
        {
            get { return _runningSession; }
            set { SetProperty(ref _runningSession, value); }
        }
        private DelegateCommand _startSessionCommand;
        public DelegateCommand StartSessionCommand =>
            _startSessionCommand ?? (_startSessionCommand = new DelegateCommand(ExecuteStartSessionCommand));

        async void ExecuteStartSessionCommand()
        {
            var parameters = new NavigationParameters();
            parameters.Add("session", RunningSession);
            await NavigationService.NavigateAsync("NavigationPage/RunningSessionPage", parameters);
        }
        public RunTrackerPageViewModel(INavigationService navigationService, ISecureStorage storage) : base(navigationService,storage)
	    {
            RunningSession = new RunningSession();
	    }
	}
}

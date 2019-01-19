using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using HandyApp.Core.Models;
using HandyApp.Core.ViewModels;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.Fitness.ViewModels
{
	public class RunningSessionPageViewModel : ViewModelBase
	{
	    private int _index;
	    private bool _isSessionRunning;
	    private readonly IDeviceService _deviceService;
        private SessionBlock _currentSessionBlock;
        public SessionBlock CurrentSessionBlock
        {
            get { return _currentSessionBlock; }
            set { SetProperty(ref _currentSessionBlock, value); }
        }

        private ObservableCollection<SessionBlock> _sessionBlocks;
        public ObservableCollection<SessionBlock> SessionBlocks     
        {
            get { return _sessionBlocks; }
            set { SetProperty(ref _sessionBlocks, value); }
        }

        private TimeSpan _currentTime;
        public TimeSpan CurrentTime
        {
            get { return _currentTime; }
            set { SetProperty(ref _currentTime, value); }
        }

        private DelegateCommand _startSessionCommand;
        public DelegateCommand StartSessionCommand =>
            _startSessionCommand ?? (_startSessionCommand = new DelegateCommand(ExecuteStartSessionCommand));

        void ExecuteStartSessionCommand()
        {
            _isSessionRunning = true;
            _index = 0;
            CurrentSessionBlock = SessionBlocks[_index];
            _deviceService.StartTimer(TimeSpan.FromSeconds(1), ManageSession );
        }

	    private bool ManageSession()
	    {
            _deviceService.BeginInvokeOnMainThread(() => CurrentTime = CurrentTime.Add(new TimeSpan(0, 0, 1)));
	        //CurrentTime = CurrentTime.Add(new TimeSpan(0, 0, 1));

	        if (CurrentTime >= CurrentSessionBlock.Time)
	        {
	            _index++;
	            if (_index < SessionBlocks.Count)
	            {
	                _deviceService.BeginInvokeOnMainThread(() => CurrentSessionBlock = SessionBlocks[_index]);
	                _deviceService.BeginInvokeOnMainThread(() => CurrentTime = TimeSpan.Zero);
                    return _isSessionRunning;
	            }

	            _isSessionRunning = false;
	            return _isSessionRunning;
	        }
	        return _isSessionRunning;
	    }

	    public RunningSessionPageViewModel(INavigationService navigationService, IDeviceService deviceService, ISecureStorage storage) : base(navigationService, storage)
        {
            _deviceService = deviceService;
            SessionBlocks = new ObservableCollection<SessionBlock>();
            CurrentTime = new TimeSpan(0,0,0);
	    }

	    public override void OnNavigatingTo(INavigationParameters parameters)
	    {
	        base.OnNavigatingTo(parameters);
	        var session = parameters.GetValue<RunningSession>("session");

	        CreateSessionBlocksFromSession(session);
	    }

	    private void CreateSessionBlocksFromSession(RunningSession session)
	    {
            SessionBlocks.Clear();
            for (int i = 0; i < session.Sets; i++)
	        {
	            for (int j = 0; j < session.Reps; j++)
	            {
	                SessionBlocks.Add(new SessionBlock
	                {
                        Time = session.RepTimeSpan,
                        Type = BlockType.Run,
                        Set = i + 1,
                        Rep = j + 1
	                });
	                if (j != session.Reps - 1)
	                {
	                    SessionBlocks.Add(new SessionBlock
	                    {
	                        Time = session.RepInterval,
	                        Type = BlockType.Rest,
                            Set = i + 1,
                            Rep = j + 1
	                    });
                    }
	                
	            }
	            SessionBlocks.Add(new SessionBlock
	            {
	                Time = session.SetInterval,
	                Type = BlockType.Rest
	            });
            }
	    }
	}
}

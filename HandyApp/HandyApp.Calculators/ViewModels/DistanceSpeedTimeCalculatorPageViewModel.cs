using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyApp.Calculators.Enums;
using HandyApp.Calculators.Services;
using HandyApp.Core;
using HandyApp.Core.ViewModels;
using Prism.Navigation;
using Prism.Services;
using UnitsNet.Units;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.Calculators.ViewModels
{
	public class DistanceSpeedTimeCalculatorPageViewModel : ViewModelBase
	{

	    private readonly IDSTCalculationService _calculationService;
	    private readonly IPageDialogService _dialogService;

	    private readonly IEnumerable<LengthUnit> _supportedLengthUnits = new List<LengthUnit>
	    {
	        LengthUnit.Kilometer,
	        LengthUnit.Meter,
	        LengthUnit.Mile,
	        LengthUnit.Foot
	    };

	    private readonly IEnumerable<SpeedUnit> _supportedSpeedUnits = new List<SpeedUnit>
	    {
	        SpeedUnit.KilometerPerHour,
	        SpeedUnit.MeterPerSecond,
	        SpeedUnit.MilePerHour,
	        SpeedUnit.FootPerSecond
	    };


	    public IEnumerable<LengthUnit> DistanceUnits => Enum.GetValues(typeof(LengthUnit))
	        .Cast<LengthUnit>().Where(x => _supportedLengthUnits.Contains(x)).ToList();

	    public IEnumerable<SpeedUnit> SpeedUnits => Enum.GetValues(typeof(SpeedUnit)).Cast<SpeedUnit>().Where(x => _supportedSpeedUnits.Contains(x)).ToList();
        
        private DSTCalculation _distanceCalculation;
        public DSTCalculation DistanceCalculation
        {
            get { return _distanceCalculation; }
            set { SetProperty(ref _distanceCalculation, value); }
        }

	    private DSTCalculation _timeCalculation;
        public DSTCalculation TimeCalculation
        {
            get { return _timeCalculation; }
            set { SetProperty(ref _timeCalculation, value); }
        }
	    private DSTCalculation _speedCalculation;
        public DSTCalculation SpeedCalculation
        {
            get { return _speedCalculation; }
            set { SetProperty(ref _speedCalculation, value); }
        }

        private DelegateCommand<object> _calculateCommand;
        public DelegateCommand<object> CalculateCommand =>
            _calculateCommand ?? (_calculateCommand = new DelegateCommand<object>(ExecuteCalculateCommand));

        private string _speedResult;
        public string SpeedResult
        {
            get { return _speedResult; }
            set { SetProperty(ref _speedResult, value); }
        }

        private string _distanceResult;
        public string DistanceResult
        {
            get { return _distanceResult; }
            set { SetProperty(ref _distanceResult, value); }
        }

        private string _timeResult;
        public string TimeResult
        {
            get { return _timeResult; }
            set { SetProperty(ref _timeResult, value); }
        }

        async void ExecuteCalculateCommand(object obj)
        {
            var type = (DSTCalculationType)obj;
            await Calculate(type);
        }

	    public async Task Calculate(DSTCalculationType type)
	    {
	        switch (type)
	        {
                case DSTCalculationType.Distance:
                    var distance = _calculationService.Calculate(DistanceCalculation, type);
                    DistanceResult = distance;
                    break;
                case DSTCalculationType.Speed:
                    var speed = _calculationService.Calculate(SpeedCalculation, type);
                    SpeedResult = speed;
                    //await _dialogService.DisplayAlertAsync("Result", speed,"Ok");
                    break;
	            case DSTCalculationType.Time:
                    var time = _calculationService.Calculate(TimeCalculation, type);
                    TimeResult = time;
                    //await _dialogService.DisplayAlertAsync("Result", speed,"Ok");
                    break;
	        }
	    }

	    

	    public DistanceSpeedTimeCalculatorPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ISecureStorage storage, IDSTCalculationService service) : base(navigationService, storage)
	    {
	        _calculationService = service;
	        _dialogService = pageDialogService;
            DistanceCalculation = new DSTCalculation();
            SpeedCalculation = new DSTCalculation();
            TimeCalculation = new DSTCalculation();
	    }
	}

    public class DSTCalculation : BindableBase
    {
        private double _speed;
        public double Speed
        {
            get { return _speed; }
            set { SetProperty(ref _speed, value); }
        }

        private SpeedUnit _speedUnit;
        public SpeedUnit SpeedUnit
        {
            get { return _speedUnit; }
            set { SetProperty(ref _speedUnit, value); }
        }

        private string _speedText;
        public string SpeedText
        {
            get { return _speedText; }
            set
            {
                SetProperty(ref _speedText, value);
                if (double.TryParse(_speedText, out double speed))
                {
                    Speed = speed;
                }
            }
        }

        private double _distance;
        public double Distance
        {
            get { return _distance; }
            set
            {
                SetProperty(ref _distance, value);
                
            }
        }


        private LengthUnit _distanceUnit;
        public LengthUnit DistanceUnit
        {
            get { return _distanceUnit; }
            set { SetProperty(ref _distanceUnit, value); }
        }

        private string _distanceValueText;
        public string DistanceText
        {
            get { return _distanceValueText; }
            set
            {
                SetProperty(ref _distanceValueText, value);
                if (double.TryParse(_distanceValueText, out double doubleValue))
                {
                    Distance = doubleValue;
                }
            }
        }

        

        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }
    }
}

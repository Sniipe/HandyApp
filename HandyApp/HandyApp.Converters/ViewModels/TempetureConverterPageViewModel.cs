using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HandyApp.Converters.Services;
using HandyApp.Core.Models;
using HandyApp.Core.ViewModels;
using Prism.Navigation;
using UnitsNet;
using UnitsNet.Units;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.Converters.ViewModels
{
	public class TempetureConverterPageViewModel : ViewModelBase
	{
	    private readonly IConverterService _converterService;
        private string _convertedFromValue;
        public string ConvertedFromValue
        {
            get { return _convertedFromValue; }
            set { SetProperty(ref _convertedFromValue, value); }
        }

        private string _convertFrom;
        public string ConvertFrom
        {
            get { return _convertFrom; }
            set { SetProperty(ref _convertFrom, value); }
        }
        private string _convertTo;
        public string ConvertTo
        {
            get { return _convertTo; }
            set { SetProperty(ref _convertTo, value); }
        }

        private string _convertedToValue;
        public string ConvertedToValue
        {
            get { return _convertedToValue; }
            set { SetProperty(ref _convertedToValue, value); }
        }
        public ObservableCollection<string> Tempetures { get; set; }

        private DelegateCommand _convertCommand;
        public DelegateCommand ConvertCommand =>
            _convertCommand ?? (_convertCommand = new DelegateCommand(ExecuteConvertCommand));

        void ExecuteConvertCommand()
        {
            ConvertedToValue = _converterService.CalculateTempereture(ConvertFrom, ConvertedFromValue, ConvertTo);
        }
	    public TempetureConverterPageViewModel(INavigationService navigationService, ISecureStorage storage,
	        IConverterService converterService) : base(navigationService, storage)
	    {
	        _converterService = converterService;
            Tempetures = new ObservableCollection<string>(Enum.GetNames(typeof(TemperatureUnit)).ToList().Where(x => x != "undefined"));
	    }
	}
}

using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HandyApp.Converters.Services;
using HandyApp.Core.Enums;
using HandyApp.Core.Models;
using HandyApp.Core.ViewModels;
using Prism.Navigation;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.Converters.ViewModels
{
	public class CurrencyConverterPageViewModel : ViewModelBase
	{
	    private readonly ICurrencyService _currencyService;
        private string _convertFromCurrency;
        public string ConvertFromCurrency
        {
            get { return _convertFromCurrency; }
            set { SetProperty(ref _convertFromCurrency, value); }
        }

        private string _convertToCurrency;
        public string ConvertToCurrency
        {
            get { return _convertToCurrency; }
            set { SetProperty(ref _convertToCurrency, value); }
        }

	    private string _amount;
        public string Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }

	    private string _convertedValue;
        public string ConvertedValue
        {
            get { return _convertedValue; }
            set { SetProperty(ref _convertedValue, value); }
        }

        private ObservableCollection<string> _currencys;
        public ObservableCollection<string> Currencys
        {
            get { return _currencys; }
            set { SetProperty(ref _currencys, value); }
        }

        private DelegateCommand _convertCurrencyCommand;
        public DelegateCommand ConvertCurrencyCommand =>
            _convertCurrencyCommand ?? (_convertCurrencyCommand = new DelegateCommand(ExecuteConvertCurrencyCommand));

        async void ExecuteConvertCurrencyCommand()
        {
            var result = await _currencyService.GetConversionRate(ConvertFromCurrency, ConvertToCurrency, Amount);
            ConvertedValue = result.ToString();
        }
        public CurrencyConverterPageViewModel(INavigationService navigationService, ICurrencyService currencyService,ISecureStorage storage) : base(navigationService,storage)
        {
            _currencyService = currencyService;
            Currencys = new ObservableCollection<string>()
            {
                "EUR",
                "USD",
                "GBP"
            };
	    }
	}
}

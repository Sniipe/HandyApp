using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HandyApp.Converters.Services;
using HandyApp.Core.Enums;
using HandyApp.Core.Models;
using HandyApp.Core.ViewModels;
using Prism.Navigation;
using UnitsNet;
using UnitsNet.Units;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.Converters.ViewModels
{
	public class DistanceConverterPageViewModel : ViewModelBase
	{
	    private readonly IConverterService _converterService;
        private string _selectedDistanceFrom;
        public string SelectedDistanceFrom
        {
            get { return _selectedDistanceFrom; }
            set { SetProperty(ref _selectedDistanceFrom, value); }
        }

        private string _selectedDistanceTo;
        public string SelectedDistanceTo
        {
            get { return _selectedDistanceTo; }
            set { SetProperty(ref _selectedDistanceTo, value); }
        }
        private ObservableCollection<string> _distances;
        public ObservableCollection<string> Distances       
        {
            get { return _distances; }
            set { SetProperty(ref _distances, value); }
        }

        private string _distanceFrom;
        public string DistanceFrom
        {
            get { return _distanceFrom; }
            set { SetProperty(ref _distanceFrom, value); }
        }

        private string _distanceTo;
        public string DistanceTo
        {
            get { return _distanceTo; }
            set { SetProperty(ref _distanceTo, value); }
        }

        private DelegateCommand _convertCommand;
        public DelegateCommand ConvertCommand =>
            _convertCommand ?? (_convertCommand = new DelegateCommand(ExecuteConvertCommand));

        void ExecuteConvertCommand()
        {
            DistanceTo = _converterService.CalculateDistance(SelectedDistanceFrom, DistanceFrom, SelectedDistanceTo);
        }
        public DistanceConverterPageViewModel(INavigationService navigationService, IConverterService converterService, ISecureStorage secure) : base(navigationService, secure)
        {
            _converterService = converterService;
            Distances = new ObservableCollection<string>(Enum.GetNames(typeof(MassUnit)));
	    }
	}
}

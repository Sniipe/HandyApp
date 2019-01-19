using System;
using HandyApp.Core.Enums;
using Prism.Mvvm;

namespace HandyApp.Fitness
{
    public class RunningSession : BindableBase
    {
        private int _sets;
        public int Sets
        {
            get { return _sets; }
            set { SetProperty(ref _sets, value); }
        }

        private int _reps;
        public int Reps
        {
            get { return _reps; }
            set { SetProperty(ref _reps, value); }
        }

        private TimeSpan _repTimeSpan;
        public TimeSpan RepTimeSpan
        {
            get { return _repTimeSpan; }
            set { SetProperty(ref _repTimeSpan, value); }
        }

        private TimeSpan _repInterval;
        public TimeSpan RepInterval
        {
            get { return _repInterval; }
            set { SetProperty(ref _repInterval, value); }
        }

        private TimeSpan _setInterval;
        public TimeSpan SetInterval
        {
            get { return _setInterval; }
            set { SetProperty(ref _setInterval, value); }
        }


    }
}
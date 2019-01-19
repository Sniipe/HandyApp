using System;
using Prism.Mvvm;

namespace HandyApp.Fitness
{
    public class SessionBlock : BindableBase
    {
        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        private BlockType _type;
        public BlockType Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        private int _set;
        public int Set
        {
            get { return _set; }
            set { SetProperty(ref _set, value); }
        }
        private int _rep;
        public int Rep
        {
            get { return _rep; }
            set { SetProperty(ref _rep, value); }
        }
    }

    public enum BlockType
    {
        Run,
        Rest
    }
}
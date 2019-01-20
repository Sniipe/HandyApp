using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HandyApp.Core
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> ToObservableCollection<T>(this T value)
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
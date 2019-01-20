using System;
using HandyApp.Calculators.Enums;
using HandyApp.Calculators.ViewModels;
using UnitsNet;
using UnitsNet.Units;

namespace HandyApp.Calculators.Services
{
    public class DSTCalculationService : IDSTCalculationService
    {
        public string Calculate(DSTCalculation data, DSTCalculationType type)
        {
            switch (type)
            {
                case DSTCalculationType.Speed:
                    Speed speed = CalculateSpeed(data);
                    return $"Speed = {speed.As(data.SpeedUnit)}{Speed.GetAbbreviation(data.SpeedUnit)}";
                case DSTCalculationType.Distance:
                    Length distance = CalculateDistance(data);
                    return $"Distance = {distance.As(data.DistanceUnit)} {Length.GetAbbreviation(data.DistanceUnit)}";
                case DSTCalculationType.Time:
                    TimeSpan time = CalculateTime(data);
                    
                    return $"Time = {FormatTime(time)} ";
                default:
                    throw new Exception("Unsupported Action");

            }
            
            
        }

        private string FormatTime(TimeSpan time)
        {
            var timeString = "";
            if (time.Days > 0)
            {
                var day = time.Days > 1 ? "Days" : "Day";
                timeString += $" {time.Days} {day}";
            }
            if (time.Hours > 0)
            {
                var day = time.Hours > 1 ? "Hours" : "Hour";
                timeString += $" {time.Hours} {day}";
            }
            if (time.Minutes > 0)
            {
                var day = time.Minutes > 1 ? "Minutes" : "Minute";
                timeString += $" {time.Minutes} {day}";
            }
            if (time.Seconds > 0)
            {
                var day = time.Seconds > 1 ? "Seconds" : "Second";
                timeString += $" {time.Seconds} {day}";
            }

            return timeString;
        }

        private Length CalculateDistance(DSTCalculation data)
        {
            var speed = Speed.From(data.Speed, data.SpeedUnit);
            switch (data.SpeedUnit)
            {
                case SpeedUnit.FootPerSecond:
                    var distance = speed.As(data.SpeedUnit) * data.Time.TotalSeconds;
                    return Length.FromFeet(distance);
                case SpeedUnit.MeterPerSecond:
                    var distance2 = speed.As(data.SpeedUnit) * data.Time.TotalSeconds;
                    return Length.FromMeters(distance2);
                case SpeedUnit.KilometerPerHour:
                    var distance3 = speed.As(data.SpeedUnit) * data.Time.Hours;
                    return Length.FromKilometers(distance3);
                case SpeedUnit.MilePerHour:
                    var distance4 = speed.As(data.SpeedUnit) * data.Time.TotalHours;
                    return Length.FromMiles(distance4);

            }
            throw new Exception("unsupported action");
        }

        private Speed CalculateSpeed(DSTCalculation data)
        {
            var distance = Length.From(data.Distance, data.DistanceUnit);
            switch (data.SpeedUnit)
            {
                case SpeedUnit.FootPerSecond:
                    var feetPerSec = distance.Feet / data.Time.TotalSeconds;
                    return Speed.FromFeetPerSecond(feetPerSec);
                case SpeedUnit.MeterPerSecond:
                    var meterPerSec = distance.Meters / data.Time.TotalSeconds;
                    return Speed.FromMetersPerSecond(meterPerSec);
                case SpeedUnit.KilometerPerHour:
                    var kiloPerHour = distance.Kilometers / data.Time.TotalHours;
                    return Speed.FromKilometersPerHour(kiloPerHour);
                case SpeedUnit.MilePerHour:
                    var milePerHour = distance.Miles / data.Time.TotalHours;
                    return Speed.FromMilesPerHour(milePerHour);

            }

            throw new Exception($"unsupported Speed Unit: {data.SpeedUnit.ToString()}");
        }

        private TimeSpan CalculateTime(DSTCalculation data)
        {
            var distance = Length.From(data.Distance, data.DistanceUnit);
            var speed = Speed.From(data.Speed, data.SpeedUnit);
            switch (data.SpeedUnit)
            {
                case SpeedUnit.FootPerSecond:
                    var seconds = distance.Feet / speed.FeetPerSecond;
                    return TimeSpan.FromSeconds(seconds);
                case SpeedUnit.MeterPerSecond:
                    var seconds2 = distance.Meters / speed.MetersPerSecond;
                    return TimeSpan.FromSeconds(seconds2);
                case SpeedUnit.KilometerPerHour:
                    var hours = distance.Kilometers / speed.KilometersPerHour;
                    return TimeSpan.FromHours(hours);
                case SpeedUnit.MilePerHour:
                    var hours2 = distance.Miles / speed.MilesPerHour;
                    return TimeSpan.FromHours(hours2);
            }

            throw new Exception($"unsupported Speed Unit: {data.SpeedUnit.ToString()}");
        }

        //private string CalculateSymbol(DistanceUnit dataDistanceUnit, SpeedUnit dataSpeedUnit)
        //{
        //    switch (dataDistanceUnit)
        //    {
        //            case 
        //    }
        //}

        //private double DetermineTimeUnit(TimeSpan dataTime, SpeedUnit dataSpeedUnit)
        //{
        //    switch (dataSpeedUnit)
        //    {
        //        case SpeedUnit.Hour:
        //            return dataTime.TotalHours;
        //        case SpeedUnit.Minute:
        //            return dataTime.TotalMinutes;
        //        case SpeedUnit.Second:
        //            return dataTime.TotalSeconds;
        //        default:
        //            throw new Exception("No speed unit found");
        //    }
        //}

        //public TimeSpan CalculateTime(double speed, double distanceValue, string distanceUnit)
        //{
        //    return TimeSpan.FromHours(distanceValue / speed);
        //}

        //public double CalculateDistance(LengthUnit distanceUnit, double distance, SpeedUnit speedUnit)
        //{
            
        //    switch (speedUnit)
        //    {
        //        case SpeedUnit:
        //        {
        //            switch (distanceUnit)
        //            {
        //                    case DistanceUnit.Kilometers:
        //                        return distance * 0.8;
        //                    case DistanceUnit.Feet:
        //            }
        //        }
        //    }
        //}

        
    }
}
﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary.Classes;
using CommonLibrary.LanguageExtensions;
using ConsoleHelpers.Classes;
using static System.DateTime;
using static ConsoleHelpers.Classes.ConsoleColors;

namespace DatesConsole1
{
    class Program
    {
        static void Main(string[] args)
        {

            
            InternetLocal();
            //ConsoleWaiters.PressAnyKey(20);

        }

        /// <summary>
        /// How to mock date/time, not acceptable for real unit testing
        /// </summary>
        static void ClockMocked()
        {
            Clock.Set(() => new DateTime(Now.Year, Now.Month -1, 14, Now.Hour -3, 23, 0));
            Task.Delay(2000).Wait();
            var time = Clock.UtcNow;
            Console.WriteLine(time);
        }

        /// <summary>
        /// Create date time from long value, in this case for the current date/time
        ///
        /// This may be needed when incoming data is a long value
        /// </summary>
        static void DateTime_Int_Constructor()
        {
            WriteLineYellow("DateTime(Int64) constructor.");

            long ticks = new DateTime(
                Now.Year, 
                Now.Month, 
                Now.Day, 
                Now.Hour, 
                Now.Minute, 
                Now.Second, 
                new CultureInfo("en-US", false).Calendar).Ticks;

            Console.WriteLine($"    Ticks: {ticks}");
            DateTime dateTime = new(ticks);

            Console.WriteLine($"Date/time: {dateTime}");

            ConsoleWaiters.PressAnyKey();
        }

        /// <summary>
        /// Create a new date time from year, month, day
        /// </summary>
        static void DateTime_Year_Month_Day()
        {
            WriteLineYellow("DateTime(year, month, day) constructor.");

            DateTime dateTime = new(Now.Year, Now.Month, Now.Day);

            Console.WriteLine($"Unformatted: {dateTime}");
            Console.WriteLine($"  Formatted: {dateTime:d}");
            
            ConsoleWaiters.PressAnyKey();
        }

        /// <summary>
        /// Create a date time and changing time of a DateTime after created
        /// 
        /// 1. Create DateTime with month, day, year, hours, minutes and seconds
        /// 2. Change time using <seealso cref="DateTimeExtensions.At"/> by passing a TimeSpan
        /// 3. Change time using <seealso cref="DateTimeExtensions.At"/> by passing a hour, minutes and seconds
        /// </summary>
        static void DateTime_Year_Month_Day_Hour_Min_Sec()
        {
            WriteLineYellow("DateTime(year, month, day) constructor.");

            DateTime dateTime = new(Now.Year, Now.Month, Now.Day, 13,0,0);
            Console.WriteLine($"Unformatted: {dateTime}");
            Console.WriteLine();

            WriteLineGreen("Language extension using TimeSpan");
            /*
             * Change the time via extension method
             */
            Console.WriteLine(dateTime.At(new TimeSpan(9, 20, 55)));
            Console.WriteLine();

            WriteLineGreen("Language extension using int for hour minutes seconds");
            /*
             * Change the time via extension method overload of one above
             */
            Console.WriteLine(dateTime.At(15,15,15));

            ConsoleWaiters.PressAnyKey();
        }

        /// <summary>
        /// Get DateTime elements which are valid
        /// </summary>
        private static void StringToDateTimePerfect()
        {
            List<string> data = new() { "2021-07-11 00:00:00.000", "2021-07-26 00:00:00.000", "2021-08-21 00:00:00.000" };

            List<DateTime> dates = data.Select(DateTime.Parse).ToList();

            dates.ForEach(current => Console.WriteLine(current));
            ConsoleWaiters.PressAnyKey();

        }

        /// <summary>
        /// Check if any strings can not represent a valid DateTime by their index in the array.
        /// This is useful when data is unreliable 
        /// </summary>
        private static void StringToDateTimeRealWorld()
        {
            List<string> data = new() { "202107-11 00:00:00.000", "2021-07-26 00:00:00.000", "2021-08-2100:00:00.000" };
            List<DateTime> dates = data.ToDateTimeList();

            dates.ForEach(current => Console.WriteLine(current));
            
            foreach (var index in data.GetNonDateIndexes())
            {
                Console.WriteLine(index);
            }

            ConsoleWaiters.PressAnyKey();

        }

        private static void CompareDateTime1()
        {
            /*
             * Both of these dates time is midnight
             * First one ToMidNight forces the time
             * while the second is midnight by default
             */
            DateTime dateTime1 = DateTime.Now.ToMidnight();
            DateTime dateTime2 = new(Now.Year, Now.Month, Now.Day);

            WriteLineSplit("dateTime1 == dateTime2 ", $"{dateTime1 == dateTime2}");

            /*
             * False because of time
             */
            WriteLineSplit($"Current {Now} == {dateTime2} ", $"{Now == dateTime2}");

            ConsoleWaiters.PressAnyKey(10);

        }

        /// <summary>
        /// Compare string dates in different formats (date/time does not have a format)
        /// </summary>
        private static void CompareDatesAsString()
        {
            var value1 = "2021-07-11 00:00:00.000";
            var value2 = "07-11-2021 00:00:00.000";

            if (DateTime.Parse(value1, CultureInfo.InvariantCulture) == DateTime.Parse(value2, CultureInfo.InvariantCulture))
            {
                Console.WriteLine("Match");
                
            }

            /*
             * milliseconds are different
             */
            value2 = "07-11-2021 00:00:00.001";

            Console.WriteLine(DateTime.Parse(value1, CultureInfo.InvariantCulture) == DateTime.Parse(value2, CultureInfo.InvariantCulture) ? 
                "Match" : 
                "No match");


            ConsoleWaiters.PressAnyKey(10);
        }

        private static void InternetLocal()
        {
            WriteLineBold("This will take a few seconds", false);

            var current = InternetHelpers.LocalTime();
            if (current.HasValue)
            {
                DateTimeHelpers.ShowPossibleTimeZones(current.Value);
                Console.WriteLine($"ReturnTimeOnServer: {DateTimeHelpers.ReturnTimeOnServer("11/15/2021 2:58:43 -08:00")}");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            Console.WriteLine();
            ConsoleWaiters.PressAnyKey(15);
        }
        
        /// <summary>
        /// Show russian date time for now
        /// </summary>
        static void RussianCurrentDateTime()
        {
            /*
             * one of 11 time zones
             */
            WriteLineYellow("Current Russian date time");

            // (GMT+11)
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Magadan Standard Time");
            var dateTime = TimeZoneInfo.ConvertTime(Now, timeZoneInfo);
            Console.WriteLine(dateTime.ToString("yyyy-MM-dd HH-mm-ss"));

            ConsoleWaiters.PressAnyKey();

        }

    }
}

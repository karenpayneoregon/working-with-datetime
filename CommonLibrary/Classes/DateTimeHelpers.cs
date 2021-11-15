
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace CommonLibrary.Classes
{
    public class DateTimeHelpers
    {

        /// <summary>
        /// Show potential time zones for a DateTimeOffset
        /// </summary>
        /// <param name="offsetTime"></param>
        public static void ShowPossibleTimeZones(DateTimeOffset offsetTime)
        {
            TimeSpan offset = offsetTime.Offset;

            Console.WriteLine($"{offsetTime} could belong to the following time zones:");

            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

            foreach (TimeZoneInfo timeZone in timeZones)
            {
                if (timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset))
                {
                    Console.WriteLine($"   {timeZone.DisplayName}");
                }
            }
        }

        /// <summary>
        /// If the date and time of a user request for a Web page is known and is serialized as a string in the format
        /// MM/dd/yyyy hh:mm:ss zzzz, the following ReturnTimeOnServer method converts this date and time value to the date
        /// and time on the Web server.
        /// </summary>
        /// <param name="clientString"></param>
        /// <returns></returns>
        public static DateTimeOffset ReturnTimeOnServer(string clientString)
        {
            string format = @"M/d/yyyy H:m:s zzz";
            var serverOffset = TimeZoneInfo.Local.GetUtcOffset(System.DateTimeOffset.Now);

            try
            {
                DateTimeOffset clientTime = DateTimeOffset.ParseExact(clientString, format, CultureInfo.InvariantCulture);
                DateTimeOffset serverTime = clientTime.ToOffset(serverOffset);
                return serverTime;
            }
            catch (FormatException)
            {
                return DateTimeOffset.MinValue;
            }
        }
    }
}

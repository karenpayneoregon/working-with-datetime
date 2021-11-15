using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.LanguageExtensions
{
    /// <summary>
    /// Common string extensions 
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Get possible time zones for a DateTimeOffset
        /// </summary>
        /// <param name="offsetTime"></param>
        /// <returns>time zone names</returns>
        public static List<string> PossibleTimeZones(this DateTimeOffset offsetTime)
        {
            List<string> list = new();
            TimeSpan offset = offsetTime.Offset;

            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

            list.AddRange(from TimeZoneInfo timeZone in timeZones
                where timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset)
                select timeZone.DaylightName);

            return list;
        }
        public static List<DateTime> ToDateTimeList(this IEnumerable<string> sender) =>
            Array
                .ConvertAll(sender.ToArray(), (input) => new { IsDateTime = DateTime.TryParse(input, out var integerValue), Value = integerValue })
                .Where(result => result.IsDateTime)
                .Select(result => result.Value)
                .ToList();
        public static int[] GetNonDateIndexes(this IEnumerable<string> sender) =>
            sender.Select(
                    (item, index) => DateTime.TryParse(item, out var tResult) ?
                        new { IsValid = true, Index = index } :
                        new { IsValid = false, Index = index }
                    )
                .ToArray()
                .Where(item => item.IsValid == false)
                .Select(item => item.Index).ToArray();

        /// <summary>
        /// Combine date and time
        /// </summary>
        /// <param name="dateTime">Valid Initialized DateTime</param>
        /// <param name="time">Valid initialized TimeSpan</param>
        /// <returns>Day with Time</returns>
        public static DateTime At(this DateTime dateTime, TimeSpan time) =>
            new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0).Add(time);

        /// <summary>
        /// Combine date and time
        /// </summary>
        /// <param name="dateTime">Valid Initialized DateTime</param>
        /// <param name="hour">set hour</param>
        /// <param name="minutes">set minutes</param>
        /// <param name="seconds">set seconds</param>
        /// <returns></returns>
        public static DateTime At(this DateTime dateTime, int hour, int minutes, int seconds) => 
            dateTime.At(time: new(hour, minutes, seconds));

        public static DateTime ToMidnight(this DateTime dateTime) =>
            dateTime.At(time: new(0, 0, 0, 0));

        /// <summary>
        /// Show possible time zone for a DateTimeOffset
        /// </summary>
        /// <param name="offsetTime"><see cref="DateTimeOffset"/></param>
        /// <returns>list of possible time zones</returns>
        /// <remarks>
        /// var dstDate = new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0);
        /// DateTimeOffset thisTime = new DateTimeOffset(dstDate, new TimeSpan(-7, 0, 0));
        /// Console.WriteLine("{0} could belong to the following time zones:", thisTime.ToString());
        /// thisTime.ShowPossibleTimeZones().ForEach(Console.WriteLine);
        /// </remarks>
        public static List<string> ShowPossibleTimeZones(this DateTimeOffset offsetTime)
        {
            TimeSpan offset = offsetTime.Offset;
            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

            return (from timeZone in timeZones where timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset) select timeZone.DisplayName).ToList();
        }
    }
}

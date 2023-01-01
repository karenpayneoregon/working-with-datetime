using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace CommonLibrary.LanguageExtensions;

/// <summary>
/// Common datetime extensions 
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Get possible time zones for a DateTimeOffset
    /// </summary>
    /// <param name="offsetTime"></param>
    /// <returns>time zone names</returns>
    public static ImmutableList<string> PossibleTimeZones(this DateTimeOffset offsetTime)
    {
        List<string> list = new();
        TimeSpan offset = offsetTime.Offset;

        ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        list.AddRange(from TimeZoneInfo timeZone in timeZones
            where timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset)
            select timeZone.DaylightName);

        return list.ToImmutableList();
    }

    /// <summary>
    /// Convert string representations of date time to <see cref="DateTime"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static List<DateTime> ToDateTimeList(this IEnumerable<string> sender) =>
        Array
            .ConvertAll(sender.ToArray(), (input) => new { IsDateTime = DateTime.TryParse(input, out var integerValue), Value = integerValue })
            .Where(result => result.IsDateTime)
            .Select(result => result.Value)
            .ToList();

    /// <summary>
    /// Get indices which can not represent a DateTime
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Return time at mid-night
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Round up by minutes DateTime.Now.RoundUp(TimeSpan.FromMinutes(15))
    /// </summary>
    /// <param name="dateTime">Base datetime object to round up.</param>
    /// <param name="timeSpan">Timespan interval for rounding</param>
    /// <returns>Rounded datetime</returns>
    public static DateTime RoundUp(this DateTime dateTime, TimeSpan timeSpan)
        => new((dateTime.Ticks + timeSpan.Ticks - 1) / timeSpan.Ticks * timeSpan.Ticks, dateTime.Kind);

    /// <summary>
    /// Format a TimeSpan with AM PM
    /// </summary>
    /// <param name="sender">TimeSpan to format</param>
    /// <param name="format">Optional format</param>
    /// <returns></returns>
    public static string Formatted(this TimeSpan sender, string format = "hh:mm tt") =>
        DateTime.Today.Add(sender).ToString(format);

    /// <summary>
    /// Determines whether the specified DateTime object occurs on a weekend.
    /// </summary>
    /// <param name="self">The DateTime object.</param>
    /// <returns></returns>
    public static bool IsWeekend(this DateTime self)
    {
        return (self.DayOfWeek == DayOfWeek.Sunday || self.DayOfWeek == DayOfWeek.Saturday);
    }

    /// <summary>
    /// Determines whether the specified DayOfWeek occurs on a weekend.
    /// </summary>
    /// <param name="self">The Day of Week.</param>
    /// <returns></returns>
    public static bool IsWeekend(this DayOfWeek self)
    {
        return !self.IsWeekday();
    }

    /// <summary>
    /// Determines whether the specified DateTime occurs on a week day.
    /// </summary>
    /// <param name="self">The DateTime object.</param>
    /// <returns></returns>
    public static bool IsWeekday(this DateTime self) => !self.IsWeekend();

    /// <summary>
    /// Determines whether the specified DayOfWeek occurs on a week day.
    /// </summary>
    /// <param name="self">The DayOfWeek.</param>
    /// <returns></returns>
    public static bool IsWeekday(this DayOfWeek self) =>
        self switch
        {
            DayOfWeek.Sunday => false,
            DayOfWeek.Saturday => false,
            _ => true
        };

    /// <summary>
    /// Conditionally format TimeSpan dependent on if there are days, hours, minutes.
    /// Does not handle years and milliseconds
    /// </summary>
    /// <param name="span"><see cref="TimeSpan"/> from two dates</param>
    /// <returns>Formatted string</returns>
    public static string FormatElapsed(this TimeSpan span) => span.Days switch
    {
        > 0 => $"{span.Days} days, {span.Hours} hours, {span.Minutes} minutes, {span.Seconds} seconds",
        _ => span.Hours switch
        {
            > 0 => $"{span.Hours} hours, {span.Minutes} minutes, {span.Seconds} seconds",
            _ => span.Minutes switch
            {
                > 0 => $"{span.Minutes} minutes, {span.Seconds} seconds",
                _ => span.Seconds switch
                {
                    > 0 => $"{span.Seconds} seconds",
                    _ => ""
                }
            }
        }
    };
}
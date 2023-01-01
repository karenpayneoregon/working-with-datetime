using System.Text.RegularExpressions;

namespace DateOnlyApp.Classes;
internal static class Extensions
{
    public static void Deconstruct(this DateOnly date, out int day, out int month, out int year) =>
        (day, month, year) = (date.Day, date.Month, date.Year);

    public static bool IsWeekend(this DateTime sender)
        => (sender.DayOfWeek == DayOfWeek.Sunday || sender.DayOfWeek == DayOfWeek.Saturday);

    public static bool IsWeekDay(this DateTime sender)
        => !sender.IsWeekend();

    public static bool IsWeekDay(this DayOfWeek sender)
    {
        return sender is DayOfWeek.Monday or DayOfWeek.Tuesday || sender == DayOfWeek.Wednesday ||
               sender == DayOfWeek.Thursday || sender == DayOfWeek.Friday;
    }

    public static bool IsWeekend(this DayOfWeek sender) => !sender.IsWeekDay();

    public static bool IsWeekend(this DateOnly sender)
        => (sender.DayOfWeek == DayOfWeek.Sunday || sender.DayOfWeek == DayOfWeek.Saturday);

    public static bool IsWeekDay(this DateOnly sender)
        => !sender.IsWeekend();

    /// <summary>
    /// Get all days in month as <see cref="DateOnly"/> list
    /// </summary>
    /// <param name="month">Month index</param>
    /// <returns>list of date only for given month</returns>
    public static List<DateOnly> GetMonthDays(this int month)
    {
        var year = DateTime.Now.Year;

        return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
            .Select(day => new DateOnly(year, month, day))
            .ToList();
    }

    public static string ToYesNo(this bool value) => value ? "Yes" : "No";

    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", Regex.Matches(sender, @"([A-Z][a-z]+)")
            .Select(m => m.Value));
}

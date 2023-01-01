using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOnlyApp.Classes;
internal static class Extensions
{
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

    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
}

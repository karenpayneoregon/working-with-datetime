using Microsoft.Data.SqlClient;

namespace NewtonsoftDateOnlyTimeOnlyApp.Classes;

/// <summary>
/// Extension methods to make it easy to get at DateOnly and TimeOnly as done with convention data types
/// </summary>
internal static class Extensions
{

    public static DateOnly GetDateOnly(this SqlDataReader reader, int index)
        => reader.GetFieldValue<DateOnly>(index);

    public static string GetDateOnlyFormatted(this SqlDataReader reader, int index)
        => reader.GetFieldValue<DateOnly>(index).ToString("MM/dd/yyyy");

    public static TimeOnly GetTimeOnly(this SqlDataReader reader, int index)
        => reader.GetFieldValue<TimeOnly>(index);

    public static string GetTimeOnlyFormatted(this SqlDataReader reader, int index)
        => reader.GetFieldValue<TimeOnly>(index).ToString("hh:mm tt");
}
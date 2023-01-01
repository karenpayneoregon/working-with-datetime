using ConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using NewtonsoftDateOnlyTimeOnlyApp.Models;

namespace NewtonsoftDateOnlyTimeOnlyApp.Classes;

internal class DataOperations
{
    /// <summary>
    /// Example for reading <see cref="DateOnly"/> and <see cref="TimeOnly"/> with <see cref="SqlDataReader"/>
    /// </summary>
    /// <returns></returns>
    public static async Task Read()
    {
        Helpers.PrintSampleName();
        var statement =
            "SELECT VL.VisitOn, VL.EnteredTime, VL.ExitedTime FROM Visitor AS V " + 
            "INNER JOIN VisitorLog AS VL ON V.VisitorIdentifier = VL.VisitorIdentifier WHERE (V.VisitorIdentifier = 1);";

        await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        await using var cmd = new SqlCommand { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        await using var reader = await cmd.ExecuteReaderAsync();



        reader.Read();
        var logItem = new VisitorLog()
        {
            VisitOn = reader.GetDateOnly(0), EnteredTime = reader.GetTimeOnly(1), ExitedTime = reader.GetTimeOnly(2)
        };

        string json = JsonConvert.SerializeObject(logItem, Formatting.Indented);

        Console.WriteLine(json);

    }


}
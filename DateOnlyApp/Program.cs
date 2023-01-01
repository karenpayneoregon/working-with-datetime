using System;
using System.Runtime.InteropServices.JavaScript;
using DateOnlyApp.Classes;

namespace DateOnlyApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        CompareDateTimeToDateOnlySimple();
        DateOnlyGetDaysInSpecificMonth();

        Console.ReadLine();
    }

    private static void DateOnlyGetDaysInSpecificMonth()
    {
        Helpers.PrintSampleName();

        var result = 1.GetMonthDays();
        var chunked = result.Chunk(7);

        foreach (var dateOnlyArray in chunked)
        {
            foreach (var dateOnly in dateOnlyArray)
            {
                Console.WriteLine(string.Join(",", dateOnly));
            }

            Console.WriteLine();
        }
    }

    private static void CompareDateTimeToDateOnlySimple()
    {
        Helpers.PrintSampleName();

        DateTime dateTime = new DateTime(2023, 12, 14, 13, 2, 0);
        AnsiConsole.MarkupLine($"[cyan]{dateTime}[/] is week day? [cyan]{dateTime.IsWeekDay().ToYesNo()}[/]");

        DateOnly dateOnly = new DateOnly(2023, 12, 14);
        AnsiConsole.MarkupLine($"[cyan]{dateOnly}[/] is week day? [cyan]{dateOnly.IsWeekDay().ToYesNo()}[/]");

        var (day, month, year) = dateOnly;
        AnsiConsole.MarkupLine($"[cyan]Deconstruct[/] [white]{year}[/]/[white]{month}[/]/[white]{day}[/]");
    }
}
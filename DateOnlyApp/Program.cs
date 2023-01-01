using System.Runtime.InteropServices.JavaScript;
using DateOnlyApp.Classes;

namespace DateOnlyApp;

internal partial class Program
{
    static void Main(string[] args)
    {


        DateTime dateTime = new DateTime(2023, 1, 1, 13, 2, 0);
        AnsiConsole.MarkupLine($"[cyan]{dateTime}[/] is week day? [cyan]{dateTime.IsWeekDay().ToYesNo()}[/]");

        DateOnly dateOnly = new DateOnly(2023, 1, 1);
        AnsiConsole.MarkupLine($"[cyan]{dateOnly}[/] is week day? [cyan]{dateOnly.IsWeekDay().ToYesNo()}[/]");


        Console.ReadLine();
    }
}
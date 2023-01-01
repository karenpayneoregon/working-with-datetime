using System.Runtime.CompilerServices;

namespace DateOnlyApp.Classes;

internal class Helpers
{
    public static void PrintSampleName([CallerMemberName] string? methodName = null)
    {
        Console.WriteLine();
        AnsiConsole.MarkupLine($"[cyan]Sample:[/] [white]{methodName!.SplitCamelCase()}[/]");
        Console.WriteLine();
    }
}
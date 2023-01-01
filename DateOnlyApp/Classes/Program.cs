using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace DateOnlyApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample: DateOnly";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}

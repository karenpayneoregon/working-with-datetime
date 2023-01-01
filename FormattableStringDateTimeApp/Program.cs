using System.Globalization;

namespace FormattableStringDateTimeApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        string[] codes = new[] { "it-IT", "es-ES", "fr-FR", "jp-JP" };
        DateTime dateTime = DateTime.Now;
        FormattableString fs = $"[white]{dateTime:yyyy-MM-dd dddd}[/]";

        foreach (var code in codes)
        {
            AnsiConsole.MarkupLine($"[yellow]{code}[/] " + fs.ToString(new CultureInfo(code)));
        }
        Console.ReadLine();
    }
}
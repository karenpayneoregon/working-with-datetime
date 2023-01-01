using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace NewtonsoftDateOnlyTimeOnlyApp
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            AnsiConsole.MarkupLine("");
            Console.Title = "Code sample: Newtonsoft/Json.net supporting DateOnly and TimeOnly";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }

        private static void Render(Rule rule)
        {
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
        }

        private static void ExitPrompt()
        {
            Console.WriteLine();
            Render(new Rule($"[white on blue]Press a key to exit[/]").RuleStyle(Style.Parse("cyan")).Centered());
            Console.ReadLine();
        }

        public static void LineBreak()
        {
            Render(new Rule().RuleStyle(Style.Parse("cyan")));
        }


    }
}

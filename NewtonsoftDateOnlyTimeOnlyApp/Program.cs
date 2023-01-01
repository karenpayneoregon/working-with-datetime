using Newtonsoft.Json;
using NewtonsoftDateOnlyTimeOnlyApp.Classes;
using NewtonsoftDateOnlyTimeOnlyApp.Models;

namespace NewtonsoftDateOnlyTimeOnlyApp
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            AnsiConsole.MarkupLine("[white]Working with [/][cyan]DateOnly[/] [white]and[/] [cyan]TimeOnly[/] [white]using[/] [cyan]Newtonsoft.Json[/]");
            Console.WriteLine();
            await DataOperations.Read();
            LineBreak();
            Sample1();
            LineBreak();
            Sample2();

            ExitPrompt();
        }

        private static void Sample1()
        {

            Helpers.PrintSampleName();

            var containers = Mocked.Container();
            string json = JsonConvert.SerializeObject(containers, Formatting.Indented);

            Console.WriteLine(json);

            Console.WriteLine();

            var readContainers = JsonConvert.DeserializeObject<List<Container>>(json);

            foreach (var container in readContainers)
            {
                Console.WriteLine(
                    $"{container.Id,-3}{container.FirstName,-10}{container.LastName,-15}{container.StartDate,-12} {container.StartTime}");
            }
        }

        /// <summary>
        /// Uses Bogus to create a list where Bogus jut recently began supporting DateOnly and TimeOnly
        /// </summary>
        private static void Sample2()
        {

            Helpers.PrintSampleName();

            var containers = Mocked.People(2);
            string json = JsonConvert.SerializeObject(containers, Formatting.Indented);

            Console.WriteLine(json);

            Console.WriteLine();

            var readContainers = JsonConvert.DeserializeObject<List<Container>>(json);

            foreach (var container in readContainers)
            {
                Console.WriteLine(
                    $"{container.Id,-3}{container.FirstName,-10}{container.LastName,-15}{container.StartDate,-12} {container.StartTime}");
            }
        }
    }
}
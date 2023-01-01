namespace ConsoleHelpers.Classes;

public static class Menu
{
    public static string DisplayMenu()
    {

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Menu - Press a letter then enter");
        Console.ResetColor();

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("A ");
        Console.ResetColor();
        Console.Write("Create date time default\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("B ");
        Console.ResetColor();
        Console.Write("Create date time with year, month, day\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("C ");
        Console.ResetColor();
        Console.Write("Create date time with year, month, day, hour, minutes, seconds\n");


        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("D ");
        Console.ResetColor();
        Console.Write("Get DateTime elements which are valid in container\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("E ");
        Console.ResetColor();
        Console.Write("Check if any strings can not represent a valid DateTime by their index in the array\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("F ");
        Console.ResetColor();
        Console.Write("Basic compare two dates\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("G ");
        Console.ResetColor();
        Console.Write("Compare string dates in different formats (date/time does not have a format)\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("H ");
        Console.ResetColor();
        Console.Write("Round to quarter hour\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("I ");
        Console.ResetColor();
        Console.Write("Format time AM/PM\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("J ");
        Console.ResetColor();
        Console.Write("Format TimeSpan elapsed time\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("K ");
        Console.ResetColor();
        Console.Write("Mocked time\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Q ");
        Console.ResetColor();
        Console.Write("Exit\n");

        var result = Console.ReadLine();

        Console.Clear();

        return result!.ToUpper();

    }

}
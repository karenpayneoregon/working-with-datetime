namespace ConsoleHelpers.Classes;

public static class ConsoleWaiters
{
    /// <summary>
    /// ReadLine with timeout
    /// </summary>
    /// <param name="seconds">Length of time for time out</param>
    /// <param name="message">Optional message to display</param>
    /// <returns></returns>
    public static string ReadLineWithTimeout(int seconds, string message = "")
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            Colored(message, ConsoleColor.White);
        }

        var timeSpan = TimeSpan.FromSeconds(seconds);
        var task = Task.Factory.StartNew(Console.ReadLine);

        var result = (Task.WaitAny(new Task[] { task }, timeSpan) == 0) ? task.Result : string.Empty;

        return result!;

    }

    public static void PressEnterKey(int seconds = 5)
    {
        var timeSpan = TimeSpan.FromSeconds(seconds);
        var task = Task.Factory.StartNew(Console.ReadLine);

        Colored($"Press any key to exit (timeout in {seconds} seconds)", ConsoleColor.White);
        var _ = (Task.WaitAny(new Task[] { task }, timeSpan) == 0) ? task.Result : string.Empty;
    }

    /// <summary>
    /// Set fore color for Console.WriteLine
    /// </summary>
    /// <param name="message">Text to display</param>
    /// <param name="foreConsoleColor">Color for foreground, defaults to Yellow</param>
    public static void Colored(string message, ConsoleColor foreConsoleColor = ConsoleColor.Yellow)
    {
        Console.ForegroundColor = foreConsoleColor;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
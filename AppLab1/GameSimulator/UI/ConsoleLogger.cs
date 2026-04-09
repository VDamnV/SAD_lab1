namespace GameSimulator.UI;

public static class ConsoleLogger
{
    // Цей метод ми будемо підписувати на події OnGameStateChanged з наших ігор
    public static void LogMessage(string message)
    {
        Console.WriteLine($"[СИСТЕМА]: {message}");
    }
    
    public static void LogError(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ПОМИЛКА]: {error}");
        Console.ResetColor();
    }
}
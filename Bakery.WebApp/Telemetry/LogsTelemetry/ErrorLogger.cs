namespace Bakery.WebApp.Telemetry;
public class ErrorLogger
{
    public void LogError(string errorMessage)
    {
        Console.WriteLine($"Error: {errorMessage}");
    }
}

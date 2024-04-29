using Microsoft.Extensions.Logging;

namespace Bakery.WebApp.Telemetry;
public class ErrorLogger
{
    private readonly ILogger<ErrorLogger> _logger;
    private int _errorCount;
    public int ErrorCount => _errorCount;

    public ErrorLogger(ILogger<ErrorLogger> logger)
    {
      _logger = logger;
      _errorCount = 0;  
    }
    public void LogErrorGenerator(string errorMessage)
    {
        _logger.LogError($"Error: {errorMessage}");
        _errorCount++;
    }
}

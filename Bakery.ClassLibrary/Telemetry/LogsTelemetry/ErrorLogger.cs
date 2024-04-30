using Microsoft.Extensions.Logging;

namespace Bakery.WebApp.Telemetry;
public class ErrorLogger
{
    private readonly ILogger<ErrorLogger> _logger;

    public ErrorLogger(ILogger<ErrorLogger> logger)
    {
      _logger = logger;
    }
    public void LogErrorGenerator(string errorMessage)
    {
        _logger.LogError($"Error: {errorMessage}");
    }
}

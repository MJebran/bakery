
using Microsoft.Extensions.Logging;

namespace Bakery.WebApp.Telemetry;
public class PageLogger
{
    private readonly ILogger<PageLogger> _logger;
    private int _errorCount;
    DateTime dateTime = DateTime.Now;

    public int ErrorCount => _errorCount;

    public PageLogger(ILogger<PageLogger> logger)
    {
        _logger = logger;
        _errorCount = 0;
    }

    public void LogHomePageAccess(string username)
    {
        _logger.LogInformation($"User '{username}' accessed the Home page.");
    }

    public void LogMenuPageAccess(string username)
    {
        _logger.LogInformation($"User '{username}' accessed the Menu page.");
    }
    public void AddCategoryLogNotification()
    {
        _logger.LogInformation($"New Category added at {dateTime}");
    }
    public void AddToppingLogNotification()
    {
        _logger.LogInformation($"New Topping added at: {dateTime}");
    }
}

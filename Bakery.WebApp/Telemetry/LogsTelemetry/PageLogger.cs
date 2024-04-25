
namespace Bakery.WebApp.Telemetry;
public class PageLogger
{
    private readonly ILogger<PageLogger> _logger;
    private int _errorCount;

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

}

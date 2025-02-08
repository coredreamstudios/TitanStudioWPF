using Microsoft.Extensions.Logging;
using TitanStudio.Core.Interfaces;

namespace TitanStudio.Core.Services;
public class TestService : ITestService
{
    private readonly ILogger<TestService> _logger;

    public TestService(ILogger<TestService> logger)
    {
        _logger = logger;
    }

    public async Task TestAsync()
    {
        _logger.LogInformation("Test command is executing.");
        await Task.Delay(1000);
        _logger.LogInformation("Test command has been executed.");
    }
}

using LearningDotNet.Interfaces;

namespace LearningDotNet;
public class LoggingService : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class MyClassConstructorInjection(ILogger loggingService)
{
    public void PerformAction()
    {
        loggingService.Log("Constructor Injection: Logging message.");
    }
}

public class MyClassSetterInjection(ILogger loggingService)
{
    private ILogger LoggingService { get; set; } = loggingService;

    public void PerformAction()
    {
        this.LoggingService.Log("Setter Injection: Logging message.");
    }
}

public interface IDependencyInjector
{
    void SetDependency(ILogger loggingService);
}

public class MyClassInterfaceInjection(ILogger loggingService) : IDependencyInjector
{
    private ILogger _loggingService = loggingService;

    public void SetDependency(ILogger loggingService)
    {
        _loggingService = loggingService;
    }

    public void PerformAction()
    {
        this._loggingService.Log("Interface Injection: Logging message.");
    }
}
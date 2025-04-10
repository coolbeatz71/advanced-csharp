namespace LearningDotNet;

public interface ILoggingService
{
    void Log(string message);
}

public class LoggingService : ILoggingService
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class MyClassConstructorInjection(ILoggingService loggingService)
{
    public void PerformAction()
    {
        loggingService.Log("Constructor Injection: Logging message.");
    }
}

public class MyClassSetterInjection(ILoggingService loggingService)
{
    private ILoggingService LoggingService { get; set; } = loggingService;

    public void PerformAction()
    {
        this.LoggingService.Log("Setter Injection: Logging message.");
    }
}

public interface IDependencyInjector
{
    void SetDependency(ILoggingService loggingService);
}

public class MyClassInterfaceInjection(ILoggingService loggingService) : IDependencyInjector
{
    private ILoggingService _loggingService = loggingService;

    public void SetDependency(ILoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    public void PerformAction()
    {
        this._loggingService.Log("Interface Injection: Logging message.");
    }
}
using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class StockMonitorTest
{
   [Fact]
    public void SettingPrice_AboveThreshold_ShouldNotTriggerAlert()
    {
        // Arrange
        var monitor = new StockMonitor { Threshold = 100 };
        string? capturedMessage = null;
        monitor.OnPriceChanged += message => capturedMessage = message;

        // Act
        monitor.Price = 120;

        // Assert
        capturedMessage.Should().Be("(No alert for 120)");
    }

    [Fact]
    public void SettingPrice_BelowThreshold_ShouldTriggerAlert()
    {
        // Arrange
        var monitor = new StockMonitor { Threshold = 100 };
        string? capturedMessage = null;
        monitor.OnPriceChanged += message => capturedMessage = message;

        // Act
        monitor.Price = 90;

        // Assert
        capturedMessage.Should().Be("Stock Alert: Stock price is below threshold!");
    }

    [Fact]
    public void SettingPrice_ExactlyAtThreshold_ShouldNotTriggerAlert()
    {
        // Arrange
        var monitor = new StockMonitor { Threshold = 100 };
        string? capturedMessage = null;
        monitor.OnPriceChanged += message => capturedMessage = message;

        // Act
        monitor.Price = 100;

        // Assert
        capturedMessage.Should().Be("(No alert for 100)");
    }

    [Fact]
    public void MultipleSubscribers_AllShouldReceiveMessage()
    {
        // Arrange
        var monitor = new StockMonitor { Threshold = 200 };
        string? msg1 = null;
        string? msg2 = null;
        monitor.OnPriceChanged += message => msg1 = message;
        monitor.OnPriceChanged += message => msg2 = message;

        // Act
        monitor.Price = 190;

        // Assert
        msg1.Should().Be("Stock Alert: Stock price is below threshold!");
        msg2.Should().Be("Stock Alert: Stock price is below threshold!");
    }

    [Fact]
    public void NoSubscribers_ShouldNotThrowException()
    {
        // Arrange
        var monitor = new StockMonitor { Threshold = 100 };

        // Act
        Action act = () => monitor.Price = 90;

        // Assert
        act.Should().NotThrow(); // No subscriber to OnPriceChanged, should be safe
    }
    
    [Fact]
    public void OnPriceChanged_PrintsCorrectMessageToConsole()
    {
        // Arrange
        var alert = new StockAlert();
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        const string message = "Test alert message";
        
        // Act
        alert.OnPriceChanged(message);

        // Assert
        var output = consoleOutput.ToString();
        output.Trim().Should().Be($"Alert: {message}");
    }
}
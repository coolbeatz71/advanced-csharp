using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class TemperatureMonitorTest
{
    [Fact]
    public void Temperature_SetBelowThreshold_DoesNotTriggerEvent()
    {
        // Arrange
        var monitor = new TemperatureMonitor();
        var eventTriggered = false;
        monitor.OnTemperatureChanged += _ => eventTriggered = true;

        // Act
        monitor.Temperature = 36;

        // Assert
        eventTriggered.Should().BeFalse();
    }
    
    [Fact]
    public void Temperature_SetAboveThreshold_TriggersEventWithCorrectMessage()
    {
        // Arrange
        var monitor = new TemperatureMonitor();
        string? receivedMessage = null;
        monitor.OnTemperatureChanged += message => receivedMessage = message;

        // Act
        monitor.Temperature = 37;

        // Assert
        receivedMessage.Should().Be("Body Temperature Above Threshold");
    }
    
    [Fact]
    public void Temperature_SetExactlyAtThreshold_DoesNotTriggerEvent()
    {
        // Arrange
        var monitor = new TemperatureMonitor();
        var eventTriggered = false;
        monitor.OnTemperatureChanged += _ => eventTriggered = true;

        // Act
        monitor.Temperature = 36.0;

        // Assert
        eventTriggered.Should().BeFalse();
    }
    
    [Fact]
    public void Temperature_SetMultipleTimes_EventTriggersOnlyWhenAboveThreshold()
    {
        // Arrange
        var monitor = new TemperatureMonitor();
        var messages = new List<string>();
        monitor.OnTemperatureChanged += msg => messages.Add(msg);

        // Act
        monitor.Temperature = 35;
        monitor.Temperature = 36;
        
        // Should trigger Event
        monitor.Temperature = 36.5;
        monitor.Temperature = 37;

        // Assert
        messages.Should().HaveCount(2);
        messages.Should().Contain("Body Temperature Above Threshold");
    }
}
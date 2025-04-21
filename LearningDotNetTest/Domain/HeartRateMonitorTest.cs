using System;
using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class HeartRateMonitorTests
{
    [Fact]
    public void SettingHeartRate_AboveThreshold_ShouldTriggerEvent()
    {
        // Arrange
        var monitor = new HeartRateMonitor();
        HeartRateChangeEventArgs? receivedEventArgs = null;
        monitor.OnHeartRateChanged += (_, args) => receivedEventArgs = args;

        // Act
        monitor.HeartRate = 120;

        // Assert
        receivedEventArgs.Should().NotBeNull();
        receivedEventArgs!.HeartRate.Should().Be(120);
    }

    [Fact]
    public void SettingHeartRate_BelowThreshold_ShouldNotTriggerEvent()
    {
        // Arrange
        var monitor = new HeartRateMonitor();
        bool eventTriggered = false;
        monitor.OnHeartRateChanged += (_, _) => eventTriggered = true;

        // Act
        monitor.HeartRate = 90;

        // Assert
        eventTriggered.Should().BeFalse();
    }

    [Fact]
    public void HeartRateAlert_ShouldPrintMessage_WhenEventIsRaised()
    {
        // Arrange
        var monitor = new HeartRateMonitor();
        var alert = new HeartRateAlert();
        monitor.OnHeartRateChanged += alert.OnHeartRateChanged;

        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        monitor.HeartRate = 130;

        // Assert
        var output = consoleOutput.ToString().Trim();
        output.Should().Contain("Alert: 130BPM - Dangerously Above The Threshold");
    }
}
using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class AdvancedHeartRateMonitorTests
{
    [Fact]
    public void TriggerChangedEvent_ShouldRaiseEvent_WithCorrectArguments()
    {
        // Arrange
        var monitor = new AdvancedHeartRateMonitor();
        AdvancedHeartRateMonitorEventArgs? receivedArgs = null;

        monitor.OnHeartRateChanged += (_, args) => receivedArgs = args;

        const int age = 30;
        const int heartRate = 160;

        // Act
        monitor.TriggerChangedEvent(age, heartRate);

        // Assert
        receivedArgs.Should().NotBeNull();
        receivedArgs!.Age.Should().Be(age);
        receivedArgs.HeartRate.Should().Be(heartRate);
    }
}

public class AdvancedHeartRateAlertTests
{
    [Theory]
    [InlineData(25, 55, "Bradycardia")]
    [InlineData(40, 200, "exceeds the estimated maximum")]
    [InlineData(35, 175, "elevated and may be nearing your maximum")]
    [InlineData(30, 150, "within a healthy exercise target zone")]
    [InlineData(28, 75, "normal for resting conditions")]
    public void OnHeartRateChanged_ShouldDisplayCorrectMessage(int age, int bpm, string expectedMessagePart)
    {
        // Arrange
        var alert = new AdvancedHeartRateAlert();
        var args = new AdvancedHeartRateMonitorEventArgs(bpm, age);

        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        alert.OnHeartRateChanged(null, args);
        var output = sw.ToString();

        // Assert
        output.Should().Contain(expectedMessagePart);
    }
}


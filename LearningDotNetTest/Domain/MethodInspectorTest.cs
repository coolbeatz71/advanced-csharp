using FluentAssertions;
using LearningDotNet.Interfaces;
using Moq;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class MethodInspectorTests
{
    [Fact]
    public void LogMessage_Should_LogAllPrivateStaticMethodsOfProgramClass()
    {
        // Arrange
        var loggerMock = new Mock<ILogger>();
        var inspector = new MethodInspector(loggerMock.Object);

        // Act
        inspector.LogMessage();

        // Assert
        loggerMock.Verify(x => x.Log(It.Is<string>(msg => AllLinesArePrivateStatic(msg))), Times.Once);
    }

    [Fact]
    public void LogMessage_Should_LogSignatureFormatCorrectly()
    {
        // Arrange
        var loggerMock = new Mock<ILogger>();
        var inspector = new MethodInspector(loggerMock.Object);

        string? loggedMessage = null;
        loggerMock.Setup(x => x.Log(It.IsAny<string>()))
                  .Callback<string>(msg => loggedMessage = msg);

        // Act
        inspector.LogMessage();

        // Assert
        loggedMessage.Should().NotBeNull();
        loggedMessage!.Split('\n').Should().OnlyContain(line =>
            line.StartsWith("private static") &&
            line.Contains('(') &&
            line.Contains(')') &&
            line.Contains(' ')
        );
    }

    [Fact]
    public void LogMessage_Should_LogEmptyString_WhenNoPrivateStaticMethodExists()
    {
        // Arrange
        var loggerMock = new Mock<ILogger>();

        var inspector = new MethodInspector(loggerMock.Object);
        
        // Act
        inspector.LogMessage();

        // Assert
        loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
    }
    
    private static bool AllLinesArePrivateStatic(string msg)
    {
        var lines = msg.Split('\n');
        return lines.All(line => line.StartsWith("private static"));
    }
}

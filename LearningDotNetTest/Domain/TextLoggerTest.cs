using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class TextLoggerTests: IDisposable
{
    private const string FolderName = "TestLogs";
    private const string FileName = "test.log";
    
    private readonly string _folderPath;
    private readonly string _filePath;
    
    public TextLoggerTests()
    {
        _folderPath = Path.Combine(Directory.GetCurrentDirectory(), FolderName);
        _filePath = Path.Combine(_folderPath, FileName);
        Cleanup();
    }
    
    [Fact]
    public void Log_WritesMessageToFile()
    {
        // Arrange
        var logger = new TextLogger(FolderName, FileName);
        const string message = "This is a test log message.";

        // Act
        logger.Log(message);

        // Assert
        File.Exists(_filePath).Should().BeTrue("log file should be created");
        var content = File.ReadAllText(_filePath);
        content.Should().Contain(message);
    }

    [Fact]
    public void Log_CreatesFolderIfItDoesNotExist()
    {
        // Arrange
        var logger = new TextLogger(FolderName, FileName);

        // Pre-Assert
        Directory.Exists(_folderPath).Should().BeFalse("folder should not exist before logging");

        // Act
        logger.Log("Checking folder creation");

        // Assert
        Directory.Exists(_folderPath).Should().BeTrue("logger should create the folder if it doesn't exist");
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing) Cleanup();
    }
    
    private void Cleanup()
    {
        if (Directory.Exists(_folderPath))
        {
            Directory.Delete(_folderPath, true);
        }
    }
}
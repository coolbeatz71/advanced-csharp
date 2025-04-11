using LearningDotNet.Interfaces;

namespace LearningDotNet;

/// <summary>
/// An implementation of <see cref="ILogger"/> that logs messages to a text file
/// in a specified folder and filename.
/// </summary>
/// <param name="folderName">The name of the folder to store the log file.</param>
/// <param name="fileName">The name of the log file.</param>
public class TextLogger(string folderName, string fileName) : ILogger
{
    /// <summary>
    /// Gets the full path to the log folder.
    /// </summary>
    private string FolderPath => Path.Combine(Directory.GetCurrentDirectory(), folderName);
    
    /// <summary>
    /// Gets the full path to the log file.
    /// </summary>
    private string FilePath => Path.Combine(FolderPath, fileName);
    
    /// <summary>
    /// Writes the given message to the log file and displays the file path in the console.
    /// Creates the folder if it does not already exist.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <example>
    /// <code>
    /// ILogger logger = new TextLogger("Logs", "app.log");
    /// logger.Log("This is a log entry.");
    /// </code>
    /// </example>
    public void Log(string message)
    {
        if (!Directory.Exists(FolderPath)) Directory.CreateDirectory(FolderPath);

        File.AppendAllText(FilePath, message + Environment.NewLine);
        Console.WriteLine($"Log written to: {FilePath}");
    }
}
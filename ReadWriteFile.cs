using LearningDotNet.Interfaces;

namespace LearningDotNet;

public class ReadWriteFile : IReadWriteFile
{
    public void CreateFile(string folderName, string fileName, string content)
    {
        var directoryPath = Directory.GetCurrentDirectory();
        var filePath = Path.Combine($"{directoryPath}/{folderName}", fileName);
        
        if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
        
        File.AppendAllText(filePath, content);
        Console.WriteLine($"log file created at: {filePath} {content}");
    }
}
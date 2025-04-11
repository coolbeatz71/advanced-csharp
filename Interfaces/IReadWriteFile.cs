namespace LearningDotNet.Interfaces;

public interface IReadWriteFile
{
    void CreateFile(string folderName, string fileName, string content);
}
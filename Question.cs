namespace LearningDotNet;

/// <summary>
/// Represents a single quiz question.
/// </summary>
public class Question
{
    public string Title { get; set; }
    public string[] Answers { get; set; }
    public int CorrectAnswerIndex { get; set; }

    public Question(string title, string[] answers, int correctAnswerIndex)
    {
        this.Title = title;
        this.Answers = answers;
        this.CorrectAnswerIndex = correctAnswerIndex;
    }
    
    /// <summary>
    /// Checks whether a user's answer is correct.
    /// </summary>
    /// <param name="chosenAnswer">The user's answer index.</param>
    /// <returns>True if correct, false otherwise.</returns>
    public bool IsCorrectAnswer(int chosenAnswer)
    {
        return this.CorrectAnswerIndex == chosenAnswer;
    }
}
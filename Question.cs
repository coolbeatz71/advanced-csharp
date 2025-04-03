namespace LearningDotNet;

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

    public bool IsCorrect(int chosenAnswer)
    {
        return this.CorrectAnswerIndex == chosenAnswer;
    }
}
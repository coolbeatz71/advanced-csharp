namespace LearningDotNet;

public class Question
{
    public string QuestionTitle { get; set; }
    public string[] Answers { get; set; }
    private int CorrectAnswerIndex { get; set; }

    public Question(string questionTitle, string[] answers, int correctAnswerIndex)
    {
        this.QuestionTitle = questionTitle;
        this.Answers = answers;
        this.CorrectAnswerIndex = correctAnswerIndex;
    }

    public bool IsCorrect(int chosenAnswer)
    {
        return this.CorrectAnswerIndex == chosenAnswer;
    }
}
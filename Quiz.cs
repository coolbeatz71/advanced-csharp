namespace LearningDotNet;

public class Quiz
{
    private Question[] _questions;

    public Quiz(Question[] questions)
    {
        this._questions = questions;
    }

    private void DisplayQuestion(Question question)
    {
        Console.WriteLine(question.QuestionTitle);
    }
}
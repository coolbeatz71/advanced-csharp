namespace LearningDotNet;

public class Quiz
{
    private readonly Question[] _questions;

    public Quiz(Question[] questions)
    {
        this._questions = questions;
    }

    public void StartQuiz()
    {
        Console.WriteLine("Welcome to the Quiz!");
        var questionNumber = 1;

        foreach (var question in this._questions)
        {
            Console.WriteLine($"Question {questionNumber++}");
            DisplayQuestion(question);

            var userChoice = this.GetUserChoice(question.Answers.Length);
            
            Console.WriteLine(question.IsCorrect(userChoice)
                ? "Great\ud83d\udc4c\ud83c\udffd! That's Correct"
                : $"Incorrect!\ud83d\ude14, the correct answer was '{question.Answers[question.CorrectAnswerIndex]}'");
        }
    }

    private void DisplayQuestion(Question question)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("======================================");
        Console.WriteLine("||            QUESTION              ||");
        Console.WriteLine("======================================");
        Console.ResetColor();
        Console.WriteLine(question.Title);

        for (var i = 0; i < question.Answers.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"   {i + 1}");
            Console.ResetColor();
            Console.WriteLine($": {question.Answers[i]}.");
        }
    }

    private int GetUserChoice(int answersCount)
    {
        Console.WriteLine("Your answer: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var choice))
            {
                // check if choice is within the questions range
                bool outOfRange = choice < 1 || choice > answersCount;
                if (!outOfRange) return choice - 1;
            }

            Console.WriteLine($"Invalid Choice. Enter a number between 1 and {answersCount}.");
        }
    }
}
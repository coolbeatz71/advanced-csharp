namespace LearningDotNet;

/// <summary>
/// Represents a single quiz session.
/// </summary>
public class Quiz(Question[] questions)
{
    private int _score = 0;

    /// <summary>
    /// Starts the quiz session.
    /// </summary>
    public void StartQuiz()
    {
        Console.WriteLine("Welcome to the Quiz!");
        var questionNumber = 1;

        foreach (var question in questions)
        {
            Console.WriteLine($"Question {questionNumber++}");
            DisplayQuestion(question);

            var userChoice = this.GetUserChoice(question.Answers.Length);

            if (question.IsCorrectAnswer(userChoice))
            {
                this._score++;
                Console.WriteLine("Great\ud83d\udc4c\ud83c\udffd! That's Correct");
            }
            else
            {
                Console.WriteLine($"Incorrect!\ud83d\ude14, the correct answer was '{question.Answers[question.CorrectAnswerIndex]}'");
            }
        }

        this.DisplayResult();
    }
    
    /// <summary>
    /// Displays the final quiz results.
    /// </summary>
    private void DisplayResult()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("======================================");
        Console.WriteLine("||             RESULTS              ||");
        Console.WriteLine("======================================");
        Console.ResetColor();

        Console.WriteLine($"Quiz Finished! \ud83d\ude80. Your score is {this._score} out of {questions.Length}.");
        
        var percentage = (double) this._score / questions.Length * 100;
        
        var results = new List<(int min, int max, ConsoleColor color, string message)>
        {
            (70, 100, ConsoleColor.Green, "Excellent! 🏆"),
            (60, 69, ConsoleColor.Yellow, "Good! 👍"),
            (50, 59, ConsoleColor.DarkYellow, "Not Bad! 😐"),
            (0, 49, ConsoleColor.Red, "Too Bad! ❌")
        };

        foreach (var (min, max, color, message) in results)
        {
            if (!(percentage >= min) || !(percentage <= max)) continue;
            
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
            break;
        }
    }
    
    /// <summary>
    /// Displays the question and available answers.
    /// </summary>
    /// <param name="question">Question to display.</param>
    /// <example>
    /// <code>
    /// DisplayQuestion(new Question("Title", new[] {"A", "B"}, 0));
    /// </code>
    /// </example>
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
    
    /// <summary>
    /// Prompts the user to select an answer.
    /// </summary>
    /// <param name="answersCount">Total number of answers.</param>
    /// <returns>Selected answer index (zero-based).</returns>
    /// <example>
    /// <code>
    /// int index = GetUserChoice(4); // waits for input between 1-4
    /// </code>
    /// </example>
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
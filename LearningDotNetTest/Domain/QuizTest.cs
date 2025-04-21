using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class QuizTests
{
    [Fact]
    public void StartQuiz_Should_DisplayCorrectResults_When_AllAnswersCorrect()
    {
        // Arrange
        var questions = new[]
        {
            new Question("What is 2 + 2?", ["3", "4", "5"], 1),
            new Question("Capital of France?", ["Berlin", "Paris", "London"], 1)
        };

        var input = new StringReader("2\n2\n");
        var output = new StringWriter();

        Console.SetIn(input);
        Console.SetOut(output);

        var quiz = new Quiz(questions);

        // Act
        quiz.StartQuiz();

        // Assert
        var result = output.ToString();
        result.Should().Contain("Great", "the user got the answer right");
        result.Should().Contain("Excellent", "the final result message should reflect full score");
        result.Should().Contain("Your score is 2 out of 2", "the user answered all questions correctly");
    }

    [Fact]
    public void StartQuiz_Should_HandleIncorrectAnswers()
    {
        // Arrange
        var questions = new[]
        {
            new Question("What is 10 + 5?", ["10", "15", "20"], 1),
            new Question("Largest planet?", ["Earth", "Jupiter", "Mars"], 1)
        };

        var input = new StringReader("1\n3\n"); // both are wrong
        var output = new StringWriter();

        Console.SetIn(input);
        Console.SetOut(output);

        var quiz = new Quiz(questions);

        // Act
        quiz.StartQuiz();

        // Assert
        var result = output.ToString();
        result.Should().Contain("Incorrect", "the user selected the wrong answers");
        result.Should().Contain("Too Bad", "final feedback should reflect low score");
        result.Should().Contain("Your score is 0 out of 2", "user got no answers correct");
    }
}
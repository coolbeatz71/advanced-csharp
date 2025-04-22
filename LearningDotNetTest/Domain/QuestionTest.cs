using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class QuestionTests
{
    [Fact]
    public void IsCorrectAnswer_Should_ReturnTrue_When_AnswerIsCorrect()
    {
        // Arrange
        var question = new Question(
            title: "What is the capital of France?",
            answers: ["Berlin", "Paris", "Madrid"],
            correctAnswerIndex: 1);

        // Act
        var result = question.IsCorrectAnswer(1);

        // Assert
        result.Should().BeTrue("the correct answer index was chosen");
    }

    [Fact]
    public void IsCorrectAnswer_Should_ReturnFalse_When_AnswerIsIncorrect()
    {
        // Arrange
        var question = new Question(
            title: "What is 2 + 2?",
            answers: ["3", "4", "5"],
            correctAnswerIndex: 1);

        // Act
        var result = question.IsCorrectAnswer(0);

        // Assert
        result.Should().BeFalse("the selected index does not match the correct answer index");
    }

    [Fact]
    public void Constructor_Should_InitializePropertiesCorrectly()
    {
        // Arrange
        var title = "Which language is this test written in?";
        var answers = new[] { "Java", "C#", "Python" };
        var correctIndex = 1;

        // Act
        var question = new Question(title, answers, correctIndex);

        // Assert
        question.Title.Should().Be(title);
        question.Answers.Should().BeEquivalentTo(answers, "the provided answers should match");
        question.CorrectAnswerIndex.Should().Be(correctIndex);
    }
}
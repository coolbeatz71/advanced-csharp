using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class NamesTests
{
    [Fact]
    public void PrintHelloFullName_Should_ReturnFormattedGreeting()
    {
        // Arrange
        var names = new Names();
        const string firstName = "john";
        const string lastName = "doe";

        // Act
        var result = names.PrintHelloFullName(firstName, lastName);

        // Assert
        result.Should().Be("Hello, John Doe!");
    }

    [Fact]
    public void PrintHelloFullName_Should_ThrowArgumentNullException_WhenFirstNameIsNull()
    {
        // Arrange
        var names = new Names();

        // Act
        var act = () => names.PrintHelloFullName(null, "Smith");

        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("firstName");
    }

    [Fact]
    public void PrintHelloFullName_Should_ThrowArgumentNullException_WhenLastNameIsNull()
    {
        // Arrange
        var names = new Names();

        // Act
        var act = () => names.PrintHelloFullName("Anna", null);

        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("lastName");
    }

    [Theory]
    [InlineData("marie", "curie", "Hello, Marie Curie!")]
    [InlineData("ada", "lovelace", "Hello, Ada Lovelace!")]
    public void PrintHelloFullName_Should_CapitalizeNamesCorrectly(string firstName, string lastName, string expected)
    {
        // Arrange
        var names = new Names();

        // Act
        var result = names.PrintHelloFullName(firstName, lastName);

        // Assert
        result.Should().Be(expected);
    }
}
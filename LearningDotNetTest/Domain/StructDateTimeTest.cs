using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class StructDateTimeTests
{
    [Fact]
    public void Constructor_WithValidDates_ShouldCreateEvent()
    {
        // Arrange
        var start = new DateTime(2024, 7, 1);
        var end = new DateTime(2024, 7, 10);

        // Act
        var eventInstance = new Event(start, end);

        // Assert
        eventInstance.GetDurationInDays().Should().Be(9);
    }
    
    [Fact]
    public void Constructor_WithEndDateBeforeStartDate_ShouldThrowArgumentException()
    {
        // Arrange
        var start = new DateTime(2024, 7, 10);
        var end = new DateTime(2024, 7, 1);

        // Act
        Action act = () => new Event(start, end);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("EndDate must be after StartDate.");
    }

    [Theory]
    [InlineData("2024-07-01", "2024-07-10", "2024-07-05", "2024-07-15", true)]  // overlapping
    [InlineData("2024-07-01", "2024-07-10", "2024-07-10", "2024-07-15", false)] // touching end/start, not overlapping
    [InlineData("2024-07-01", "2024-07-10", "2024-06-25", "2024-07-01", false)] // touching start, not overlapping
    [InlineData("2024-07-01", "2024-07-10", "2024-06-25", "2024-07-02", true)]  // overlapping by a day
    [InlineData("2024-07-01", "2024-07-10", "2024-07-03", "2024-07-05", true)]  // fully contained
    public void IsOverlapping_ShouldReturnExpectedResult(string s1, string e1, string s2, string e2, bool expected)
    {
        // Arrange
        var event1 = new Event(DateTime.Parse(s1), DateTime.Parse(e1));
        var event2 = new Event(DateTime.Parse(s2), DateTime.Parse(e2));

        // Act
        var result = event1.IsOverlapping(event2);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void GetDurationInDays_ShouldReturnCorrectDecimalDuration()
    {
        // Arrange
        var start = new DateTime(2024, 7, 1, 10, 0, 0);
        var end = new DateTime(2024, 7, 3, 10, 0, 0);
        var eventInstance = new Event(start, end);

        // Act
        var duration = eventInstance.GetDurationInDays();

        // Assert
        duration.Should().Be(2);
    }
}
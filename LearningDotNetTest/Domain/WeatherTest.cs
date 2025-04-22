using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class WeatherTests
{
    [Fact]
    public void GetAverageTemperature_ReturnsCorrectAverage()
    {
        var temperatures = new[] { 72, 68, 74, 80, 76 };
        var weather = new Weather(temperatures, ["Sunny"]);

        double result = weather.GetAverageTemperature();

        result.Should().Be(74.0);
    }

    [Fact]
    public void GetMaxTemperature_ReturnsMaximumValue()
    {
        var temperatures = new[] { 72, 68, 74, 80, 76 };
        var weather = new Weather(temperatures, ["Rainy"]);

        int result = weather.GetMaxTemperature();

        result.Should().Be(80);
    }

    [Fact]
    public void GetMinTemperature_ReturnsMinimumValue()
    {
        var temperatures = new[] { 72, 68, 74, 80, 76 };
        var weather = new Weather(temperatures, ["Cloudy"]);

        int result = weather.GetMinTemperature();

        result.Should().Be(68);
    }

    [Fact]
    public void GetMostCommonCondition_ReturnsMostFrequentCondition()
    {
        var conditions = new[] { "Sunny", "Rainy", "Cloudy", "Sunny", "Sunny" };
        var weather = new Weather([70], conditions);

        string result = weather.GetMostCommonCondition();

        result.Should().Be("Sunny");
    }

    [Fact]
    public void Constructor_NullTemperatures_ThrowsArgumentNullException()
    {
        Action act = () => new Weather(null, ["Sunny"]);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Constructor_NullConditions_ThrowsArgumentNullException()
    {
        Action act = () => new Weather([70], null);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GetAverageTemperature_EmptyTemperatures_ThrowsInvalidOperationException()
    {
        var weather = new Weather([], ["Sunny"]);

        Action act = () => weather.GetAverageTemperature();

        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void GetMostCommonCondition_EmptyConditions_ThrowsInvalidOperationException()
    {
        var weather = new Weather([70], []);

        Action act = () => weather.GetMostCommonCondition();

        act.Should().Throw<InvalidOperationException>();
    }
}

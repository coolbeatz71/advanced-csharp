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

            Assert.Equal(74.0, result);
        }

        [Fact]
        public void GetMaxTemperature_ReturnsMaximumValue()
        {
            var temperatures = new[] { 72, 68, 74, 80, 76 };
            var weather = new Weather(temperatures, ["Rainy"]);

            int result = weather.GetMaxTemperature();

            Assert.Equal(80, result);
        }

        [Fact]
        public void GetMinTemperature_ReturnsMinimumValue()
        {
            var temperatures = new[] { 72, 68, 74, 80, 76 };
            var weather = new Weather(temperatures, ["Cloudy"]);

            int result = weather.GetMinTemperature();

            Assert.Equal(68, result);
        }

        [Fact]
        public void GetMostCommonCondition_ReturnsMostFrequentCondition()
        {
            var conditions = new[] { "Sunny", "Rainy", "Cloudy", "Sunny", "Sunny" };
            var weather = new Weather([70], conditions);

            string result = weather.GetMostCommonCondition();

            Assert.Equal("Sunny", result);
        }

        [Fact]
        public void Constructor_NullTemperatures_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Weather(null, ["Sunny"]));
        }

        [Fact]
        public void Constructor_NullConditions_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Weather([70], null));
        }

        [Fact]
        public void GetAverageTemperature_EmptyTemperatures_ThrowsInvalidOperationException()
        {
            var weather = new Weather([], ["Sunny"]);

            Assert.Throws<InvalidOperationException>(() => weather.GetAverageTemperature());
        }

        [Fact]
        public void GetMostCommonCondition_EmptyConditions_ThrowsInvalidOperationException()
        {
            var weather = new Weather([70], []);

            Assert.Throws<InvalidOperationException>(() => weather.GetMostCommonCondition());
        }
    }

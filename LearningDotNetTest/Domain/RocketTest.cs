using System.Reflection;
using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class RocketTests
    {
        [Fact]
        public void GenerateRocket_ShouldReturnMultilineString()
        {
            // Arrange
            var rocket = new Rocket();
            var method = typeof(Rocket).GetMethod("GenerateRocket", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            string result = (string)method!.Invoke(rocket, null)!;

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Split('\n').Length.Should().BeGreaterThan(10);
            result.Should().Contain("NASA");
        }

        [Fact]
        public void GetRocketHeight_ShouldMatchLineCountOfGeneratedRocket()
        {
            // Arrange
            var rocket = new Rocket();
            var generateMethod = typeof(Rocket).GetMethod("GenerateRocket", BindingFlags.NonPublic | BindingFlags.Instance);
            var heightMethod = typeof(Rocket).GetMethod("GetRocketHeight", BindingFlags.NonPublic | BindingFlags.Instance);

            string rocketArt = (string)generateMethod!.Invoke(rocket, null)!;
            int expectedHeight = rocketArt.Split('\n').Length;

            // Act
            int actualHeight = (int)heightMethod!.Invoke(rocket, null)!;

            // Assert
            actualHeight.Should().Be(expectedHeight);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(2, false)]
        public void DrawRocket_ShouldOutputCorrectLines(int padding, bool showThrusters)
        {
            // Arrange
            var rocket = new Rocket();
            var drawMethod = typeof(Rocket).GetMethod("DrawRocket", BindingFlags.NonPublic | BindingFlags.Instance);
            var generateMethod = typeof(Rocket).GetMethod("GenerateRocket", BindingFlags.NonPublic | BindingFlags.Instance);
            string rocketArt = (string) generateMethod!.Invoke(rocket, null)!;

            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            drawMethod!.Invoke(rocket, [padding, rocketArt, showThrusters]);
            string output = sw.ToString();

            // Assert
            output.Should().StartWith(new string('\n', padding));
            output.Should().Contain(rocketArt.Trim());
            
            const string lines = "~~~~~~~~~~~~~~~~~~~~";
            if (showThrusters) output.Should().Contain(lines);
            else output.Should().NotContain(lines);
        }
    }
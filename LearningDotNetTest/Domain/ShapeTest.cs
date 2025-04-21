using FluentAssertions;
using LearningDotNet.Interfaces;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class ShapeTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, Math.PI)]
    [InlineData(2.5, Math.PI * 2.5 * 2.5)]
    [InlineData(10, Math.PI * 100)]
    public void Circle_GetArea_ShouldReturnCorrectArea(double radius, double expected)
    {
        // Arrange
        IShape circle = new Circle(radius);

        // Act
        double area = circle.GetArea();

        // Assert
        area.Should().BeApproximately(expected, 0.0001);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(4, 6, 24)]
    [InlineData(2.5, 3.5, 8.75)]
    [InlineData(10, 10, 100)]
    public void Rectangle_GetArea_ShouldReturnCorrectArea(double width, double height, double expected)
    {
        // Arrange
        IShape rectangle = new Rectangle(width, height);

        // Act
        double area = rectangle.GetArea();

        // Assert
        area.Should().BeApproximately(expected, 0.0001);
    }
}
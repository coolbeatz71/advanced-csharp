using LearningDotNet.Interfaces;

namespace LearningDotNet;

/// <summary>
/// Represents a circle and provides functionality to calculate its area.
/// </summary>
/// <param name="radius">The radius of the circle.</param>
/// <example>
/// <code>
/// IShape circle = new Circle(5.0);
/// double area = circle.GetArea(); // Output: 78.53981633974483
/// </code>
/// </example>
public class Circle(double radius) : IShape
{
    /// <summary>
    /// Calculates the area of the circle.
    /// </summary>
    /// <returns>The area of the circle.</returns>
    public double GetArea() => Math.PI * radius * radius;
}

/// <summary>
/// Represents a rectangle and provides functionality to calculate its area.
/// </summary>
/// <param name="width">The width of the rectangle.</param>
/// <param name="height">The height of the rectangle.</param>
/// <example>
/// <code>
/// IShape rectangle = new Rectangle(4.0, 6.0);
/// double area = rectangle.GetArea(); // Output: 24.0
/// </code>
/// </example>
public class Rectangle(double width, double height) : IShape
{
    /// <summary>
    /// Calculates the area of the rectangle.
    /// </summary>
    /// <returns>The area of the rectangle.</returns>
    public double GetArea() => width * height;
}
using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class ArrayDimensionTests
{
    [Fact]
    public void GetRowSum_ShouldReturnCorrectSum_ForValidRowIndex()
    {
        // Arrange
        int[,] array =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        var arrayDimension = new ArrayDimension(array);

        // Act
        int result = arrayDimension.GetRowSum(1); // 4 + 5 + 6 = 15

        // Assert
        result.Should().Be(15);
    }

    [Fact]
    public void GetRowSum_ShouldReturnZero_IfRowIsAllZeroes()
    {
        // Arrange
        int[,] array =
        {
            { 0, 0, 0 },
            { 1, 2, 3 }
        };
        var arrayDimension = new ArrayDimension(array);

        // Act
        int result = arrayDimension.GetRowSum(0);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void GetRowSum_ShouldThrowIndexOutOfRangeException_IfRowIndexIsNegative()
    {
        // Arrange
        int[,] array =
        {
            { 1, 2, 3 }
        };
        var arrayDimension = new ArrayDimension(array);

        // Act
        Action act = () => arrayDimension.GetRowSum(-1);

        // Assert
        act.Should().Throw<IndexOutOfRangeException>();
    }

    [Fact]
    public void GetRowSum_ShouldThrowIndexOutOfRangeException_IfRowIndexIsOutOfBounds()
    {
        // Arrange
        int[,] array =
        {
            { 1, 2 },
            { 3, 4 }
        };
        var arrayDimension = new ArrayDimension(array);

        // Act
        Action act = () => arrayDimension.GetRowSum(2); // only indices 0 and 1 are valid

        // Assert
        act.Should().Throw<IndexOutOfRangeException>();
    }
}
namespace LearningDotNet;

/// <summary>
/// Represents a class for performing operations on a 2-dimensional integer array.
/// </summary>
/// <param name="myArray">The 2-dimensional integer array</param>
public class ArrayDimension(int[,] myArray)
{
    
    /// <summary>
    /// Calculates the sum of all elements in a specified row of the 2D array.
    /// </summary>
    /// <param name="row">The zero-based index of the row to calculate the sum for.</param>
    /// <returns>The sum of all elements in the specified row.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if the row index is out of bounds.</exception>
    /// <example>
    /// <code>
    /// // Example usage of ArrayDimension class
    /// int[,] array = {
    ///     { 1, 2, 3 },
    ///     { 4, 5, 6 },
    ///     { 7, 8, 9 }
    /// };
    ///
    /// ArrayDimension arrayDimension = new ArrayDimension(array);
    /// int rowSum = arrayDimension.GetRowSum(1); // Calculates the sum of the second row (4 + 5 + 6)
    /// Console.WriteLine("Sum of row 1: " + rowSum); // Output: Sum of row 1: 15
    /// </code>
    /// </example>
    internal int GetRowSum(int row)
    {
        int sum = 0;
        int columns = myArray.GetLength(1);
        
        for (var i = 0; i < columns; i++)
        {
            sum += myArray[row, i];
        }

        return sum;
    }
}
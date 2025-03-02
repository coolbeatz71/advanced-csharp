using System.Globalization;

namespace LearningDotNet.Extension;

public static class StringExtension
{
    /// <summary>
    /// Converts a string into title case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The string in title case.</returns>
    /// <example>
    /// <code>
    /// string input = "hello world! this is a test.";
    /// string titleCase = input.ToTitleCase();
    /// Console.WriteLine(titleCase); // Output: Hello World! This Is A Test.
    /// </code>
    /// </example>
    public static string ToTitleCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        { 
            return input;
        }
        
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(input.ToLower());
    } 
}
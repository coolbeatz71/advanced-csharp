using System.Globalization;

namespace LearningDotNet.Extension;

public static class StringExtension
{
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
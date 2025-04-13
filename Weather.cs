namespace LearningDotNet;

/// <summary>
/// Provides weather-related calculations and statistics.
/// This class contains methods for analyzing temperature data and weather conditions.
/// </summary>
public class Weather(int[] temperatures, string[] conditions)
{
    private int[] Temperatures { get; } = temperatures ?? throw new ArgumentNullException(nameof(temperatures));
    private string[] Conditions { get; } = conditions ?? throw new ArgumentNullException(nameof(conditions));

    /// <summary>
    /// Calculates the average temperature from an array of temperature values.
    /// </summary>
    /// <returns>The average temperature as a double value</returns>
    /// <example>
    /// <code>
    /// var weather = new Weather();
    /// int[] temps = {72, 68, 74, 80, 76};
    /// double avgTemp = weather.GetAverageTemperature(temps);
    /// Console.WriteLine(avgTemp); // Output: 74.0
    /// </code>
    /// </example>
    internal double GetAverageTemperature()
    {
        Weather.ValidateData(this.Temperatures, "Temperatures");
        
        double sum = 0;
        for (int i = 0; i < this.Temperatures.Length; i++)
        {
            sum += this.Temperatures[i];
        }

        return sum / this.Temperatures.Length;
    }
    
    /// <summary>
    /// Finds the maximum temperature from an array of temperature values.
    /// </summary>
    /// <returns>The highest temperature value in the array</returns>
    /// <example>
    /// <code>
    /// var weather = new Weather();
    /// int[] temps = {72, 68, 74, 80, 76};
    /// int maxTemp = weather.GetMaxTemperature(temps);
    /// Console.WriteLine(maxTemp); // Output: 80
    /// </code>
    /// </example>

    internal int GetMaxTemperature()
    {
        Weather.ValidateData(this.Temperatures, "Temperatures");
        
        var max = this.Temperatures[0];
        for (var i = 0; i < this.Temperatures.Length; i++)
        {
            var temp = this.Temperatures[i];
            if (temp > max) max = temp;
        }

        return max;
    }
    
    /// <summary>
    /// Finds the minimum temperature from an array of temperature values.
    /// </summary>
    /// <returns>The lowest temperature value in the array</returns>
    /// <example>
    /// <code>
    /// var weather = new Weather();
    /// int[] temps = {72, 68, 74, 80, 76};
    /// int minTemp = weather.GetMinTemperature(temps);
    /// Console.WriteLine(minTemp); // Output: 68
    /// </code>
    /// </example>
    internal int GetMinTemperature()
    {
        Weather.ValidateData(this.Temperatures, "Temperatures");
        
        var min = this.Temperatures[0];
        for (var i = 0; i < this.Temperatures.Length; i++)
        {
            var temp = this.Temperatures[i];
            if (temp < min) min = temp;
        }

        return min;
    }
    
    // BigO(n^2) - raw but not optimized
    // internal string MostCommonCondition(string[] conditions)
    // {
    //     var count = 0;
    //     var common = conditions[0];
    //
    //     for(var i = 0; i < conditions.Length; i++)
    //     {
    //         var tempCount = 0;
    //
    //         for(var j = 0; j < conditions.Length; j++)
    //         {
    //             if(conditions[j] == conditions[i]) tempCount++;
    //         }
    //
    //         if (tempCount <= count) continue;
    //         
    //         count = tempCount;
    //         common = conditions[i];
    //     }
    //     
    //     return common;
    // }
    
    /// <summary>
    /// Determines the most frequently occurring weather condition from an array of conditions.
    /// Uses a frequency counter algorithm for optimal performance (O(n) time complexity).
    /// </summary>
    /// <returns>The most common weather condition</returns>
    /// <example>
    /// <code>
    /// var weather = new Weather();
    /// string[] conditions = {"Sunny", "Rainy", "Cloudy", "Sunny", "Sunny"};
    /// string commonCondition = weather.GetMostCommonCondition(conditions);
    /// Console.WriteLine(commonCondition); // Output: "Sunny"
    /// </code>
    /// </example>
    internal string GetMostCommonCondition()
    {
        Weather.ValidateData(this.Conditions, "Conditions");
        
        var frequencyMap = new Dictionary<string, int>();

        // Build the frequency Map
        // Adds conditions and their counter frequencies to the Map
        foreach (var condition in this.Conditions)
        {
            // if the key doesn't exist in the map, adds it with value 1,
            // else increment the key's value (+1) 
            if (!frequencyMap.TryAdd(condition, 1))
            {
                frequencyMap[condition]++;
            }
        }

        string common = "";
        int maxCount = 0;
        
        // Loops through to the frequency map
        // Get the key with the max frequency
        // Find condition with the highest frequency
        foreach (var freq in frequencyMap)
        {
            if (freq.Value > maxCount)
            {
                maxCount = freq.Value;
                common = freq.Key;
            }
        }

        return common;
    }
    
    private static void ValidateData<T>(IEnumerable<T> data, string label)
    {
        if (data == null || !data.Any())
            throw new InvalidOperationException($"No Data Available. Please Provide ${label}.");
    }
}

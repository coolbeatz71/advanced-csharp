namespace LearningDotNet;

public class Weather
{
    internal double GetAverageTemperature(int[] temperatures)
    {
        double sum = 0;
        for (var i = 0; i < temperatures.Length; i++)
        {
            sum += temperatures[i];
        }

        return sum / temperatures.Length;
    }

    internal int GetMaxTemperature(int[] temperatures)
    {
        var max = temperatures[0];

        for (var i = 0; i < temperatures.Length; i++)
        {
            var temp = temperatures[i];
            if (temp > max) max = temp;
        }

        return max;
    }
    
    internal int GetMinTemperature(int[] temperatures)
    {
        var min = temperatures[0];

        for (var i = 0; i < temperatures.Length; i++)
        {
            var temp = temperatures[i];
            if (temp < min) min = temp;
        }

        return min;
    }
    
    // BigO(n^2) - not optimized
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
    
    // BigO(n) - optimized
    internal string MostCommonCondition(string[] conditions)
    {
        var frequencyMap = new Dictionary<string, int>();

        // adds conditions and they frequencies to a map
        foreach (var condition in conditions)
        {
            // if the key doesn't exist in the map, adds it with value 1,
            // else move to the next key in the map 
            if (!frequencyMap.TryAdd(condition, 1))
            {
                frequencyMap[condition]++;
            }
        }

        string common = "";
        int maxCount = 0;
        
        // loops through to the frequency map
        // get the key with the max frequency
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
}
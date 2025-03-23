using LearningDotNet.Enums;

namespace LearningDotNet;

internal class Program
{
    private static void Main(string[] args)
    {
        // // Get user's name and print a greeting
        Program.GreetingUserName();
        //
        // // Simulate a rocket landing
        Program.SimulateRocketLanding();
        //
        // // Work with a 2D array and calculate row sums
        Program.CalculateRowSums();

        Program.CalculateTemperatureAverage();
    }

    private static void GreetingUserName()
    {
        Names names = new Names();
        
        Console.WriteLine("What's your first name?");
        string? firstName = Console.ReadLine();
        
        Console.WriteLine("What's your last name?");
        string? lastName = Console.ReadLine();
        
        Console.WriteLine(names.PrintHelloFullName(firstName, lastName));
    }

    private static void SimulateRocketLanding()
    {
        Rocket rocket = new Rocket();
        rocket.StartLanding();
    }

    private static void CalculateRowSums()
    {
        int[,] myArray =
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},
        };
        
        ArrayDimension ad = new ArrayDimension(myArray);
        int rows = myArray.GetLength(0);
        
        for (int row = 0; row < rows; row++)
        {
            Console.WriteLine($"Sum of row {row + 1} = {ad.GetRowSum(row)}");
        }
    }

    private static void CalculateTemperatureAverage()
    {
        Weather weather = new Weather();
        Console.WriteLine("Enter the number of days to simulate");
        int days =  Convert.ToInt32(Console.ReadLine());
        
        int[] temperatures = new int[days];
        string[] conditions = new string[days];
        
        Random random = new Random();
        for (int i = 0; i < days; i++)
        {
            temperatures[i] = random.Next(-10, 40);
            conditions[i] = temperatures[i] switch
            {
                < 0 => nameof(EnumWeather.Snowy),
                >= 10 and < 20 => nameof(EnumWeather.Cloudy),
                >= 20 and < 30 => nameof(EnumWeather.Rainy),
                _ => nameof(EnumWeather.Sunny)
            };
        }

        Console.WriteLine($"The average temperature is {weather.GetAverageTemperature(temperatures)} °C");
        Console.WriteLine($"The Minimum temperature is {weather.GetMinTemperature(temperatures)} °C");
        Console.WriteLine($"The Maximum temperature is {weather.GetMaxTemperature(temperatures)} °C");
        Console.WriteLine($"The Most common condition is '{weather.GetMostCommonCondition(conditions)}'");
    }
}
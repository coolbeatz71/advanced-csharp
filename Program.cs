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
        //
        // // Get weather and temperature statistics
        Program.CalculateTemperatureStats();
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

    private static void CalculateTemperatureStats()
    {
        Console.WriteLine("Enter the number of days to simulate the weather");
        int days = Program.GetValidDaysInput();

        var (temperatures, conditions) = Program.GenerateWeatherData(days);
        Weather weather = new Weather(temperatures, conditions);
        
        Console.WriteLine($"Temperatures: [{string.Join(", ", temperatures)}]");
        Console.WriteLine($"Conditions: [{string.Join(", ", conditions)}]\n");

        // the :F1 formats double to only show 1 decimal place (e.g: "23.5") 
        Console.WriteLine($"- Average temperature: {weather.GetAverageTemperature():F1}°C");
        
        Console.WriteLine($"- Minimum temperature: {weather.GetMinTemperature()}°C");
        Console.WriteLine($"- Maximum temperature: {weather.GetMaxTemperature()}°C");
        Console.WriteLine($"- Most common condition: '{weather.GetMostCommonCondition()}'");
    }

    private static int GetValidDaysInput()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var days) && days > 0)
            {
                return days;
            }

            Console.WriteLine("Invalid input. Please enter a positive number:");
        }
    }

    private static (int[] temperatures, string[] conditions) GenerateWeatherData(int days)
    {
        Random random = new Random();
        int[] temperatures = new int[days];
        string[] conditions = new string[days];

        for (int i = 0; i < days; i++)
        {
            temperatures[i] = random.Next(-10, 40);
            conditions[i] = temperatures[i] switch
            {
                < 0 => nameof(EnumWeather.Snowy),
                >= 0 and < 15 => nameof(EnumWeather.Rainy),
                >= 15 and < 25 => nameof(EnumWeather.Cloudy),
                _ => nameof(EnumWeather.Sunny),
            };
        }

        return (temperatures, conditions);
    }
}
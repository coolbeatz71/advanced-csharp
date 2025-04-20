using System.Diagnostics;
using System.Reflection;
using LearningDotNet.Enums;
using LearningDotNet.Interfaces;

namespace LearningDotNet;

internal class Program
{
    // private static void Main(string[] args)
    // {
    //     // Get user's name and print a greeting
    //     Program.GreetingUserName();
    //     //
    //     // Simulate a rocket landing
    //     Program.SimulateRocketLanding();
    //     //
    //     // Work with a 2D array and calculate row sums
    //     Program.CalculateRowSums();
    //     //
    //     // Get weather and temperature statistics
    //     Program.CalculateTemperatureStats();
    //     //
    //     // Start the Quiz
    //     Program.RunQuiz();
    //     //
    //     // Create Log File: Prints all Program's methods 
    //     Program.CreateLogFile();
    //     //
    //     // Print circle and rectangle
    //     Program.PrintAreas();
    //     //
    //     // Bubble sort by age and name
    //     Program.BubbleSortPerson();
    //     //
    //     // Temperature alert
    //     Program.MonitorTemperature();
    //     //
    //     // Stock Price
    //     Program.MonitorStockPrice();
    //     //
    //     // Simple Heart Rate 
    //     Program.MonitorHeartRate();
    //     //
    //     // Advanced Heart Rate 
    //     Program.AdvancedMonitorHeartRate();
    //     //
    //     // Example of Generics
    //     Program.GetGenericTaskReport();
    // }

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

    private static (int[]? temperatures, string[]? conditions) GenerateWeatherData(int days)
    {
        Random random = new Random();
        int[] temperatures = new int[days];
        string[]? conditions = new string[days];

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

    private static void RunQuiz()
    {
        var questions = new[]
        {
            new Question("What is the Capital City of DR Congo?",
                ["Kinshasa", "Kigali", "Johannesburg", "Paris"], 0),
            new Question("What is the square root of 16: (√ 16)?",
                ["2", "5", "4", "12"], 2),
            new Question("Which planet is known as the Red Planet?",
                ["Earth", "Mars", "Jupiter", "Venus"], 1),
            new Question("In which year did the Titanic sink?",
                ["1912", "1905", "1898", "1920"], 0),
            new Question("What is the chemical symbol for Gold?",
                ["Au", "Ag", "Gd", "Go"], 0),
            new Question("Who painted the Mona Lisa?",
                ["Pablo Picasso", "Leonardo da Vinci", "Vincent Van Gogh", "Claude Monet"], 1),
            new Question("Which country has the most natural lakes?",
                ["USA", "Russia", "Canada", "Brazil"], 2),
            new Question("What is the powerhouse of the cell?",
                ["Nucleus", "Mitochondria", "Ribosome", "Chloroplast"], 1),
            new Question("What is the longest river in the world?",
                ["Amazon River", "Yangtze River", "Mississippi River", "Nile River"], 3),
            new Question("In Jeopardy!, what is unique about how answers are given?",
                ["They are in rhyme", "They must be whispered", "They must be in the form of a question", "They are timed with music"
                ], 2)
        };

        new Quiz(questions).StartQuiz();
    }

    private static void CreateLogFile()
    {
        ILogger textLogger = new TextLogger("Logs", "debug.log");
        var inspector = new MethodInspector(textLogger);
        inspector.LogMessage();
    }
    
    private static void PrintAreas()
    {
        Console.WriteLine($"Area: {new Circle(5).GetArea()}");
        Console.WriteLine($"Area: {new Rectangle(4, 6).GetArea()}");
    }

    private static void BubbleSortPerson()
    {
        Person[] persons =
        [
            new Person("Alice", 22),
            new Person("Charlie", 20),
            new Person("Bob", 25),
            new Person("Diana", 23),
            new Person("Ethan", 21),
            new Person("Fiona", 24),
            new Person("George", 19),
            new Person("Hannah", 22),
            new Person("Ian", 26),
            new Person("Jasmine", 20)
        ];

        PersonSorter.Sort(persons, Comparer.ByName);
        Program.DisplaySorted("name", persons);

        PersonSorter.Sort(persons, Comparer.ByAge);
        Program.DisplaySorted("age", persons);
    }
    
    private static void DisplaySorted(string title, Person[] persons)
    {
        Console.WriteLine($"\nSorted by {title.ToUpper()}:");
        Console.WriteLine(new string('=', 12));
        foreach (var person in persons)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }

    private static void MonitorTemperature()
    {
        var monitor = new TemperatureMonitor();
        var alert = new TemperatureAlert();
        
        monitor.OnTemperatureChanged += alert.OnTemperatureChanged;
        
        monitor.Temperature = Program.GetValidatedInput<double>(
            "Please enter the temperature in Celsius:",
            input => (double.TryParse(input, out var val), val),
            temp => temp is > -100 and < 100,
            "Temperature should be between -100 and 100 degrees Celsius."
        );;
    }

    private static void MonitorStockPrice()
    {
        var monitor = new StockMonitor();
        var alert = new StockAlert();
        
        monitor.OnPriceChanged += alert.OnPriceChanged;
        
        monitor.Threshold = 120;

        monitor.Price = 150;
        monitor.Price = 130;
        monitor.Price = 100;
    }
    
    private static void MonitorHeartRate()
    {
        var monitor = new HeartRateMonitor();
        var alert = new HeartRateAlert();
        
        monitor.OnHeartRateChanged += alert.OnHeartRateChanged;
        
        monitor.HeartRate = GetValidatedInput(
            "Enter your current heart rate (BPM):",
            input => (int.TryParse(input, out var val), val),
            bpm => bpm is > 30 and < 220,
            "Heart rate must be a realistic number between 30 and 220 BPM."
        );
    }
    
    private static void AdvancedMonitorHeartRate()
    {
        var monitor = new AdvancedHeartRateMonitor();
        var alert = new AdvancedHeartRateAlert();
        
        monitor.OnHeartRateChanged += alert.OnHeartRateChanged;
        
        var heartRate = GetValidatedInput(
            "Enter your current heart rate (BPM):",
            input => (int.TryParse(input, out var val), val),
            bpm => bpm is > 30 and < 220,
            "Heart rate must be a realistic number between 30 and 220 BPM."
        );
        
        var age = GetValidatedInput(
            "Enter your age:",
            input => (int.TryParse(input, out var val), val),
            age => age is >= 1 and <= 120,
            "Please enter a valid age between 1 and 120."
        );
        
        monitor.TriggerChangedEvent(age, heartRate);
    }
    
    private static T GetValidatedInput<T>(
        string prompt,
        Func<string?, (bool success, T value)> parser,
        Func<T, bool>? validate = null,
        string? errorMessage = null)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            var (success, value) = parser(input);

            if (!success)
            {
                Console.WriteLine("Invalid input. Please enter a valid value.");
                continue;
            }

            if (validate == null || validate(value)) return value;
            Console.WriteLine(errorMessage ?? "Input did not meet validation requirements.");
        }
    }

    private static void GetGenericTaskReport()
    {
        const string message = "Hello, his is a message email";
        const string recipient = "jean-vincent.mutombo@gmail.com";
        
        var emailTask = new EmailTask(message, recipient);
        var reportTask = new ReportTask("Monthly-Report");
        
        var emailProcessor = new TaskProcessor<EmailTask, string>(emailTask);
        var reportProcessor = new TaskProcessor<ReportTask, string>(reportTask);

        Console.WriteLine(emailProcessor.Execute());
        Console.WriteLine(reportProcessor.Execute());
    }
}


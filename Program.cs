namespace LearningDotNet;
class Program
{
    private static void Main(string[] args)
    {
        // Get user's name and print a greeting
        Program.GreetingUserName();

        // Simulate a rocket landing
        Program.SimulateRocketLanding();

        // Work with a 2D array and calculate row sums
        Program.CalculateRowSums();
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
}
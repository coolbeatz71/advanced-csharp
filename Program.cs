
namespace LearningDotNet;

class Program
{
    static void Main(string[] args)
    {
        Names names = new Names();
        Console.WriteLine("What's your first name?");
        string? firstName = Console.ReadLine();
        
        Console.WriteLine("What's your last name?");
        string? lastName = Console.ReadLine();
        
        Console.WriteLine(names.PrintHelloFullName(firstName, lastName));
        
        Rocket simulation = new Rocket();
        simulation.StartLanding();
    }
}

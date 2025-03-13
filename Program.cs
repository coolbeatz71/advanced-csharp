namespace LearningDotNet;

class Program
{
    private string? LastName { get; set; } = "";

    private string? FirstName { get; set; } = "";

    private string PrintHelloFullName(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        
        return $"Hello, {this.FirstName} {this.LastName}!";
    }

    static void Main(string[] args)
    {
        Program pg = new Program();
        Console.WriteLine("What's your first name?");
        string? firstName = Console.ReadLine();
        
        Console.WriteLine("What's your last name?");
        string? lastName = Console.ReadLine();
        
        Console.WriteLine(pg.PrintHelloFullName(firstName!, lastName!));
    }
}

namespace LearningDotNet;

class Program
{
    private string LastName { get; set; } = "";

    private string FirstName { get; set; } = "";

    /// <summary>
    /// This prints "Hello, firstName lastName" to the console
    /// </summary>
    /// <param name="firstName">firstName</param>
    /// <param name="lastName">lastName</param>
    /// <returns>Hello, firstName lastName</returns>
    /// <exception cref="ArgumentNullException"></exception>
    private string PrintHelloFullName(string? firstName, string? lastName)
    {
        this.FirstName = firstName ?? throw  new ArgumentNullException(nameof(firstName));
        this.LastName = lastName ?? throw  new ArgumentNullException(nameof(lastName));
        
        string fullName = String.Concat(firstName, " ", lastName);
        return $"Hello, {fullName}!";
    }

    static void Main(string[] args)
    {
        Program pg = new Program();
        Console.WriteLine("What's your first name?");
        string? firstName = Console.ReadLine();
        
        Console.WriteLine("What's your last name?");
        string? lastName = Console.ReadLine();
        
        Console.WriteLine(pg.PrintHelloFullName(firstName, lastName));
    }
}

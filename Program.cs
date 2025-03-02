using LearningDotNet.Extension;

namespace LearningDotNet;

class Program
{
    private string LastName { get; set; } = "";

    private string FirstName { get; set; } = "";

    /// <summary>
    /// This prints "Hello, firstName lastName" to the console.
    /// </summary>
    /// <param name="firstName">The first name of the person.</param>
    /// <param name="lastName">The last name of the person.</param>
    /// <returns>A greeting message in the format "Hello, firstName lastName".</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstName"/> or <paramref name="lastName"/> is null or empty.</exception>
    /// <example>
    /// <code>
    /// string firstName = "john";
    /// string lastName = "doe";
    /// string greeting = new Program().PrintHelloFullName(firstName, lastName);
    /// Console.WriteLine(greeting); // Output: Hello, John Doe!
    /// </code>
    /// </example>
    private string PrintHelloFullName(string? firstName, string? lastName)
    {
        this.FirstName = firstName ?? throw  new ArgumentNullException(nameof(firstName));
        this.LastName = lastName ?? throw  new ArgumentNullException(nameof(lastName));
        
        string fullName = String.Concat(firstName, " ", lastName).ToTitleCase();
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

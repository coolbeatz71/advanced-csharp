namespace HelloWorld;

class Program
{

    private string lastName = "Mutombo";
    private string firstName = "Jean-vincent";

    private string PrintHelloFullName()
    {
        return $"Hello, {this.firstName} {this.lastName}!";
    }

    static void Main(string[] args)
    {
        Program pg = new Program();
        Console.WriteLine(pg.PrintHelloFullName());
    }
}

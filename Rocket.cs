namespace LearningDotNet;

public class Rocket
{
    internal void StartLanding()
    {
        string rocket = GenerateRocket();
        int consoleHeight = Console.WindowHeight - CountRocketLines(rocket);

        for (int i = 0; i < consoleHeight; i++)
        {
            Console.Clear();
            PrintRocket(i, rocket, i < consoleHeight - 3);
            Thread.Sleep(100);
        }

        Console.Clear();
        PrintRocket(consoleHeight, rocket, false);
        Console.WriteLine("\n🚀 The rocket has landed safely! Mission Success! 🎉");
    }
    
    private string GenerateRocket()
    {
        return """
                        /\  
                       |  |  
                      |    |  
                     | NASA |  
                     |      |  
                     |------|  
                    /|======|\  
                   / |++++++| \  
                  /  |======|  \  
                 /===|______|===\  
                     /      \  
                    /        \  
                   /__________\  
                     ||    ||  
                     ||    ||  

               """;
    }
    
    private int CountRocketLines(string rocket)
    {
        return rocket.Split('\n').Length;
    }
    
    private void PrintRocket(int topPadding, string rocket, bool showThrusters)
    {
        Console.Write(new string('\n', topPadding));
        Console.Write(rocket);

        if (showThrusters)
        {
            for (int i = 0; i < 4; i++) 
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            }
        }
    }
}
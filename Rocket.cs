namespace LearningDotNet;

/// <summary>
/// Represents a rocket that can be launched and landed.
/// This class simulates the landing of a rocket in the console.
/// </summary>
public class Rocket
{
    /// <summary>
    /// Starts the rocket landing simulation.
    /// This method clears the console, prints the rocket at different positions,
    /// and simulates the landing process with a delay between each frame.
    /// </summary>
    /// <example>
    /// <code>
    /// Rocket roc = new Rocket();
    /// roc.StartLanding(); // Simulates the rocket landing in the console.
    /// </code>
    /// </example>
    internal void StartLanding()
    {
        string rocket = this.GenerateRocket();
        int consoleHeight = Console.WindowHeight - this.CountRocketLines(rocket);
        
        for (int i = 0; i < consoleHeight; i++)
        {
            Console.Clear();
            DrawRocket(i, rocket, i < consoleHeight - 1);
            Thread.Sleep(100);
        }
        
        Console.WriteLine("\n🚀 The rocket has landed safely! Mission Success! 🎉");
    }

    /// <summary>
    /// Generates a string representation of the rocket.
    /// </summary>
    /// <returns>A multi-line string representing the rocket.</returns>
    /// <example>
    /// <code>
    /// string rocket = GenerateRocket();
    /// Console.WriteLine(rocket); // Prints the rocket to the console.
    /// </code>
    /// </example>
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

    /// <summary>
    /// Counts the number of lines in the rocket string.
    /// </summary>
    /// <param name="rocket">The rocket string to count lines from.</param>
    /// <returns>The number of lines in the rocket string.</returns>
    /// <example>
    /// <code>
    /// string rocket = GenerateRocket();
    /// int lineCount = CountRocketLines(rocket); // Returns 16.
    /// </code>
    /// </example>
    private int CountRocketLines(string rocket)
    {
        return rocket.Split('\n').Length;
    }

    /// <summary>
    /// Draws the rocket at a specific position in the console.
    /// Optionally, displays thrusters below the rocket.
    /// </summary>
    /// <param name="topPadding">The number of empty lines to add above the rocket.</param>
    /// <param name="rocket">The rocket string to print.</param>
    /// <param name="showThrusters">Whether to display thrusters below the rocket.</param>
    /// <example>
    /// <code>
    /// string rocket = GenerateRocket();
    /// DrawRocket(5, rocket, true); // Prints the rocket with 5 empty lines above it and thrusters.
    /// </code>
    /// </example>
    private void DrawRocket(int topPadding, string rocket, bool showThrusters)
    {
        Console.Write(new string('\n', topPadding));
        Console.Write(rocket);

        if (showThrusters)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            }
        }
    }
}
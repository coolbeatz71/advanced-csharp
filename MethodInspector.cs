using System.Reflection;
using LearningDotNet.Interfaces;

namespace LearningDotNet;

/// <summary>
/// Provides functionality to inspect and log method signatures
/// from the <c>Program</c> class using reflection.
/// </summary>
public class MethodInspector(ILogger logger)
{
    /// <summary>
    /// Logs the method signatures of all static, non-public methods
    /// defined in the <c>Program</c> class.
    /// </summary>
    public void LogMessage()
    {
        var message = this.GetMethodSignature();
        logger.Log(message);
    }
    
    /// <summary>
    /// Retrieves the method signatures of all static, non-public methods
    /// in the <c>Program</c> class.
    /// </summary>
    /// <returns>
    /// A newline-separated string containing the signatures of each method,
    /// formatted as <c>private static ReturnType MethodName(Type1 param1, Type2 param2)</c>.
    /// </returns>
    private string GetMethodSignature()
    {
        // Get all methods from the Program class that are static and non-public
        var methods = typeof(Program).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
        
        // Select the method signature as a string (e.g., "public static void MethodName()")
        var signatureList = methods
            .Select(m =>
            {
                var methodName = m.Name; // Get the name of the method
                var returnType = m.ReturnType.Name; // Get the return type of the method

                // Get a comma-separated string of parameters (e.g., "int param1, string param2")
                var parameters = string.Join(", ",
                    m.GetParameters() // Get the parameters of the method
                        .Select(p => $"{p.ParameterType.Name} {p.Name}") // Format each parameter as "type name"
                );

                // Return a formatted string representing the method's signature
                return $"private static {returnType} {methodName}({parameters})";
            });

        // Convert the list of method signatures to an array (if it isn't already)
        var enumerable = signatureList as string[] ?? signatureList.ToArray();

        // Join all the method signatures into a single string, separated by new lines
        return string.Join("\n", enumerable);
    }
}
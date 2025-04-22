namespace LearningDotNet.LearningDotNetTest.Domain;

public class TestHelper
{
    public static bool IsTest()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .Any(a => a.FullName != null && a.FullName.StartsWith("xunit", StringComparison.OrdinalIgnoreCase));
    }
}
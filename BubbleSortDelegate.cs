namespace LearningDotNet;

/// <summary>
/// Delegate for comparing two objects of the same type.
/// </summary>
/// <typeparam name="T">Type of the objects to compare.</typeparam>
/// <param name="a">First object.</param>
/// <param name="b">Second object.</param>
/// <returns>
/// A negative number if a &lt; b, 0 if a == b, positive number if a &gt; b.
/// </returns>
public delegate int Comparison<in T>(T a, T b);

/// <summary>
/// Represents a person with a name and an age.
/// This class is abstract and meant to be inherited.
/// </summary>
/// <param name="name">The name of the person.</param>
/// <param name="age">The age of the person.</param>
public class Person(string name, int age)
{
    public int Age { get; } = age;
    public string Name { get; } = name;
}

/// <summary>
/// Provides sorting functionality for arrays of <see cref="Person"/> using a custom comparison delegate.
/// </summary>
public abstract class PersonSorter
{
    /// <summary>
    /// Sorts an array of <see cref="Person"/> objects in-place using the specified comparison logic.
    /// </summary>
    /// <param name="people">The array of people to sort.</param>
    /// <param name="comparison">The delegate that defines the comparison logic.</param>
    /// <exception cref="ArgumentNullException">Thrown if the array or comparison delegate is null.</exception>
    public static void Sort(Person[] people, Comparison<Person> comparison)
    {
        ArgumentNullException.ThrowIfNull(people);
        ArgumentNullException.ThrowIfNull(comparison);

        for (var i = 0; i < people.Length - 1; i++)
        {
            for (var j = i + 1; j < people.Length; j++)
            {
                // Swap if elements are out of order
                if (comparison(people[i], people[j]) > 0)
                {
                    (people[i], people[j]) = (people[j], people[i]);
                }
            }
        }
    }
}

/// <summary>
/// Provides reusable comparison logic for sorting <see cref="Person"/> objects.
/// </summary>
public static class Comparer
{
    /// <summary>
    /// Compares two people by their age in ascending order.
    /// </summary>
    /// <param name="a">The first person.</param>
    /// <param name="b">The second person.</param>
    /// <returns>
    /// A value less than 0 if <paramref name="a"/> is younger than <paramref name="b"/>; 
    /// 0 if they are the same age; greater than 0 if <paramref name="a"/> is older.
    /// </returns>
    /// <example>
    /// This example demonstrates how to compare two people by age.
    /// <code>
    /// var person1 = new Student("Alice", 25);
    /// var person2 = new Student("Bob", 30);
    /// int result = Comparer.ByAge(person1, person2);
    /// // result will be negative because Alice is younger than Bob
    /// </code>
    /// </example>
    public static int ByAge(Person a, Person b)
    {
        return a.Age.CompareTo(b.Age);
    }

    /// <summary>
    /// Compares two people by their name in ascending alphabetical order.
    /// </summary>
    /// <param name="a">The first person.</param>
    /// <param name="b">The second person.</param>
    /// <returns>
    /// A value less than 0 if <paramref name="a"/>'s name comes before <paramref name="b"/>'s name alphabetically; 
    /// 0 if they are the same; greater than 0 if <paramref name="a"/>'s name comes after.
    /// </returns>
    /// <example>
    /// This example demonstrates how to compare two people by name.
    /// <code>
    /// var person1 = new Student("Alice", 25);
    /// var person2 = new Student("Bob", 30);
    /// int result = Comparer.ByName(person1, person2);
    /// // result will be negative because "Alice" comes before "Bob"
    /// </code>
    /// </example>
    public static int ByName(Person a, Person b)
    {
        return string.Compare(a.Name, b.Name, StringComparison.Ordinal);
    }
}

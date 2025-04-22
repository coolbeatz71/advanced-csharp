using FluentAssertions;
using Xunit;

namespace LearningDotNet.LearningDotNetTest.Domain;

public class PersonSorterTests
{
    [Fact]
    public void Sort_ShouldOrderByAgeAscending_WhenUsingByAgeComparer()
    {
        // Arrange
        var people = new[]
        {
            new Person("Charlie", 45),
            new Person("Alice", 30),
            new Person("Bob", 40)
        };

        // Act
        PersonSorter.Sort(people, Comparer.ByAge);

        // Assert
        people.Should().BeInAscendingOrder(p => p.Age);
        people.Select(p => p.Name).Should().ContainInOrder("Alice", "Bob", "Charlie");
    }

    [Fact]
    public void Sort_ShouldOrderByNameAscending_WhenUsingByNameComparer()
    {
        // Arrange
        var people = new[]
        {
            new Person("Charlie", 25),
            new Person("Alice", 30),
            new Person("Bob", 40)
        };

        // Act
        PersonSorter.Sort(people, Comparer.ByName);

        // Assert
        people.Select(p => p.Name).Should().ContainInOrder("Alice", "Bob", "Charlie");
    }

    [Fact]
    public void Sort_ShouldThrowArgumentNullException_WhenPeopleArrayIsNull()
    {
        // Arrange
        Person[]? people = null;

        // Act
        var act = () => PersonSorter.Sort(people!, Comparer.ByAge);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Sort_ShouldThrowArgumentNullException_WhenComparisonIsNull()
    {
        // Arrange
        var people = new[]
        {
            new Person("John", 50)
        };

        // Act
        var act = () => PersonSorter.Sort(people, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Comparer_ByAge_ShouldReturnCorrectValue()
    {
        // Arrange
        var younger = new Person("Y", 20);
        var older = new Person("O", 30);

        // Act & Assert
        Comparer.ByAge(younger, older).Should().BeLessThan(0);
        Comparer.ByAge(older, younger).Should().BeGreaterThan(0);
        Comparer.ByAge(younger, younger).Should().Be(0);
    }

    [Fact]
    public void Comparer_ByName_ShouldReturnCorrectValue()
    {
        // Arrange
        var alice = new Person("Alice", 25);
        var bob = new Person("Bob", 30);

        // Act & Assert
        Comparer.ByName(alice, bob).Should().BeLessThan(0);
        Comparer.ByName(bob, alice).Should().BeGreaterThan(0);
        Comparer.ByName(alice, alice).Should().Be(0);
    }
}

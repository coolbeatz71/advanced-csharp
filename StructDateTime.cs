namespace LearningDotNet;

/// <summary>
/// Represents an event with a start and end date.
/// </summary>
public readonly struct Event
{
    private DateTime StartDate { get; }
    private DateTime EndDate { get; }
    
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Event"/> struct with specified start and end dates.
    /// </summary>
    /// <param name="startDate">The start date of the event.</param>
    /// <param name="endDate">The end date of the event. Must be after the start date.</param>
    /// <exception cref="ArgumentException">Thrown if the end date is earlier than the start date.</exception>
    public Event(DateTime startDate, DateTime endDate)
    {
        if (endDate < startDate)
        {
            throw new ArgumentException("EndDate must be after StartDate.");
        }

        StartDate = startDate;
        EndDate = endDate;
    }
    
    /// <summary>
    /// Gets the duration of the event in days.
    /// </summary>
    /// <returns>The duration of the event in days, including partial days as a decimal number.</returns>
    /// <example>
    /// <code>
    /// var eventOne = new Event(new DateTime(2024, 07, 01), new DateTime(2024, 07, 10));
    /// double duration = eventOne.GetDurationInDays();
    /// Console.WriteLine(duration); // Output: 9
    /// </code>
    /// </example>
    public double GetDurationInDays()
    {
        return (EndDate - StartDate).TotalDays;
    }
    
    /// <summary>
    /// Checks if this event overlaps with another event.
    /// </summary>
    /// <param name="otherEvent">The other event to check for overlap.</param>
    /// <returns><c>true</c> if the events overlap, otherwise <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// var eventOne = new Event(new DateTime(2024, 07, 01), new DateTime(2024, 07, 10));
    /// var eventTwo = new Event(new DateTime(2024, 07, 05), new DateTime(2024, 07, 15));
    /// bool isOverlapping = eventOne.IsOverlapping(eventTwo);
    /// Console.WriteLine(isOverlapping); // Output: true
    /// </code>
    /// </example>
    public bool IsOverlapping(Event otherEvent)
    {
        return StartDate < otherEvent.EndDate && otherEvent.StartDate < EndDate;
    }
}

public class Exercise
{
    public void TestEvents()
    {
        var eventOne = new Event(
            new DateTime(2024, 07, 01),
            new DateTime(2024, 07, 10)
        );

        var eventTwo = new Event(
            new DateTime(2024, 07, 05),
            new DateTime(2024, 07, 15)
        );

        Console.WriteLine($"Event 1 Duration: {eventOne.GetDurationInDays()} days");
        Console.WriteLine($"Event 2 Duration: {eventTwo.GetDurationInDays()} days");
        Console.WriteLine($"Events Overlap: {eventOne.IsOverlapping(eventTwo)}");
    }
}
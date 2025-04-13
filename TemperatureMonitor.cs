namespace LearningDotNet;

/// <summary>
/// Represents the method signature for handling temperature change notifications.
/// </summary>
/// <param name="message">The alert message related to the temperature change.</param>
public delegate void TemperatureChangeHandler(string message); 

/// <summary>
/// Monitors temperature values and raises an event when a defined threshold is exceeded.
/// </summary>
public class TemperatureMonitor
{
    /// <summary>
    /// Event triggered when the temperature exceeds a safe threshold.
    /// </summary>
    public event TemperatureChangeHandler? OnTemperatureChanged;
    
    private double _temperature;
    
    /// <summary>
    /// Gets or sets the current temperature.
    /// When the value is set and exceeds 36, an alert is triggered.
    /// </summary>
    /// <example>
    /// <code>
    /// var monitor = new TemperatureMonitor();
    /// monitor.Temperature = 37; // Triggers the event if subscribed
    /// </code>
    /// </example>
    public double Temperature
    {
        get => _temperature;
        set
        {
            _temperature = value;
            if (_temperature > 36)
            {
                // Trigger event if threshold is exceeded
                this.TriggerChangedEvent("Body Temperature Above Threshold");
            }
        }
    }
    
    /// <summary>
    /// Safely triggers the <see cref="OnTemperatureChanged"/> event with the specified message.
    /// </summary>
    /// <param name="message">The message describing the temperature alert.</param>

    private void TriggerChangedEvent(string message)
    {
        OnTemperatureChanged?.Invoke(message);
    }
}

/// <summary>
/// Handles temperature alerts and provides a method to respond to them.
/// </summary>
public class TemperatureAlert
{
    /// <summary>
    /// Handles the temperature change event and prints an alert to the console.
    /// </summary>
    /// <param name="message">The alert message received from the temperature monitor.</param>
    /// <example>
    /// <code>
    /// var alert = new TemperatureAlert();
    /// alert.OnTemperatureChanged("High temperature!");
    /// </code>
    /// </example>
    public void OnTemperatureChanged(string message)
    {
        Console.WriteLine($"Alert: {message}");
    }
}




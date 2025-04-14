namespace LearningDotNet;

/// <summary>
/// Provides data for the <see cref="HeartRateMonitor.OnHeartRateChanged"/> event.
/// Contains the heart rate value that triggered the alert.
/// </summary>
/// <param name="heartRate">The current heart rate that exceeded the threshold.</param>
public class HeartRateChangeEventArgs(double heartRate) : EventArgs
{
    public double HeartRate { get; } = heartRate;
}

/// <summary>
/// Monitors heart rate values and raises an event when a defined threshold is exceeded.
/// </summary>
public class HeartRateMonitor
{
    /// <summary>
    /// Event triggered when the heart rate exceeds a safe threshold.
    /// </summary>
    public event EventHandler<HeartRateChangeEventArgs>? OnHeartRateChanged;
    
    private int _heartRate;
    
    /// <summary>
    /// Gets or sets the current heart rate.
    /// When the value is set and exceeds 100 BPM, an alert is triggered.
    /// </summary>
    /// <example>
    /// <code>
    /// var monitor = new HeartRateMonitor();
    /// monitor.HeartRate = 110; // Triggers the event if subscribed
    /// </code>
    /// </example>
    public int HeartRate
    {
        get => _heartRate;
        set
        {
            _heartRate = value;
            if (_heartRate > 100)
            {
                // Trigger event if threshold is exceeded
                this.TriggerChangedEvent(new HeartRateChangeEventArgs(value));
            }
        }
    }
    
    /// <summary>
    /// Invokes the <see cref="OnHeartRateChanged"/> event with the provided event data.
    /// </summary>
    /// <param name="eventArgs">The event data containing the heart rate value.</param>
    private void TriggerChangedEvent(HeartRateChangeEventArgs eventArgs)
    {
        OnHeartRateChanged?.Invoke(this, eventArgs);
    }
}

/// <summary>
/// Handles heart rate alerts and provides a method to respond to them.
/// </summary>
public class HeartRateAlert
{
    /// <summary>
    /// Responds to the heart rate change event by printing an alert to the console.
    /// </summary>
    /// <param name="sender">The source of the event (typically the <see cref="HeartRateMonitor"/>).</param>
    /// <param name="eventArgs">The event arguments containing the heart rate information.</param>
    /// <example>
    /// <code>
    /// var monitor = new HeartRateMonitor();
    /// var alert = new HeartRateAlert();
    /// monitor.OnHeartRateChanged += alert.OnHeartRateChanged;
    /// monitor.HeartRate = 110; // Triggers console alert
    /// </code>
    /// </example>
    public void OnHeartRateChanged(object? sender, HeartRateChangeEventArgs eventArgs)
    {
        Console.WriteLine($"Alert: {eventArgs.HeartRate}BPM - Dangerously Above The Threshold");
    }
}

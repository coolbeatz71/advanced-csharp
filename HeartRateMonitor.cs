namespace LearningDotNet;

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
                this.TriggerChangedEvent("Heart Rate Above Normal Range");
            }
        }
    }
    
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
    public void OnHeartRateChanged(object? sender, HeartRateChangeEventArgs eventArgs)
    {
        Console.WriteLine($"Alert: {eventArgs.HeartRate}");
    }
}

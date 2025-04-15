namespace LearningDotNet;

public class AdvancedHeartRateMonitorEventArgs(double heartRate, int age) : EventArgs
{
    public double HeartRate { get; } = heartRate;
    public int Age { get; } = age;
}

public class AdvancedHeartRateMonitor
{
    /// <summary>
    /// Event triggered when the heart rate exceeds a safe threshold.
    /// </summary>
    public event EventHandler<AdvancedHeartRateMonitorEventArgs>? OnHeartRateChanged;
    
    /// <summary>
    /// Evaluates heart rate against thresholds based on the user's age.
    /// </summary>
    /// <param name="age">The user's age.</param>
    /// <param name="heartRate">The user's current heart rate (in BPM).</param>
    public void TriggerChangedEvent(int age, int heartRate)
    {
        OnHeartRateChanged?.Invoke(this, new AdvancedHeartRateMonitorEventArgs(heartRate, age));
    }
}

public class AdvancedHeartRateAlert
{
    public void OnHeartRateChanged(object? sender, AdvancedHeartRateMonitorEventArgs args)
    {
        var maxHeartRate = 220 - args.Age;
        var lowerTarget = maxHeartRate * 0.50;
        var upperTarget = maxHeartRate * 0.85;
        
        Console.WriteLine($"\nAge: {args.Age}");
        Console.WriteLine($"Heart Rate: {args.HeartRate}BPM");
        Console.WriteLine($"Estimated Max Heart Rate: {maxHeartRate}BPM");
        Console.WriteLine($"Target Heart Rate Zone: {lowerTarget:F0} - {upperTarget:F0}BPM");
        
        var heartRate = args.HeartRate;
        var message = heartRate switch
        {
            < 60 => "⚠️ Alert: Bradycardia (Heart rate too low for resting adults).",
            > 100 when heartRate > maxHeartRate => "❗ Alert: Your heart rate exceeds the estimated maximum! Stop activity and consult a medical professional.",
            > 100 when heartRate > upperTarget => "⚠️ Your heart rate is elevated and may be nearing your maximum. Exercise with caution.",
            > 100 when heartRate >= lowerTarget => "✅ Your heart rate is within a healthy exercise target zone.",
            _ => "ℹ️ Your heart rate is normal for resting conditions."
        };

        Console.WriteLine(message);
    }
}
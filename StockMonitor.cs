namespace LearningDotNet;

/// <summary>
/// Represents the method signature for handling price change notifications.
/// </summary>
/// <param name="message">The alert message related to the price change.</param>
public delegate void PriceChangedHandler(string message);

/// <summary>
/// Monitors stock price changes and raises an event if the price crosses a set threshold.
/// </summary>
public sealed class StockMonitor
{
    /// <summary>
    /// Event triggered when the price exceeds or is below a safe threshold.
    /// </summary>
    public event PriceChangedHandler? OnPriceChanged;
    
    private decimal _price;
    
    /// <summary>
    /// Gets or sets the current stock price.
    /// Triggers an alert if the price is less than the set threshold.
    /// </summary>
    /// <example>
    /// <code>
    /// var monitor = new StockMonitor { Threshold = 100 };
    /// monitor.Price = 90; // Triggers alert
    /// </code>
    /// </example>
    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            this.TriggerPriceChangedEvent(_price < Threshold
                ? "Stock Alert: Stock price is below threshold!"
                : $"(No alert for {_price})");
        }
    }
    
    /// <summary>
    /// Gets or sets the price threshold. If <see cref="Price"/> is lower than this, an alert is triggered.
    /// </summary>
    /// <example>
    /// <code>
    /// var monitor = new StockMonitor();
    /// monitor.Threshold = 150.00m;
    /// </code>
    /// </example>
    public decimal Threshold { get; set; }
    
    /// <summary>
    /// Safely triggers the <see cref="OnPriceChanged"/> event with the specified message.
    /// </summary>
    /// <param name="message">The message describing the stock price alert.</param>
    private void TriggerPriceChangedEvent(string message)
    {
        OnPriceChanged?.Invoke(message);
    }
}

/// <summary>
/// Handles alerts triggered by stock price changes.
/// </summary>
public class StockAlert
{
    /// <summary>
    /// Handles the stock price change event and prints an alert to the console.
    /// </summary>
    /// <param name="message">The alert message received from the stock price monitor.</param>
    /// <example>
    /// <code>
    /// var alert = new StockAlert();
    /// alert.OnPriceChanged("Price dropped below threshold!");
    /// </code>
    /// </example>
    public void OnPriceChanged(string message)
    {
        Console.WriteLine($"Alert: {message}");
    }
}
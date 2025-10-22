namespace FreightBackend.Models;

/// <summary>
/// Represents a freight item in the marketplace
/// </summary>
public class Freight
{
    /// <summary>
    /// Unique identifier for the freight
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Description of the freight
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Origin location
    /// </summary>
    public string Origin { get; set; } = string.Empty;

    /// <summary>
    /// Destination location
    /// </summary>
    public string Destination { get; set; } = string.Empty;

    /// <summary>
    /// Weight in kilograms
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// Volume in cubic meters
    /// </summary>
    public decimal Volume { get; set; }

    /// <summary>
    /// Current status of the freight
    /// </summary>
    public FreightStatus Status { get; set; } = FreightStatus.Available;

    /// <summary>
    /// Pickup date
    /// </summary>
    public DateTime? PickupDate { get; set; }

    /// <summary>
    /// Delivery date
    /// </summary>
    public DateTime? DeliveryDate { get; set; }

    /// <summary>
    /// Price for the freight
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Date when the freight was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Date when the freight was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// Status of a freight item
/// </summary>
public enum FreightStatus
{
    /// <summary>
    /// Freight is available for booking
    /// </summary>
    Available,

    /// <summary>
    /// Freight has been booked
    /// </summary>
    Booked,

    /// <summary>
    /// Freight is in transit
    /// </summary>
    InTransit,

    /// <summary>
    /// Freight has been delivered
    /// </summary>
    Delivered,

    /// <summary>
    /// Freight booking was cancelled
    /// </summary>
    Cancelled
}

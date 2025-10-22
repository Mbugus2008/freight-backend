using System.ComponentModel.DataAnnotations;
using FreightBackend.Models;

namespace FreightBackend.DTOs;

/// <summary>
/// Data transfer object for creating a freight item
/// </summary>
public class CreateFreightDto
{
    /// <summary>
    /// Description of the freight
    /// </summary>
    [Required(ErrorMessage = "Description is required")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Origin location
    /// </summary>
    [Required(ErrorMessage = "Origin is required")]
    [StringLength(200, ErrorMessage = "Origin cannot exceed 200 characters")]
    public string Origin { get; set; } = string.Empty;

    /// <summary>
    /// Destination location
    /// </summary>
    [Required(ErrorMessage = "Destination is required")]
    [StringLength(200, ErrorMessage = "Destination cannot exceed 200 characters")]
    public string Destination { get; set; } = string.Empty;

    /// <summary>
    /// Weight in kilograms
    /// </summary>
    [Required(ErrorMessage = "Weight is required")]
    [Range(0.1, 100000, ErrorMessage = "Weight must be between 0.1 and 100000 kg")]
    public decimal Weight { get; set; }

    /// <summary>
    /// Volume in cubic meters
    /// </summary>
    [Required(ErrorMessage = "Volume is required")]
    [Range(0.01, 10000, ErrorMessage = "Volume must be between 0.01 and 10000 cubic meters")]
    public decimal Volume { get; set; }

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
    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1000000")]
    public decimal Price { get; set; }
}

/// <summary>
/// Data transfer object for updating a freight item
/// </summary>
public class UpdateFreightDto
{
    /// <summary>
    /// Description of the freight
    /// </summary>
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters")]
    public string? Description { get; set; }

    /// <summary>
    /// Origin location
    /// </summary>
    [StringLength(200, ErrorMessage = "Origin cannot exceed 200 characters")]
    public string? Origin { get; set; }

    /// <summary>
    /// Destination location
    /// </summary>
    [StringLength(200, ErrorMessage = "Destination cannot exceed 200 characters")]
    public string? Destination { get; set; }

    /// <summary>
    /// Weight in kilograms
    /// </summary>
    [Range(0.1, 100000, ErrorMessage = "Weight must be between 0.1 and 100000 kg")]
    public decimal? Weight { get; set; }

    /// <summary>
    /// Volume in cubic meters
    /// </summary>
    [Range(0.01, 10000, ErrorMessage = "Volume must be between 0.01 and 10000 cubic meters")]
    public decimal? Volume { get; set; }

    /// <summary>
    /// Current status of the freight
    /// </summary>
    public FreightStatus? Status { get; set; }

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
    [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1000000")]
    public decimal? Price { get; set; }
}

/// <summary>
/// Data transfer object for freight response
/// </summary>
public class FreightDto
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
    public string Status { get; set; } = string.Empty;

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
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date when the freight was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

using FreightBackend.DTOs;
using FreightBackend.Models;

namespace FreightBackend.Services;

/// <summary>
/// Interface for freight service operations
/// </summary>
public interface IFreightService
{
    /// <summary>
    /// Get all freight items
    /// </summary>
    /// <returns>List of freight items</returns>
    Task<IEnumerable<FreightDto>> GetAllAsync();

    /// <summary>
    /// Get freight by ID
    /// </summary>
    /// <param name="id">Freight ID</param>
    /// <returns>Freight item or null if not found</returns>
    Task<FreightDto?> GetByIdAsync(int id);

    /// <summary>
    /// Create a new freight item
    /// </summary>
    /// <param name="createDto">Freight creation data</param>
    /// <returns>Created freight item</returns>
    Task<FreightDto> CreateAsync(CreateFreightDto createDto);

    /// <summary>
    /// Update an existing freight item
    /// </summary>
    /// <param name="id">Freight ID</param>
    /// <param name="updateDto">Updated freight data</param>
    /// <returns>True if updated successfully, false if not found</returns>
    Task<bool> UpdateAsync(int id, UpdateFreightDto updateDto);

    /// <summary>
    /// Delete a freight item
    /// </summary>
    /// <param name="id">Freight ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    Task<bool> DeleteAsync(int id);
}

/// <summary>
/// Implementation of freight service with in-memory storage
/// </summary>
public class FreightService : IFreightService
{
    private readonly List<Freight> _freights = new();
    private readonly ILogger<FreightService> _logger;
    private int _nextId = 1;

    public FreightService(ILogger<FreightService> logger)
    {
        _logger = logger;
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
        _freights.AddRange(new[]
        {
            new Freight
            {
                Id = _nextId++,
                Description = "Electronics shipment from warehouse to distribution center",
                Origin = "New York, NY",
                Destination = "Los Angeles, CA",
                Weight = 500,
                Volume = 2.5m,
                Status = FreightStatus.Available,
                Price = 1500,
                PickupDate = DateTime.UtcNow.AddDays(2),
                DeliveryDate = DateTime.UtcNow.AddDays(7)
            },
            new Freight
            {
                Id = _nextId++,
                Description = "Construction materials for building project",
                Origin = "Chicago, IL",
                Destination = "Houston, TX",
                Weight = 2000,
                Volume = 10,
                Status = FreightStatus.InTransit,
                Price = 3500,
                PickupDate = DateTime.UtcNow.AddDays(-2),
                DeliveryDate = DateTime.UtcNow.AddDays(3)
            }
        });
    }

    public Task<IEnumerable<FreightDto>> GetAllAsync()
    {
        _logger.LogInformation("Getting all freight items. Count: {Count}", _freights.Count);
        var dtos = _freights.Select(MapToDto);
        return Task.FromResult(dtos);
    }

    public Task<FreightDto?> GetByIdAsync(int id)
    {
        _logger.LogInformation("Getting freight with ID: {FreightId}", id);
        var freight = _freights.FirstOrDefault(f => f.Id == id);
        return Task.FromResult(freight != null ? MapToDto(freight) : null);
    }

    public Task<FreightDto> CreateAsync(CreateFreightDto createDto)
    {
        _logger.LogInformation("Creating new freight item");
        
        var freight = new Freight
        {
            Id = _nextId++,
            Description = createDto.Description,
            Origin = createDto.Origin,
            Destination = createDto.Destination,
            Weight = createDto.Weight,
            Volume = createDto.Volume,
            Price = createDto.Price,
            PickupDate = createDto.PickupDate,
            DeliveryDate = createDto.DeliveryDate,
            Status = FreightStatus.Available,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _freights.Add(freight);
        _logger.LogInformation("Created freight with ID: {FreightId}", freight.Id);
        
        return Task.FromResult(MapToDto(freight));
    }

    public Task<bool> UpdateAsync(int id, UpdateFreightDto updateDto)
    {
        _logger.LogInformation("Updating freight with ID: {FreightId}", id);
        
        var freight = _freights.FirstOrDefault(f => f.Id == id);
        if (freight == null)
        {
            _logger.LogWarning("Freight with ID {FreightId} not found", id);
            return Task.FromResult(false);
        }

        if (updateDto.Description != null) freight.Description = updateDto.Description;
        if (updateDto.Origin != null) freight.Origin = updateDto.Origin;
        if (updateDto.Destination != null) freight.Destination = updateDto.Destination;
        if (updateDto.Weight.HasValue) freight.Weight = updateDto.Weight.Value;
        if (updateDto.Volume.HasValue) freight.Volume = updateDto.Volume.Value;
        if (updateDto.Status.HasValue) freight.Status = updateDto.Status.Value;
        if (updateDto.PickupDate.HasValue) freight.PickupDate = updateDto.PickupDate;
        if (updateDto.DeliveryDate.HasValue) freight.DeliveryDate = updateDto.DeliveryDate;
        if (updateDto.Price.HasValue) freight.Price = updateDto.Price.Value;
        
        freight.UpdatedAt = DateTime.UtcNow;
        
        _logger.LogInformation("Updated freight with ID: {FreightId}", id);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        _logger.LogInformation("Deleting freight with ID: {FreightId}", id);
        
        var freight = _freights.FirstOrDefault(f => f.Id == id);
        if (freight == null)
        {
            _logger.LogWarning("Freight with ID {FreightId} not found", id);
            return Task.FromResult(false);
        }

        _freights.Remove(freight);
        _logger.LogInformation("Deleted freight with ID: {FreightId}", id);
        return Task.FromResult(true);
    }

    private static FreightDto MapToDto(Freight freight)
    {
        return new FreightDto
        {
            Id = freight.Id,
            Description = freight.Description,
            Origin = freight.Origin,
            Destination = freight.Destination,
            Weight = freight.Weight,
            Volume = freight.Volume,
            Status = freight.Status.ToString(),
            Price = freight.Price,
            PickupDate = freight.PickupDate,
            DeliveryDate = freight.DeliveryDate,
            CreatedAt = freight.CreatedAt,
            UpdatedAt = freight.UpdatedAt
        };
    }
}

using FluentAssertions;
using FreightBackend.DTOs;
using FreightBackend.Models;
using FreightBackend.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FreightBackend.Tests.Services;

public class FreightServiceTests
{
    private readonly Mock<ILogger<FreightService>> _mockLogger;
    private readonly FreightService _service;

    public FreightServiceTests()
    {
        _mockLogger = new Mock<ILogger<FreightService>>();
        _service = new FreightService(_mockLogger.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllFreights()
    {
        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCountGreaterThanOrEqualTo(2); // We have 2 sample items
    }

    [Fact]
    public async Task GetByIdAsync_WithValidId_ShouldReturnFreight()
    {
        // Arrange
        var existingId = 1;

        // Act
        var result = await _service.GetByIdAsync(existingId);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(existingId);
        result.Description.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetByIdAsync_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var invalidId = 99999;

        // Act
        var result = await _service.GetByIdAsync(invalidId);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task CreateAsync_WithValidData_ShouldCreateFreight()
    {
        // Arrange
        var createDto = new CreateFreightDto
        {
            Description = "Test freight for unit testing",
            Origin = "Test Origin City",
            Destination = "Test Destination City",
            Weight = 100,
            Volume = 5,
            Price = 500
        };

        // Act
        var result = await _service.CreateAsync(createDto);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().BeGreaterThan(0);
        result.Description.Should().Be(createDto.Description);
        result.Origin.Should().Be(createDto.Origin);
        result.Destination.Should().Be(createDto.Destination);
        result.Weight.Should().Be(createDto.Weight);
        result.Volume.Should().Be(createDto.Volume);
        result.Price.Should().Be(createDto.Price);
        result.Status.Should().Be("Available");
    }

    [Fact]
    public async Task UpdateAsync_WithValidId_ShouldUpdateFreight()
    {
        // Arrange
        var existingId = 1;
        var updateDto = new UpdateFreightDto
        {
            Description = "Updated description for testing",
            Status = FreightStatus.InTransit
        };

        // Act
        var result = await _service.UpdateAsync(existingId, updateDto);

        // Assert
        result.Should().BeTrue();
        
        // Verify the update
        var updated = await _service.GetByIdAsync(existingId);
        updated.Should().NotBeNull();
        updated!.Description.Should().Be(updateDto.Description);
        updated.Status.Should().Be("InTransit");
    }

    [Fact]
    public async Task UpdateAsync_WithInvalidId_ShouldReturnFalse()
    {
        // Arrange
        var invalidId = 99999;
        var updateDto = new UpdateFreightDto
        {
            Description = "This should not work"
        };

        // Act
        var result = await _service.UpdateAsync(invalidId, updateDto);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteAsync_WithValidId_ShouldDeleteFreight()
    {
        // Arrange
        var createDto = new CreateFreightDto
        {
            Description = "Freight to be deleted",
            Origin = "Delete Origin",
            Destination = "Delete Destination",
            Weight = 50,
            Volume = 2,
            Price = 200
        };
        var created = await _service.CreateAsync(createDto);

        // Act
        var result = await _service.DeleteAsync(created.Id);

        // Assert
        result.Should().BeTrue();
        
        // Verify deletion
        var deleted = await _service.GetByIdAsync(created.Id);
        deleted.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_WithInvalidId_ShouldReturnFalse()
    {
        // Arrange
        var invalidId = 99999;

        // Act
        var result = await _service.DeleteAsync(invalidId);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task CreateAsync_ShouldSetTimestamps()
    {
        // Arrange
        var createDto = new CreateFreightDto
        {
            Description = "Freight with timestamps",
            Origin = "Origin City",
            Destination = "Destination City",
            Weight = 75,
            Volume = 3,
            Price = 300
        };

        // Act
        var result = await _service.CreateAsync(createDto);

        // Assert
        result.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        result.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateTimestamp()
    {
        // Arrange
        var createDto = new CreateFreightDto
        {
            Description = "Freight for timestamp test",
            Origin = "Origin",
            Destination = "Destination",
            Weight = 100,
            Volume = 4,
            Price = 400
        };
        var created = await _service.CreateAsync(createDto);
        var originalUpdatedAt = created.UpdatedAt;
        
        await Task.Delay(100); // Small delay to ensure timestamp difference

        var updateDto = new UpdateFreightDto
        {
            Description = "Updated description"
        };

        // Act
        await _service.UpdateAsync(created.Id, updateDto);
        var updated = await _service.GetByIdAsync(created.Id);

        // Assert
        updated.Should().NotBeNull();
        updated!.UpdatedAt.Should().BeAfter(originalUpdatedAt);
    }
}

using Microsoft.AspNetCore.Mvc;
using FreightBackend.DTOs;
using FreightBackend.Services;

namespace FreightBackend.Controllers;

/// <summary>
/// Controller for managing freight operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class FreightController : ControllerBase
{
    private readonly IFreightService _freightService;
    private readonly ILogger<FreightController> _logger;

    public FreightController(
        IFreightService freightService,
        ILogger<FreightController> logger)
    {
        _freightService = freightService;
        _logger = logger;
    }

    /// <summary>
    /// Get all freight listings
    /// </summary>
    /// <returns>List of freight items</returns>
    /// <response code="200">Returns the list of freight items</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FreightDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FreightDto>>> GetAll()
    {
        _logger.LogInformation("Fetching all freight listings");
        var freights = await _freightService.GetAllAsync();
        return Ok(freights);
    }

    /// <summary>
    /// Get a specific freight item by ID
    /// </summary>
    /// <param name="id">Freight ID</param>
    /// <returns>Freight item details</returns>
    /// <response code="200">Returns the freight item</response>
    /// <response code="404">Freight item not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FreightDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FreightDto>> GetById(int id)
    {
        _logger.LogInformation("Fetching freight with ID: {FreightId}", id);
        
        var freight = await _freightService.GetByIdAsync(id);
        if (freight == null)
        {
            return NotFound(new { Message = $"Freight with ID {id} not found" });
        }
        
        return Ok(freight);
    }

    /// <summary>
    /// Create a new freight listing
    /// </summary>
    /// <param name="createDto">Freight details</param>
    /// <returns>Created freight item</returns>
    /// <response code="201">Freight item created successfully</response>
    /// <response code="400">Invalid input data</response>
    [HttpPost]
    [ProducesResponseType(typeof(FreightDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FreightDto>> Create([FromBody] CreateFreightDto createDto)
    {
        _logger.LogInformation("Creating new freight listing");
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var freight = await _freightService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = freight.Id }, freight);
    }

    /// <summary>
    /// Update an existing freight listing
    /// </summary>
    /// <param name="id">Freight ID</param>
    /// <param name="updateDto">Updated freight details</param>
    /// <returns>No content on success</returns>
    /// <response code="204">Freight item updated successfully</response>
    /// <response code="400">Invalid input data</response>
    /// <response code="404">Freight item not found</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateFreightDto updateDto)
    {
        _logger.LogInformation("Updating freight with ID: {FreightId}", id);
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _freightService.UpdateAsync(id, updateDto);
        if (!result)
        {
            return NotFound(new { Message = $"Freight with ID {id} not found" });
        }
        
        return NoContent();
    }

    /// <summary>
    /// Delete a freight listing
    /// </summary>
    /// <param name="id">Freight ID</param>
    /// <returns>No content on success</returns>
    /// <response code="204">Freight item deleted successfully</response>
    /// <response code="404">Freight item not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation("Deleting freight with ID: {FreightId}", id);
        
        var result = await _freightService.DeleteAsync(id);
        if (!result)
        {
            return NotFound(new { Message = $"Freight with ID {id} not found" });
        }
        
        return NoContent();
    }
}

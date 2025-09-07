using HotelBediaX.Application.UseCases.DestinationUseCases;
using Microsoft.AspNetCore.Mvc;

namespace HotelBediaX.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DestinationController(
    CreateUseCase createUseCase, 
    GetByIdUseCase getById, 
    GetAllUseCase getAll, 
    UpdateUseCase updateUseCase,
    DeleteUseCase deleteUseCase
    ) : ControllerBase
{
    private readonly CreateUseCase _createUseCase = createUseCase;
    private readonly GetByIdUseCase _getById = getById;
    private readonly GetAllUseCase _getAll = getAll;
    private readonly UpdateUseCase _updateUseCase = updateUseCase;
    private readonly DeleteUseCase _deleteUseCase = deleteUseCase;

    [HttpPost]
    public async Task<IActionResult> CreateDestination([FromBody] CreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await _createUseCase.ExecuteAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getById.ExecuteAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? filter,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var results = await _getAll.ExecuteAsync(pageNumber, pageSize, filter);
        return Ok(results);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDestination(int id, [FromBody] UpdateDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID in URL and body do not match.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _updateUseCase.ExecuteAsync(dto);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteUseCase.ExecuteAsync(id);
        return NoContent();
    }
}

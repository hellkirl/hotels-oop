using hotels.Application.Events.Suite.Commands;
using hotels.Application.Events.Suite.Queries;
using hotels.Application.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Presentation.Http.Controllers;

[ApiController]
[Route("api/v1/hotel_suite_types")]

public class SuiteController : ControllerBase
{
    private readonly IMediator _mediator;

    public SuiteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSuite(CreateSuiteDto createSuiteDto)
    {
        try
        {
            var command = new CreateSuiteCommand(
                hotelId: createSuiteDto.HotelId,
                name: createSuiteDto.Name,
                basePrice: createSuiteDto.BasePrice,
                nSuits: createSuiteDto.NSuits,
                description: createSuiteDto.Description,
                maxOccupancy: createSuiteDto.MaxOccupancy);
            var suiteId = await _mediator.Send(command);
            return Ok($"New suite id is {suiteId}");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }

    [HttpGet("{suiteId}")]
    public async Task<IActionResult> GetSuite(uint suiteId)
    {
        try
        {
            var suiteModel = await _mediator.Send(new GetSuiteQuery(suiteId));
            return Ok(suiteModel);
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }

    [HttpDelete("{suiteId}")]
    public async Task<IActionResult> DeleteSuite(uint suiteId)
    {
        try
        {
            await _mediator.Send(new DeleteSuiteCommand(suiteId));
            return Ok("Suite was successfully deleted");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSuite(UpdateSuiteDto updateSuiteDto)
    {
        try
        {
            var command = new UpdateSuiteCommand(
                updateSuiteDto.SuiteId,
                updateSuiteDto.Name,
                updateSuiteDto.BasePrice,
                updateSuiteDto.NSuits,
                updateSuiteDto.Description,
                updateSuiteDto.MaxOccupancy);
            await _mediator.Send(command);
            return Ok("Suite was successfully updated");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSuits()
    {
        try
        {
            var allSuits = await _mediator.Send(new GetAllSuitsQuery());
            return Ok(allSuits);
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
}
using hotels.Application.Events.Hotel.Commands;
using hotels.Application.Events.Hotel.Queries;
using hotels.Application.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Presentation.Http.Controllers;

[ApiController]
[Route("api/v1/")]
public class HotelController : ControllerBase
{
    private readonly IMediator _mediator;

    public HotelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("hotels/{hotelId}")]
    public async Task<IActionResult> GetHotel(uint hotelId)
    {
        try
        {
            var hotelModel = await _mediator.Send(new GetHotelQuery(hotelId));
            return Ok(hotelModel);
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpGet("hotel_chains/{hotelChainId}")]
    public async Task<IActionResult> GetHotelChain(uint hotelChainId)
    {
        try
        {
            var hotelChainModel = await _mediator.Send(new GetHotelChainQuery(hotelChainId));
            return Ok(hotelChainModel);
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }

    [HttpPost("hotels")]
    public async Task<IActionResult> CreateHotel(CreateHotelDto createHotelDto)
    {
        try
        {
            var command = new CreateHotelCommand(
                createHotelDto.HotelChainId,
                createHotelDto.Name,
                createHotelDto.Stars,
                createHotelDto.HotelManager,
                createHotelDto.Phone,
                createHotelDto.Catering,
                createHotelDto.Country,
                createHotelDto.City,
                createHotelDto.Street,
                createHotelDto.BuildingNumber,
                createHotelDto.Index);
            var newHotelId = await _mediator.Send(command);
            return Ok($"New hotel id is {newHotelId}");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpPost("hotel_chains")]
    public async Task<IActionResult> CreateHotelChain(HotelChainDto hotelChainDto)
    {
        try
        {
            var command = new CreateHotelChainCommand(
                hotelChainDto.Name,
                hotelChainDto.HotelNumber,
                hotelChainDto.HotelChainManager);
            var newHotelChainId = await _mediator.Send(command);
            return Ok($"New hotel chain id is {newHotelChainId}");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpDelete("hotels/{hotelId}")]
    public async Task<IActionResult> DeleteHotel(uint hotelId)
    {
        try
        {
            await _mediator.Send(new DeleteHotelCommand(hotelId));
            return Ok("Hotel was successfully deleted");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpDelete("hotel_chains/{hotelChainId}")]
    public async Task<IActionResult> DeleteHotelChain(uint hotelChainId)
    {
        try
        {
            await _mediator.Send(new DeleteHotelChainCommand(hotelChainId));
            return Ok("Hotel chain was successfully deleted");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpPut("hotels")]
    public async Task<IActionResult> UpdateHotel(UpdateHotelDto hotelDto)
    {
        try
        {
            var command = new UpdateHotelCommand(
                hotelDto.HotelId,
                hotelDto.HotelChainId,
                hotelDto.LocationId,
                hotelDto.Name,
                hotelDto.Stars,
                hotelDto.HotelManager,
                hotelDto.Phone,
                hotelDto.Catering);
            await _mediator.Send(command);
            return Ok($"Hotel updated.");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpPut("hotel_chains")]
    public async Task<IActionResult> UpdateHotelChain(UpdateHotelChainDto hotelChainDto)
    {
        try
        {
            var command = new UpdateHotelChainCommand(
                hotelChainDto.HotelChainId,
                hotelChainDto.HotelChainManager,
                hotelChainDto.HotelChainManager,
                hotelChainDto.HotelNumber);
            await _mediator.Send(command);
            return Ok("Hotel chain updated.");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpGet("hotel_chains")]
    public async Task<IActionResult> GetAllHotelChains()
    {
        try
        {
            var allHotelChains = await _mediator.Send(new GetAllHotelChainsQuery());
            return Ok(allHotelChains);
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpPost("hotels/range")]
    public async Task<IActionResult> RangeHotels(RangeForHotelDto rangeForHotelDto)
    {
        try
        {
            var command = new RangeHotelsCommand(
                city: rangeForHotelDto.City,
                stars: rangeForHotelDto.Stars,
                catering: rangeForHotelDto.Catering,
                priceLimit: rangeForHotelDto.PriceLimit,
                dateIn: rangeForHotelDto.DateIn,
                dateOut: rangeForHotelDto.DateOut);

            var hotelsInRange = await _mediator.Send(command);
            return Ok(hotelsInRange);
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpPost("hotels/rooms")]
    public async Task<IActionResult> GetHotelSuites(RangeForSuiteDto rangeForSuiteDto)
    {
        try
        {
            var query = new GetHotelSuitsQuery(hotelId: rangeForSuiteDto.HotelId,
                dateOut: rangeForSuiteDto.DateOut,
                dateIn: rangeForSuiteDto.DateIn,
                occupancy: rangeForSuiteDto.Occupancy);
            var hotelSuites = await _mediator.Send(query);
            return Ok(hotelSuites);
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
}
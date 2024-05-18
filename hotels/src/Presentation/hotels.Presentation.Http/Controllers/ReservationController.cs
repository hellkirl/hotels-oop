using hotels.Application.Contracts.ServicesInterfaces;
using hotels.Application.Events.Reservation.Commands;
using hotels.Application.Events.Reservation.Queries;
using hotels.Application.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Presentation.Http.Controllers;

[ApiController]
[Route("api/v1/")]

public class ReservationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("hotels/book")]
    public async Task<IActionResult> BookReservation(BookReservationDto bookReservationDto)
    {
        try
        {
            var command = new BookReservationCommand(
                bookReservationDto.userId,
                bookReservationDto.hotelId,
                bookReservationDto.suiteId,
                bookReservationDto.dateIn,
                bookReservationDto.dateOut,
                bookReservationDto.catering);
            var id = await _mediator.Send(command);
            return Ok($"New reservation id is {id}");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }

    }

    [HttpDelete("reservations")]
    public async Task<IActionResult> DeleteReservation(uint reservationId)
    {
        try
        {
            await _mediator.Send(new DeleteReservationCommand(reservationId));
            return Ok("Reservation was successfully deleted");
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }
    
    [HttpGet("reservations/{reservationId}")]
    public async Task<IActionResult> GetReservation(uint reservationId)
    {
        try
        {
            var reservationModel = await _mediator.Send(new GetReservationQuery(reservationId));
            return Ok(reservationModel);
        }
        catch (Exception exception)
        {
            return StatusCode(500, "ERROR: " + exception.Message);
        }
    }

}
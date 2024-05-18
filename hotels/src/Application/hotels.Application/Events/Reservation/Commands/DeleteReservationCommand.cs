using MediatR;

namespace hotels.Application.Events.Reservation.Commands;

public class DeleteReservationCommand : IRequest
{
    public uint ReservationId { get; set; }

    public DeleteReservationCommand(uint reservationId)
    {
        ReservationId = reservationId;
    }
}
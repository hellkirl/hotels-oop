using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Reservation.Queries;

public class GetReservationQuery : IRequest<ReservationModel>
{
    public uint ReservationId { get; set; }

    public GetReservationQuery(uint reservationId)
    {
        ReservationId = reservationId;
    }
}
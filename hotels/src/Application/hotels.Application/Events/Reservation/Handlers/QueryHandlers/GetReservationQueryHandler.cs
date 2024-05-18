using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Reservation.Queries;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Reservation.Handlers.QueryHandlers;

public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, ReservationModel>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    public async Task<ReservationModel> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var reservationModel = await _reservationRepository.FindReservationById(request.ReservationId);
        return reservationModel;
    }
}
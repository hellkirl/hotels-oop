using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Reservation.Commands;
using MediatR;

namespace hotels.Application.Events.Reservation.Handlers.CommandHandlers;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
{
    private readonly IReservationRepository _reservationRepository;

    public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    public async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        await _reservationRepository.DeleteReservation(request.ReservationId);
    }
}
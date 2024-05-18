using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Suite.Commands;
using MediatR;

namespace hotels.Application.Events.Suite.Handlers.CommandHandlers;

public class DeleteSuiteCommandHandler : IRequestHandler<DeleteSuiteCommand>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ISuiteRepository _suiteRepository;

    public DeleteSuiteCommandHandler(IReservationRepository reservationRepository, ISuiteRepository suiteRepository)
    {
        _suiteRepository = suiteRepository;
        _reservationRepository = reservationRepository;
    }
    
    public async Task Handle(DeleteSuiteCommand request, CancellationToken cancellationToken)
    {
        var targetReservationsId = await _reservationRepository.FindReservationsIdBySuiteId(request.SuiteId);
        
        if (targetReservationsId != null && targetReservationsId.Any())
        {
            foreach (var reservationId in targetReservationsId)
            {
                await _reservationRepository.DeleteReservation(reservationId);
            }
        }
        await _suiteRepository.DeleteSuite(request.SuiteId);
    }
}
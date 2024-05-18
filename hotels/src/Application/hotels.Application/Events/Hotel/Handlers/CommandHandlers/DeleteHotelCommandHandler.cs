using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Commands;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.CommandHandlers;

public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand>
{
    private readonly ISuiteRepository _suiteRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IHotelRepository _hotelRepository;

    public DeleteHotelCommandHandler(ISuiteRepository suiteRepository, IReservationRepository reservationRepository, IHotelRepository hotelRepository)
    {
        _suiteRepository = suiteRepository;
        _reservationRepository = reservationRepository;
        _hotelRepository = hotelRepository;
    }

    public async Task Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        var targetSuitIds = await _suiteRepository.FindSuitesByHotelId(request.HotelId);
        if (targetSuitIds != null && targetSuitIds.Any())
        {
            foreach (var suiteModel in targetSuitIds)
            {
                await _suiteRepository.DeleteSuite(suiteModel.SuiteId);
            }
        }
        
        var targetReservationsId = await _reservationRepository.FindReservationsIdByHotelId(request.HotelId);
        if (targetReservationsId != null && targetReservationsId.Any())
        {
            foreach (var reservationId in targetReservationsId)
            {
                await _reservationRepository.DeleteReservation(reservationId);
            }
        }
        
        await _hotelRepository.DeleteHotel(request.HotelId);
    }
}
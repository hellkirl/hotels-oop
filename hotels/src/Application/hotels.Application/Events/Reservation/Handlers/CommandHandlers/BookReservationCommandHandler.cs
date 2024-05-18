using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Reservation.Commands;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Reservation.Handlers.CommandHandlers;

public class BookReservationCommandHandler : IRequestHandler<BookReservationCommand, uint>
{
    private readonly ISuiteRepository _suiteRepository;
    private readonly IReservationRepository _reservationRepository;

    public BookReservationCommandHandler(ISuiteRepository suiteRepository, IReservationRepository reservationRepository)
    {
        _suiteRepository = suiteRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<uint> Handle(BookReservationCommand request, CancellationToken cancellationToken)
    {
        var reservationModel = new ReservationModel()
        {
            UserId = request.UserId,
            HotelId = request.HotelId,
            SuiteId = request.SuiteId,
            DateIn = request.DateIn,
            DateOut = request.DateOut,
            Catering = request.Catering
        };
        var connectedSuite = await _suiteRepository.FindSuiteById(reservationModel.SuiteId);
        if (connectedSuite.HotelId != request.HotelId)
        {
            throw new Exception($"Your input hotelId ({request.HotelId}) and suite hotelId ({connectedSuite.HotelId}) must be the same");
        }
        
        uint newReservationId = await _reservationRepository.AddReservation(reservationModel);
        return newReservationId;
    }
}
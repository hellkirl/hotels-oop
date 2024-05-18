using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Commands;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.CommandHandlers;

public class RangeHotelsCommandHandler : IRequestHandler<RangeHotelsCommand, List<HotelModel>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly ISuiteRepository _suiteRepository;
    private readonly IReservationRepository _reservationRepository;

    public RangeHotelsCommandHandler(IHotelRepository hotelRepository, ILocationRepository locationRepository,
        ISuiteRepository suiteRepository, IReservationRepository reservationRepository)
    {
        _hotelRepository = hotelRepository;
        _locationRepository = locationRepository;
        _suiteRepository = suiteRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<List<HotelModel>> Handle(RangeHotelsCommand request, CancellationToken cancellationToken)
    {
        if (request.DateIn > request.DateOut)
        {
            throw new Exception("Invalid dates; Date in should precede Date out");
        }

        if (request.PriceLimit <= 0)
        {
            throw new Exception($"Invalid price - {request.PriceLimit}; Should be a positive decimal number");
        }

        var hotelModel = new HotelModel
        {
            Catering = request.Catering,
            Stars = request.Stars
        };

        var hotelsByRange = await _hotelRepository.FindHotelInRange(hotelModel);
        var hotelsToRemove = new List<HotelModel>();

        foreach (var hotel in hotelsByRange)
        {
            bool allSuitesConflict = true;
            var locationId = hotel.LocationId;
            var locationModelInRange = await _locationRepository.FindLocationById(locationId);
            var suitesInRange = await _suiteRepository.FindSuitesByHotelId(hotel.HotelId);

            if (suitesInRange == null)
            {
                hotelsToRemove.Add(hotel);
                continue;
            }

            foreach (var suite in suitesInRange)
            {
                var reservationIds = await _reservationRepository.FindReservationsIdBySuiteId(suite.SuiteId);
                if (reservationIds == null)
                {
                    throw new Exception("Reservation extraction failed");
                }

                var price = suite.BasePrice;
                if (locationModelInRange == null || locationModelInRange.City != request.City ||
                    price > request.PriceLimit)
                {
                    hotelsToRemove.Add(hotel);
                }
                else
                {
                    foreach (var reservationId in reservationIds)
                    {
                        var reservationModel = await _reservationRepository.FindReservationById(reservationId);
                        if (reservationModel.DateOut <= request.DateIn && reservationModel.DateIn >= request.DateOut)
                        {
                            allSuitesConflict = false;
                            break;
                        }
                    }
                }

                if (allSuitesConflict)
                {
                    hotelsToRemove.Add(hotel);
                }
            }
        }

        hotelsByRange.RemoveAll(h => hotelsToRemove.Contains(h));
        return hotelsByRange;
    }
}

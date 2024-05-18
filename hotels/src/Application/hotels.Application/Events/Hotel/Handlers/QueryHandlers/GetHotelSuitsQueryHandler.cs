using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Queries;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.QueryHandlers;

public class GetHotelSuitsQueryHandler : IRequestHandler<GetHotelSuitsQuery, List<SuiteModel>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly ISuiteRepository _suiteRepository;
    private readonly IReservationRepository _reservationRepository;

    public GetHotelSuitsQueryHandler(IHotelRepository hotelRepository, ISuiteRepository suiteRepository, IReservationRepository reservationRepository)
    {
        _hotelRepository = hotelRepository;
        _suiteRepository = suiteRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<List<SuiteModel>> Handle(GetHotelSuitsQuery request, CancellationToken cancellationToken)
    {
        if (request.DateIn > request.DateOut)
        {
            throw new Exception("Invalid dates; Date in should preceded Date out");
        }
        if (request.Occupancy <= 0)
        {
            throw new Exception($"Invalid occupancy = {request.Occupancy}; Should be a positive uint");
        }
        
        // тут по идее вылезает экспешен от хотел-репозитория и проверять не надо
        HotelModel hotelModel = await _hotelRepository.FindHotelById(request.HotelId);
        if (hotelModel is null)
        {
            throw new Exception($"Hotel with hotel_id = {request.HotelId} not found");
        }
        List<SuiteModel>? suitesInRange = await _suiteRepository.FindSuitesByHotelId(request.HotelId);
        if (suitesInRange is null)
        {
            throw new Exception($"No suite for hotel with hotel_id = {request.HotelId} found");
        }
        
        var suitesToRemove = new List<SuiteModel>();
        foreach (SuiteModel suite in suitesInRange)
        {
            if (suite.MaxOccupancy < request.Occupancy)
            {
                suitesToRemove.Add(suite);
            }
            else
            {
                var reservationIds = await _reservationRepository.FindReservationsIdBySuiteId(suite.SuiteId);
                if (reservationIds is null)
                {
                    throw new Exception("Reservation extraction fail");
                }
            
                bool allReservationsConflict = true;
                foreach (var reservationId in reservationIds)
                {
                    var reservationModel = await _reservationRepository.FindReservationById(reservationId);
                    if (!(reservationModel.DateOut <= request.DateIn || reservationModel.DateIn >= request.DateOut))
                    {
                        allReservationsConflict = false;
                        break;
                    }
                }
                if (allReservationsConflict)
                {
                    suitesToRemove.Add(suite);
                }
            }
        }
        suitesInRange.RemoveAll(s => suitesToRemove.Contains(s));
        return suitesInRange;
    }
}
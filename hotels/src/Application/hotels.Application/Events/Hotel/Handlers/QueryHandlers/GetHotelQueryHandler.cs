using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Queries;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.QueryHandlers;

public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, HotelModel>
{
    private readonly IHotelRepository _hotelRepository;

    public GetHotelQueryHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }
    
    public async Task<HotelModel> Handle(GetHotelQuery request, CancellationToken cancellationToken)
    {
        var hotelModel = await _hotelRepository.FindHotelById(request.HotelId);
        return hotelModel;
    }
}
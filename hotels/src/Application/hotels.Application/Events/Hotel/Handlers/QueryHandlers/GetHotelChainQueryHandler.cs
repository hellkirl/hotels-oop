using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Queries;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.QueryHandlers;

public class GetHotelChainQueryHandler : IRequestHandler<GetHotelChainQuery, HotelChainModel>
{
    private readonly IHotelChainRepository _hotelChainRepository;

    public GetHotelChainQueryHandler(IHotelChainRepository hotelChainRepository)
    {
        _hotelChainRepository = hotelChainRepository;
    }
    public async Task<HotelChainModel> Handle(GetHotelChainQuery request, CancellationToken cancellationToken)
    {
        var hotelChainModel = await _hotelChainRepository.FindHotelChainById(request.HotelChainId);
        return hotelChainModel;
    }
}
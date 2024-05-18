using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Queries;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.QueryHandlers;

public class GetAllHotelChainsQueryHandler : IRequestHandler<GetAllHotelChainsQuery, List<HotelChainModel>>
{
    private readonly IHotelChainRepository _hotelChainRepository;

    public GetAllHotelChainsQueryHandler(IHotelChainRepository hotelChainRepository)
    {
        _hotelChainRepository = hotelChainRepository;
    }
    
    public async Task<List<HotelChainModel>> Handle(GetAllHotelChainsQuery request, CancellationToken cancellationToken)
    {
        List<HotelChainModel> allHotelChains = await _hotelChainRepository.GetAllHotelChains();
        return allHotelChains;
    }
}
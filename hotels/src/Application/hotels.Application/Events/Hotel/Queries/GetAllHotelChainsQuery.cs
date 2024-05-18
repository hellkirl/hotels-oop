using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Queries;

public class GetAllHotelChainsQuery : IRequest<List<HotelChainModel>>
{
    public GetAllHotelChainsQuery()
    {
    }
}
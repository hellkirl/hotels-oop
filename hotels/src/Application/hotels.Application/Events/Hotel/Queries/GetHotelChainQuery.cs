using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Queries;

public class GetHotelChainQuery : IRequest<HotelChainModel>
{
    public uint HotelChainId { get; set; }

    public GetHotelChainQuery(uint hotelChainId)
    {
        HotelChainId = hotelChainId;
    }
}
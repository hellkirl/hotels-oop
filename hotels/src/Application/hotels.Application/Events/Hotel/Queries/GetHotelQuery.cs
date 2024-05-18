using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Queries;

public class GetHotelQuery : IRequest<HotelModel>
{
    public uint HotelId { get; set; }

    public GetHotelQuery(uint hotelId)
    {
        HotelId = hotelId;
    }
}
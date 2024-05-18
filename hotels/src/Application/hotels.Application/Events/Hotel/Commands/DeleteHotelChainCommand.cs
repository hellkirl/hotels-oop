using MediatR;

namespace hotels.Application.Events.Hotel.Commands;

public class DeleteHotelChainCommand : IRequest
{
    public uint HotelChainId { get; set; }

    public DeleteHotelChainCommand(uint hotelChainId)
    {
        HotelChainId = hotelChainId;
    }
}
using MediatR;

namespace hotels.Application.Events.Hotel.Commands;

public class DeleteHotelCommand : IRequest
{
    public uint HotelId { get; set; }

    public DeleteHotelCommand(uint hotelId)
    {
        HotelId = hotelId;
    }
}
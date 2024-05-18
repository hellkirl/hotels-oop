using MediatR;

namespace hotels.Application.Events.Hotel.Commands;

public class UpdateHotelChainCommand : IRequest
{
    public uint HotelChainId { get; set; }
    public string Name { get; set; } 
    public string HotelChainManager { get; set; }
    public uint HotelNumber { get; set; }
    
    public UpdateHotelChainCommand(uint hotelChainId, string name, string hotelChainManager, uint hotelNumber)
    {
        HotelChainId = hotelChainId;
        Name = name;
        HotelChainManager = hotelChainManager;
        HotelNumber = hotelNumber;
    }
}
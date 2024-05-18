using MediatR;

namespace hotels.Application.Events.Hotel.Commands;

public class CreateHotelChainCommand : IRequest<uint>
{
    public string Name { get; set; }
    public uint HotelNumber { get; set; }
    public string HotelChainManager { get; set; }
    
    public CreateHotelChainCommand(string name, uint hotelNumber, string hotelChainManager)
    {
        Name = name;
        HotelNumber = hotelNumber;
        HotelChainManager = hotelChainManager;
    }
}
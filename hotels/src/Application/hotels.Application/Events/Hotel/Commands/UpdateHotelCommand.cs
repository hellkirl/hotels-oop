using MediatR;

namespace hotels.Application.Events.Hotel.Commands;

public class UpdateHotelCommand : IRequest
{
    public uint HotelId { get; set; }
    public uint HotelChainId { get; set; }
    public uint LocationId { get; set; }
    public string Name { get; set; }
    public string Stars { get; set; }
    public string HotelManager { get; set; }
    public string Phone { get; set; }
    public List<string> Catering { get; set; }
    
    public UpdateHotelCommand(uint hotelId, uint hotelChainId, uint locationId, string name, string stars, string hotelManager, string phone, List<string> catering)
    {
        HotelId = hotelId;
        HotelChainId = hotelChainId;
        LocationId = locationId;
        Name = name;
        Stars = stars;
        HotelManager = hotelManager;
        Phone = phone;
        Catering = catering;
    }
}
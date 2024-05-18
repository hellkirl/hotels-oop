using MediatR;

namespace hotels.Application.Events.Hotel.Commands;

public class CreateHotelCommand : IRequest<uint>
{
    public uint HotelChainId { get; set; }
    public string Name { get; set; }
    public string Stars { get; set; }
    public string HotelManager { get; set; }
    public string Phone { get; set; }
    public List<string> Catering { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string Index { get; set; }
    
    public CreateHotelCommand(uint hotelChainId, string name, string stars, string hotelManager, string phone, List<string> catering, string country, string city, string street, string buildingNumber, string index)
    {
        HotelChainId = hotelChainId;
        Name = name;
        Stars = stars;
        HotelManager = hotelManager;
        Phone = phone;
        Catering = catering;
        Country = country;
        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
        Index = index;
    }
}
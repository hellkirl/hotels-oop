namespace hotels.Application.Models.Dto;

public class CreateHotelDto
{
    public uint HotelChainId { get; set; } // Foreign Key of HotelChain
    public uint LocationId { get; set; } // Foreign Key of location
    public string Name { get; set; } // Name of the hotel
    public string Stars { get; set; } // Hotel rating
    public string HotelManager { get; set; } // Name of the hotel manager
    public string Phone { get; set; } // Phone number of the hotel
    public List<string> Catering { get; set; } // Type of the catering service
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string Index { get; set; }
}

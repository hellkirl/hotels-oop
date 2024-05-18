namespace hotels.Application.Models.HotelModels;

/// <summary>
/// This class represents the hotel entity
/// </summary>
public class HotelModel
{
    public uint HotelId { get; set; } // Primary Key
    public uint HotelChainId { get; set; } // Foreign Key of HotelChain
    public uint LocationId { get; set; } // Foreign Key of location
    public string Name { get; set; } // Name of the hotel
    public string Stars { get; set; } // Hotel rating
    public string HotelManager { get; set; } // Name of the hotel manager
    public string Phone { get; set; } // Phone number of the hotel
    public List<string>? Catering { get; set; } // Type of the catering service
}

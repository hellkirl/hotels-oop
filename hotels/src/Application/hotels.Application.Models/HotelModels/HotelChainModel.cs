namespace hotels.Application.Models.HotelModels;

/// <summary>
/// This class represents the hotel chain entity
/// </summary>
public class HotelChainModel
{
    public uint HotelChainId { get; set; } // Primary Key
    public string Name { get; set; } // Name of the hotel chain
    public uint HotelNumber { get; set; } // Number of hotels in the chain
    public string HotelChainManager { get; set; } // Manager of the hotel chain
}
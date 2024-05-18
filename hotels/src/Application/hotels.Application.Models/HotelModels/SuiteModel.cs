namespace hotels.Application.Models.HotelModels;

/// <summary>
/// This class represents the suite entity
/// </summary>
public class SuiteModel
{
    public uint SuiteId { get; set; } // Primary Key
    public uint HotelId { get; set; } // Foreign Key of Hotel
    public string Name { get; set; } // Name of the suite (its type)
    public decimal BasePrice { get; set; } // Base price of the suit
    public uint NSuits { get; set; } // Number of suits in the hotel
    public string Description { get; set; } // Description of the suite
    public uint MaxOccupancy { get; set; } // Max occupancy of the suite
}

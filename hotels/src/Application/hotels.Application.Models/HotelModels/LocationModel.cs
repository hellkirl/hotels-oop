namespace hotels.Application.Models.HotelModels;

/// <summary>
/// This class represents the location entity
/// </summary>
public class LocationModel
{
    public uint LocationId { get; set; } // Primary Key
    public string Country { get; set; } // Country of the location
    public string City { get; set; } // City of the location
    public string Street { get; set; } // Street of the location
    public string BuildingNumber { get; set; } // Building of the location
    public string Index { get; set; } // Index of the location
}
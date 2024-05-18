namespace hotels.Application.Models.HotelModels;

/// <summary>
/// This class represents the Reservation entity
/// </summary>
public class ReservationModel
{
    public uint ReservationId { get; set; } // Primary Key
    public uint HotelId { get; set; } // Foreign Key of the Hotel
    public uint UserId { get; set; } // Foreign Key of the User
    public uint SuiteId { get; set; } // Foreign Key of the Suite
    public DateTime DateIn { get; set; } // Date in
    public DateTime DateOut { get; set; } // Date put
    public List<string>? Catering { get; set; } // Type of the catering service
}

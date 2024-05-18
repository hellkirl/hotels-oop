using System.ComponentModel.DataAnnotations;

namespace hotels.Infrastructure.Persistence.Entities;

public class ReservationEntity
{
    [Key]
    public uint reservation_id { get; set; }
    public uint user_id { get; set; }
    public uint hotel_id { get; set; }
    public uint suit_id { get; set; }
    public DateTime checkin { get; set; }
    public DateTime checkout { get; set; }
    public string catering { get; set; }
}
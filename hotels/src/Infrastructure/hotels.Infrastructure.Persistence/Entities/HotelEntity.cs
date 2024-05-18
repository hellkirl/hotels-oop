using System.ComponentModel.DataAnnotations;

namespace hotels.Infrastructure.Persistence.Entities;

public class HotelEntity
{
    [Key]
    public uint hotel_id { get; set; }
    public uint hotel_chain_id { get; set; }
    public uint location_id { get; set; }
    public string name { get; set; }
    public string stars { get; set; }
    public string hotel_manager { get; set; }
    public string phone { get; set; }
    public string catering { get; set; }
}

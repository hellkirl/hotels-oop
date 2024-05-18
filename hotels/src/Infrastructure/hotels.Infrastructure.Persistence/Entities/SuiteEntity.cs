using System.ComponentModel.DataAnnotations;

namespace hotels.Infrastructure.Persistence.Entities;

public class SuiteEntity
{
    [Key]
    public uint suit_id { get; set; }
    public uint hotel_id { get; set; }
    public decimal base_price { get; set; }
    public string name { get; set; }
    public uint n_suits { get; set; }
    public string description { get; set; }
    public uint max_occupancy { get; set; }
}
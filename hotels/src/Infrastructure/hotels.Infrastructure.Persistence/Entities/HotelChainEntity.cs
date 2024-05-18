using System.ComponentModel.DataAnnotations;

namespace hotels.Infrastructure.Persistence.Entities;

public class HotelChainEntity
{
    [Key]
    public uint hotel_chain_id { get; set; }
    public string name { get; set; }
    public string manager { get; set; }
    public uint n_hotels { get; set; }
}

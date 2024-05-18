using System.ComponentModel.DataAnnotations;

namespace hotels.Infrastructure.Persistence.Entities;

public class LocationEntity
{
    [Key]
    public uint location_id { get; set; }
    public string country { get; set; }
    public string city { get; set; }
    public string street { get; set; }
    public string building { get; set; }
    public string index { get; set; }
}
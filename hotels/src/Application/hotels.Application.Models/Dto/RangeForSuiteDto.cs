namespace hotels.Application.Models.Dto;

public class RangeForSuiteDto
{
    public uint HotelId { get; set; }
    public DateTime DateIn { get; set; }
    public DateTime DateOut { get; set; }
    public uint Occupancy { get; set; }
}
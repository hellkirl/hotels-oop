namespace hotels.Application.Models.Dto;

public class CreateSuiteDto
{
    public uint HotelId { get; set; } 
    public string Name { get; set; }
    public uint BasePrice { get; set; }
    public uint NSuits { get; set; }
    public string Description { get; set; }
    public uint MaxOccupancy { get; set; }
}
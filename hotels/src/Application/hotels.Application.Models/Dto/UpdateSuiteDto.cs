namespace hotels.Application.Models.Dto;

public class UpdateSuiteDto
{
    public uint SuiteId { get; set; }
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public uint NSuits { get; set; }
    public string Description { get; set; }
    public uint MaxOccupancy { get; set; }
}
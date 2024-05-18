namespace hotels.Application.Models.Dto;

public class RangeForHotelDto
{
    public string City { get; set; }
    public string Stars { get; set; }
    public List<string> Catering { get; set; }
    public decimal PriceLimit { get; set; }
    public DateTime DateIn { get; set; }
    public DateTime DateOut { get; set; }
}
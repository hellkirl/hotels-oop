using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Commands;

public class RangeHotelsCommand : IRequest<List<HotelModel>>
{
    public string City { get; set; }
    public string Stars { get; set; }
    public List<string> Catering { get; set; }
    public decimal PriceLimit { get; set; }
    public DateTime DateIn { get; set; }
    public DateTime DateOut { get; set; }
    
    public RangeHotelsCommand(string city, string stars, List<string> catering, decimal priceLimit, DateTime dateIn, DateTime dateOut)
    {
        City = city;
        Stars = stars;
        Catering = catering;
        PriceLimit = priceLimit;
        DateIn = dateIn;
        DateOut = dateOut;
    }
}
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Queries;

public class GetHotelSuitsQuery : IRequest<List<SuiteModel>>
{
    public uint HotelId { get; set; }
    public DateTime DateIn { get; set; }
    public DateTime DateOut { get; set; }
    public uint Occupancy { get; set; }
    
    public GetHotelSuitsQuery(uint hotelId, DateTime dateIn, DateTime dateOut, uint occupancy)
    {
        HotelId = hotelId;
        DateIn = dateIn;
        DateOut = dateOut;
        Occupancy = occupancy;
    }

}
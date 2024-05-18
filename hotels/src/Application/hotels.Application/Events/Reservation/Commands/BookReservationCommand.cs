using MediatR;

namespace hotels.Application.Events.Reservation.Commands;

public class BookReservationCommand : IRequest<uint>
{
    public uint UserId { get; set; }
    public uint HotelId { get; set; }
    public uint SuiteId { get; set; }
    public DateTime DateIn { get; set; }
    public DateTime DateOut { get; set; }
    public List<string> Catering { get; set; }
    
    public BookReservationCommand(uint userId, uint hotelId, uint suiteId, DateTime dateIn, DateTime dateOut, List<string> catering)
    {
        UserId = userId;
        HotelId = hotelId;
        SuiteId = suiteId;
        DateIn = dateIn;
        DateOut = dateOut;
        Catering = catering;
    }
}
namespace hotels.Application.Models.Dto;

public class BookReservationDto
{
    public uint userId { get; set; }
    public uint hotelId { get; set; }
    public uint suiteId { get; set; }
    public DateTime dateIn { get; set; }
    public DateTime dateOut  { get; set; }
    public List<string> catering  { get; set; }
}
using MediatR;

namespace hotels.Application.Events.Suite.Commands;

public class CreateSuiteCommand : IRequest<uint>
{
    public uint HotelId { get; set; }
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public uint NSuits { get; set; }
    public string Description { get; set; }
    public uint MaxOccupancy { get; set; }
    
    public CreateSuiteCommand(uint hotelId, string name, decimal basePrice, uint nSuits, string description, uint maxOccupancy)
    {
        HotelId = hotelId;
        Name = name;
        BasePrice = basePrice;
        NSuits = nSuits;
        Description = description;
        MaxOccupancy = maxOccupancy;
    }

}
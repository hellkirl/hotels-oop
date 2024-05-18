using MediatR;

namespace hotels.Application.Events.Suite.Commands;

public class UpdateSuiteCommand : IRequest
{
    public uint SuiteId { get; set; }
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public uint NSuits { get; set; }
    public string Description { get; set; }
    public uint MaxOccupancy { get; set; }
    
    public UpdateSuiteCommand(uint suiteId, string name, decimal basePrice, uint nSuits, string description, uint maxOccupancy)
    {
        SuiteId = suiteId;
        Name = name;
        BasePrice = basePrice;
        NSuits = nSuits;
        Description = description;
        MaxOccupancy = maxOccupancy;
    }
}
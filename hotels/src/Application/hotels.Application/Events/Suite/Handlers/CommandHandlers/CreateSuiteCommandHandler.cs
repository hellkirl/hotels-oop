using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Suite.Commands;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Suite.Handlers.CommandHandlers;

public class CreateSuiteCommandHandler : IRequestHandler<CreateSuiteCommand, uint>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly ISuiteRepository _suiteRepository;

    public CreateSuiteCommandHandler(IHotelRepository hotelRepository, ISuiteRepository suiteRepository)
    {
        _suiteRepository = suiteRepository;
        _hotelRepository = hotelRepository;
    }
    
    public async Task<uint> Handle(CreateSuiteCommand request, CancellationToken cancellationToken)
    {
        var suiteModel = new SuiteModel
        {
            HotelId = request.HotelId,
            BasePrice = request.BasePrice,
            Name = request.Name,
            NSuits = request.NSuits,
            Description = request.Description,
            MaxOccupancy = request.MaxOccupancy
        };
        
        await _hotelRepository.FindHotelById(request.HotelId);
        var newSuiteId = await _suiteRepository.AddSuite(suiteModel);
        return newSuiteId;
    }
}
using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Commands;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.CommandHandlers;

public class CreateHotelChainCommandHandler : IRequestHandler<CreateHotelChainCommand, uint>
{
    private readonly IHotelChainRepository _hotelChainRepository;

    public CreateHotelChainCommandHandler(IHotelChainRepository hotelChainRepository)
    {
        _hotelChainRepository = hotelChainRepository;
    }
    public async Task<uint> Handle(CreateHotelChainCommand request, CancellationToken cancellationToken)
    {
        var hotelChainModel = new HotelChainModel
        {
            HotelChainManager = request.HotelChainManager,
            Name = request.Name,
            HotelNumber = request.HotelNumber
        };
        uint newHotelChainId = await _hotelChainRepository.AddHotelChain(hotelChainModel);

        return newHotelChainId;
    }
}
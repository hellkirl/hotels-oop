using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Commands;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.CommandHandlers;

public class UpdateHotelChainCommandHandler : IRequestHandler<UpdateHotelChainCommand>
{
    private readonly IHotelChainRepository _hotelChainRepository;

    public UpdateHotelChainCommandHandler(IHotelChainRepository hotelChainRepository)
    {
        _hotelChainRepository = hotelChainRepository;
    }
    
    public async Task Handle(UpdateHotelChainCommand request, CancellationToken cancellationToken)
    {
        var hotelChainModel = await _hotelChainRepository.FindHotelChainById(request.HotelChainId);

        hotelChainModel.HotelChainManager = request.HotelChainManager;
        hotelChainModel.Name = request.Name;
        hotelChainModel.HotelNumber = request.HotelNumber;
        
        await _hotelChainRepository.UpdateHotelChain(hotelChainModel);
    }
}
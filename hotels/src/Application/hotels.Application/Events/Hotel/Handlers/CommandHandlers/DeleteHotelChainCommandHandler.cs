using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Commands;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.CommandHandlers;

public class DeleteHotelChainCommandHandler : IRequestHandler<DeleteHotelChainCommand>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IHotelChainRepository _hotelChainRepository;

    public DeleteHotelChainCommandHandler(IHotelRepository hotelRepository, IHotelChainRepository hotelChainRepository)
    {
        _hotelRepository = hotelRepository;
        _hotelChainRepository = hotelChainRepository;
    }
    
    public async Task Handle(DeleteHotelChainCommand request, CancellationToken cancellationToken)
    {
        var targetHotelsId = await _hotelRepository.FindHotelsIdByHotelChainId(request.HotelChainId);
        if (targetHotelsId.Any())
        {
            foreach (var hotelId in targetHotelsId)
            {
                await _hotelRepository.DeleteHotel(hotelId);
            }
        }
        await _hotelChainRepository.DeleteHotelChain(request.HotelChainId);
    }
}
using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Commands;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.CommandHandlers;

public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand>
{
    private readonly IHotelRepository _hotelRepository;

    public UpdateHotelCommandHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }
    
    public async Task Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotelModel = await _hotelRepository.FindHotelById(request.HotelId);

        hotelModel.HotelChainId = request.HotelChainId;
        hotelModel.LocationId = request.LocationId;
        hotelModel.Name = request.Name;
        hotelModel.Stars = request.Stars;
        hotelModel.HotelManager = request.HotelManager;
        hotelModel.Phone = request.Phone;
        hotelModel.Catering = request.Catering;
        
        await _hotelRepository.UpdateHotel(hotelModel);
    }
}
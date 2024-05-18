using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Hotel.Commands;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Hotel.Handlers.CommandHandlers;

public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, uint>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IHotelRepository _hotelRepository;

    public CreateHotelCommandHandler(ILocationRepository locationRepository, IHotelRepository hotelRepository)
    {
        _locationRepository = locationRepository;
        _hotelRepository = hotelRepository;
    }
    
    public async Task<uint> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var locationModel = new LocationModel
        {
            Country = request.Country,
            City = request.City,
            Street = request.Street,
            BuildingNumber = request.BuildingNumber,
            Index = request.Index
        };

        uint newLocationId = await _locationRepository.AddLocation(locationModel);
        
        var hotelModel = new HotelModel
        {
            Catering = request.Catering,
            HotelChainId = request.HotelChainId,
            LocationId = newLocationId,
            Name = request.Name,
            Stars = request.Stars,
            HotelManager = request.HotelManager,
            Phone = request.Phone
        };
        uint newHotelId = await _hotelRepository.AddHotel(hotelModel);
        
        return newHotelId;
    }
}
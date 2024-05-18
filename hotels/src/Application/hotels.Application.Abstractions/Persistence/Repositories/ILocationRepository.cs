using hotels.Application.Models.HotelModels;

namespace Hotels.Application.Abstractions.Persistence.Repositories;

public interface ILocationRepository
{
    Task<LocationModel> FindLocationById(uint locationId);
    Task<uint> AddLocation(LocationModel locationModel);
    Task UpdateLocation(LocationModel locationModel);
    Task DeleteLocation(uint locationId);
}
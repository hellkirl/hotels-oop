using hotels.Application.Models.HotelModels;

namespace Hotels.Application.Abstractions.Persistence.Repositories;

public interface IHotelRepository
{
    Task<HotelModel> FindHotelById(uint hotelId);
    Task<List<uint>> FindHotelsIdByHotelChainId(uint hotelChainId);
    Task<uint> AddHotel(HotelModel hotelModel);
    Task UpdateHotel(HotelModel hotelModel);
    Task DeleteHotel(uint hotelId);
    Task<List<HotelModel>> FindHotelInRange(HotelModel hotelModel);
}

using hotels.Application.Models.HotelModels;

namespace Hotels.Application.Abstractions.Persistence.Repositories;

public interface IHotelChainRepository
{
    Task<HotelChainModel> FindHotelChainById(uint hotelChainId);
    Task<uint> AddHotelChain(HotelChainModel hotelChainModel);
    Task UpdateHotelChain(HotelChainModel hotelChainModel);
    Task DeleteHotelChain(uint hotelChainId);
    Task<List<HotelChainModel>> GetAllHotelChains();
}
using hotels.Application.Models.HotelModels;

namespace Hotels.Application.Abstractions.Persistence.Repositories;

public interface ISuiteRepository
{
    Task<SuiteModel> FindSuiteById(uint suiteId);
    Task<List<SuiteModel>?> FindSuitesByHotelId(uint hotelId);
    Task<uint> AddSuite(SuiteModel suiteModel);
    Task UpdateSuite(SuiteModel suiteModel);
    Task DeleteSuite(uint suiteId);
    Task<List<SuiteModel>> GetAllSuits();
}
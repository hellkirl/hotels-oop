using hotels.Application.Models.HotelModels;

namespace Hotels.Application.Abstractions.Persistence.Repositories;

public interface IReservationRepository
{
    Task<ReservationModel> FindReservationById(uint reservationId);
    Task<List<uint>?> FindReservationsIdBySuiteId(uint suiteId);
    Task<List<uint>?> FindReservationsIdByUserId(uint userId);
    Task<List<uint>?> FindReservationsIdByHotelId(uint hotelId);
    Task<uint> AddReservation(ReservationModel reservationModel);
    Task UpdateReservation(ReservationModel reservationModel);
    Task DeleteReservation(uint reservationId);
}
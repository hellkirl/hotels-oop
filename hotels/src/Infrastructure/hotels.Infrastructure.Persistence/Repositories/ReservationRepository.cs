using System.Data.Entity;
using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Models.HotelModels;
using hotels.Infrastructure.Persistence.Context;
using Hotels.Infrastructure.Persistence.Utils;
using Hotels.Infrastructure.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Persistence.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ReservationModel> FindReservationById(uint reservationId)
    {
        var reservationEntity = await _context.Reservations.FirstOrDefaultAsync(u => u.reservation_id == reservationId);
  
        if (reservationEntity != null)
        {
            return Entity2ModelMapper.Reservation(reservationEntity);
        }

        throw new NotFound($"Reservation with id {reservationId} not found");
    }
    
    public async Task<List<uint>?> FindReservationsIdBySuiteId(uint suiteId)
    {
        var reservations = await _context.Reservations
            .Where(h => h.suit_id == suiteId)
            .Select(h => h.reservation_id)
            .ToListAsync();

        return reservations.Any() ? reservations : null;
    }
    
    public async Task<List<uint>?> FindReservationsIdByUserId(uint userId)
    {
        var userIds = await _context.Reservations
            .Where(h => h.user_id == userId)
            .Select(h => h.reservation_id).ToListAsync();
        
        return userIds.Any() ? userIds : null;
    }
    
    public async Task<List<uint>?> FindReservationsIdByHotelId(uint hotelId)
    {
        var hotelIds = await _context.Reservations
            .Where(h => h.hotel_id == hotelId)
            .Select(h => h.reservation_id).ToListAsync();
        
        return hotelIds.Any() ? hotelIds : null;
    }

    public async Task<uint> AddReservation(ReservationModel reservationModel)
    {
        var newReservationEntity = Model2EntityMapper.Reservation(reservationModel);
        await _context.Reservations.AddAsync(newReservationEntity);
        
        try
        {
            await _context.SaveChangesAsync();
            return newReservationEntity.reservation_id;
        }
        catch (Exception exception)
        {
            throw new Exception("Reservation was not added. " + exception.Message);
        }
    }

    public async Task UpdateReservation(ReservationModel reservationModel)
    {
        var reservationEntityUpdated = Model2EntityMapper.Reservation(reservationModel);
        var existingReservationEntity = await _context.Reservations.SingleOrDefaultAsync(u => u.reservation_id == reservationModel.ReservationId);
        
        if (existingReservationEntity != null)
        {
            _context.Entry(existingReservationEntity).CurrentValues.SetValues(reservationEntityUpdated);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Reservation was not updated. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"Reservation with id {reservationModel.ReservationId} not found");
        }
    }

    public async Task DeleteReservation(uint reservationId)
    {
        var reservationEntityToDelete = await _context.Reservations.SingleOrDefaultAsync(u => u.reservation_id == reservationId);
        
        if (reservationEntityToDelete != null)
        {
            _context.Reservations.Remove(reservationEntityToDelete);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Reservation was not deleted. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"Reservation with id {reservationId} not found");
        }
    }

    public async Task<Tuple<string, List<ReservationModel>>> FindAllReservationsBySuiteId(uint suiteId)
    {
        try
        {
            var reservations = await _context.Reservations.ToListAsync();
            var reservationModels = reservations.Select(Entity2ModelMapper.Reservation).ToList();
            var matchingReservations = reservationModels.Where(r => r.SuiteId == suiteId).ToList();
            return new Tuple<string, List<ReservationModel>>("success", matchingReservations);
        }
        catch (Exception ex)
        {
            return new Tuple<string, List<ReservationModel>>("fail" + ex.Message, new List<ReservationModel>());
        }
    }
}
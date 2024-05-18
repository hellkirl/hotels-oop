using System.Data.Entity;
using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Models.HotelModels;
using hotels.Infrastructure.Persistence.Context;
using Hotels.Infrastructure.Persistence.Exceptions;
using Hotels.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Persistence.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly ApplicationDbContext _context;
    
    public HotelRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HotelModel> FindHotelById(uint hotelId)
    {
        var hotelEntity = await _context.Hotels.FirstOrDefaultAsync(h => h.hotel_id == hotelId);
        
        if (hotelEntity != null)
        {
            return Entity2ModelMapper.Hotel(hotelEntity);
        }

        throw new NotFound($"Hotel with id {hotelId} not found");
    }
    
    public async Task<List<uint>> FindHotelsIdByHotelChainId(uint hotelChainId)
    {
        var hotelIds = await _context.Hotels
            .Where(h => h.hotel_chain_id == hotelChainId)
            .Select(h => h.hotel_id)
            .ToListAsync();

        if (hotelIds.Any())
        {
            return hotelIds;
        }
        
        throw new NotFound($"No hotels with chain id {hotelChainId} found");
    }
    
    public async Task DeleteHotel(uint hotelId)
    {
        var hotelEntityToDelete = await _context.Hotels.SingleOrDefaultAsync(h => h.hotel_id == hotelId);
        
        if (hotelEntityToDelete != null)
        {
            _context.Hotels.Remove(hotelEntityToDelete);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Hotel was not deleted. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"Hotel with id {hotelId} not found");
        }
    }
    
    public async Task<uint> AddHotel(HotelModel hotelModel)
    {
        var hotelEntity = Model2EntityMapper.Hotel(hotelModel);
        await _context.Hotels.AddAsync(hotelEntity);
        
        try
        {
            await _context.SaveChangesAsync();
            return hotelEntity.hotel_id;
        }
        catch (Exception exception)
        {
            throw new Exception("Hotel was not added. " + exception.Message);
        }
    }
    
    public async Task UpdateHotel(HotelModel hotelModel)
    {
        var hotelEntityUpdated = Model2EntityMapper.Hotel(hotelModel);
        var existingHotelEntity = await _context.Hotels.SingleOrDefaultAsync(h => h.hotel_id == hotelEntityUpdated.hotel_id);
        
        if (existingHotelEntity != null)
        {
            _context.Entry(existingHotelEntity).CurrentValues.SetValues(hotelEntityUpdated);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Hotel was not updated. " + exception.Message);
            }
        }
        else
        {
            throw new Exception($"Hotel with id {hotelModel.HotelId} not found.");
        }
    }

    public async Task<List<HotelModel>> FindHotelInRange(HotelModel hotelModel)
    // match by stars and catering
    {
        try
        {
            var hotels = await _context.Hotels.ToListAsync();
            var hotelModels = hotels.Select(Entity2ModelMapper.Hotel).ToList(); //breaks here
            
            var matchingHotels = hotelModels.Where(h =>
                h.Stars == hotelModel.Stars &&
                (hotelModel.Catering == null || (h.Catering != null && hotelModel.Catering.All(cateringOption => h.Catering.Contains(cateringOption))))).ToList();
            return matchingHotels;
        }
        catch (Exception)
        {
            throw new NotFound("No hotels with such criteria were found");
        }
    }
}

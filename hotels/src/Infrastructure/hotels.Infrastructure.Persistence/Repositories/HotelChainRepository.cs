using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Models.HotelModels;
using hotels.Infrastructure.Persistence.Context;
using hotels.Infrastructure.Persistence.Entities;
using Hotels.Infrastructure.Persistence.Exceptions;
using Hotels.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hotels.Infrastructure.Persistence.Repositories;

public class HotelChainRepository : IHotelChainRepository
{
    private readonly ApplicationDbContext _context;
    
    public HotelChainRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HotelChainModel> FindHotelChainById(uint hotelChainId)
    {
        var hotelChainEntity = await _context.HotelChains.FirstOrDefaultAsync(c => c.hotel_chain_id == hotelChainId);
        if (hotelChainEntity != null)
        {
            return Entity2ModelMapper.HotelChain(hotelChainEntity);
        }

        throw new NotFound($"Hotel chain with id {hotelChainId} not found.");
    }

    public async Task<uint> AddHotelChain(HotelChainModel hotelChainModel)
    {
        var hotelChainEntity = Model2EntityMapper.HotelChain(hotelChainModel);
        await _context.HotelChains.AddAsync(hotelChainEntity);
        
        try
        {
            await _context.SaveChangesAsync();
            return hotelChainEntity.hotel_chain_id;
        }
        catch (Exception exception)
        {
            throw new Exception("Hotel chain info was not added. " + exception.Message);
        }
    }

    public async Task UpdateHotelChain(HotelChainModel hotelChainModel)
    {
        var hotelChainEntityUpdated = Model2EntityMapper.HotelChain(hotelChainModel);
        var existingHotelChainEntity = await _context.HotelChains.SingleOrDefaultAsync(c => c.hotel_chain_id == hotelChainModel.HotelChainId);
        
        if (existingHotelChainEntity != null)
        {
            _context.Entry(existingHotelChainEntity).CurrentValues.SetValues(hotelChainEntityUpdated);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Hotel chain was not updated. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"Hotel chain with id {hotelChainModel.HotelChainId} not found");
        }
    }

    public async Task DeleteHotelChain(uint hotelChainId)
    {
        var hotelChainEntityToDelete = await _context.HotelChains.SingleOrDefaultAsync(c => c.hotel_chain_id == hotelChainId);
        
        if (hotelChainEntityToDelete != null)
        {
            _context.HotelChains.Remove(hotelChainEntityToDelete);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Hotel chain was not deleted. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"Hotel chain with id {hotelChainId} not found");
        }
    }
    
    public async Task<List<HotelChainModel>> GetAllHotelChains()
    {
        try
        {
            var hotelChains = await _context.HotelChains.ToListAsync();
            var hotelChainModels = hotelChains.Select(Entity2ModelMapper.HotelChain).ToList();
            return hotelChainModels;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }
}
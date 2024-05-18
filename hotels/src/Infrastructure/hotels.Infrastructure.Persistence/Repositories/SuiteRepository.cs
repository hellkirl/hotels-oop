using System.Data.Entity;
using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Models.HotelModels;
using Hotels.Infrastructure.Persistence.Exceptions;
using hotels.Infrastructure.Persistence.Context;
using Hotels.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Persistence.Repositories;

public class SuiteRepository : ISuiteRepository
{
    private readonly ApplicationDbContext _context;
    
    public SuiteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SuiteModel> FindSuiteById(uint suiteId)
    {
        var suiteEntity = await _context.HotelSuits.FirstOrDefaultAsync(s => s.suit_id == suiteId);
        
        if (suiteEntity != null)
        {
            return Entity2ModelMapper.Suite(suiteEntity);
        }

        throw new NotFound($"Suite with id {suiteId} not found");
    }
    
    public async Task<List<SuiteModel>?> FindSuitesByHotelId(uint hotelId)
    {
        var suiteEntities = await _context.HotelSuits.Where(s => s.hotel_id == hotelId).ToListAsync();
        return suiteEntities.Any() ? suiteEntities.Select(Entity2ModelMapper.Suite).ToList() : null;
    }

    public async Task<uint> AddSuite(SuiteModel suiteModel)
    {
        var newSuiteEntity = Model2EntityMapper.Suite(suiteModel);
        await _context.HotelSuits.AddAsync(newSuiteEntity);
        
        try
        {
            await _context.SaveChangesAsync();
            return newSuiteEntity.suit_id;
        }
        catch (Exception exception)
        {
            throw new Exception("Suite was not added. " + exception.Message);
        }
    }

    public async Task UpdateSuite(SuiteModel suiteModel)
    {
        var suiteEntityUpdated = Model2EntityMapper.Suite(suiteModel);
        var existingSuiteEntity = await _context.HotelSuits.SingleOrDefaultAsync(u => u.suit_id == suiteModel.SuiteId);
        
        if (existingSuiteEntity != null)
        {
            _context.Entry(existingSuiteEntity).CurrentValues.SetValues(suiteEntityUpdated);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Suite was not updated. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"Suite with id {suiteModel.SuiteId} not found");
        }
    }

    public async Task DeleteSuite(uint suiteId)
    {
        var suiteEntityToDelete = await _context.HotelSuits.SingleOrDefaultAsync(u => u.suit_id == suiteId);

        if (suiteEntityToDelete != null)
        {
            _context.HotelSuits.Remove(suiteEntityToDelete);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Suite was not deleted. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"Suite with id {suiteId} not found");
        }
    }
    
    public async Task<List<SuiteModel>> GetAllSuits()
    {
        try
        {
            var suits = await _context.HotelSuits.ToListAsync();
            var suiteModels = suits.Select(Entity2ModelMapper.Suite).ToList();
            return suiteModels;
        }
        catch (Exception exception)
        {
            throw new Exception("Cannot get all suits: " + exception.Message);
        }
    }
}
using System.Data.Entity;
using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Models.HotelModels;
using hotels.Infrastructure.Persistence.Context;
using Hotels.Infrastructure.Persistence.Utils;
using Hotels.Infrastructure.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Persistence.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _context;

    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LocationModel> FindLocationById(uint locationId)
    {
        var locationEntity = await _context.Locations.FirstOrDefaultAsync(u => u.location_id == locationId);
        
        if (locationEntity != null)
        {
            return Entity2ModelMapper.Location(locationEntity);
        }

        throw new NotFound($"Reservation with id {locationId} not found");
    }

    public async Task<uint> AddLocation(LocationModel locationModel)
    {
        var newLocationEntity = Model2EntityMapper.Location(locationModel);
        await _context.Locations.AddAsync(newLocationEntity);

        try
        {
            await _context.SaveChangesAsync();
            return newLocationEntity.location_id;
        }
        catch (Exception exception)
        {
            throw new Exception("Location was not added. " + exception.Message);
        }
    }

    public async Task UpdateLocation(LocationModel locationModel)
    {
        var locationEntityUpdated = Model2EntityMapper.Location(locationModel);
        var existingLocationEntity = await _context.Locations.SingleOrDefaultAsync(u => u.location_id == locationModel.LocationId);

        if (existingLocationEntity != null)
        {
            _context.Entry(existingLocationEntity).CurrentValues.SetValues(locationEntityUpdated);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Location was not updated. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"Location with id {locationModel.LocationId} not found");
        }
    }

    public async Task DeleteLocation(uint locationId)
    {
        var locationEntityToDelete = await _context.Locations.SingleOrDefaultAsync(u => u.location_id == locationId);

        if (locationEntityToDelete != null)
        {
            _context.Locations.Remove(locationEntityToDelete);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Location was not deleted. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"Location with id {locationId} not found");
        }
    }
}
using System.Data.Entity;
using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Exceptions.User;
using hotels.Application.Models.UserModels;
using hotels.Infrastructure.Persistence.Context;
using Hotels.Infrastructure.Persistence.Exceptions;
using Hotels.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<UserModel> FindUserById(uint userId)
    {
        var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.user_id == userId);
        if (userEntity != null)
        {
            return Entity2ModelMapper.User(userEntity);
        }

        throw new NotFound($"User with id {userId} not found.");
    }

    public async Task<uint> AddUser(UserModel userModel)
    {
        var userEntity = Model2EntityMapper.User(userModel);
        await _context.Users.AddAsync(userEntity);
        
        try
        {
            await _context.SaveChangesAsync();
            return userEntity.user_id;
        }
        catch (Exception exception)
        {
            throw new Exception("User info was not added. " + exception.Message);
        }
    }

    public async Task UpdateUser(UserModel userModel)
    {
        var userEntityUpdated = Model2EntityMapper.User(userModel);
        var existingUserEntity = await _context.Users.SingleOrDefaultAsync(u => u.user_id == userModel.UserId);
        
        if (existingUserEntity != null)
        {
            if (userEntityUpdated.password_hash != existingUserEntity.password_hash)
            {
                throw new WrongPassword("Wrong password.");
            }

            if (userEntityUpdated.login != existingUserEntity.login)
            {
                throw new WrongPassword("Wrong login.");
            }

            _context.Entry(existingUserEntity).CurrentValues.SetValues(userEntityUpdated);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("User was not updated. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"User with id {userModel.UserId} not found");
        }
    }

    public async Task DeleteUser(uint userId)
    {
        var userEntityToDelete = await _context.Users.SingleOrDefaultAsync(u => u.user_id == userId);
        
        if (userEntityToDelete != null)
        {
            _context.Users.Remove(userEntityToDelete);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("User was not deleted. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"User with id {userId} not found.");
        }
    }
}
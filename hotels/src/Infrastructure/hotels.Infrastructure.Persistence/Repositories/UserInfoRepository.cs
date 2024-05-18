using System.Data.Entity;
using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Models.UserModels;
using hotels.Infrastructure.Persistence.Context;
using Hotels.Infrastructure.Persistence.Exceptions;
using Hotels.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Persistence.Repositories;

public class UserInfoRepository : IUserInfoRepository
{
    private readonly ApplicationDbContext _context;

    public UserInfoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<UserInfoModel> FindUserById(uint userId)
    {
        var userInfoEntity = await _context.UserInfos.FirstOrDefaultAsync(u => u.user_id == userId);
        if (userInfoEntity != null)
        {
            return Entity2ModelMapper.UserInfo(userInfoEntity);
        }

        throw new NotFound($"User with id {userId} not found.");
    }

    public async Task<uint> AddUserInfo(UserInfoModel userInfoModel)
    {
        var newUserInfoEntity = Model2EntityMapper.UserInfo(userInfoModel);
        await _context.UserInfos.AddAsync(newUserInfoEntity);
        
        try
        {
            await _context.SaveChangesAsync();
            return newUserInfoEntity.user_id;
        }
        catch (Exception exception)
        {
            throw new Exception("User info was not added. " + exception.Message);
        }
    }

    public async Task UpdateUserInfo(UserInfoModel userInfoModel)
    {
        var userInfoEntityUpdated = Model2EntityMapper.UserInfo(userInfoModel);
        var existingUserInfoEntity = await _context.UserInfos.SingleOrDefaultAsync(u => u.user_id == userInfoModel.UserId);
        
        if (existingUserInfoEntity != null)
        {
            _context.Entry(existingUserInfoEntity).CurrentValues.SetValues(userInfoEntityUpdated);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("User info was not updated. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"User with id {userInfoModel.UserId} not found.");
        }
    }

    public async Task DeleteUserInfo(uint userId)
    {
        var userInfoEntityToDelete = await _context.UserInfos.SingleOrDefaultAsync(u => u.user_id == userId);
        if (userInfoEntityToDelete != null)
        {
            _context.UserInfos.Remove(userInfoEntityToDelete);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("User info was not deleted. " + exception.Message);
            }
        }
        else
        {
            throw new NotFound($"User with id {userId} not found");
        }
    }
}
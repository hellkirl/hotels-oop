using hotels.Application.Models.UserModels;

namespace Hotels.Application.Abstractions.Persistence.Repositories;

public interface IUserInfoRepository
{
    Task<UserInfoModel> FindUserById(uint userId);
    Task<uint> AddUserInfo(UserInfoModel userInfoModel);
    Task UpdateUserInfo(UserInfoModel userInfoModel);
    Task DeleteUserInfo(uint userId);
}
using hotels.Application.Models.UserModels;

namespace Hotels.Application.Abstractions.Persistence.Repositories;

public interface IUserRepository
{
    Task<UserModel> FindUserById(uint userId);
    Task<uint> AddUser(UserModel userModel);
    Task UpdateUser(UserModel userModel);
    Task DeleteUser(uint userId);
}
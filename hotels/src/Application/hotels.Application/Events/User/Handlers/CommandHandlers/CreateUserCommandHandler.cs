using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.User.Commands;
using hotels.Application.Models.UserModels;
using MediatR;

namespace hotels.Application.Events.User.Handlers.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, uint>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserInfoRepository _userInfoRepository;

    public CreateUserCommandHandler(IUserRepository userRepository, IUserInfoRepository userInfoRepository)
    {
        _userRepository = userRepository;
        _userInfoRepository = userInfoRepository;
    }

    public async Task<uint> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userModel = new UserModel
        {
            Login = request.Login, 
            PasswordHash = request.Password
        };
        uint userId = await _userRepository.AddUser(userModel);

        var userInfoModel = new UserInfoModel
        {
            Birthday = request.Birthday,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Passport = request.Passport,
            Phone = request.Phone,
            UserId = userId
        };
        await _userInfoRepository.AddUserInfo(userInfoModel);

        return userId;
    }
}
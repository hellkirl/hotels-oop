using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.User.Commands;
using hotels.Application.Models.UserModels;
using MediatR;

namespace hotels.Application.Events.User.Handlers.CommandHandlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserInfoRepository _userInfoRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUserInfoRepository userInfoRepository)
    {
        _userRepository = userRepository;
        _userInfoRepository = userInfoRepository;
    }
    
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userModel = new UserModel
        {
            UserId = request.UserId,
            Login = request.Login,
            PasswordHash = request.Password
        };
        await _userRepository.UpdateUser(userModel);
        var userInfo = await _userInfoRepository.FindUserById(request.UserId);

        userInfo.FirstName = request.FirstName;
        userInfo.LastName = request.LastName;
        userInfo.Phone = request.Phone;
        userInfo.Email = request.Email;
        userInfo.Birthday = request.Birthday;
        userInfo.Passport = request.Passport;
        
        await _userInfoRepository.UpdateUserInfo(userInfo);
    }
}
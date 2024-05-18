using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.User.Queries;
using hotels.Application.Models.UserModels;
using MediatR;

namespace hotels.Application.Events.User.Handlers.QueryHandlers;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserInfoModel>
{
    private readonly IUserInfoRepository _userInfoRepository;

    public GetUserInfoQueryHandler(IUserInfoRepository userInfoRepository)
    {
        _userInfoRepository = userInfoRepository;
    }
    
    public async Task<UserInfoModel> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var userInfo = await _userInfoRepository.FindUserById(request.UserId);
        return userInfo;
    }
}
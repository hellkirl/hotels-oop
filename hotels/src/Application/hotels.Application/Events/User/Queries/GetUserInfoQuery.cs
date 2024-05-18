using hotels.Application.Models.UserModels;
using MediatR;

namespace hotels.Application.Events.User.Queries;

public class GetUserInfoQuery : IRequest<UserInfoModel>
{
    public uint UserId { get; set; }

    public GetUserInfoQuery(uint userId)
    {
        UserId = userId;
    }
}
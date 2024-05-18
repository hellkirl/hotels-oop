using MediatR;

namespace hotels.Application.Events.User.Commands;

public class DeleteUserCommand : IRequest
{
    public DeleteUserCommand(uint userId)
    {
        UserId = userId;
    }

    public uint UserId { get; set; }
}
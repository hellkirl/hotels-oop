using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.User.Commands;
using MediatR;

namespace hotels.Application.Events.User.Handlers.CommandHandlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IReservationRepository _reservationRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository, IUserInfoRepository userInfoRepository, IReservationRepository reservationRepository)
    {
        _userRepository = userRepository;
        _userInfoRepository = userInfoRepository;
        _reservationRepository = reservationRepository;
    }
    
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var targetReservationsId = await _reservationRepository.FindReservationsIdByUserId(request.UserId);
        
        if (targetReservationsId != null && targetReservationsId.Any())
        {
            foreach (var reservationId in targetReservationsId)
            {
                await _reservationRepository.DeleteReservation(reservationId);
            }
        }
        
        await _userInfoRepository.DeleteUserInfo(request.UserId);
        await _userRepository.DeleteUser(request.UserId);
    }
}
using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Suite.Commands;
using MediatR;

namespace hotels.Application.Events.Suite.Handlers.CommandHandlers;

public class UpdateSuiteCommandHandler : IRequestHandler<UpdateSuiteCommand>
{
    private readonly ISuiteRepository _suiteRepository;

    public UpdateSuiteCommandHandler(ISuiteRepository suiteRepository)
    {
        _suiteRepository = suiteRepository;
    }

    public async Task Handle(UpdateSuiteCommand request, CancellationToken cancellationToken)
    {
        var suiteModel = await _suiteRepository.FindSuiteById(request.SuiteId);

        suiteModel.Name = request.Name;
        suiteModel.BasePrice = request.BasePrice;
        suiteModel.NSuits = request.NSuits;
        suiteModel.Description = request.Description;
        suiteModel.MaxOccupancy = request.MaxOccupancy;
        
        await _suiteRepository.UpdateSuite(suiteModel);
    }
}
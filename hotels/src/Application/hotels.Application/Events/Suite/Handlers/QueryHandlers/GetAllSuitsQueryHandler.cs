using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Suite.Queries;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Suite.Handlers.QueryHandlers;

public class GetAllSuitsQueryHandler : IRequestHandler<GetAllSuitsQuery, List<SuiteModel>>
{
    private readonly ISuiteRepository _suiteRepository;

    public GetAllSuitsQueryHandler(ISuiteRepository suiteRepository)
    {
        _suiteRepository = suiteRepository;
    }
    
    public async Task<List<SuiteModel>> Handle(GetAllSuitsQuery request, CancellationToken cancellationToken)
    {
        return await _suiteRepository.GetAllSuits();
    }
}
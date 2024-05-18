using Hotels.Application.Abstractions.Persistence.Repositories;
using hotels.Application.Events.Suite.Queries;
using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Suite.Handlers.QueryHandlers;

public class GetSuiteQueryHandler : IRequestHandler<GetSuiteQuery, SuiteModel>
{
    private readonly ISuiteRepository _suiteRepository;

    public GetSuiteQueryHandler(ISuiteRepository suiteRepository)
    {
        _suiteRepository = suiteRepository;
    }
    
    public async Task<SuiteModel> Handle(GetSuiteQuery request, CancellationToken cancellationToken)
    {
        var suiteModel = await _suiteRepository.FindSuiteById(request.SuiteId);
        return suiteModel;
    }
}
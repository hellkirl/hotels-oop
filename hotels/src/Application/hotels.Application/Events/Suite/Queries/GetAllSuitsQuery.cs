using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Suite.Queries;

public class GetAllSuitsQuery : IRequest<List<SuiteModel>>
{
    public GetAllSuitsQuery()
    {
    }
}
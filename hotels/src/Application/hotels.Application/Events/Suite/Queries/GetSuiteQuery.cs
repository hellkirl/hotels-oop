using hotels.Application.Models.HotelModels;
using MediatR;

namespace hotels.Application.Events.Suite.Queries;

public class GetSuiteQuery : IRequest<SuiteModel>
{
    public uint SuiteId { get; set; }

    public GetSuiteQuery(uint suiteId)
    {
        SuiteId = suiteId;
    }
}
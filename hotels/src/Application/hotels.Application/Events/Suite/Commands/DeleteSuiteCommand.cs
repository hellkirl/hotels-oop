using MediatR;

namespace hotels.Application.Events.Suite.Commands;

public class DeleteSuiteCommand : IRequest
{
    public uint SuiteId { get; set; }

    public DeleteSuiteCommand(uint suiteId)
    {
        SuiteId = suiteId;
    }
}
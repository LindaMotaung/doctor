using MediatR;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Queries.GetEventAllocations
{
    public class GetEventAllocationListQuery : IRequest<List<EventAllocationDto>>
    {
    }
}

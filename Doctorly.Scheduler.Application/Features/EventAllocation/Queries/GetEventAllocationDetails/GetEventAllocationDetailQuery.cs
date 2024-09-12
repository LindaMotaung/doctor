using MediatR;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Queries.GetEventAllocationDetails
{
    public class GetEventAllocationDetailQuery : IRequest<EventAllocationDetailsDto>
    {
        public int Id { get; set; }
    }
}

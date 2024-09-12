using MediatR;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Commands.CreateEventAllocation
{
    public class CreateEventAllocationCommand : IRequest<Unit>
    {
        public int EventTypeId { get; set; }
    }
}

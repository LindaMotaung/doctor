using MediatR;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Commands.DeleteEventAllocation
{
    public class DeleteEventAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}

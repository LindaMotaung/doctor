using MediatR;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Commands.UpdateEventAllocation
{
    public class UpdateEventAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public int EventTypeId { get; set; }
        public int Period { get; set; }
    }
}

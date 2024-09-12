using FluentValidation;
using Doctorly.Scheduler.Application.Contracts.Persistence;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Commands.CreateEventAllocation
{
    public class CreateEventAllocationCommandValidator : AbstractValidator<CreateEventAllocationCommand>
    {
        private readonly IEventTypeRepository _eventTypeRepository;

        public CreateEventAllocationCommandValidator(IEventTypeRepository eventTypeRepository)
        {
            _eventTypeRepository = eventTypeRepository;

            RuleFor(p => p.EventTypeId)
                .GreaterThan(0)
                .MustAsync(LeaveTypeMustExist)
                .WithMessage("{PropertyName} does not exist.");
        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
        {
            var eventType = await _eventTypeRepository.GetByIdAsync(id);
            return eventType != null;
        }
    }
}


using FluentValidation;
using Doctorly.Scheduler.Application.Contracts.Persistence;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Commands.UpdateEventAllocation
{
    public class UpdateEventAllocationCommandValidator : AbstractValidator<UpdateEventAllocationCommand>
    {
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IEventAllocationRepository _eventAllocationRepository;

        public UpdateEventAllocationCommandValidator(IEventTypeRepository eventTypeRepository, IEventAllocationRepository eventAllocationRepository)
        {
            _eventTypeRepository = eventTypeRepository;
            this._eventAllocationRepository = eventAllocationRepository;
            RuleFor(p => p.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} must greater than {ComparisonValue}");

            RuleFor(p => p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.EventTypeId)
                .GreaterThan(0)
                .MustAsync(EventTypeMustExist)
                .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(EventAllocationMustExist)
                .WithMessage("{PropertyName} must be present");
        }

        private async Task<bool> EventAllocationMustExist(int id, CancellationToken arg2)
        {
            var eventAllocation = await _eventAllocationRepository.GetByIdAsync(id);
            return eventAllocation != null;
        }

        private async Task<bool> EventTypeMustExist(int id, CancellationToken arg2)
        {
            var eventType = await _eventTypeRepository.GetByIdAsync(id);
            return eventType != null;
        }
    }
}

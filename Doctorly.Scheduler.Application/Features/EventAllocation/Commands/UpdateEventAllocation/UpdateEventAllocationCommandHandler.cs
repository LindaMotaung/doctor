using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctorly.Scheduler.Application.Contracts.Persistence;
using Doctorly.Scheduler.Application.Exceptions;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Commands.UpdateEventAllocation
{
    public class UpdateEventAllocationCommandHandler : IRequestHandler<UpdateEventAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IEventAllocationRepository _eventAllocationRepository;

        public UpdateEventAllocationCommandHandler(IMapper mapper,
            IEventTypeRepository eventTypeRepository,
            IEventAllocationRepository eventAllocationRepository)
        {
            _mapper = mapper;
            this._eventTypeRepository = eventTypeRepository;
            this._eventAllocationRepository = eventAllocationRepository;
        }

        public async Task<Unit> Handle(UpdateEventAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEventAllocationCommandValidator(_eventTypeRepository, _eventAllocationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Event Allocation", validationResult);

            var eventAllocation = await _eventAllocationRepository.GetByIdAsync(request.Id);

            if (eventAllocation is null)
                throw new NotFoundException(nameof(EventAllocation), request.Id);

            _mapper.Map(request, eventAllocation);

            await _eventAllocationRepository.UpdateAsync(eventAllocation);
            return Unit.Value;
        }
    }
}

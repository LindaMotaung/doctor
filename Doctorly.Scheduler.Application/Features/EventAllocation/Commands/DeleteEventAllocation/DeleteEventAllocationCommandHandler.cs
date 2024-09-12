using AutoMapper;
using Doctorly.Scheduler.Application.Contracts.Persistence;
using Doctorly.Scheduler.Application.Exceptions;
using MediatR;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Commands.DeleteEventAllocation
{
    public class DeleteEventAllocationCommandHandler : IRequestHandler<DeleteEventAllocationCommand>
    {
        private readonly IEventAllocationRepository _eventAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteEventAllocationCommandHandler(IEventAllocationRepository eventAllocationRepository, IMapper mapper)
        {
            this._eventAllocationRepository = eventAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEventAllocationCommand request, CancellationToken cancellationToken)
        {
            var eventAllocation = await _eventAllocationRepository.GetByIdAsync(request.Id);

            if (eventAllocation == null)
                throw new NotFoundException(nameof(EventAllocation), request.Id);

            await _eventAllocationRepository.DeleteAsync(eventAllocation);
            return Unit.Value;
        }
    }
}

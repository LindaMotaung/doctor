using AutoMapper;
using MediatR;
using Doctorly.Scheduler.Application.Contracts.Persistence;
using Doctorly.Scheduler.Application.Exceptions;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Queries.GetEventAllocationDetails
{
    public class GetEventAllocationDetailRequestHandler : IRequestHandler<GetEventAllocationDetailQuery, EventAllocationDetailsDto>
    {
        private readonly IEventAllocationRepository _eventAllocationRepository;
        private readonly IMapper _mapper;

        public GetEventAllocationDetailRequestHandler(IEventAllocationRepository eventAllocationRepository, IMapper mapper)
        {
            _eventAllocationRepository = eventAllocationRepository;
            _mapper = mapper;
        }

        public async Task<EventAllocationDetailsDto> Handle(GetEventAllocationDetailQuery request, CancellationToken cancellationToken)
        {
            var eventAllocation = await _eventAllocationRepository.GetEventAllocationWithDetails(request.Id);
            if (eventAllocation == null)
                throw new NotFoundException(nameof(EventAllocation), request.Id);

            return _mapper.Map<EventAllocationDetailsDto>(eventAllocation);
        }
    }
}

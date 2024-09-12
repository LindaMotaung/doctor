using AutoMapper;
using MediatR;
using Doctorly.Scheduler.Application.Contracts.Persistence;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Queries.GetEventAllocations
{
    public class GetEventAllocationListHandler : IRequestHandler<GetEventAllocationListQuery, List<EventAllocationDto>>
    {
        private readonly IEventAllocationRepository _eventAllocationRepository;
        private readonly IMapper _mapper;

        public GetEventAllocationListHandler(IEventAllocationRepository eventAllocationRepository,
            IMapper mapper)
        {
            _eventAllocationRepository = eventAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<EventAllocationDto>> Handle(GetEventAllocationListQuery request, CancellationToken cancellationToken)
        {
            // To Add later
            // - Get records for specific user
            // - Get allocations per attendee

            var eventAllocations = await _eventAllocationRepository.GetEventAllocationsWithDetails();
            var allocations = _mapper.Map<List<EventAllocationDto>>(eventAllocations);

            return allocations;
        }
    }
}

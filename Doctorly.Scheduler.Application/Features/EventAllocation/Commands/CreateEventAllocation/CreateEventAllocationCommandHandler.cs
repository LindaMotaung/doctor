using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctorly.Scheduler.Application.Contracts.Identity;
using Doctorly.Scheduler.Application.Contracts.Persistence;
using Doctorly.Scheduler.Application.Exceptions;
using MediatR;
using Doctorly.Scheduler.Domain.Common;

namespace Doctorly.Scheduler.Application.Features.EventAllocation.Commands.CreateEventAllocation
{
    public class CreateEventAllocationCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventAllocationRepository _eventAllocationRepository;
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IUserService _userService;

        public CreateEventAllocationCommandHandler(IMapper mapper,
            IEventAllocationRepository eventAllocationRepository, IEventTypeRepository eventTypeRepository,
            IUserService userService) 
        {
            _mapper = mapper;
            this._eventAllocationRepository = eventAllocationRepository;
            this._eventTypeRepository = eventTypeRepository;
            this._userService = userService;
        }

        public async Task<Unit> Handle(CreateEventAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventAllocationCommandValidator(_eventTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Event Allocation Request", validationResult);

            // Get Event type for allocations
            var eventType = await _eventTypeRepository.GetByIdAsync(request.EventTypeId);

            // Get Attendees
            var attendees = await _userService.GetAttendees();

            //Get Period
            var period = DateTime.Now.Year;

            //Assign Allocations IF an allocation doesn't already exist for period and event type
            var allocations = new List<Domain.Events.EventAllocation>();
            foreach (var att in attendees)
            {
                var allocationExists = await _eventAllocationRepository.AllocationExists(Convert.ToString(att.Id), request.EventTypeId, period);

                if (allocationExists == false)
                {
                    allocations.Add(new Domain.Events.EventAllocation
                    {
                        AttendeeId = Convert.ToString(att.Id),
                        LeaveTypeId = eventType.Id,
                        NumberOfDays = eventType.DefaultDays,
                        Period = period,
                    });
                }
            }

            if (allocations.Any())
            {
                await _eventAllocationRepository.AddAllocations(allocations);
            }

            return Unit.Value;
        }
    }
}

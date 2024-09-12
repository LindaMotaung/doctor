using Doctorly.Scheduler.Application.Features.EventAllocation.Commands.CreateEventAllocation;
using Doctorly.Scheduler.Application.Features.EventAllocation.Commands.DeleteEventAllocation;
using Doctorly.Scheduler.Application.Features.EventAllocation.Commands.UpdateEventAllocation;
using Doctorly.Scheduler.Application.Features.EventAllocation.Queries.GetEventAllocationDetails;
using Doctorly.Scheduler.Application.Features.EventAllocation.Queries.GetEventAllocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Doctorly.Scheduler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventAllocationDto>>> Get(bool isLoggedInUser = false)
        {
            var eventAllocations = await _mediator.Send(new GetEventAllocationListQuery());
            return Ok(eventAllocations);
        }

        // GET api/<EventAllocationsController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<EventAllocationDetailsDto>> Get(int id)
        {
            var eventAllocation = await _mediator.Send(new GetEventAllocationDetailQuery { Id = id });
            return Ok(eventAllocation);
        }

        // POST api/<EventAllocationsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateEventAllocationCommand eventAllocation)
        {
            var response = await _mediator.Send(eventAllocation);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<EventAllocationsController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateEventAllocationCommand eventAllocation)
        {
            await _mediator.Send(eventAllocation);
            return NoContent();
        }

        // DELETE api/<EventAllocationsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteEventAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

using Doctorly.Scheduler.Application.Contracts.Persistence;
using Doctorly.Scheduler.Domain.Events;
using Doctorly.Scheduler.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Doctorly.Scheduler.Persistence.Repositories
{
    public class EventRequestRepository : GenericRepository<EventRequest>, IEventRequestRepository
    {
        public EventRequestRepository(DoctorlyDatabaseContext context) : base(context)
        {
        }

        public async Task<List<EventRequest>> GetEventRequestsWithDetails()
        {
            var eventRequests = await _context.EventRequests
                .Where(q => !string.IsNullOrEmpty(q.RequestingAttendeeId))
                .Include(q => q.EventType)
                .ToListAsync();
            return eventRequests;
        }

        public async Task<List<EventRequest>> GetEventRequestsWithDetails(string userId)
        {
            var EventRequests = await _context.EventRequests
                .Where(q => q.RequestingAttendeeId == userId)
                .Include(q => q.EventType)
                .ToListAsync();
            return EventRequests;
        }

        public async Task<EventRequest> GetEventRequestWithDetails(int id)
        {
            var EventRequest = await _context.EventRequests
                .Include(q => q.EventType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return EventRequest;
        }
    }
}

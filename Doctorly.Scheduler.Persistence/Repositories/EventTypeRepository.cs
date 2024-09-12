using Doctorly.Scheduler.Application.Contracts.Persistence;
using Doctorly.Scheduler.Domain.Events;
using Doctorly.Scheduler.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Doctorly.Scheduler.Persistence.Repositories
{
    public class EventTypeRepository : GenericRepository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(DoctorlyDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsEventTypeUnique(string name)
        {
            return await _context.EventTypes.AnyAsync(q => q.Name == name) == false;
        }
    }
}

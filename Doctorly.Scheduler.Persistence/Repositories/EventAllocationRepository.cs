using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctorly.Scheduler.Application.Contracts.Persistence;
using Doctorly.Scheduler.Domain.Events;
using Doctorly.Scheduler.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Doctorly.Scheduler.Persistence.Repositories
{
    public class EventAllocationRepository : GenericRepository<EventAllocation>, IEventAllocationRepository
    {
        public EventAllocationRepository(DoctorlyDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<EventAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int eventTypeId, int period)
        {
            return await _context.EventAllocations.AnyAsync(q => q.AttendeeId == userId
                                                                 && q.eventTypeId == eventTypeId
                                                                 && q.Period == period);
        }

        public async Task<List<EventAllocation>> GetEventAllocationsWithDetails()
        {
            var EventAllocations = await _context.EventAllocations
                .Include(q => q.EventType)
                .ToListAsync();
            return EventAllocations;
        }

        public async Task<List<EventAllocation>> GetEventAllocationsWithDetails(string userId)
        {
            var EventAllocations = await _context.EventAllocations.Where(q => q.AttendeeId == userId)
                .Include(q => q.EventType)
                .ToListAsync();
            return EventAllocations;
        }

        public async Task<EventAllocation> GetEventAllocationWithDetails(int id)
        {
            var EventAllocation = await _context.EventAllocations
                .Include(q => q.EventType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return EventAllocation;
        }

        public async Task<EventAllocation> GetUserAllocations(string userId, int eventTypeId)
        {
            return await _context.EventAllocations.FirstOrDefaultAsync(q => q.AttendeeId == userId
                                                                            && q.eventTypeId == eventTypeId);
        }
    }
}

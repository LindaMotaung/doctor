
using Doctorly.Scheduler.Domain.Events;

namespace Doctorly.Scheduler.Application.Contracts.Persistence
{
    public interface IEventAllocationRepository : IGenericRepository<EventAllocation>
    {
        Task<EventAllocation> GetEventAllocationWithDetails(int id);
        Task<List<EventAllocation>> GetEventAllocationsWithDetails();
        Task<List<EventAllocation>> GetEventAllocationsWithDetails(string userId);
        Task<bool> AllocationExists(string userId, int eventTypeId, int period);
        Task AddAllocations(List<EventAllocation> allocations);
        Task<EventAllocation> GetUserAllocations(string userId, int eventTypeId);
    }
}

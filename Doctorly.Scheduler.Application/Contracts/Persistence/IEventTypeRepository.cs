using Doctorly.Scheduler.Domain.Events;

namespace Doctorly.Scheduler.Application.Contracts.Persistence
{
    /// <summary>
    /// This will specify the types of events. E.g
    /// 1. Generic consultation with the doctor
    /// 2. Hospitalization
    /// </summary>
    public interface IEventTypeRepository : IGenericRepository<EventType>
    {
        Task<bool> IsEventTypeUnique(string name);
    }
}

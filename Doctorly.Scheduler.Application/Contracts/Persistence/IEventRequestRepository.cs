using Doctorly.Scheduler.Domain.Events;

namespace Doctorly.Scheduler.Application.Contracts.Persistence
{
    public interface IEventRequestRepository : IGenericRepository<EventRequest>
    {
        Task<EventRequest> GetEventRequestWithDetails(int id);
        Task<List<EventRequest>> GetEventRequestsWithDetails();
        /// <summary>
        /// User ID could be the doctor's ID or the Attendees' ID. Attendee being the sick patient
        /// The system should be designed to show Events for the Attendee.
        /// The system should be designed to show Events for a doctor that shows a list of attendees along with their event i.e are they in for a general check-up or hospitalization
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<EventRequest>> GetEventRequestsWithDetails(string userId); 
    }
}

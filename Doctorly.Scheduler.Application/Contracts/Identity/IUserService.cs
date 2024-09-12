using Doctorly.Scheduler.Domain;

namespace Doctorly.Scheduler.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Attendee>> GetAttendees();
        Task<Attendee> GetAttendee(string userId);
        public string UserId { get; }
    }
}

using Doctorly.Scheduler.Domain.Common;

namespace Doctorly.Scheduler.Domain
{
    public class Attendee : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsAttending { get; set; } = false;
    }
}

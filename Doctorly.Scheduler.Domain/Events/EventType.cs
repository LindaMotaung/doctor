using Doctorly.Scheduler.Domain.Common;

namespace Doctorly.Scheduler.Domain.Events
{
    public class EventType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}

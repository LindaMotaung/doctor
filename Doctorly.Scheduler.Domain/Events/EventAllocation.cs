
using Doctorly.Scheduler.Domain.Common;

namespace Doctorly.Scheduler.Domain.Events
{
    public class EventAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; } //How long is the doctor's visit? 
        public int LeaveTypeId { get; set; }
        public EventType? EventType { get; set; }
        public int eventTypeId { get; set; }
        public int Period { get; set; } //When is the doctor's visit? 
        public string AttendeeId { get; set; } = string.Empty;
    }
}

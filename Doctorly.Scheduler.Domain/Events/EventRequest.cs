using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctorly.Scheduler.Domain.Common;

namespace Doctorly.Scheduler.Domain.Events
{
    public class EventRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EventType? EventType { get; set; }
        public int EventTypeId { get; set; }

        public DateTime DateRequested { get; set; }
        public string? RequestComments { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

        public string RequestingAttendeeId { get; set; } = string.Empty;
    }
}

using Doctorly.Scheduler.Domain.Common;

namespace Doctorly.Scheduler.Domain
{
    public class Event : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Attendee Attendees { get; set; } = new Attendee(); //Composition: An event is made up of attendees
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}

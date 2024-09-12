namespace Doctorly.Scheduler.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } //This will be used as a unique key to identify an attendee or an event
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}

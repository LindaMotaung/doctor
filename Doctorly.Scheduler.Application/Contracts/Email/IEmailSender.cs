using Doctorly.Scheduler.Application.Models.Email;

namespace Doctorly.Scheduler.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email); //We want to send an email to the doctor once an attendee belongs to an event
    }
}

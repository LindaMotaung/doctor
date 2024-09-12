namespace Doctorly.Scheduler.Application.Models.Identity
{
    /// <summary>
    /// We want to be able to implement auth to validate the identity of the person trying to log into the system (provided the API will be consumed by a front-end in future) as well as assign them their appropriate rights and privileges 
    /// </summary>
    public class AuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

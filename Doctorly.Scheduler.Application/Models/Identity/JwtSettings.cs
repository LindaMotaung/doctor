namespace Doctorly.Scheduler.Application.Models.Identity
{
    /// <summary>
    /// Making the application secure in regards to validating claims identity 
    /// </summary>
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public double DurationInMinutes { get; set; }
    }
}

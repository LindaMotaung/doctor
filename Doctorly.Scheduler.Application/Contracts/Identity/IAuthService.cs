using Doctorly.Scheduler.Application.Models.Identity;

namespace Doctorly.Scheduler.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}

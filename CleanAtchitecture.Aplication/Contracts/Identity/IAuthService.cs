using Litethinking.NetInventory.Backend.Application.Models.Identity;

namespace Litethinking.NetInventory.Backend.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}

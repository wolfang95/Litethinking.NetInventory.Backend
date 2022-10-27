using Litethinking.NetInventory.Backend.Application.Models;

namespace Litethinking.NetInventory.Backend.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}

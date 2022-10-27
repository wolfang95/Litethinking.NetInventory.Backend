using Microsoft.AspNetCore.Identity;

namespace Litethinking.NetInventory.Backend.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;
    }
}

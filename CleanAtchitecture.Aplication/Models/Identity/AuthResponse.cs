

namespace Litethinking.NetInventory.Backend.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;

        public Boolean Admin { get; set; } = false;
    }
}

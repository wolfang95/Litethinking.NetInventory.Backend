using Litethinking.NetInventory.Backend.API.Extensions;
using Litethinking.NetInventory.Backend.Application.Contracts.Identity;
using Litethinking.NetInventory.Backend.Application.Models.Identity;
using Litethinking.NetInventory.Backend.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Litethinking.NetInventory.Backend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;


        public AccountController(IAuthService authService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;

        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AuthResponse>> GetUsuario()
        {
            
            var usuario = await _userManager.BuscarUsuarioAsync(HttpContext.User);

            var roles = await _userManager.GetRolesAsync(usuario);

            return new AuthResponse
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = "Corredor Review",
                Email = usuario.Email,
                Username = usuario.UserName,
                Imagen = "asd",
                Token = "token",
                Admin = roles.Contains("ADMIN") ? true : false
            };
        }

    }
}




using Litethinking.NetInventory.Backend.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> BuscarUsuarioConDireccionAsync(this UserManager<ApplicationUser> input, ClaimsPrincipal usr)
        {
            var email = usr?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var usuario = await input.Users.Include(x => x.UserName).SingleOrDefaultAsync(x => x.Email == email);

            return usuario;
        }

        public static async Task<ApplicationUser> BuscarUsuarioAsync(this UserManager<ApplicationUser> input, ClaimsPrincipal usr)
        {
            var email = usr?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            //var usuario1 = await _userManager.FindByEmailAsync(Email);

            var usuario = await input.Users.SingleOrDefaultAsync(x => x.Email == email);

            return usuario;
        }

    }
}

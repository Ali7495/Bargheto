using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Common.Extentions
{
    public static class IdentityExtention
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new UnauthorizedAccessException("There is no such a user!");

            string userId = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier).Value ?? claimsPrincipal?.FindFirst(JwtRegisteredClaimNames.Sub).Value;

            if (!Guid.TryParse(userId, out Guid id))
            {
                throw new UnauthorizedAccessException("The user is invalid!");
            }

            return userId;
        }

        public static List<string> GetUserRoles(this ClaimsPrincipal user)
        {
            return user.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
        }
    }
}

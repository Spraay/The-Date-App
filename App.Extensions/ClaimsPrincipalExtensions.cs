using System;
using System.Security.Claims;

namespace App.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            Guid.TryParse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value, result: out Guid result);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace TvPlusGame.DataAccess.Services
{
    public static class TokenService
    {
        public static string GetUniqueNameFromToken(string bearerToken)
        {
            var token = bearerToken.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);
            var uniqueName = decodedToken.Claims.Where(c => c.Type == "unique_name")
                .Select(c => c.Value).SingleOrDefault();
            return uniqueName;
        }
    }
}

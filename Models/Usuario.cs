using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FrontClinicaMedica.Models
{
    public static class UsuarioInfo
    {
        public static string JWTToken { get; set; } = string.Empty;
        public static string Username { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;

        public static void SetToken (string _token)
        {
            var handler = new JwtSecurityTokenHandler();

            var token = handler.ReadJwtToken(_token);

            var claims = token.Claims;

            JWTToken = _token;
            Username = claims.FirstOrDefault(c => c.Type == "given_name")?.Value;
            Email = claims.FirstOrDefault(c => c.Type == "email")?.Value;
            Role = claims.FirstOrDefault(c => c.Type == "role")?.Value;
        }
    }


    public class UsuarioLogin {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioSignup
    {
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}

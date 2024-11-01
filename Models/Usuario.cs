using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontClinicaMedica.Models
{
    public static class UsuarioInfo
    {
        public static string JWTToken { get; set; } = string.Empty;
    }


    public class UsuarioLogin {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

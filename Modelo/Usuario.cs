using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public string User { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Usuario(string user, string pass, bool admin)
        {
            User = user;
            Password = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }

    
}

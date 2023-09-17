using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Helper
{
    public class ValidarUsuario
    {
        public static bool validarUsuario(Usuario usuario)
        {
            bool logueado = false;
            if (usuario != null)
            {
                logueado = true;
            }
            return logueado;
        }

        public static bool validarAdmin(Usuario usuario)
        {
            bool logueado = false;
            if (usuario != null)
            {
                logueado = usuario.Admin;
            }
            return logueado;
        }
    }
}

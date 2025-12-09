using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocios._01ClaseUsuarios
{
    public class AccesoUsuario
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        public UsuarioDatos.UsuarioDTO Login(string usuario, string contrasena)
        {
            // Validación básica antes de enviar a SQL
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                return null;
            }

            // Llamar a la capa datos
            return datos.Login(usuario, contrasena);
        }
    }
}

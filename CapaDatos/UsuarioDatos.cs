using System.Data.SqlClient;
using System;


namespace CapaDatos
{
    public class UsuarioDatos
    {
        public class UsuarioDTO
        {
            public int IdUsuario { get; set; }
            public string NombreCompleto { get; set; }
            public string Rol { get; set; }
        }

        public UsuarioDTO Login(string usuario, string contrasena)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"
                SELECT U.IdUsuario, U.NombreCompleto, R.NombreRol
                FROM Usuario U
                INNER JOIN Rol R ON U.IdRol = R.IdRol
                WHERE U.UsuarioLogin = @user AND U.Contrasena = @pass";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", usuario);
                cmd.Parameters.AddWithValue("@pass", contrasena);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return new UsuarioDTO
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        Rol = dr["NombreRol"].ToString()
                    };
                }

                return null;
            }
        }
    }
}

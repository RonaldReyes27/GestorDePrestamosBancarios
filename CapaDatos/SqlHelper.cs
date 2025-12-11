using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public static class SqlHelper
    {
        public static DataTable EjecutarConsulta(string query, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);

                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        public static bool EjecutarNoConsulta(string query, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static object EjecutarEscalar(string query, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);

                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}

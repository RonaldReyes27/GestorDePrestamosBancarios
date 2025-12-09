
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        // CADENA DE CONEXIÓN OFICIAL DEL SISTEMA
        public static SqlConnection Conectar()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=BancoPrestamosDB;Integrated Security=True;");
        }
    }
}

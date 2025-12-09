using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ClienteDatos
    {
        // Insertar cliente
        public bool GuardarCliente(string nombre, string tipoDoc, string documento,
                                   string ciudad, string direccion, string email, string telefono)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"INSERT INTO Cliente (Nombre, Cedula, Ciudad, CorreoElectronico, Telefono)
                                 VALUES (@n, @doc, @c, @cor, @t)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@doc", documento); // Cédula o Pasaporte
                cmd.Parameters.AddWithValue("@c", ciudad);
                cmd.Parameters.AddWithValue("@cor", email);
                cmd.Parameters.AddWithValue("@t", telefono);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Listar clientes en DataTable
        public DataTable ListarClientes()
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"SELECT IdCliente, Nombre, Cedula AS Documento, Ciudad,
                                        CorreoElectronico AS Correo, Telefono
                                 FROM Cliente";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Buscar clientes según filtro
        public DataTable BuscarClientes(string columna, string valor)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = $@"
            SELECT 
                IdCliente,
                Nombre,
                Cedula AS Documento,
                Ciudad,
                CorreoElectronico AS Correo,
                Telefono
            FROM Cliente
            WHERE {columna} LIKE @v";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@v", "%" + valor + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }


        // Eliminar cliente
        public bool EliminarCliente(int id)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = "DELETE FROM Cliente WHERE IdCliente = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Editar cliente
        public bool EditarCliente(int id, string nombre, string documento, string ciudad,
                                  string correo, string telefono)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"UPDATE Cliente SET Nombre = @n, Cedula = @doc, Ciudad=@c,
                                  CorreoElectronico=@cor, Telefono=@t
                                 WHERE IdCliente = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@doc", documento);
                cmd.Parameters.AddWithValue("@c", ciudad);
                cmd.Parameters.AddWithValue("@cor", correo);
                cmd.Parameters.AddWithValue("@t", telefono);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public DataTable ObtenerClientePorId(int id)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"SELECT * FROM Cliente WHERE IdCliente = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool ActualizarCliente(int idCliente, string nombre, string tipoDocumento, string documento, string ciudad, string direccion, string email, string telefono)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"
            UPDATE Cliente SET
                Nombre = @Nombre,
                Documento = @Documento,
                Cedula = @Cedula,
                Ciudad = @Ciudad,
                Direccion = @Direccion,
                CorreoElectronico = @Correo,
                Telefono = @Telefono
            WHERE IdCliente = @Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", idCliente);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Documento", tipoDocumento);
                cmd.Parameters.AddWithValue("@Cedula", documento);
                cmd.Parameters.AddWithValue("@Ciudad", ciudad);
                cmd.Parameters.AddWithValue("@Direccion", direccion);
                cmd.Parameters.AddWithValue("@Correo", email);
                cmd.Parameters.AddWithValue("@Telefono", telefono);

                con.Open();
                int filas = cmd.ExecuteNonQuery();
                con.Close();

                return filas > 0;
            }
        }

    }
}

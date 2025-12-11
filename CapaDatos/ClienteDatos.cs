using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ClienteDatos
    {
        // ======================================================
        // INSERTAR CLIENTE
        // ======================================================
        public bool GuardarCliente(string nombre, string documento,
                                   string ciudad, string email, string telefono)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"INSERT INTO Cliente 
                                 (Nombre, Cedula, Ciudad, CorreoElectronico, Telefono)
                                 VALUES (@n, @doc, @c, @cor, @t)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@doc", documento);
                cmd.Parameters.AddWithValue("@c", ciudad);
                cmd.Parameters.AddWithValue("@cor", email);
                cmd.Parameters.AddWithValue("@t", telefono);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ======================================================
        // LISTAR CLIENTES
        // ======================================================
        public DataTable ListarClientes()
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"
            SELECT 
                IdCliente,
                Nombre,
                Cedula,
                Ciudad,
                CorreoElectronico,
                Telefono,
                Direccion
            FROM Cliente
            ORDER BY IdCliente ASC";


                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ======================================================
        // BUSCAR CLIENTES
        // ======================================================
        public DataTable BuscarClientes(string filtro, string valor)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                // MAPEAMOS EL TEXTO DEL COMBO A LA COLUMNA REAL
                string columna = filtro switch
                {
                    "Nombre" => "Nombre",
                    "Documento" => "Cedula",
                    "Ciudad" => "Ciudad",
                    "Correo" => "CorreoElectronico",
                    "Telefono" => "Telefono",
                    _ => "Nombre"
                };

                string query = $@"
                SELECT 
                    IdCliente,
                    Nombre,
                    Cedula AS Documento,
                    Ciudad,
                    CorreoElectronico AS Correo,
                    Telefono
                FROM Cliente
                WHERE {columna} LIKE @valor";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@valor", "%" + valor + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ======================================================
        // ELIMINAR CLIENTE
        // ======================================================
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

        // ======================================================
        // EDITAR CLIENTE
        // ======================================================
        public bool EditarCliente(int id, string nombre, string documento,
                                  string ciudad, string correo, string telefono)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"
                UPDATE Cliente SET
                    Nombre = @n,
                    Cedula = @doc,
                    Ciudad = @c,
                    CorreoElectronico = @cor,
                    Telefono = @t
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

        // ======================================================
        // OBTENER CLIENTE POR ID
        // ======================================================
        public DataTable ObtenerClientePorId(int id)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = @"
            SELECT 
                IdCliente,
                Nombre,
                Cedula,
                TipoDocumento,
                Direccion,
                Ciudad,
                CorreoElectronico,
                Telefono
            FROM Cliente
            WHERE IdCliente = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}

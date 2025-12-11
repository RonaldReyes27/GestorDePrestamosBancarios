using CapaDatos;
using System.Data.SqlClient;
using System.Data;


namespace CapaNegocios
{
    public class ClienteNegocio
    {
        private readonly ClienteDatos datos = new ClienteDatos();

        // ======================================================
        // REGISTRAR CLIENTE
        // ======================================================
        public bool GuardarCliente(string nombre, string documento, string ciudad,
                                   string correo, string telefono)
        {
            return datos.GuardarCliente(nombre, documento, ciudad, correo, telefono);
        }

        // ======================================================
        // LISTAR CLIENTES
        // ======================================================
        public DataTable ListarClientes()
        {
            return datos.ListarClientes();
        }

        // ======================================================
        // BUSCAR CLIENTES
        // ======================================================
        public DataTable Buscar(string filtro, string valor)
        {
            // Aquí enviamos el filtro correcto a CapaDatos
            return datos.BuscarClientes(filtro, valor);
        }

        // ======================================================
        // ELIMINAR CLIENTE
        // ======================================================
        public bool EliminarCliente(int idCliente)
        {
            return datos.EliminarCliente(idCliente);
        }

        // ======================================================
        // EDITAR CLIENTE
        // ======================================================
        public bool EditarCliente(int idCliente, string nombre, string documento,
                                  string ciudad, string correo, string telefono)
        {
            return datos.EditarCliente(idCliente, nombre, documento, ciudad, correo, telefono);
        }

        // ======================================================
        // OBTENER CLIENTE POR ID
        // ======================================================
        public DataTable ObtenerClientePorId(int idCliente)
        {
            return datos.ObtenerClientePorId(idCliente);
        }
        

    }

}

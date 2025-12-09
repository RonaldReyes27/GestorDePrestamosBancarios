using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class ClienteNegocio
    {
        ClienteDatos datos = new ClienteDatos();

        public bool GuardarCliente(string n, string tipo, string doc, string c, string dir, string cor, string t)
        {
            return datos.GuardarCliente(n, tipo, doc, c, dir, cor, t);
        }

        public DataTable ListarClientes()
        {
            return datos.ListarClientes();
        }

        public DataTable Buscar(string columna, string valor)
        {
            return datos.BuscarClientes(columna, valor);
        }

        public bool EliminarCliente(int id)
        {
            return datos.EliminarCliente(id);
        }

        public bool EditarCliente(int id, string n, string doc, string c, string cor, string t)
        {
            return datos.EditarCliente(id, n, doc, c, cor, t);
        }
        public DataTable ObtenerClientePorId(int id)
        {
            return datos.ObtenerClientePorId(id);
        }
        public bool ActualizarCliente(int idCliente, string nombre, string tipoDocumento, string documento, string ciudad, string direccion, string email, string telefono)
        {
            return datos.ActualizarCliente(idCliente, nombre, tipoDocumento, documento, ciudad, direccion, email, telefono);
        }
    }
}

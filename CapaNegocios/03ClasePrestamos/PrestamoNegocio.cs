using CapaDatos;
using System.Data;

namespace CapaNegocios._03ClasePrestamos
{
    public class PrestamoNegocio
    {
        private readonly PrestamoDatos datos = new PrestamoDatos();

        public int CrearPrestamo(int idCliente, decimal monto, decimal tasa,
                                 int meses, string tipo, DateTime fechaInicio)
        {
            return datos.CrearPrestamo(idCliente, monto, tasa, meses, tipo, fechaInicio);
        }

        public DataTable ObtenerPrestamo(int idPrestamo)
        {
            return datos.ObtenerPrestamo(idPrestamo);
        }

        public DataTable ObtenerPrestamosCliente(int idCliente)
        {
            return datos.ObtenerPrestamosCliente(idCliente);
        }

        public DataTable ObtenerCuotasPendientes(int idPrestamo)
        {
            return datos.ObtenerCuotasPendientes(idPrestamo);
        }
    }
}

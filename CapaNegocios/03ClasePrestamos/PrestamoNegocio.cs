using System.Data;
using CapaDatos;

namespace CapaNegocios._03ClasePrestamos
{
    public class PrestamoNegocio
    {
        private readonly PrestamoDatos datos = new PrestamoDatos();

        // Crear préstamo
        public int CrearPrestamo(int idCliente, decimal monto, decimal tasaAnual,
                                 int meses, string tipoPrestamo, DateTime fechaInicio)
        {
            return datos.CrearPrestamo(idCliente, monto, tasaAnual, meses, tipoPrestamo, fechaInicio);
        }

        // Obtener préstamo por ID
        public DataTable ObtenerPrestamo(int idPrestamo)
        {
            return datos.ObtenerPrestamo(idPrestamo);
        }

        // Listar préstamos de un cliente
        public DataTable ObtenerPrestamosCliente(int idCliente)
        {
            return datos.ObtenerPrestamosCliente(idCliente);
        }

        // Cuotas pendientes
        public DataTable ObtenerCuotasPendientes(int idPrestamo)
        {
            return datos.ObtenerCuotasPendientes(idPrestamo);
        }
    }
}

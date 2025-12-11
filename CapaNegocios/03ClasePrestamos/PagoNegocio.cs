using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class PagoNegocio
    {
        private readonly PagoDatos datos = new PagoDatos();

        public bool RegistrarPago(int idPrestamo, int numeroCuota, decimal monto)
        {
            return datos.RegistrarPago(idPrestamo, numeroCuota, monto);
        }

        public DataTable HistorialPagos(int idPrestamo)
        {
            return datos.ObtenerHistorialPagos(idPrestamo);
        }
    }
}

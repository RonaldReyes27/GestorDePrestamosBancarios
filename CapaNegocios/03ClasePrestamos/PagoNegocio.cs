using CapaDatos;

namespace CapaNegocios
{
    public class PagoNegocio
    {
        PagoDatos datos = new PagoDatos();

        public bool RegistrarPago(int idPrestamo, int numeroCuota, decimal monto)
        {
            return datos.RegistrarPago(idPrestamo, numeroCuota, monto);
        }
        public bool CuotaEstaPagada(int idPrestamo, int numeroCuota)
        {
            PagoDatos pagoDatos = new PagoDatos();
            return pagoDatos.CuotaFuePagada(idPrestamo, numeroCuota);
        }
    }
}

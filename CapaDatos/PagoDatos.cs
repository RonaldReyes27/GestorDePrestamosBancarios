using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class PagoDatos
    {
        public bool RegistrarPago(int idPrestamo, int numeroCuota, decimal monto)
        {
            string sql = @"INSERT INTO Pago (IdPrestamo, NumeroCuotaPagada, MontoPagado)
                           VALUES (@id, @cuota, @monto)";

            return SqlHelper.EjecutarNoConsulta(sql,
                new SqlParameter("@id", idPrestamo),
                new SqlParameter("@cuota", numeroCuota),
                new SqlParameter("@monto", monto)
            );
        }

        public DataTable ObtenerHistorialPagos(int idPrestamo)
        {
            string sql = @"SELECT * FROM Pago WHERE IdPrestamo = @id ORDER BY FechaPago DESC";

            return SqlHelper.EjecutarConsulta(sql,
                new SqlParameter("@id", idPrestamo)
            );
        }
    }
}

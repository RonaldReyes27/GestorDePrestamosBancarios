using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class PrestamoDatos
    {
        // ==========================================================
        // CREAR PRÉSTAMO — devuelve el ID generado
        // ==========================================================
        public int CrearPrestamo(int idCliente, decimal monto, decimal tasa,
                                 int meses, string tipo, DateTime fechaInicio)
        {
            string sql = @"
                INSERT INTO Prestamo (IdCliente, Monto, Tasa, Meses, TipoPrestamo, FechaInicio)
                VALUES (@cliente, @monto, @tasa, @meses, @tipo, @fecha);
                SELECT SCOPE_IDENTITY();
            ";

            object result = SqlHelper.EjecutarEscalar(sql,
                new SqlParameter("@cliente", idCliente),
                new SqlParameter("@monto", monto),
                new SqlParameter("@tasa", tasa),
                new SqlParameter("@meses", meses),
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@fecha", fechaInicio)
            );

            return Convert.ToInt32(result);
        }

        // ==========================================================
        // OBTENER PRÉSTAMO POR ID
        // ==========================================================
        public DataTable ObtenerPrestamo(int idPrestamo)
        {
            string sql = @"SELECT * FROM Prestamo WHERE IdPrestamo = @id";

            return SqlHelper.EjecutarConsulta(sql,
                new SqlParameter("@id", idPrestamo));
        }

        // ==========================================================
        // LISTAR PRÉSTAMOS DE UN CLIENTE
        // ==========================================================
        public DataTable ObtenerPrestamosCliente(int idCliente)
        {
            string sql = @"SELECT * FROM Prestamo WHERE IdCliente = @idCliente";

            return SqlHelper.EjecutarConsulta(sql,
                new SqlParameter("@idCliente", idCliente));
        }

        // ==========================================================
        // OBTENER CUOTAS PENDIENTES DE UN PRÉSTAMO
        // ==========================================================
        public DataTable ObtenerCuotasPendientes(int idPrestamo)
        {
            string sql = @"
                SELECT * FROM Cuota
                WHERE IdPrestamo = @idPrestamo AND Pagada = 0
                ORDER BY NumeroCuota ASC
            ";

            return SqlHelper.EjecutarConsulta(sql,
                new SqlParameter("@idPrestamo", idPrestamo));
        }
    }
}

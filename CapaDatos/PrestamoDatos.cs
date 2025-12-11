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
        public int CrearPrestamo(int idCliente, decimal monto, decimal tasaAnual,
                                 int plazoMeses, string tipoPrestamo, DateTime fechaInicio)
        {
            string sql = @"
                INSERT INTO Prestamo 
                (IdCliente, Monto, TasaAnual, PlazoMeses, TipoPrestamo, FechaInicio, SaldoRestante)
                VALUES 
                (@cliente, @monto, @tasaAnual, @plazoMeses, @tipo, @fecha, @saldoRestante);

                SELECT SCOPE_IDENTITY();
            ";

            object result = SqlHelper.EjecutarEscalar(sql,
                new SqlParameter("@cliente", idCliente),
                new SqlParameter("@monto", monto),
                new SqlParameter("@tasaAnual", tasaAnual),
                new SqlParameter("@plazoMeses", plazoMeses),
                new SqlParameter("@tipo", tipoPrestamo),
                new SqlParameter("@fecha", fechaInicio),

                // 🔥 ESTE ES EL VALOR QUE FALTABA PARA EVITAR EL ERROR
                new SqlParameter("@saldoRestante", monto)
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
                WHERE IdPrestamo = @idPrestamo AND BalanceRestante > 0
                ORDER BY NumeroCuota ASC
            ";

            return SqlHelper.EjecutarConsulta(sql,
                new SqlParameter("@idPrestamo", idPrestamo));
        }
    }
}

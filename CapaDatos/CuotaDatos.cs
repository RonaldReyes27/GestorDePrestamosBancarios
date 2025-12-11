using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CuotaDatos
    {
        // ============================================================
        // GUARDAR CUOTA (YA EXISTÍA)
        // ============================================================
        public void GuardarCuota(int idPrestamo, int numeroCuota, decimal capital,
                                 decimal interes, decimal montoCuota,
                                 decimal balanceRestante, DateTime fechaCobro)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();

                string query = @"INSERT INTO Cuota (IdPrestamo, NumeroCuota, Capital, Interes, 
                                MontoCuota, BalanceRestante, FechaProgramada)
                                VALUES (@IdPrestamo, @Numero, @Capital, @Interes,
                                        @Monto, @Balance, @Fecha);";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                cmd.Parameters.AddWithValue("@Numero", numeroCuota);
                cmd.Parameters.AddWithValue("@Capital", capital);
                cmd.Parameters.AddWithValue("@Interes", interes);
                cmd.Parameters.AddWithValue("@Monto", montoCuota);
                cmd.Parameters.AddWithValue("@Balance", balanceRestante);
                cmd.Parameters.AddWithValue("@Fecha", fechaCobro);

                cmd.ExecuteNonQuery();
            }
        }


        // ============================================================
        // OBTENER TODAS LAS CUOTAS DE UN PRÉSTAMO
        // ============================================================
        public DataTable ObtenerCuotasPorPrestamo(int idPrestamo)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();

                string query = @"SELECT *
                                 FROM Cuota
                                 WHERE IdPrestamo = @IdPrestamo
                                 ORDER BY NumeroCuota ASC;";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }


        // ============================================================
        // OBTENER PRÓXIMA CUOTA PENDIENTE (PRIMERA NO PAGADA)
        // ============================================================
        public DataTable ObtenerCuotasPendientes(int idPrestamo)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();

                string query = @"
                    SELECT TOP 1 c.*
                    FROM Cuota c
                    WHERE c.IdPrestamo = @IdPrestamo
                    AND c.NumeroCuota NOT IN (
                        SELECT NumeroCuotaPagada
                        FROM Pago
                        WHERE IdPrestamo = @IdPrestamo
                    )
                    ORDER BY c.NumeroCuota ASC;";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }


        // ============================================================
        // REGISTRAR PAGO DE UNA CUOTA
        // ============================================================
        public bool RegistrarPago(int idPrestamo, int numeroCuota, decimal montoPagado)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();

                string query = @"INSERT INTO Pago (IdPrestamo, NumeroCuotaPagada, MontoPagado)
                                 VALUES (@IdPrestamo, @NumeroCuota, @Monto);";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                cmd.Parameters.AddWithValue("@NumeroCuota", numeroCuota);
                cmd.Parameters.AddWithValue("@Monto", montoPagado);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

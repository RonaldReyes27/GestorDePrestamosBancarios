using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class PagoDatos
    {
        // ==========================================================
        // REGISTRAR PAGO DE UNA CUOTA
        // ==========================================================
        public bool RegistrarPago(int idPrestamo, int numeroCuota, decimal monto)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                SqlTransaction tx = cn.BeginTransaction();

                try
                {
                    // 1) Insertar pago (CORREGIDO)
                    string sqlPago = @"
                INSERT INTO Pago (IdPrestamo, NumeroCuotaPagada, MontoPagado)
                VALUES (@prestamo, @cuota, @monto);";

                    SqlCommand cmd1 = new SqlCommand(sqlPago, cn, tx);
                    cmd1.Parameters.AddWithValue("@prestamo", idPrestamo);
                    cmd1.Parameters.AddWithValue("@cuota", numeroCuota);
                    cmd1.Parameters.AddWithValue("@monto", monto);
                    cmd1.ExecuteNonQuery();

                    // 2) Marcar cuota como pagada
                    string sqlCuota = @"
                UPDATE Cuota 
                SET BalanceRestante = 0
                WHERE IdPrestamo = @prestamo
                AND NumeroCuota = @cuota;";

                    SqlCommand cmd2 = new SqlCommand(sqlCuota, cn, tx);
                    cmd2.Parameters.AddWithValue("@prestamo", idPrestamo);
                    cmd2.Parameters.AddWithValue("@cuota", numeroCuota);
                    cmd2.ExecuteNonQuery();

                    // 3) Actualizar saldo del préstamo
                    string sqlSaldo = @"
                UPDATE Prestamo
                SET SaldoRestante = SaldoRestante - @monto
                WHERE IdPrestamo = @prestamo;";

                    SqlCommand cmd3 = new SqlCommand(sqlSaldo, cn, tx);
                    cmd3.Parameters.AddWithValue("@prestamo", idPrestamo);
                    cmd3.Parameters.AddWithValue("@monto", monto);
                    cmd3.ExecuteNonQuery();

                    tx.Commit();
                    return true;
                }
                catch
                {
                    tx.Rollback();
                    return false;
                }
            }
        }
        public bool CuotaFuePagada(int idPrestamo, int numeroCuota)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = @"SELECT COUNT(*) 
                         FROM Pago 
                         WHERE IdPrestamo = @IdPrestamo 
                         AND NumeroCuotaPagada = @Numero;";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                cmd.Parameters.AddWithValue("@Numero", numeroCuota);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }   
    }
}

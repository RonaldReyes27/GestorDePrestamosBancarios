using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios._04ClaseCuotas
{
    public class CuotaNegocio
    {
        private readonly CuotaDatos datosCuota = new CuotaDatos();

        // ============================================================
        // GUARDAR TODAS LAS CUOTAS GENERADAS EN UN PRÉSTAMO
        // ============================================================
        public void GuardarCuotas(int idPrestamo, List<CuotaModelo> cuotas)
        {
            foreach (var c in cuotas)
            {
                datosCuota.GuardarCuota(
                    idPrestamo,
                    c.NumeroCuota,
                    c.Capital,
                    c.Interes,
                    c.MontoCuota,
                    c.BalanceRestante,
                    c.FechaCobro
                );
            }
        }

        // ============================================================
        // OBTENER CUOTAS DE UN PRÉSTAMO
        // ============================================================
        public DataTable ObtenerCuotasPorPrestamo(int idPrestamo)
        {
            return datosCuota.ObtenerCuotasPorPrestamo(idPrestamo);
        }

        // ============================================================
        // OBTENER PRÓXIMA CUOTA PENDIENTE
        // ============================================================
        public DataTable ObtenerCuotasPendientes(int idPrestamo)
        {
            return datosCuota.ObtenerCuotasPendientes(idPrestamo);
        }

        // ============================================================
        // REGISTRAR PAGO DE UNA CUOTA
        // ============================================================
        public bool RegistrarPago(int idPrestamo, int numeroCuota, decimal montoPagado)
        {
            return datosCuota.RegistrarPago(idPrestamo, numeroCuota, montoPagado);
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocios;
using CapaNegocios._03ClasePrestamos;
using CapaNegocios._04ClaseCuotas;

namespace CapaPresent.UserControls
{
    public partial class UC_Cobrar : UserControl
    {
        private int idClienteSeleccionado = 0;
        private int idPrestamoSeleccionado = 0;

        public UC_Cobrar()
        {
            InitializeComponent();
        }

        // ==========================================================
        // BOTÓN SELECCIONAR CLIENTE
        // ==========================================================
        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            FrmSeleccionarCliente frm = new FrmSeleccionarCliente();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                idClienteSeleccionado = frm.IdClienteSeleccionado;

                CargarDatosCliente(idClienteSeleccionado);
                CargarPrestamosCliente(idClienteSeleccionado);
            }
        }

        // ==========================================================
        // CARGAR DATOS DEL CLIENTE
        // ==========================================================
        private void CargarDatosCliente(int idCliente)
        {
            ClienteNegocio clienteNeg = new ClienteNegocio();
            DataTable dt = clienteNeg.ObtenerClientePorId(idCliente);

            if (dt.Rows.Count > 0)
            {
                txtNombreCompleto.Text = dt.Rows[0]["Nombre"].ToString();
                txtNumDoc.Text = dt.Rows[0]["Cedula"].ToString();
                txtCiudad.Text = dt.Rows[0]["Ciudad"].ToString();
                txtCorreo.Text = dt.Rows[0]["CorreoElectronico"].ToString();
                txtTelefono.Text = dt.Rows[0]["Telefono"].ToString();
            }
        }

        // ==========================================================
        // CARGAR PRÉSTAMOS DEL CLIENTE
        // ==========================================================
        private void CargarPrestamosCliente(int idCliente)
        {
            PrestamoNegocio prestamoNeg = new PrestamoNegocio();
            DataTable dt = prestamoNeg.ObtenerPrestamosCliente(idCliente);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Este cliente no posee préstamos activos.");
                return;
            }

            DataRow p = dt.Rows[0]; // Usamos el primer préstamo

            txtMontoPrestamo.Text = p["Monto"].ToString();
            txtInteres.Text = p["TasaAnual"].ToString();
            txtNumCuotas.Text = p["PlazoMeses"].ToString();
            txtTipoMoneda.Text = "RD$";

            // Aquí cargamos como FORMA DE PAGO lo que el usuario registró (Diario, Mensual, etc.)
            txtFormaPago.Text = p["TipoPrestamo"].ToString();

            txtFechaInicio.Text = Convert.ToDateTime(p["FechaInicio"]).ToShortDateString();

            idPrestamoSeleccionado = Convert.ToInt32(p["IdPrestamo"]);

            CargarProximaCuota(idPrestamoSeleccionado);
        }

        // ==========================================================
        // CARGAR PRÓXIMA CUOTA
        // ==========================================================
        private void CargarProximaCuota(int idPrestamo)
        {
            CuotaNegocio cuotaNeg = new CuotaNegocio();
            DataTable cuotas = cuotaNeg.ObtenerCuotasPendientes(idPrestamo);

            if (cuotas.Rows.Count == 0)
            {
                MessageBox.Show("Este préstamo está completamente pagado.");
                return;
            }

            DataRow c = cuotas.Rows[0];

            // ➤ DATOS DE LA SIGUIENTE CUOTA A PAGAR
            txtCuotaPagar.Text = c["NumeroCuota"].ToString();
            txtFechaLimitePago.Text = Convert.ToDateTime(c["FechaProgramada"]).ToShortDateString();
            txtImportePagar.Text = c["MontoCuota"].ToString();

            // ➤ Monto por cuota (es el mismo para todas)
            decimal montoCuota = Convert.ToDecimal(c["MontoCuota"]);
            txtMontoPorCuotas.Text = montoCuota.ToString("N2");

            // ======================================================
            //   🔥 CÁLCULO CORRECTO DEL TOTAL DE INTERESES
            // ======================================================
            // Fórmula: (cuota * cantidadCuotas) – montoPrestamo
            // Esto no requiere tener columna Interes en BD
            // ======================================================

            decimal montoPrestamo = Convert.ToDecimal(txtMontoPrestamo.Text);
            int totalCuotas = Convert.ToInt32(txtNumCuotas.Text);

            decimal totalIntereses = (montoCuota * totalCuotas) - montoPrestamo;

            if (totalIntereses < 0)
                totalIntereses = 0;

            txtTotalInteres.Text = totalIntereses.ToString("N2");

            // ➤ Total a pagar = Cuota * número de cuotas
            decimal totalAPagar = montoCuota * totalCuotas;
            txtTotalAPagar.Text = totalAPagar.ToString("N2");
        }

        // ==========================================================
        // REGISTRAR PAGO
        // ==========================================================
        private void btnRegistrarCobro_Click(object sender, EventArgs e)
        {
            if (idPrestamoSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente con préstamo activo.", "Advertencia");
                return;
            }

            int numeroCuota = Convert.ToInt32(txtCuotaPagar.Text);
            decimal monto = Convert.ToDecimal(txtImportePagar.Text);

            PagoNegocio pagoNeg = new PagoNegocio();
            bool ok = pagoNeg.RegistrarPago(idPrestamoSeleccionado, numeroCuota, monto);

            if (ok)
            {
                MessageBox.Show("Pago registrado correctamente.", "Éxito");

                // Recargar la siguiente cuota pendiente
                CargarProximaCuota(idPrestamoSeleccionado);
            }
            else
            {
                MessageBox.Show("Error al registrar pago.", "Error");
            }
        }
    }
}

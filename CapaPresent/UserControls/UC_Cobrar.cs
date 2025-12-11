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
            frm.ShowDialog();

            if (frm.IdClienteSeleccionado > 0)
            {
                idClienteSeleccionado = frm.IdClienteSeleccionado;

                CargarDatosCliente(idClienteSeleccionado);
                CargarPrestamosCliente(idClienteSeleccionado);
            }
        }

        // ==========================================================
        // CARGAR DATOS BÁSICOS DEL CLIENTE
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

            // Usamos el primer préstamo activo
            idPrestamoSeleccionado = Convert.ToInt32(dt.Rows[0]["IdPrestamo"]);

            CargarInformacionPrestamo(idPrestamoSeleccionado);
            CargarProximaCuota(idPrestamoSeleccionado);
        }

        // ==========================================================
        // CARGAR INFORMACIÓN GENERAL DEL PRÉSTAMO
        // ==========================================================
        private void CargarInformacionPrestamo(int idPrestamo)
        {
            PrestamoNegocio prestamoNeg = new PrestamoNegocio();
            DataTable dt = prestamoNeg.ObtenerPrestamo(idPrestamo);

            if (dt.Rows.Count == 0) return;

            txtMontoPrestamo.Text = dt.Rows[0]["Monto"].ToString();
            txtInteres.Text = dt.Rows[0]["TasaAnual"].ToString();
            txtNumCuotas.Text = dt.Rows[0]["PlazoMeses"].ToString();
            txtFechaInicio.Text = Convert.ToDateTime(dt.Rows[0]["FechaInicio"]).ToShortDateString();

            txtTipoMoneda.Text = "RD$"; // Puedes cambiarlo luego si usas otra moneda
        }

        // ==========================================================
        // CARGAR PRÓXIMA CUOTA PENDIENTE
        // ==========================================================
        private void CargarProximaCuota(int idPrestamo)
        {
            CuotaNegocio cuotaNeg = new CuotaNegocio();
            DataTable cuotas = cuotaNeg.ObtenerCuotasPendientes(idPrestamo);

            if (cuotas.Rows.Count == 0)
            {
                MessageBox.Show("Este préstamo está totalmente pagado.");
                return;
            }

            // Tomamos la primera cuota pendiente
            txtCuotaPagar.Text = cuotas.Rows[0]["NumeroCuota"].ToString();
            txtFechaLimitePago.Text = Convert.ToDateTime(cuotas.Rows[0]["FechaProgramada"]).ToShortDateString();
            txtImportePagar.Text = cuotas.Rows[0]["MontoCuota"].ToString();
        }

        // ==========================================================
        // REGISTRAR EL COBRO (BOTÓN)
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
                CargarProximaCuota(idPrestamoSeleccionado);
            }
            else
            {
                MessageBox.Show("Error al registrar pago.", "Error");
            }
        }
    }
}

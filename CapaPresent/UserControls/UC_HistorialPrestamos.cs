using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocios;
using CapaNegocios._03ClasePrestamos;
using CapaNegocios._04ClaseCuotas;

namespace CapaPresent.UserControls
{
    public partial class UC_HistorialPrestamos : UserControl
    {
        private int idClienteSeleccionado = 0;
        private int idPrestamoSeleccionado = 0;

        public UC_HistorialPrestamos()
        {
            InitializeComponent();
            CrearColumnasCuotas();   // ← SE CREA SIEMPRE (soluciona error)
        }

        // ===============================================================
        // CREAR COLUMNAS DEL GRID (OBLIGATORIO)
        // ===============================================================
        private void CrearColumnasCuotas()
        {
            dgvResumenCuotas.AutoGenerateColumns = false;

            if (dgvResumenCuotas.Columns.Count > 0)
                return;

            dgvResumenCuotas.Columns.Add("NumeroCuota", "Cuota");
            dgvResumenCuotas.Columns.Add("Fecha", "Fecha");
            dgvResumenCuotas.Columns.Add("Monto", "Monto");
            dgvResumenCuotas.Columns.Add("Interes", "Interés");
            dgvResumenCuotas.Columns.Add("Estado", "Estado");
        }

        private void UC_HistorialPrestamos_Load(object sender, EventArgs e)
        {
            CrearColumnasCuotas(); // ← Backup por si acaso
        }

        // ===============================================================
        // BOTÓN SELECCIONAR CLIENTE
        // ===============================================================
        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            FrmSeleccionarCliente frm = new FrmSeleccionarCliente();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                idClienteSeleccionado = frm.IdClienteSeleccionado;

                CargarDatosCliente(idClienteSeleccionado);
                CargarUltimoPrestamo(idClienteSeleccionado);
            }
        }

        // ===============================================================
        // DATOS DEL CLIENTE
        // ===============================================================
        private void CargarDatosCliente(int idCliente)
        {
            ClienteNegocio clienteNeg = new ClienteNegocio();
            DataTable dt = clienteNeg.ObtenerClientePorId(idCliente);

            if (dt.Rows.Count == 0) return;

            DataRow c = dt.Rows[0];

            txtNombre.Text = c["Nombre"].ToString();
            txtNumDoc.Text = c["Cedula"].ToString();
            txtDireccion.Text = c["Direccion"].ToString();
            txtCiudad.Text = c["Ciudad"].ToString();
            txtCorreo.Text = c["CorreoElectronico"].ToString();
            txtTelefono.Text = c["Telefono"].ToString();
        }

        // ===============================================================
        // CARGAR ÚLTIMO PRÉSTAMO DEL CLIENTE
        // ===============================================================
        private void CargarUltimoPrestamo(int idCliente)
        {
            PrestamoNegocio prestamoNeg = new PrestamoNegocio();
            DataTable dt = prestamoNeg.ObtenerPrestamosCliente(idCliente);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Este cliente no tiene préstamos registrados.");
                return;
            }

            DataRow p = dt.Rows[dt.Rows.Count - 1];

            idPrestamoSeleccionado = Convert.ToInt32(p["IdPrestamo"]);

            txtMontoPrestamo.Text = Convert.ToDecimal(p["Monto"]).ToString("N2");
            txtInteres.Text = p["TasaAnual"].ToString();
            txtNumCuotas.Text = p["PlazoMeses"].ToString();
            txtFormaPago.Text = "Mensual";
            txtTipoMoneda.Text = "RD$";
            txtFechaInicio.Text = Convert.ToDateTime(p["FechaInicio"]).ToShortDateString();

            CargarCuotas(idPrestamoSeleccionado);
        }

        // ===============================================================
        // CARGAR CUOTAS
        // ===============================================================
        private void CargarCuotas(int idPrestamo)
        {
            dgvResumenCuotas.Rows.Clear();

            CuotaNegocio cuotaNeg = new CuotaNegocio();
            DataTable dt = cuotaNeg.ObtenerCuotasPorPrestamo(idPrestamo);

            decimal totalInteres = 0;
            decimal totalAPagar = 0;

            foreach (DataRow c in dt.Rows)
            {
                PagoNegocio pagoNeg = new PagoNegocio();
                bool pagada = pagoNeg.CuotaEstaPagada(idPrestamo, Convert.ToInt32(c["NumeroCuota"]));

                decimal monto = Convert.ToDecimal(c["MontoCuota"]);
                decimal interes = Convert.ToDecimal(c["Interes"]);

                totalInteres += interes;
                totalAPagar += monto;

                int row = dgvResumenCuotas.Rows.Add(
                    c["NumeroCuota"],
                    Convert.ToDateTime(c["FechaProgramada"]).ToShortDateString(),
                    monto.ToString("N2"),
                    interes.ToString("N2"),
                    pagada ? "Pagada" : "Pendiente"
                );

                dgvResumenCuotas.Rows[row].DefaultCellStyle.BackColor =
                    pagada ? Color.LightGreen : Color.LightYellow;
            }

            // Asignación de totales
            txtMontoPorCuotas.Text = dt.Rows.Count > 0
                ? Convert.ToDecimal(dt.Rows[0]["MontoCuota"]).ToString("N2")
                : "0.00";

            txtTotalInteres.Text = totalInteres.ToString("N2");
            txtTotalAPagar.Text = totalAPagar.ToString("N2");
        }
    }
}

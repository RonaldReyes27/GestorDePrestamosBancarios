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
            FixDataGridHeader();
        }
        private void FixDataGridHeader()
        {
            dgvResumenCuotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResumenCuotas.ColumnHeadersHeight = 32;
            dgvResumenCuotas.ScrollBars = ScrollBars.Vertical;

            // Evita que la cabecera se esconda al cambiar el layout
            dgvResumenCuotas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // FORZAR RELOCATION
            dgvResumenCuotas.Location = new Point(0, dgvResumenCuotas.Location.Y + 1);
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
            //txtDireccion.Text = c["Direccion"].ToString();
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

            if (dt.Rows.Count == 0)
                return;

            // ============================================
            // Datos generales del préstamo
            // ============================================
            decimal montoPrestamo = Convert.ToDecimal(txtMontoPrestamo.Text);
            decimal tasaAnual = Convert.ToDecimal(txtInteres.Text);
            int numCuotas = Convert.ToInt32(txtNumCuotas.Text);

            decimal tasaMensual = tasaAnual / 100m / 12m;

            decimal saldo = montoPrestamo;

            decimal totalInteres = 0;
            decimal totalAPagar = 0;

            foreach (DataRow c in dt.Rows)
            {
                int numeroCuota = Convert.ToInt32(c["NumeroCuota"]);
                decimal montoCuota = Convert.ToDecimal(c["MontoCuota"]);

                // ============================================
                // Calcular interés REAL de la cuota
                // ============================================
                decimal interesCuota = saldo * tasaMensual;
                decimal capitalCuota = montoCuota - interesCuota;

                if (capitalCuota < 0)
                    capitalCuota = 0;

                // Disminuir el saldo para la siguiente cuota
                saldo -= capitalCuota;
                if (saldo < 0) saldo = 0;

                // Verificar si la cuota está pagada
                PagoNegocio pagoNeg = new PagoNegocio();
                bool pagada = pagoNeg.CuotaEstaPagada(idPrestamo, numeroCuota);

                int row = dgvResumenCuotas.Rows.Add(
                    numeroCuota,
                    Convert.ToDateTime(c["FechaProgramada"]).ToShortDateString(),
                    montoCuota.ToString("N2"),
                    interesCuota.ToString("N2"),  // <--- AHORA MUESTRA EL INTERÉS REAL
                    pagada ? "Pagada" : "Pendiente"
                );

                dgvResumenCuotas.Rows[row].DefaultCellStyle.BackColor =
                    pagada ? Color.LightGreen : Color.LightYellow;

                // Totales
                totalInteres += interesCuota;
                totalAPagar += montoCuota;
            }

            // ============================================
            // Mostrar totales
            // ============================================
            txtMontoPorCuotas.Text = dt.Rows.Count > 0
                ? Convert.ToDecimal(dt.Rows[0]["MontoCuota"]).ToString("N2")
                : "0.00";

            txtTotalInteres.Text = totalInteres.ToString("N2");
            txtTotalAPagar.Text = totalAPagar.ToString("N2");
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

       
    }
}

using CapaNegocios._03ClasePrestamos;
using CapaNegocios._04ClaseCuotas;
using System;
using System.Windows.Forms;

namespace CapaPresent.UserControls
{
    public partial class UcNuevoPrestamo : UserControl
    {
        private int _idClienteSeleccionado = 0;

        public UcNuevoPrestamo()
        {
            InitializeComponent();
            Load += UcNuevoPrestamo_Load; // Evento Load
        }

        // ============================================================
        //                CARGAR DATOS INICIALES
        // ============================================================
        private void UcNuevoPrestamo_Load(object sender, EventArgs e)
        {
            CargarCuotas();
            CargarTipoPrestamo();
            CargarFormaPago();
            CargarTipoMoneda();

            cmbTipoPrestamo.SelectedIndexChanged += cmbTipoPrestamo_SelectedIndexChanged;
        }

        private void CargarCuotas()
        {
            cmbNumCuotas.Items.Clear();
            for (int i = 1; i <= 60; i++)
                cmbNumCuotas.Items.Add(i);

            cmbNumCuotas.SelectedIndex = 0;
        }

        private void CargarTipoPrestamo()
        {
            cmbTipoPrestamo.Items.Clear();
            cmbTipoPrestamo.Items.Add("Personal");
            cmbTipoPrestamo.Items.Add("Vehicular");
            cmbTipoPrestamo.Items.Add("Hipotecario");
            cmbTipoPrestamo.Items.Add("Empresarial");

            cmbTipoPrestamo.SelectedIndex = 0;
        }

        private void CargarFormaPago()
        {
            cmbFormaPago.Items.Clear();
            cmbFormaPago.Items.Add("Diario");
            cmbFormaPago.Items.Add("Semanal");
            cmbFormaPago.Items.Add("Quincenal");
            cmbFormaPago.Items.Add("Mensual");

            cmbFormaPago.SelectedIndex = 3; // Mensual por defecto
        }

        private void CargarTipoMoneda()
        {
            cmbTipoMoneda.Items.Clear();
            cmbTipoMoneda.Items.Add("$ DOP");
            cmbTipoMoneda.Items.Add("$ USD");

            cmbTipoMoneda.SelectedIndex = 0;
        }

        // ============================================================
        //                 INTERÉS AUTOMÁTICO
        // ============================================================
        private void cmbTipoPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTipoPrestamo.SelectedItem.ToString())
            {
                case "Personal": txtInteres.Text = "20"; break;
                case "Vehicular": txtInteres.Text = "13"; break;
                case "Hipotecario": txtInteres.Text = "9"; break;
                case "Empresarial": txtInteres.Text = "12"; break;
            }
        }

        // ============================================================
        //                BOTON GENERAR CUOTAS
        // ============================================================

        private void btnGenerarCuotas_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (!decimal.TryParse(txtMontoPrestamo.Text, out decimal monto))
            {
                MessageBox.Show("Monto inválido");
                return;
            }

            if (!decimal.TryParse(txtInteres.Text, out decimal tasaAnual))
            {
                MessageBox.Show("Interés inválido");
                return;
            }

            int cuotas = Convert.ToInt32(cmbNumCuotas.SelectedItem);
            DateTime fechaInicio = dtpFechaInicioPrestamo.Value;

            decimal tasaMensual = (tasaAnual / 100m) / 12m;

            // Fórmula Cuota Fija (Sistema Francés)
            decimal cuota = (monto * tasaMensual) /
                (1 - (decimal)Math.Pow((double)(1 + tasaMensual), -cuotas));

            txtMontoCuota.Text = cuota.ToString("N2");

            decimal totalIntereses = (cuota * cuotas) - monto;
            txtTotalInteres.Text = totalIntereses.ToString("N2");

            txtMontoPagar.Text = (monto + totalIntereses).ToString("N2");

            dtgvInfoCuotas.Rows.Clear();

            // Generar lista de cuotas
            for (int i = 1; i <= cuotas; i++)
            {
                fechaInicio = CalcularFechaProxima(fechaInicio, cmbFormaPago.SelectedItem.ToString());

                dtgvInfoCuotas.Rows.Add(
                    i,
                    fechaInicio.ToShortDateString(),
                    cuota.ToString("N2")
                );
            }
        }

        // ============================================================
        //         FUNCIÓN PARA CALCULAR FECHA SEGÚN FORMA PAGO
        // ============================================================

        private DateTime CalcularFechaProxima(DateTime fecha, string formaPago)
        {
            switch (formaPago)
            {
                case "Diario": return fecha.AddDays(1);
                case "Semanal": return fecha.AddDays(7);
                case "Quincenal": return fecha.AddDays(15);
                case "Mensual": return fecha.AddMonths(1);
                default: return fecha.AddMonths(1);
            }
        }

        // ============================================================
        //          BOTÓN SELECCIONAR CLIENTE (LO LLENARÁS LUEGO)
        // ============================================================

        private void btnSeleccionCliente_Click(object sender, EventArgs e)
        {
            FrmSeleccionarCliente frm = new FrmSeleccionarCliente();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Guardar ID del cliente
                _idClienteSeleccionado = frm.IdClienteSeleccionado;
                txtDocumento.Tag = frm.IdClienteSeleccionado;

                // Llenar campos del formulario
                txtNombreCompleto.Text = frm.NombreSeleccionado;
                txtDocumento.Text = frm.DocumentoSeleccionado;
                txtCiudad.Text = frm.CiudadSeleccionada;
                txtCorreo.Text = frm.CorreoSeleccionado;
                txtTelefono.Text = frm.TelefonoSeleccionado;
            }
        }

        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIONES
                if (txtDocumento.Tag == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente.");
                    return;
                }

                if (!decimal.TryParse(txtMontoPrestamo.Text, out decimal monto))
                {
                    MessageBox.Show("Monto inválido.");
                    return;
                }

                if (!decimal.TryParse(txtInteres.Text, out decimal tasaAnual))
                {
                    MessageBox.Show("Interés inválido.");
                    return;
                }

                if (!int.TryParse(cmbNumCuotas.SelectedItem.ToString(), out int cuotas))
                {
                    MessageBox.Show("Seleccione el número de cuotas.");
                    return;
                }

                int idCliente = Convert.ToInt32(txtDocumento.Tag);
                string tipoPrestamo = cmbTipoPrestamo.SelectedItem.ToString();
                DateTime fechaInicio = dtpFechaInicioPrestamo.Value;

                // CAPA NEGOCIO
                PrestamoNegocio prestamoNeg = new PrestamoNegocio();
                CuotaNegocio cuotaNeg = new CuotaNegocio();

                // 1️⃣ Guardar PRÉSTAMO (CORREGIDO)
                int idPrestamo = prestamoNeg.CrearPrestamo(
                    idCliente,
                    monto,
                    tasaAnual,
                    cuotas,
                    tipoPrestamo,
                    fechaInicio
                );

                // 2️⃣ CONVERTIR DGV → LISTA DE CUOTAS (CORREGIDO)
                List<CuotaModelo> listaCuotas = new List<CuotaModelo>();

                foreach (DataGridViewRow row in dtgvInfoCuotas.Rows)
                {
                    if (row.IsNewRow) continue;

                    listaCuotas.Add(new CuotaModelo
                    {
                        NumeroCuota = Convert.ToInt32(row.Cells["ColCuotaNumero"].Value),
                        MontoCuota = Convert.ToDecimal(row.Cells["ColMontoCuota"].Value),
                        FechaCobro = Convert.ToDateTime(row.Cells["ColFechaCobro"].Value)
                    });
                }

                // 3️⃣ Guardar CUOTAS (CORREGIDO)
                cuotaNeg.GuardarCuotas(idPrestamo, listaCuotas);

                MessageBox.Show("Préstamo registrado con éxito.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombreCompleto.Clear();
            txtDocumento.Clear();
            txtCiudad.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();

            txtMontoPrestamo.Clear();
            txtInteres.Clear();
            txtTotalInteres.Clear();
            txtMontoPagar.Clear();
            txtMontoCuota.Clear();

            cmbNumCuotas.SelectedIndex = 0;
            cmbTipoPrestamo.SelectedIndex = 0;

            dtgvInfoCuotas.Rows.Clear();
        }
    }
}

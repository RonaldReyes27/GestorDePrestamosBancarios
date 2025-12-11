using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresent
{
    public partial class FrmSeleccionarCliente : Form
    {
        private ClienteNegocio clienteNeg = new ClienteNegocio();

        // Valores que devolveremos al formulario principal
        public int IdClienteSeleccionado { get; private set; }
        public string NombreSeleccionado { get; private set; }
        public string DocumentoSeleccionado { get; private set; }
        public string CiudadSeleccionada { get; private set; }
        public string CorreoSeleccionado { get; private set; }
        public string TelefonoSeleccionado { get; private set; }

        public FrmSeleccionarCliente()
        {
            InitializeComponent();
            ConfigurarColumnas();
            ConfigurarFiltro();
            CargarClientes();
        }

        // =============================================
        // CREAR LAS COLUMNAS DEL DATAGRID
        // =============================================
        private void ConfigurarColumnas()
        {
            dgvSeleccionarCliente.AutoGenerateColumns = false;
            dgvSeleccionarCliente.Columns.Clear();

            dgvSeleccionarCliente.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColIdCliente",
                DataPropertyName = "IdCliente",
                HeaderText = "ID",
                Width = 60
            });

            dgvSeleccionarCliente.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColNombre",
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 150
            });

            dgvSeleccionarCliente.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColDocumento",
                DataPropertyName = "Cedula",
                HeaderText = "Documento",
                Width = 120
            });

            dgvSeleccionarCliente.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColCiudad",
                DataPropertyName = "Ciudad",
                HeaderText = "Ciudad",
                Width = 140
            });

            dgvSeleccionarCliente.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColCorreo",
                DataPropertyName = "CorreoElectronico",
                HeaderText = "Correo",
                Width = 160
            });

            dgvSeleccionarCliente.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColTelefono",
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Width = 120
            });

            // 🔥 ÚNICA columna de selección
            dgvSeleccionarCliente.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "ColSeleccionar",
                HeaderText = "Acción",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true,
                Width = 120
            });

            dgvSeleccionarCliente.CellClick += dgvSeleccionarCliente_CellClick;
        }

        // =============================================
        // CONFIGURAR COMBO DE FILTRO
        // =============================================
        private void ConfigurarFiltro()
        {
            cbBuscarPor.Items.Clear();
            cbBuscarPor.Items.Add("Nombre");
            cbBuscarPor.Items.Add("Documento");
            cbBuscarPor.Items.Add("Ciudad");
            cbBuscarPor.Items.Add("Correo");
            cbBuscarPor.Items.Add("Telefono");

            cbBuscarPor.SelectedIndex = 0;
        }

        private void AplicarFiltro()
        {
            string filtro = cbBuscarPor.SelectedItem.ToString();
            string valor = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(valor))
            {
                CargarClientes();
                return;
            }

            DataTable dt = clienteNeg.Buscar(filtro, valor);
            dgvSeleccionarCliente.DataSource = dt;
        }

        // =============================================
        // CARGAR CLIENTES
        // =============================================
        private void CargarClientes()
        {
            DataTable dt = clienteNeg.ListarClientes();
            dgvSeleccionarCliente.DataSource = dt;
        }

        // =============================================
        // BOTÓN BUSCAR (ICONO)
        // =============================================
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // =============================================
        // FILTRO AUTOMÁTICO
        // =============================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // =============================================
        // CUANDO SE PRESIONA EL BOTÓN "SELECCIONAR"
        // =============================================
        private void dgvSeleccionarCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvSeleccionarCliente.Columns[e.ColumnIndex].Name != "ColSeleccionar")
                return;

            DataGridViewRow row = dgvSeleccionarCliente.Rows[e.RowIndex];

            IdClienteSeleccionado = Convert.ToInt32(row.Cells["ColIdCliente"].Value);
            NombreSeleccionado = row.Cells["ColNombre"].Value.ToString();
            DocumentoSeleccionado = row.Cells["ColDocumento"].Value?.ToString() ?? "";
            CiudadSeleccionada = row.Cells["ColCiudad"].Value.ToString();
            CorreoSeleccionado = row.Cells["ColCorreo"].Value.ToString();
            TelefonoSeleccionado = row.Cells["ColTelefono"].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // =============================================
        // BOTÓN CANCELAR
        // =============================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresent.UserControls
{
    public partial class UC_Clientes : UserControl
    {
        ClienteNegocio negocio = new ClienteNegocio();

        public UC_Clientes()
        {
            InitializeComponent();
            this.Load += UC_Clientes_Load;
        }

        // ============================================================
        //      CONFIGURAR COLUMNAS DEL DATAGRIDVIEW POR CÓDIGO
        // ============================================================
        private void ConfigurarColumnas()
        {
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColId",
                HeaderText = "ID",
                DataPropertyName = "IdCliente"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColNombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColDocumento",
                HeaderText = "Documento",
                DataPropertyName = "Cedula"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColCiudad",
                HeaderText = "Ciudad",
                DataPropertyName = "Ciudad"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColCorreo",
                HeaderText = "Correo",
                DataPropertyName = "CorreoElectronico"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColTelefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColDireccion",
                HeaderText = "Dirección",
                DataPropertyName = "Direccion"
            });
        }

        // ============================================================
        //      CARGAR LISTA DE CLIENTES
        // ============================================================
        private void CargarListaClientes()
        {
            DataTable clientes = negocio.ListarClientes();
            dgvClientes.DataSource = clientes;
        }

        // ============================================================
        //      LOAD DEL USERCONTROL
        // ============================================================
        private void UC_Clientes_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();   // ← MUY IMPORTANTE
            CargarListaClientes();

            cbBuscarPor.Items.Clear();
            cbBuscarPor.Items.Add("Nombre");
            cbBuscarPor.Items.Add("Documento");
            cbBuscarPor.Items.Add("Ciudad");
            cbBuscarPor.SelectedIndex = 0;
        }

        // ============================================================
        //      NUEVO CLIENTE
        // ============================================================
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (FrmNuevoCliente frm = new FrmNuevoCliente())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarListaClientes();
                }
            }
        }

        // ============================================================
        //      BUSCAR CLIENTE
        // ============================================================
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
            {
                CargarListaClientes();
                return;
            }

            string columna = cbBuscarPor.SelectedItem.ToString() switch
            {
                "Nombre" => "Nombre",
                "Documento" => "Cedula",
                "Ciudad" => "Ciudad",
                _ => "Nombre"
            };

            DataTable dt = negocio.Buscar(columna, txtBuscar.Text.Trim());
            dgvClientes.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                dgvClientes.ClearSelection();
                dgvClientes.Rows[0].Selected = true;
            }
        }

        // BUSCAR AUTOMÁTICO
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscarCliente_Click(sender, e);
        }

        // ============================================================
        //      EVENTOS DE CELDAS (EDITAR / ELIMINAR)
        // ============================================================
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["ColId"].Value);

            // EDITAR
            if (e.ColumnIndex == dgvClientes.Columns["Editar"].Index)
            {
                FrmNuevoCliente frm = new FrmNuevoCliente(id);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarListaClientes();
                }
            }

            // ELIMINAR
            if (e.ColumnIndex == dgvClientes.Columns["Eliminar"].Index)
            {
                if (MessageBox.Show("¿Deseas eliminar este cliente?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    negocio.EliminarCliente(id);
                    CargarListaClientes();
                }
            }
        }
    }
}

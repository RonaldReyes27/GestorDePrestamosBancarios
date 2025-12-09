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

        // ============================================
        //      CARGAR TODOS LOS CLIENTES
        // ============================================
        private void CargarListaClientes()
        {
            DataTable dt = negocio.ListarClientes();
            dgvClientes.AutoGenerateColumns = false; // NECESARIO
            dgvClientes.DataSource = dt;
        }

        // ============================================
        //      LOAD DEL USERCONTROL
        // ============================================
        private void UC_Clientes_Load(object sender, EventArgs e)
        {
            CargarListaClientes();

            

            cbBuscarPor.Items.Clear();
            cbBuscarPor.Items.Add("Nombre");
            cbBuscarPor.Items.Add("Documento");
            cbBuscarPor.Items.Add("Ciudad");
            cbBuscarPor.SelectedIndex = 0;
        }

        // ============================================
        //      ABRIR FORM NUEVO CLIENTE
        // ============================================
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

        // ============================================
        //      BOTÓN BUSCAR
        // ============================================
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
            {
                CargarListaClientes();
                return;
            }

            string columna = "";

            switch (cbBuscarPor.SelectedItem.ToString())
            {
                case "Nombre":
                    columna = "Nombre";
                    break;

                case "Documento":
                    columna = "Cedula";  // ASAUME QUE GUARDAS CEDULA/PASAPORTE AQUÍ
                    break;

                case "Ciudad":
                    columna = "Ciudad";
                    break;
            }

            DataTable dt = negocio.Buscar(columna, txtBuscar.Text.Trim());

            dgvClientes.DataSource = dt;

            // Seleccionar primera fila encontrada
            if (dt.Rows.Count > 0)
            {
                dgvClientes.ClearSelection();
                dgvClientes.Rows[0].Selected = true;
            }
        }

        

        // ============================================
        //     BUSCAR AUTOMÁTICO AL ESCRIBIR
        // ============================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscarCliente_Click(sender, e);

        }

        // ============================================
        //     CLICK EN CELDAS (EDITAR / ELIMINAR)
        // ============================================
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["ColIdCliente"].Value);

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
                DialogResult r = MessageBox.Show(
                    "¿Deseas eliminar este cliente?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (r == DialogResult.Yes)
                {
                    negocio.EliminarCliente(id);
                    CargarListaClientes();
                }
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

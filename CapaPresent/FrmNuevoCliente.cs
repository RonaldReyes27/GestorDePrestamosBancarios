using System;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresent
{
    public partial class FrmNuevoCliente : Form
    {
        private int _idCliente = 0; // 0 = Nuevo, >0 = Editar

        // -------------------------------------------------------------
        // CONSTRUCTOR → NUEVO CLIENTE
        // -------------------------------------------------------------
        public FrmNuevoCliente()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------------
        // CONSTRUCTOR → EDITAR CLIENTE
        // -------------------------------------------------------------
        public FrmNuevoCliente(int idCliente)
        {
            InitializeComponent();
            _idCliente = idCliente;
            CargarDatosCliente();
        }

        // -------------------------------------------------------------
        // BOTÓN CANCELAR
        // -------------------------------------------------------------
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // -------------------------------------------------------------
        // CARGAR DATOS PARA EDICIÓN
        // -------------------------------------------------------------
        private void CargarDatosCliente()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            var dt = negocio.ObtenerClientePorId(_idCliente);

            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];

                txtNombre.Text = row["Nombre"].ToString();
                cbTipoDocumento.Text = row["TipoDocumento"].ToString(); // CORRECTO
                txtDocumento.Text = row["Cedula"].ToString();
                txtCiudad.Text = row["Ciudad"].ToString();
                txtDireccion.Text = row["Direccion"].ToString();
                txtEmail.Text = row["CorreoElectronico"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
            }
        }

        // -------------------------------------------------------------
        // BOTÓN GUARDAR
        // -------------------------------------------------------------
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Validación básica
            if (txtNombre.Text.Trim() == "" ||
                cbTipoDocumento.SelectedIndex == -1 ||
                txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Complete los campos obligatorios");
                return;
            }

            ClienteNegocio negocio = new ClienteNegocio();
            bool resultado = false;

            // ---------------------------------------------------------
            // NUEVO CLIENTE
            // ---------------------------------------------------------
            if (_idCliente == 0)
            {
                resultado = negocio.GuardarCliente(
                    txtNombre.Text.Trim(),
                    txtDocumento.Text.Trim(),      // Cedula / Pasaporte (número)
                    txtCiudad.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtTelefono.Text.Trim()
                );
            }
            // ---------------------------------------------------------
            // EDITAR CLIENTE EXISTENTE
            // ---------------------------------------------------------
            else
            {
                resultado = negocio.EditarCliente(
                    _idCliente,
                    txtNombre.Text.Trim(),
                    txtDocumento.Text.Trim(),
                    txtCiudad.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtTelefono.Text.Trim()
                );
            }

            // ---------------------------------------------------------
            // RESPUESTA
            // ---------------------------------------------------------
            if (resultado)
            {
                MessageBox.Show("Cliente guardado correctamente");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar cliente");
            }
        }
    }
}

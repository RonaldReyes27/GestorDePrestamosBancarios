using System;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresent
{
    public partial class FrmNuevoCliente : Form
    {
        private int _idCliente = 0;  // 0 = Nuevo | >0 = Editar

        // 🔹 Constructor para NUEVO cliente
        public FrmNuevoCliente()
        {
            InitializeComponent();
        }

        // 🔹 Constructor para EDITAR cliente
        public FrmNuevoCliente(int idCliente)
        {
            InitializeComponent();
            _idCliente = idCliente;
            CargarDatosCliente();
        }

        // 🔹 Botón Cancelar
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 🔹 Cargar datos cuando es EDICIÓN
        private void CargarDatosCliente()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            var dt = negocio.ObtenerClientePorId(_idCliente);

            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];

                txtNombre.Text = row["Nombre"].ToString();
                cbTipoDocumento.Text = row["Documento"].ToString();
                txtDocumento.Text = row["Cedula"].ToString();
                txtCiudad.Text = row["Ciudad"].ToString();
                txtDireccion.Text = row["Direccion"].ToString();
                txtEmail.Text = row["CorreoElectronico"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
            }
        }

        // 🔹 Botón GUARDAR
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Validación
            if (txtNombre.Text.Trim() == "" ||
                cbTipoDocumento.SelectedIndex == -1 ||
                txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Complete los campos obligatorios");
                return;
            }

            ClienteNegocio negocio = new ClienteNegocio();
            bool resultado = false;

            if (_idCliente == 0)
            {
                // ✔ Registrar cliente NUEVO
                resultado = negocio.GuardarCliente(
                    txtNombre.Text.Trim(),
                    cbTipoDocumento.Text,
                    txtDocumento.Text.Trim(),
                    txtCiudad.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtTelefono.Text.Trim()
                );
            }
            else
            {
                // ✔ Actualizar cliente EXISTENTE
                resultado = negocio.ActualizarCliente(
                    _idCliente,
                    txtNombre.Text.Trim(),
                    cbTipoDocumento.Text,
                    txtDocumento.Text.Trim(),
                    txtCiudad.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtTelefono.Text.Trim()
                );
            }

            // ✔ Respuesta
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

using CapaNegocios._01ClaseUsuarios;

namespace CapaPresent
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContraseña.Text.Trim();

            AccesoUsuario negocio = new AccesoUsuario();
            var resultado = negocio.Login(usuario, contrasena);

            if (resultado != null)
            {
                // LOGIN CORRECTO
                MessageBox.Show($"Bienvenido {resultado.NombreCompleto}\nRol: {resultado.Rol}",
                                "Acceso concedido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Abrir formulario principal
                FrmMenu menu = new FrmMenu();
                menu.Show();
                this.Hide();
            }
            else
            {
                // LOGIN INCORRECTO
                MessageBox.Show("Usuario o contraseña incorrectos",
                                "Acceso denegado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

        }
    }
}
    
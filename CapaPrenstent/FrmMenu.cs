using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresent
{
    public partial class FrmMenu : Form
    {
        bool menuExpandido = true;   // true = abierto; false = colapsado
        int menuAnchoMax = 230;
        int menuAnchoMin = 60;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }
        private void AjustarMenu()
        {
            if (panelMenu.Width <= menuAnchoMin)
            {
                btnInicio.Text = "";
                btnSolicitar.Text = "";
                btnCobrar.Text = "";
                btnHistorial.Text = "";
                btnClientes.Text = "";
            }
            else
            {
                btnInicio.Text = "   Inicio";
                btnSolicitar.Text = "   Solicitar Préstamo";
                btnCobrar.Text = "   Cobrar";
                btnHistorial.Text = "   Historial";
                btnClientes.Text = "   Clientes";
            }
        }

        private void MenuAnimacion_Tick(object sender, EventArgs e)
        {
            PanelContenedor.Controls.Clear();

            uc.Dock = DockStyle.Fill; // 🔥 Asegura ajuste perfecto
            PanelContenedor.Controls.Add(uc);

            uc.BringToFront();
            PanelContenedor.Update();

        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            MenuAnimacion.Start();

        }
        private void AbrirUC(UserControl uc)
        {
            PanelContenedor.Controls.Clear();

            uc.Dock = DockStyle.Fill; // 🔥 Asegura ajuste perfecto
            PanelContenedor.Controls.Add(uc);

            uc.BringToFront();
            PanelContenedor.Update();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirUC(new UserControls.UC_Clientes());
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            AbrirUC(new UserControls.UcNuevoPrestamo());
        }
    }
}

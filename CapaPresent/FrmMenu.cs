using CapaPresent.UserControls;
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
        private UC_Clientes clientesUC = new UC_Clientes();

        bool menuExpandido = true;   // true = abierto; false = colapsado
        int menuAnchoMax = 230;
        int menuAnchoMin = 60;

        public FrmMenu()
        {
            InitializeComponent();
            Uc_Inicio inicio = new Uc_Inicio();
            CargarUserControl(inicio);
        }
        private void CargarUserControl(UserControl uc)
        {
            PanelContenedor.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            PanelContenedor.Controls.Add(uc);
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


            if (menuExpandido)
            {
                // CONTRAYENDO
                panelMenu.Width -= 10;
                if (panelMenu.Width <= menuAnchoMin)
                {
                    menuExpandido = false;
                    MenuAnimacion.Stop();
                    AjustarMenu();
                }
            }
            else
            {
                // EXPANDIENDO
                panelMenu.Width += 10;
                if (panelMenu.Width >= menuAnchoMax)
                {
                    menuExpandido = true;
                    MenuAnimacion.Stop();
                    AjustarMenu();
                }
            }

            // 🔥 Esto arregla tu problema: reacomoda el contenedor en cada frame
            PanelContenedor.Left = panelMenu.Width;
            PanelContenedor.Width = this.Width - panelMenu.Width;
        }



        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            MenuAnimacion.Start();

        }
        private void AbrirUC(UserControl uc)
        {
            PanelContenedor.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            PanelContenedor.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirUC(new UserControls.UC_Clientes());
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            AbrirUC(new UserControls.UcNuevoPrestamo());
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            AbrirUC(new UserControls.UC_Cobrar());
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            AbrirUC(new UserControls.UC_HistorialPrestamos());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirUC(new UserControls.Uc_Inicio());
        }
    }
}

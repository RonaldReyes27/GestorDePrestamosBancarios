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
            if (menuExpandido)
            {
                // Contraer menú
                panelMenu.Width -= 10;
                if (panelMenu.Width <= menuAnchoMin)
                {
                    menuExpandido = false;
                    MenuAnimacion.Stop();
                }
            }
            else
            {
                // Expandir menú
                panelMenu.Width += 10;
                if (panelMenu.Width >= menuAnchoMax)
                {
                    menuExpandido = true;
                    MenuAnimacion.Stop();
                }
            }

            // Actualizar textos e iconos
            AjustarMenu();

        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            MenuAnimacion.Start();

        }
    }
}

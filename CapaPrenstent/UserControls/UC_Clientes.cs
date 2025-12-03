using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresent.UserControls
{
    public partial class UC_Clientes : UserControl
    {
        public UC_Clientes()
        {
            InitializeComponent();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (FrmNuevoCliente frm = new FrmNuevoCliente())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                   // CargarListaClientes();
                }
               
            }

        }
    }
}

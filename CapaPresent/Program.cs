using System;
using System.Windows.Forms;

namespace CapaPresent
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ARRANCAR SISTEMA DESDE EL MENU
            Application.Run(new FrmMenu());
        }
    }
}

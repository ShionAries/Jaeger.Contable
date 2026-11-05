using System;
using System.Windows.Forms;
using Jaeger.Contable.DataAccess.DependencyInjection;

namespace Jaeger.Contable {
    internal static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// La composición de dependencias se concentra en ContableApplication.
        /// </summary>
        [STAThread]
        static void Main() {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            try {
                using (var application = ContableApplication.Create()) {
                    System.Windows.Forms.Application.Run(new MainForm(application));
                }
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Jaeger.Bancos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ClinicaFrba
{
    public static class Globals
    {
        
        public static String userName = "0";
        public static string rolId = "";
        public static void irAtras(string menuAnterior, Form menuActual)
        {
            switch (menuAnterior)
            {
                case "Admin":
                    Menu_Principal.HomeAdmin home = new Menu_Principal.HomeAdmin();
                    home.Show();

                    break;

                case "Afiliado":
                    HomeAfiliado homeAf = new HomeAfiliado();
                    homeAf.Show();

                    break;

                case "Profesional":
                    Menu_Principal.HomeProfesional homeP = new Menu_Principal.HomeProfesional();
                    homeP.Show();
                    break;

                case "Custom":
                    Menu_Principal.HomeCustom homeC = new Menu_Principal.HomeCustom();
                    homeC.Show();
                    break;

                default:

                    break;

            }

            menuActual.Close();
        }
        public static DateTime getFechaActual()
        {
            return Convert.ToDateTime(ClinicaFrba.Properties.Settings.Default.FechaDelSistema.ToString("yyyy-MM-dd HH:mm "));
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);     
            Application.Run(new Login());
            
        }
    }
}

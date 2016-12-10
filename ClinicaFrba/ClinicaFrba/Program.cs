using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ClinicaFrba.Base_de_Datos;
namespace ClinicaFrba
{
    public static class Globals
    {
        public static List<string> listaFuncionalidades = new List<string>();
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

        public static void cargarFuncionalidades(int unIdRol)
        {

            string consultaFunc = "SELECT F.descripcion  FROM SELECT_GROUP.Funcionalidad F  JOIN Select_Group.Funcionalidad_Por_Rol FR ON FR.funcionalidad_idFuncionalidad = F.idFuncionalidad  JOIN Select_Group.Rol R ON FR.rol_idRol = R.idRol  WHERE idRol = " + unIdRol.ToString().Trim();
            DataTable lasFuncionalidades = new DataTable();
            Conexion.conectar();
            lasFuncionalidades = Conexion.LeerTabla(consultaFunc);

            foreach (DataRow unaFunc in lasFuncionalidades.Rows)
            {
                string nombreFunc = unaFunc["descripcion"].ToString();
                listaFuncionalidades.Add(nombreFunc);
            }

            
        }
        
        public static DateTime getFechaActual()
        {
            TimeSpan horaActual = new TimeSpan();
            horaActual = DateTime.Now.TimeOfDay;

            DateTime fechaActual = Convert.ToDateTime(ClinicaFrba.Properties.Settings.Default.FechaDelSistema.ToString("yyyy-MM-dd HH:mm ")) + horaActual;

            return fechaActual;
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

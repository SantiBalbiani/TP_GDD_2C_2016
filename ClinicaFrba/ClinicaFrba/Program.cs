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
            DataTable dt = new DataTable();
           // dt = DBSql.Query("select * from gd_esquema.Maestra");
           // foreach (DataRow dataRow in dt.Rows)
           // {
           //     foreach (var item in dataRow.ItemArray)
           //     {
           //         Console.WriteLine(item);
           //     }
           // }

         
            Application.Run(new Login());
            
        }
    }
}

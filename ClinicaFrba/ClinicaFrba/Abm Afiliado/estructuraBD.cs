using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace ClinicaFrba.Abm_Afiliado
{
    class estructuraBD
    {

        public static DataTable crearEstructuraAfiliado(DataTable afiliados) {
            DataColumn nombre = afiliados.Columns.Add("nombre", typeof(String));
            afiliados.Columns.Add("apellido", typeof(String));
            afiliados.Columns.Add("tipoDni", typeof(String));
            afiliados.Columns.Add("numeroDni", typeof(Int32));
            afiliados.Columns.Add("telefono", typeof(Int32));
            afiliados.Columns.Add("mail", typeof(String));
            afiliados.Columns.Add("fechaNac", typeof(DateTime));
            afiliados.Columns.Add("sexo", typeof(String));
            afiliados.Columns.Add("estadoCivil", typeof(String));
            afiliados.Columns.Add("direccion", typeof(String));
            afiliados.Columns.Add("usuarioId", typeof(Int32));
            afiliados.Columns.Add("planMed", typeof(Int32));

            return afiliados;
        
        }
    }
}

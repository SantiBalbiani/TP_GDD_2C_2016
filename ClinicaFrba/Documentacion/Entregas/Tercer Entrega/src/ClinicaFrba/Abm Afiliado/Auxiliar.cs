using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using ClinicaFrba.Base_de_Datos;
using System.Data.SqlClient;

namespace ClinicaFrba.Abm_Afiliado
{
    class Auxiliar
    {
        public static Boolean verificarDocumento(int numeroDocumento) {

            string query = "select AF.numeroDoc from SELECT_GROUP.Afiliado as AF where numeroDoc = ('" + numeroDocumento + "')";
            DataTable dt = Conexion.EjecutarComando(query);
            int cantidadFilas = dt.Rows.Count;
            if (cantidadFilas == 0)
            {
                return true;
            }
            else {
                return false;
            }
            
        
        
        }
    }
}

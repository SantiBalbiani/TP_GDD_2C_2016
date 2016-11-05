using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Base_de_Datos
{
    class Conexion
    {
        public static string parametros = ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString;
        //declarar una conexion llamada conexion ojo esta no es la misma que la clase E!! la diferencia esta en la c mayuscula y minuscula
        public static SqlConnection conexion;
        //vamos a validar que se conecte correctamente

        public static bool conectar()
        {
            bool conectado = false;
            //llenar la variable conexión con los parámetros de la variable parametros
            conexion = new SqlConnection(parametros);
            try
            {
                //abrir la conexion
                conexion.Open();
                conectado = true;
            }
            catch (InvalidCastException error)
            {
                conectado = false;
            }
            return conectado;
        }
        public static DataTable LeerTabla(string consulta)
        {
            SqlCommand cmd = new SqlCommand(consulta, conexion);

            // cmd.CommandText = consulta;
            //cmd.CommandType = CommandType.Text;

            DataSet dataSet = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {

                adapter.Fill(dataSet);
            }


            return dataSet.Tables[0];
            /* DataSet ds = new DataSet();
            DataTable dtresultado= new DataTable();
            if (conectar())
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                
                adaptador.Fill(ds);
                dtresultado = ds;
            }        
            return dtresultado;*/
        }
        public static int EjecutarComando(string sentencia)
        {
            int retorno = 0;
            if (conectar())
            {
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                retorno = comando.ExecuteNonQuery();
            }
            return retorno;
        }
    }
}
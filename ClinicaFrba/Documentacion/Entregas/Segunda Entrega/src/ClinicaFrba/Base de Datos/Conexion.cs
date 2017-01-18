using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Base_de_Datos;

namespace ClinicaFrba.Base_de_Datos
{
    class Conexion
    {
        
        public static string parametros = ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString;
        
        public static SqlConnection conexion;
        

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
            catch (InvalidCastException)
            {
                MessageBox.Show("Error al conectar la Base de datos");
                conectado = false;
            }
            return conectado;
        }
        public static DataTable LeerTabla(string consulta)
        {
            SqlCommand cmd = new SqlCommand(consulta, conexion);

            
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
        public static DataTable EjecutarComando(string sentencia)
        {
            DataTable retorno = new DataTable();
            SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2016;User=gd;password=gd2016;Integrated Security=True");
            SqlCommand comando = new SqlCommand(sentencia, conexion);
            SqlDataAdapter adap = new SqlDataAdapter(comando);
            adap.Fill(retorno);

            return retorno;
        }
    }
}
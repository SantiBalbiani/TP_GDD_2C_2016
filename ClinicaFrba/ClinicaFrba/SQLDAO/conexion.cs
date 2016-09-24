using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.SQL_DAO
{
    class Conexion
    {
        private SqlConnection miConexionSQL;
        private String miConnectionStringSQL;

        #region "Propiedades"

        public SqlConnection getMiConexionSQL()
        {
            return miConexionSQL;
        }

        public String getMiConnectionString()
        {
            return miConnectionStringSQL;
        }

        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor, toma el connectionString de la aplicacion
        /// </summary>
        /// <remarks></remarks>
        public Conexion()
        {
            miConexionSQL = new SqlConnection();
            miConnectionStringSQL = ClinicaFrba.Properties.Settings.Default.GD2C2016ConnectionString;
            miConexionSQL.ConnectionString = miConnectionStringSQL;
        }

        public Conexion(String _connectionString)
        {
            miConexionSQL = new SqlConnection();
            miConnectionStringSQL = _connectionString;
            miConexionSQL.ConnectionString = miConnectionStringSQL;
        }

        #endregion

        #region "Metodos"

        public SqlConnection conectar()
        {


            try
            {
                miConexionSQL.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return miConexionSQL;

        }

        public Boolean desconectar()
        {

            Boolean conexionOK = true;

            try
            {
                miConexionSQL.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexionOK = false;
            }

            return conexionOK;
        }

        public DataTable cargarTabla(SqlCommand miCommand)
        {
            DataTable ds = new DataTable();
            this.conectar();
            miCommand.Connection = miConexionSQL;
            miCommand.CommandType = CommandType.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(miCommand);
            dataAdapter.Fill(ds);
            this.desconectar();
            return ds;
        }



        public DataTable cargarCombo(SqlCommand cmd)
        {
            this.conectar();
            DataTable dt = new DataTable();
            cmd.Connection = miConexionSQL;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);
            this.desconectar();
            return dt;

        }
        public void ejecutarProcedur(ref SqlCommand miCommand)
        {
            this.conectar();
            miCommand.Connection = miConexionSQL;
            miCommand.CommandType = CommandType.StoredProcedure;
            miCommand.ExecuteNonQuery();
            this.desconectar();
        }

        public void ejecutarComando(SqlCommand miCommand)
        {
            this.conectar();
            miCommand.Connection = miConexionSQL;
            miCommand.CommandType = CommandType.Text;
            miCommand.ExecuteNonQuery();
            this.desconectar();
        }
        #endregion
    }
}
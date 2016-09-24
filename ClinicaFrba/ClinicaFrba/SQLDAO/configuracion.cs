using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Configuration;

namespace ClinicaFrba.SQL_DAO
{
    class Configuracion
    {
        public static int id_usuario_actual;
        public static int id_rol_actual;

        public static string getNombreAplicativo()
        {
            return ClinicaFrba.Properties.Settings.Default.NombreSistema;
        }

        public static DateTime getFechaActual()
        {
            return Convert.ToDateTime(ClinicaFrba.Properties.Settings.Default.fechaSistema.ToString("yyyy-MM-dd HH:mm "));
        }

        public static void CleanDataGrid(System.Windows.Forms.DataGridView dg)
        {

            while (dg.Rows.Count > 0)
            {
                dg.Rows.RemoveAt(0);
            }
        }
        public static DataTable GetDataSet(string ConnectionString, string SQL)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = SQL;
            da.SelectCommand = cmd;
            DataTable ds = new DataTable();


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                conn.Close();
            }

            return ds;
        }

        public static String encriptarSHA256(string cadena)
        {
            byte[] bytesPswd = Encoding.UTF8.GetBytes(cadena);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(bytesPswd);
            string encryptedPswd = BitConverter.ToString(hashedBytes).Replace("-", string.Empty).ToLower();
            return encryptedPswd;
        }

        public static String getSubstringUntil(String cadena, Char c)
        {
            int index = cadena.IndexOf(c);
            if (index > 0)
            {
                return cadena.Substring(0, index);
            }
            else return cadena;
        }
    }
}

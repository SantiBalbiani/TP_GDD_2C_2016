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
using ClinicaFrba.Base_de_Datos;
using System.Configuration;


 namespace ClinicaFrba.AbmRol
{ 
    public partial class asignarRolUser : Form
    {
        public asignarRolUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdRol = new SqlCommand("Select_Group.asignarRol", cnx);
            cmdRol.CommandType = CommandType.StoredProcedure;
            cmdRol.Parameters.Add("@username", SqlDbType.VarChar).Value = username.Text;
            cmdRol.Parameters.Add("@ROL", SqlDbType.VarChar).Value = rolDesasignar.Text;

           

            try
            {

                cnx.Open();
                cmdRol.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
                HomeAfiliado home = new HomeAfiliado();
                home.Show();
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void asignarRolUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnRolAsignar_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdRol = new SqlCommand("Select_Group.asignarRol", cnx);
            cmdRol.CommandType = CommandType.StoredProcedure;
            cmdRol.Parameters.Add("@username", SqlDbType.VarChar).Value = username.Text;
            cmdRol.Parameters.Add("@ROL", SqlDbType.VarChar).Value = rolAsignar.Text;
           

            try
            {

                cnx.Open();
                cmdRol.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
                HomeAfiliado home = new HomeAfiliado();
                home.Show();
                this.Close();
            }
        }
    }
}

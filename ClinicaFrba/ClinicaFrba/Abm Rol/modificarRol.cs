using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Base_de_Datos;
using System.Configuration;
using System.Data.SqlClient;

namespace ClinicaFrba.AbmRol
{
    public partial class modificarRol : Form
    {
        public modificarRol()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void modificarRol_Load(object sender, EventArgs e)
        {
            string query = "select r.nombre from SELECT_GROUP.Rol as r";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                comboBox1.Items.Add(Convert.ToString(fila["nombre"]));
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdUsuario = new SqlCommand("Select_Group.ModificarRol", cnx);
            cmdUsuario.CommandType = CommandType.StoredProcedure;
            cmdUsuario.Parameters.Add("@ROL_DESCRIP", SqlDbType.VarChar).Value = comboBox1.Text;
            cmdUsuario.Parameters.Add("@FUNCIONALIDAD_QUITAR", SqlDbType.VarChar).Value = checkedListBox1.Text;
            cmdUsuario.Parameters.Add("@FUNCIONALIDAD_AGREGAR", SqlDbType.VarChar).Value = textBox2.Text;
            try
            {

                cnx.Open();
                cmdUsuario.ExecuteNonQuery();
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

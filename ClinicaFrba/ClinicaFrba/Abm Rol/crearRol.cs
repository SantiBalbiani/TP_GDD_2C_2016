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
    public partial class crearRol : Form
    {
        public crearRol()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            Conexion.conectar();
            DataTable funcionalidades = new DataTable();

            string consultaStr = "select idFuncionalidad, descripcion from SELECT_GROUP.Funcionalidad";

            funcionalidades = Conexion.LeerTabla(consultaStr);

            DataTable nombreFuncionalidades = new DataTable();


            foreach (DataRow idFunc in funcionalidades.Rows)
            {
                ComboboxItem unaFuncionalidad = new ComboboxItem();

                unaFuncionalidad.Text = idFunc["descripcion"].ToString();
                unaFuncionalidad.Value = idFunc["idFuncionalidad"].ToString();

                checkedListBox1.Items.Add(unaFuncionalidad);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdRol = new SqlCommand("Select_Group.CrearRol", cnx);
            cmdRol.CommandType = CommandType.StoredProcedure;
            cmdRol.Parameters.Add("@ROL_DESCRIP", SqlDbType.VarChar).Value = textBox1.Text;
           // cmdRol.Parameters.Add("@FUNCIONALIDAD_DESCIP", SqlDbType.VarChar).Value = checkedListFuncionalidades.Text;

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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

       
         }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
}

}
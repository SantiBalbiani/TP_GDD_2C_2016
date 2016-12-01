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

namespace ClinicaFrba.Compra_Bono
{
    public partial class FrmComprarBonos : Form
    {
        public int precioBonoSegunPlan = 0;

        public FrmComprarBonos()
        {
            InitializeComponent();
        }

        private void FrmComprarBonos_Load(object sender, EventArgs e)
        {
            string consultaPlan = "SELECT idAfiliado, P.descripcion, P.precioDelBono_Consulta FROM Select_Group.Afiliado A JOIN Select_Group.Usuario U ON A.idUsuario = U.idUsuario AND U.nombreUsuario = '" + Globals.userName + "' JOIN Select_Group.Plan_Med P ON P.idPlan = plan_idPlan";
            string plan = " ";
            
            DataTable unUserName = new DataTable();

            
            Conexion.conectar();
            try
            {

                unUserName = Conexion.LeerTabla(consultaPlan);

                foreach (DataRow unUserN in unUserName.Rows)
                {
                   // Globals.userName = unUserN["idAfiliado"].ToString(); Me pa que va una global de afiliado... no se
                    plan = unUserN["descripcion"].ToString();
                    precioBonoSegunPlan = Int32.Parse(unUserN["precioDelBono_Consulta"].ToString());
                }


            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexion.conexion.Close();
                txtPlan.Text = plan;

            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdUsuario = new SqlCommand("Select_Group.ComprarBono", cnx);
            cmdUsuario.CommandType = CommandType.StoredProcedure;
            cmdUsuario.Parameters.Add("@userName", SqlDbType.VarChar).Value = Globals.userName;
            cmdUsuario.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad.Text;

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPlan_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = (precioBonoSegunPlan * (Convert.ToInt32(cantidad.Text))).ToString();
        }

        private void cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeAfiliado frmHome = new HomeAfiliado();
            frmHome.Show();
            this.Close();
        }



    }
}
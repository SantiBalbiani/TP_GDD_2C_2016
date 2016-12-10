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
        public string menuAnterior;
        public Form Home;
     
        public FrmComprarBonos()
        {
            InitializeComponent();
        //    flag = strFlag;
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
                if (plan == " ")
                {
                    MessageBox.Show("El número de Afiliado no existe, por favor intente nuevamente");
                    //Globals.irAtras(menuAnterior, this);
                    Home.Show();
                    this.Close();
                }

            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                SqlCommand cmdUsuario = new SqlCommand("Select_Group.ComprarBono", cnx);
                cmdUsuario.CommandType = CommandType.StoredProcedure;
                cmdUsuario.Parameters.Add("@userName", SqlDbType.VarChar).Value = Globals.userName;
                cmdUsuario.Parameters.Add("@cantidad", SqlDbType.Int).Value = txtCantidad.Text;
                cmdUsuario.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value = Globals.getFechaActual();
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
                    MessageBox.Show("Compra exitosa");
                    //Globals.irAtras(menuAnterior, this);
                    Home.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ingrese Cantidad de Bonos a comprar");
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
            if (txtCantidad.Text != "")
            {
                textBox1.Text = (precioBonoSegunPlan * (Convert.ToInt32(txtCantidad.Text))).ToString();
            }
            else
            {
                MessageBox.Show("Ingrese Cantidad de Bonos a comprar");
            }
        }


        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            txtCantidad.Text = txtCantidad.Text.Trim();
            txtCantidad.Text = txtCantidad.Text.Replace(" ", "");
            txtCantidad.SelectionStart = txtCantidad.Text.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Globals.irAtras(menuAnterior,this);
            Home.Show();
            this.Close();
            /*if (menuAnterior == "Admin")
                 {
                     Menu_Principal.HomeAdmin home = new Menu_Principal.HomeAdmin();
                     home.Show();
                     this.Close();
                 }
            if (menuAnterior == "Afiliado")
            {
                HomeAfiliado home = new HomeAfiliado();
                home.Show();
                this.Close();
            }*/
        }



    }
}
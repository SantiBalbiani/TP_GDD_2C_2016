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

namespace ClinicaFrba.Abm_Planes
{
    public partial class CambiarPlan : Form
    {
        public int idPlanMed = 0;
        public CambiarPlan(string strIdAfiliado)
        {
            InitializeComponent();
            textBox1.Text = strIdAfiliado;
        }
      


        private void CambiarPlan_Load(object sender, EventArgs e)
        {
            //Cargo el plan
            Conexion.conectar();
            cbmPlanMed.Items.Clear();
            cbmPlanMed.ResetText();
            cbmPlanMed.SelectedText = "Seleccione Nuevo Plan";
            DataTable Planes = new DataTable();
            string cadena = "select  idPlan, descripcion from SELECT_GROUP.Plan_Med";

            Planes = Conexion.LeerTabla(cadena);

            foreach (DataRow planes in Planes.Rows)
            {

                string desc = planes["descripcion"].ToString();
                ComboboxItem itemPlan = new ComboboxItem();

                itemPlan.Text = planes["descripcion"].ToString();
                itemPlan.Value = planes["idPlan"].ToString();

                cbmPlanMed.Items.Add(itemPlan);

            }
            Conexion.conexion.Close();
            // Fin de carga del plan

            // Comienzo carga Plan
            string consultaPlan = "select plan_idPlan from SELECT_GROUP.Afiliado where idAfiliado = " + textBox1.Text.ToString();
            string plan = " ";
            DataTable unUserName = new DataTable();
            Conexion.conectar();
            try
            {
                unUserName = Conexion.LeerTabla(consultaPlan);
                foreach (DataRow unUserN in unUserName.Rows)
                {
                  plan = unUserN["plan_idPlan"].ToString();
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
                    Menu_Principal.HomeAdmin frmMenu = new Menu_Principal.HomeAdmin();
                    frmMenu.Show();
                    this.Close();
                }
            }
            //Fin de Obtencion del plan

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdUsuario = new SqlCommand("Select_Group.ActualizarPlan", cnx);
            cmdUsuario.CommandType = CommandType.StoredProcedure;
            cmdUsuario.Parameters.Add("@idAfiliado", SqlDbType.Int).Value = textBox1.Text.ToString();

            Object itemGenerico = cbmPlanMed.SelectedItem;
            ComboboxItem itemCasteado = (ComboboxItem)itemGenerico;
            cmdUsuario.Parameters.Add("@idPlan", SqlDbType.Int).Value = itemCasteado.Value.ToString();

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
                MessageBox.Show("El Plan fue cambiado exitosamente!");
                cnx.Close();
                Menu_Principal.HomeAdmin home = new Menu_Principal.HomeAdmin();
                home.Show();
                this.Close();
            }
             
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbmPlanMed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Menu_Principal.HomeAdmin frmMenu = new Menu_Principal.HomeAdmin();
            frmMenu.Show();
            this.Close();
        }
    }
}

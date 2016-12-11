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
        public string menuAnterior;
        public Form Home;
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
            string consultaPlan = "select plan_idPlan from SELECT_GROUP.Afiliado where nroAfiliado = " + textBox1.Text.ToString();
            string consultaDescripcion = "select descripcion from Select_Group.Afiliado join select_group.Plan_Med on plan_idPlan=idPlan where nroAfiliado = " + textBox1.Text.ToString(); 
            string plan = " ";
            string descripcion = " ";
            DataTable unUserName = new DataTable();
            DataTable unUserName2 = new DataTable();
            Conexion.conectar();
            try
            {
                unUserName = Conexion.LeerTabla(consultaPlan);
                foreach (DataRow unUserN in unUserName.Rows)
                {
                  plan = unUserN["plan_idPlan"].ToString();
                  
                }

                unUserName2 = Conexion.LeerTabla(consultaDescripcion);
                foreach (DataRow unUserN2 in unUserName2.Rows)
                {
                    descripcion = unUserN2["descripcion"].ToString();

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
                txtPlanDescripcion.Text = descripcion;

                if (plan == " ")
                {
                    MessageBox.Show("El número de Afiliado no existe, por favor intente nuevamente");
                    Home.Show();
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

            //if (cbmPlanMed.SelectedValue.ToString() != "")
            //{
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                SqlCommand cmdUsuario = new SqlCommand("Select_Group.ActualizarPlan", cnx);
                cmdUsuario.CommandType = CommandType.StoredProcedure;
                cmdUsuario.Parameters.Add("@nroAfiliado", SqlDbType.Int).Value = textBox1.Text.ToString();
                Object itemGenerico = cbmPlanMed.SelectedItem;
                ComboboxItem itemCasteado = (ComboboxItem)itemGenerico;
                cmdUsuario.Parameters.Add("@idPlan", SqlDbType.Int).Value = txtPlanDescripcion.ToString();
                
                cmdUsuario.Parameters.Add("@motivo", SqlDbType.VarChar).Value = textBox4.Text.ToString().Trim();
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
                    MessageBox.Show("El Plan fue cambiado exitosamente!");
                    cnx.Close();
                    //Globals.irAtras(menuAnterior, this);
                    Home.Show();
                    this.Close();

                }
            //}
           // else {
           //     MessageBox.Show("Falta seleccionar Plan");
           // }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbmPlanMed_KeyPress(object sender, KeyPressEventArgs e)
        {
                      e.Handled = true;
        }

        private void cbmPlanMed_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            // Posible solucion, pero sigue dejando borrar -- cbmPlanMed.Enabled = false; 
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //Globals.irAtras(menuAnterior, this);
            Home.Show();
            this.Close();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtPlanDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

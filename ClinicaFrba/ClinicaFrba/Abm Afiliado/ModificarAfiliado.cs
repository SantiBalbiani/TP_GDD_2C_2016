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
namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        public string menuAnterior;
        public Form Home;

        public ModificarAfiliado()
        {
            InitializeComponent();
        }

        private void ModificarAfiliado_Load(object sender, EventArgs e)
        {
                       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consultaDatosAf = "SELECT [idAfiliado] ,[nombre] ,[apellido] ,[telefono],[mail] ,[sexo] ,[estadoCivil],[direccion]  FROM [Select_Group].[Afiliado] WHERE nroAfiliado =" + textBox1.Text.ToString().Trim();

            DataTable datosAfiliado = new DataTable();

            Conexion.conectar();

            datosAfiliado = Conexion.LeerTabla(consultaDatosAf);

            foreach (DataRow unAfi in datosAfiliado.Rows) 
            {
                textBox5.Text = (unAfi["nombre"].ToString()) + ", " + (unAfi["apellido"].ToString());
                tel.Text = unAfi["telefono"].ToString();
                mail.Text = unAfi["mail"].ToString();
                dir.Text = unAfi["direccion"].ToString();
                comboBox1.Text = unAfi["sexo"].ToString();
                comboBox2.Text = unAfi["estadoCivil"].ToString();
            }

            ComboboxItem masculino = new ComboboxItem();
            masculino.Text = "Masculino";
            masculino.Value = 1;


            ComboboxItem femenino = new ComboboxItem();
            femenino.Text = "Femenino";
            femenino.Value = 2;




            ComboboxItem casado = new ComboboxItem();
            casado.Text = "Casado";
            casado.Value = 1;


            ComboboxItem soltero = new ComboboxItem();
            soltero.Text = "soltero";
            soltero.Value = 2;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            comboBox1.Items.Add(masculino);
            comboBox1.Items.Add(femenino);
            comboBox2.Items.Add(casado);
            comboBox2.Items.Add(soltero);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ComboboxItem sexo = new ComboboxItem();
            sexo = (ComboboxItem)comboBox1.SelectedItem;

            ComboboxItem estCivil = new ComboboxItem();
            estCivil = (ComboboxItem)comboBox2.SelectedItem;
            
            string updateDatos = "UPDATE Select_Group.Afiliado SET telefono = " + tel.Text.ToString().Trim() + " ,mail = '" + mail.Text.ToString().Trim() + "',sexo = '" + comboBox1.Text.ToString().Trim() + "' ,estadoCivil = '" + comboBox2.Text.ToString().Trim() + "' ,direccion = '" + dir.Text.ToString().Trim() + "' WHERE nroAfiliado = " + textBox1.Text.ToString().Trim();
            SqlCommand cmdUpdAfi = new SqlCommand(updateDatos,Conexion.conexion);
            
            try
            {
            Conexion.conectar();
            cmdUpdAfi.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{
            Conexion.conexion.Close();
            MessageBox.Show("Afiliado Nro " + textBox1.Text.ToString().Trim()+" actualizado con éxito");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Globals.irAtras(menuAnterior, this);
            Home.Show();
            this.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

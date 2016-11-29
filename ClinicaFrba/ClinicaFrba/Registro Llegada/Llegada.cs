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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Llegada : Form
    {
        public Llegada()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTurno_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label4.Visible = true;
            label5.Visible = false;
            //Al tocar este boton se chequea si posee bonos dispobibles para realizar la consulta, y si tiene se habilitan las opciones, sino, se informa. 
               
            
     
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Llegada_Load(object sender, EventArgs e)
        {
            Conexion.conectar();
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            comboBox1.SelectedText = "Seleccione Especialidad";
        
            listBox1.ClearSelected();
            DataTable especialidades = new DataTable();
           
            string cadena = "select idEspecialidad, descripcion from SELECT_GROUP.Especialidad"; 

            especialidades = Conexion.LeerTabla(cadena);
            

            foreach (DataRow especialidad in especialidades.Rows)
            {

                    string desc = especialidad["descripcion"].ToString();
                    ComboboxItem itemEsp = new ComboboxItem();

                    itemEsp.Text = desc;
                    itemEsp.Value = especialidad["idEspecialidad"].ToString();

                    comboBox1.Items.Add(itemEsp);

                }
 
     
            Conexion.conexion.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.ResetText();
        }

        private void btnCargarProfesionales_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
            comboBox2.Items.Clear();
            comboBox2.ResetText();
            comboBox2.SelectedText = "Seleccione Profesional";
            
            DataTable profesionales = new DataTable();
            Object unItemEspecialidad = comboBox1.SelectedItem;
            ComboboxItem itemEspecialidad = (ComboboxItem)unItemEspecialidad;
            string consultaStr = "select profesional_idProfesional from SELECT_GROUP.Profesional_Por_Especialidad WHERE especialidad_idEspecialidad = '" + itemEspecialidad.Value.ToString() + "'";

            profesionales = Conexion.LeerTabla(consultaStr);

            DataTable nombreProfesionales = new DataTable();





            foreach (DataRow idProf in profesionales.Rows)
            {

                string consultaNyA = "select matricula, nombre, apellido from SELECT_GROUP.Profesional WHERE matricula = '" + idProf["profesional_idProfesional"].ToString() + "'";
                nombreProfesionales = Conexion.LeerTabla(consultaNyA);

                foreach (DataRow filaNombreProf in nombreProfesionales.Rows)
                {


                    string profesional = filaNombreProf["nombre"].ToString() + ", " + filaNombreProf["apellido"].ToString();
                    ComboboxItem itemProf = new ComboboxItem();

                    itemProf.Text = profesional;
                    itemProf.Value = filaNombreProf["matricula"].ToString();

                    comboBox2.Items.Add(itemProf);

                }

            }


            Conexion.conexion.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
        
    }
}

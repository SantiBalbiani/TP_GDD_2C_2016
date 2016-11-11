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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class FrmSolTurno : Form
    {
        public FrmSolTurno()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            listView1.Clear();
            DateTime fechaElegida;
            fechaElegida = monthCalendar1.SelectionEnd;
            string[] arr = new string[2];
            ListViewItem itm;
            listView1.Columns.Add("Fecha", 100);
            listView1.Columns.Add("Hora Disponible", 150);
            
            //Llamar SP de hs disponibles

            arr[0] = fechaElegida.ToString();
            arr[1] = "16:00";
            

            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);

            

            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion.conectar();
            comboBox3.Items.Clear();
            comboBox3.ResetText();
            comboBox3.SelectedText = "Seleccione Profesional";
            
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

                    comboBox3.Items.Add(itemProf);

                }

            }


            Conexion.conexion.Close();
        }

        private void FrmSolTurno_Load(object sender, EventArgs e)
        {
            Conexion.conectar();

            DataTable especialidades = new DataTable();
            string cadena = "select idTipo, descripcion from SELECT_GROUP.Tipo_Especialidad";

            especialidades = Conexion.LeerTabla(cadena);

            foreach (DataRow fila in especialidades.Rows)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = fila["descripcion"].ToString();
                item.Value = fila["idTipo"];
                comboBox2.Items.Add(item);
               


            }
            Conexion.conexion.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion.conectar();
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            comboBox1.SelectedText = "Seleccione Especialidad";
            comboBox3.Items.Clear();
            comboBox3.ResetText();
            comboBox3.SelectedText = "Seleccione Profesional";
            DataTable especialidades = new DataTable();
            Object unItem = comboBox2.SelectedItem;
            ComboboxItem unItemCasteado = (ComboboxItem)unItem;
            string cadena = "select idEspecialidad, descripcion from SELECT_GROUP.Especialidad WHERE idTipoEspecialidad = '" + unItemCasteado.Value.ToString() + "'"; 

            especialidades = Conexion.LeerTabla(cadena);
            //DataTable unProfesionaDeUnaEspecialidad = new DataTable();

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

        private void button1_Click(object sender, EventArgs e)
        {
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeAfiliado frmHome = new HomeAfiliado();
            frmHome.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

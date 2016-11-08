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
                comboBox2.SelectedIndex = 0;


            }
            Conexion.conexion.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion.conectar();

            DataTable profesionalesDeUnaEspecialidad = new DataTable();
            string cadena = "select profesional_idProfesional from SELECT_GROUP.Profesional_Por_Especialidad WHERE especialidad_idEspecialidad = '" + comboBox2.SelectedIndex.ToString() + "'"; 

            profesionalesDeUnaEspecialidad = Conexion.LeerTabla(cadena);
            DataTable unProfesionaDeUnaEspecialidad = new DataTable();

            foreach (DataRow filaProfId in profesionalesDeUnaEspecialidad.Rows)
            {

                string cadena2 = "select nombre, apellido from SELECT_GROUP.Profesional WHERE matricula = '" + filaProfId["profesional_idProfesional"].ToString() + "'";
                
                unProfesionaDeUnaEspecialidad = Conexion.LeerTabla(cadena2);
                foreach (DataRow filaNombreProf in unProfesionaDeUnaEspecialidad.Rows){


                    string profesional = filaNombreProf["nombre"].ToString() + ", " + filaNombreProf["apellido"].ToString();
                    ComboboxItem itemProf = new ComboboxItem();

                    itemProf.Text = profesional;
                    itemProf.Value = filaProfId["profesional_idProfesional"].ToString();

                    comboBox1.Items.Add(itemProf);

                }

            }
            Conexion.conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
        }
    }
}

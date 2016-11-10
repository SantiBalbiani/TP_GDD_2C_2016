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
            DataTable profesionales = new DataTable();
            Object unItemEspecialidad = comboBox1.SelectedItem;
            ComboboxItem itemEspecialidad = (ComboboxItem)unItemEspecialidad;




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

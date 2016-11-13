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
            DateTime fechaActual = DateTime.Now;
            if((DateTime.Compare(fechaElegida, fechaActual))>= 0)
            {

            


            int diaSemana = (int)fechaElegida.DayOfWeek;       
            
            listView1.Columns.Add("Fecha", 500);
            listView1.Columns.Add("Hora Disponible", 550);
     
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdUsuario = new SqlCommand("Select_Group.sp_getDiasDisponibles", cnx);
            cmdUsuario.CommandType = CommandType.StoredProcedure;
            cmdUsuario.Parameters.Add("@Dia", SqlDbType.Int).Value = diaSemana;
            ComboboxItem profesional = (ComboboxItem)comboBox3.SelectedItem;
            cmdUsuario.Parameters.Add("@idProfesional", SqlDbType.Int).Value = profesional.Value;

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
                string desde = "0";
                string hasta= "0";
                DataTable diasDisponibles = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(cmdUsuario);
                adaptador.Fill(diasDisponibles);

                foreach (DataRow diaDisponible in diasDisponibles.Rows)
                {
                    desde = diaDisponible["horaDesde"].ToString();
                    hasta = diaDisponible["horaHasta"].ToString();
                }

                cnx.Close();
                if (desde != "0") //Profesional no trabaja ese día
                {

                    int horaDesd = Int32.Parse(desde);
                    int horaHasta = Int32.Parse(hasta);
                    int cantidadTurnos = ((horaHasta - horaDesd) / 100 * 60) / 30;

                    TimeSpan primerTurno = new TimeSpan((horaDesd / 100), (horaDesd % 100), 0);

                    TimeSpan intervaloDeTurno = new TimeSpan(0, 30, 0);

                    TimeSpan[] horarioTurnos = new TimeSpan[cantidadTurnos + 1];

                    for (int i = 0; i <= cantidadTurnos; i++)
                    {
                        horarioTurnos[i] = new TimeSpan(0, 0, 0);
                        horarioTurnos[i] = horarioTurnos[i].Add(primerTurno);
                        primerTurno = primerTurno.Add(intervaloDeTurno);
                    }



                    foreach (TimeSpan turno in horarioTurnos)
                    {
                        listView1.Items.Add(turno.ToString());
                    }

                }

            }
              
            }

            
            
            
            

            
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
            listView1.Clear();
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
            listView1.Clear();
            DataTable especialidades = new DataTable();
            Object unItem = comboBox2.SelectedItem;
            ComboboxItem unItemCasteado = (ComboboxItem)unItem;
            string cadena = "select idEspecialidad, descripcion from SELECT_GROUP.Especialidad WHERE idTipoEspecialidad = '" + unItemCasteado.Value.ToString() + "'"; 

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
            listView1.Clear();
        }
    }
}

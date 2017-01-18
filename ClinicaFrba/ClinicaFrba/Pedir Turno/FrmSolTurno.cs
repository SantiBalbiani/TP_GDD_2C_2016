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
        public static String idAgenda = "0";
        public string menuAnterior;
        public Form Home;

        public FrmSolTurno()
        {
            InitializeComponent();
        }

        public static double horasTrabajadas(int matricula, DateTime fechaElegida)
        {
            
            
            int diaSem = (int)fechaElegida.DayOfWeek;
            DateTime comienzoSemana = fechaElegida.AddDays(-diaSem);
            DateTime finSemana = comienzoSemana.AddDays(6);
            double cantHoras = 0;
            DataTable horasT = new DataTable();
            Globals.getFechaActual().ToString("MM/dd/yyyy HH:mm");
            Conexion.conectar();
            string consHorasT = "SELECT ((count(*)*30)/60) AS 'cantidadHoras' FROM [SELECT_GROUP].[Agenda] A JOIN Select_Group.Agenda_Detalle D ON D.idAgenda = A.idAgenda WHERE A.profesional_idProfesional = 1000 AND D.estaCancelado = 0 AND D.fecha_Hora_Turno BETWEEN '" + comienzoSemana.ToString("MM/dd/yyyy HH:mm") + "' AND '" + finSemana.ToString("MM/dd/yyyy HH:mm") + "'";
            horasT = Conexion.LeerTabla(consHorasT);

            foreach (DataRow unaCantHora in horasT.Rows) 
            {
                cantHoras = Convert.ToDouble(unaCantHora["cantidadHoras"].ToString());
            }

            

            return cantHoras;

        }

        private static bool esMenor(TimeSpan horarioTurno) 
        {
            TimeSpan horaActual = Globals.getFechaActual().TimeOfDay;
            return horarioTurno < horaActual;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            button1.Enabled = false;
            listView1.Clear();
            DateTime fechaElegida;
            fechaElegida = monthCalendar1.SelectionEnd;
            DateTime fechaActual = Globals.getFechaActual();
            //DateTime fechaActual = DateTime.Now;
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
            ComboboxItem espec = (ComboboxItem)comboBox1.SelectedItem;
            cmdUsuario.Parameters.Add("@especialidad", SqlDbType.Int).Value = espec.Value;
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
                cnx.Close();
                foreach (DataRow diaDisponible in diasDisponibles.Rows)
                {
                    desde = diaDisponible["horaDesde"].ToString();
                    hasta = diaDisponible["horaHasta"].ToString();
                    idAgenda = diaDisponible["idAgenda"].ToString();
                }

                
                if (desde != "0") //Si es False, el Profesional no trabaja ese día
                {

                    int horaDesd = Int32.Parse(desde);
                    int horaHasta = Int32.Parse(hasta);
                    int cantidadTurnos = ((horaHasta - horaDesd) / 100 * 60) / 30;

                    TimeSpan primerTurno = new TimeSpan((horaDesd / 100), (horaDesd % 100), 0);

                    TimeSpan intervaloDeTurno = Globals.intervaloTurno;

                    TimeSpan[] horarioTurnos = new TimeSpan[cantidadTurnos + 1];

                    for (int i = 0; i <= cantidadTurnos; i++)
                    {
                        horarioTurnos[i] = new TimeSpan(0, 0, 0);
                        horarioTurnos[i] = horarioTurnos[i].Add(primerTurno);
                        primerTurno = primerTurno.Add(intervaloDeTurno);
                    }

                    Conexion.conectar();
                    DataTable turnosTomados = new DataTable();
                    string fechaTurnoSinHoraElegida = fechaElegida.Date.ToString("yyyyMMdd");

                    string queryTurnosTomados = "SELECT fecha_Hora_Turno FROM Select_Group.Agenda_Detalle WHERE CAST(fecha_Hora_Turno AS date) = " + "'" + fechaTurnoSinHoraElegida + "'" + " AND idAgenda = " + idAgenda ;

                    turnosTomados = Conexion.LeerTabla(queryTurnosTomados);

                    
                    string turnoOcupado;
                    DateTime fechaTurnoOcupado;
                    TimeSpan horaTurnoOcupado;

                    var listaHorarios = horarioTurnos.ToList();

                  

                    foreach (DataRow turnoTomado in turnosTomados.Rows)
                    {
                        turnoOcupado = turnoTomado["fecha_Hora_Turno"].ToString();
                        fechaTurnoOcupado = DateTime.Parse(turnoOcupado);
                        horaTurnoOcupado = fechaTurnoOcupado.TimeOfDay;

                        listaHorarios.Remove(horaTurnoOcupado);

                    }

                    //Remuevo horarios que ya pasaron
                    listaHorarios.RemoveAll(esMenor);

                    listaHorarios.Remove(listaHorarios.Last());


                    foreach (TimeSpan turno in listaHorarios)
                    {
                        listView1.Items.Add(turno.ToString());
                    }

                }

            }
              
            }

            
            
            
            

            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
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
            button1.Enabled = false;
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

            ComboboxItem profElected = new ComboboxItem();
            profElected = (ComboboxItem)comboBox3.SelectedItem;
            DateTime fechaSelected = monthCalendar1.SelectionEnd;
            double cantHoras = horasTrabajadas(Convert.ToInt32(profElected.Value), fechaSelected);

            if (cantHoras < 48)
            {




                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                SqlCommand cmdUsuario = new SqlCommand("Select_Group.sp_Reservar_Turno", cnx);
                cmdUsuario.CommandType = CommandType.StoredProcedure;

                DateTime turnoAReservar = monthCalendar1.SelectionEnd;
                string strHoraElegida = listView1.SelectedItems[0].Text.ToString();
                TimeSpan horaElegida = TimeSpan.Parse(strHoraElegida);

                turnoAReservar = turnoAReservar.Date + horaElegida;

                cmdUsuario.Parameters.Add("@fechaHoraTurno", SqlDbType.DateTime).Value = turnoAReservar;
                cmdUsuario.Parameters.Add("@idAgenda", SqlDbType.Int).Value = idAgenda;
                cmdUsuario.Parameters.Add("@userName", SqlDbType.VarChar).Value = Globals.userName;

                Object unItemEspecialidad = comboBox1.SelectedItem;
                ComboboxItem itemEspecialidad = (ComboboxItem)unItemEspecialidad;
                cmdUsuario.Parameters.Add("@especialidad", SqlDbType.Int).Value = itemEspecialidad.Value;
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
                    string profesional = comboBox3.SelectedText;
                    MessageBox.Show("Turno Agendado con el Dr. " + comboBox3.SelectedItem.ToString() + " para el " + turnoAReservar.ToString() + " con éxito!");
                    this.Close();
                    //HomeAfiliado frmHome = new HomeAfiliado();
                    Home.Show();
                }
            }
            else
            {
                MessageBox.Show("El Profesional ya ha alcanzado su disponibilidad de 48 hs semanales. Por favor elija otro profesional u otra semana");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Globals.irAtras(menuAnterior, this);
            Home.Show();
            this.Close();
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            listView1.Clear();
            monthCalendar1.Enabled = true;
        }
    }
}

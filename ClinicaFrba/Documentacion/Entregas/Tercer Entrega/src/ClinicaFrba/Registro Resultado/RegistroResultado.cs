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
using ClinicaFrba.Menu_Principal;
using System.Configuration;
using System.Data.SqlClient;


namespace ClinicaFrba.Registro_Resultado
{
    public partial class RegistroResultado : Form
    {
        public string menuAnterior;
        public Form home;
        public RegistroResultado(string unTurno, string idProfesional, string afiliado)
        {
            InitializeComponent();
            idTurno = unTurno;
            idProf = idProfesional;
            idAfiliado = afiliado;
        }


    public string idProf = "0";
    public string idTurno = "0";

    public string idAfiliado = "0";


    public Form Home;


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegistroResultado_Load(object sender, EventArgs e)
        {
            

            /*TimeSpan intervaloDeTurno = new TimeSpan(45, 30, 0);
            //DateTime intervaloTurnoMax = DateTime.Now + intervaloDeTurno;
            //DateTime intervaloTurnoMin = DateTime.Now - intervaloDeTurno;
            DateTime intervaloTurnoMax = Globals.getFechaActual() + intervaloDeTurno;
            DateTime intervaloTurnoMin = Globals.getFechaActual() - intervaloDeTurno;
            string estadoTurno = "0";
            string idAfiliado = "0";*/
            

            
            // se presupone que un profesional no atiende mas de un Afiliado al mismo tiempo.
            /*
            string consultaTurnoActual = "SELECT TOP 1 T.idTurno, T.afiliado_idAfiliado, T.estado FROM Select_Group.Turno T JOIN Select_Group.Agenda A ON A.idAgenda = T.idAgenda AND A.profesional_IdProfesional = "+ idProf +" WHERE fechaTurno BETWEEN '" + intervaloTurnoMin.ToString("MM/dd/yyyy hh:mm tt") + "' AND '" + intervaloTurnoMax.ToString("MM/dd/yyyy hh:mm tt") + "' ORDER BY fechaTurno ASC";
            
            Conexion.conectar();
            DataTable turnoActual = new DataTable();
            */

            try
            {

                

                DataTable unAfiliado = new DataTable();
                string nombreAfiliado = " ";
                string apellidoAfiliado = " ";

                if (idAfiliado != "0")
                {

                    string consultaNombreAfiliado = "SELECT nombre, apellido FROM Select_Group.Afiliado WHERE idAfiliado = " + idAfiliado;

                    unAfiliado = Conexion.LeerTabla(consultaNombreAfiliado);

                    foreach (DataRow unNomAfiliado in unAfiliado.Rows)
                    {
                        nombreAfiliado = unNomAfiliado["nombre"].ToString();
                        apellidoAfiliado = unNomAfiliado["apellido"].ToString();

                    }

                    label5.Text = nombreAfiliado + ", " + apellidoAfiliado;

                }
                else 
                {
                    MessageBox.Show("No hay turnos disponibles");
                    
                    HomeProfesional frmHome = new HomeProfesional();
                    frmHome.Show();
                    this.Close();
                }
            
            
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexion.conexion.Close();
               
            }
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdUsuario = new SqlCommand("Select_Group.sp_guardarDiagnostico", cnx);
            cmdUsuario.CommandType = CommandType.StoredProcedure;

            cmdUsuario.Parameters.Add("@sintomas", SqlDbType.VarChar).Value = textBox1.Text;
            cmdUsuario.Parameters.Add("@enfermedades", SqlDbType.VarChar).Value = textBox2.Text;
            cmdUsuario.Parameters.Add("@idTurno", SqlDbType.Int).Value = idTurno;
            cmdUsuario.Parameters.Add("@fechaActual", SqlDbType.DateTime).Value =Globals.getFechaActual();

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
                MessageBox.Show("Diagnostico procesado con éxito!");                
                cnx.Close();
                Home.Show();
                this.Close();
                //Volver al cuadro anterior
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "NO SE COMPLETO DIAGNOSTICO";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Globals.irAtras(menuAnterior, this);
            Home.Show();
            this.Close();
        }
    }
}

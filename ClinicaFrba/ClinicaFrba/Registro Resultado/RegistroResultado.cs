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
        public RegistroResultado()
        {
            InitializeComponent();
        }

    public string idTurno = "0";

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
            //Llamar SP que levante el turno y cargar los datos

            TimeSpan intervaloDeTurno = new TimeSpan(45, 30, 0);
            DateTime intervaloTurnoMax = DateTime.Now + intervaloDeTurno;
            DateTime intervaloTurnoMin = DateTime.Now - intervaloDeTurno;
            string estadoTurno = "0";
            string idAfiliado = "0";
            string consultaTurnoActual = "SELECT TOP 1 idTurno, afiliado_idAfiliado, estado FROM Select_Group.Turno WHERE fechaTurno BETWEEN '" + intervaloTurnoMin.ToString("MM/dd/yyyy hh:mm tt") + "' AND '" + intervaloTurnoMax.ToString("MM/dd/yyyy hh:mm tt") + "' ORDER BY fechaTurno ASC";
            string nombreAfiliado = " ";
            string apellidoAfiliado = " ";
            Conexion.conectar();
            DataTable turnoActual = new DataTable();
            DataTable unAfiliado = new DataTable();

            try
            {

                turnoActual = Conexion.LeerTabla(consultaTurnoActual);

                foreach (DataRow unTurno in turnoActual.Rows)
                {
                    idTurno = unTurno["idTurno"].ToString();
                    idAfiliado = unTurno["afiliado_idAfiliado"].ToString();
                    estadoTurno = unTurno["estado"].ToString();

                }

                string consultaNombreAfiliado = "SELECT nombre, apellido FROM Select_Group.Afiliado WHERE idAfiliado = " + idAfiliado;

                unAfiliado = Conexion.LeerTabla(consultaNombreAfiliado);

                foreach (DataRow unNomAfiliado in unAfiliado.Rows)
                {
                    nombreAfiliado = unNomAfiliado["nombre"].ToString();
                    apellidoAfiliado = unNomAfiliado["apellido"].ToString();
                    
                }

                label5.Text = nombreAfiliado + ", " + apellidoAfiliado;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexion.conexion.Close();
               
            }
            if ((nombreAfiliado == " ") || (estadoTurno == "1") || (estadoTurno == "2"))
            {
                MessageBox.Show("No hay turno agendado en este horario");

                this.Hide();
                
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
    }
}

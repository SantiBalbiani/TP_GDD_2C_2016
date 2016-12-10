using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria;
using System.Data.SqlClient;
using ClinicaFrba.Base_de_Datos;
using System.Configuration;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class FrmRegistroAgenda : Form
    {
        public Form Home;

        public FrmRegistroAgenda()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Conexion.conectar();
            SqlConnection conexion;
            bool conectado = false;
            //llenar la variable conexión con los parámetros de la variable parametros
            string parametros = ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString;
            conexion = new SqlConnection(parametros);
            try
            {
                //abrir la conexion
                conexion.Open();
                conectado = true;
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Error al conectar la Base de datos");
                conectado = false;
            }


            if (conectado == true)
            {

                try
                {
                     //valido que no ingrese dos agendas en un mismo horarios
                    using (SqlCommand cmdRol2 = new SqlCommand("SELECT COUNT(*) from select_group.Agenda where Agenda.profesional_idProfesional = @matricula and Agenda.diaDisponible =@dia and Agenda.horaDesde =@desde and Agenda.horaHasta = @hasta", conexion))
                    {
                        cmdRol2.Parameters.AddWithValue("@matricula", matriculaText.Text);
                        cmdRol2.Parameters.AddWithValue("@dia", diaSemanaText.Text);
                        cmdRol2.Parameters.AddWithValue("@desde", horaDesdeText.Text);
                        cmdRol2.Parameters.AddWithValue("@hasta", horaHastaText.Text);

                        int userCount = (int) cmdRol2.ExecuteScalar();

                        if (userCount == 0)
                        {
                            SqlCommand cmdRol = new SqlCommand("insert into Select_group.Agenda (profesional_idProfesional, diaDisponible, horaDesde, horaHasta) values (@matricula, @dia, @desde, @hasta) ", conexion);
                            cmdRol.Parameters.AddWithValue("@matricula", matriculaText.Text);
                            cmdRol.Parameters.AddWithValue("@dia", diaSemanaText.Text);
                            cmdRol.Parameters.AddWithValue("@desde", horaDesdeText.Text);
                            cmdRol.Parameters.AddWithValue("@hasta", horaHastaText.Text);

                            cmdRol.ExecuteNonQuery();

                            MessageBox.Show("Nueva Agenda creada con exito");
                            Conexion.conexion.Close();
                        }

                        else {

                            MessageBox.Show("Ya existe una agenda en ese dia y horario. Por favor, elija otros valores");
                        }
                    }

                    
                     
                   }
                  
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Home.Show();
            this.Close();
        }
    }
}

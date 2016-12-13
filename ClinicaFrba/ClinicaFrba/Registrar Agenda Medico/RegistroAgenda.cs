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
            int horaDesd = Convert.ToInt32(horaDesdeText.Text.ToString().Trim());
            int horaHasta = Convert.ToInt32(horaHastaText.Text.ToString().Trim());
            
            Menu_Principal.HomeProfesional homeProf = new Menu_Principal.HomeProfesional();
            homeProf = (Menu_Principal.HomeProfesional)Home;

            if (((diaSemanaText.Text == "0") || (horaDesd < 700) || (horaHasta > 2000) || ((horaDesd < 1000)))|| (( (diaSemanaText.Text == "6")) || ((horaHasta > 1500) && (diaSemanaText.Text == "6"))))
            {
                MessageBox.Show("Agenda fuera del horario de atención. Horario de atención: 7 a 20 hs lunes a viernes y 10 a 15 hs sabados.");
            }else{
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
                    //1//valido que no ingrese dos agendas en un mismo horarios
                    using (SqlCommand cmdRol2 = new SqlCommand("SELECT COUNT(*) from select_group.Agenda where Agenda.profesional_idProfesional = @matricula and Agenda.diaDisponible =@dia and Agenda.horaDesde =@desde and Agenda.horaHasta = @hasta", conexion))
                    {

                        




                        cmdRol2.Parameters.AddWithValue("@matricula", homeProf.idProf);
                        cmdRol2.Parameters.AddWithValue("@dia", diaSemanaText.Text);
                        cmdRol2.Parameters.AddWithValue("@desde", horaDesdeText.Text);
                        cmdRol2.Parameters.AddWithValue("@hasta", horaHastaText.Text);

                        int userCount = (int)cmdRol2.ExecuteScalar();

                        //si no lo encontro en la base esa agenda igual, que lo inserte
                        if (userCount == 0)
                        {
                            SqlCommand cmdRol = new SqlCommand("insert into Select_group.Agenda (profesional_idProfesional, diaDisponible, horaDesde, horaHasta) values (@matricula, @dia, @desde, @hasta) ", conexion);
                            cmdRol.Parameters.AddWithValue("@matricula", homeProf.idProf);
                            cmdRol.Parameters.AddWithValue("@dia", diaSemanaText.Text);
                            cmdRol.Parameters.AddWithValue("@desde", horaDesdeText.Text);
                            cmdRol.Parameters.AddWithValue("@hasta", horaHastaText.Text);

                            cmdRol.ExecuteNonQuery();

                            MessageBox.Show("Nueva Agenda creada con exito");
                            Conexion.conexion.Close();
                        }

                        else
                        {
                            //si lo encontro, que no lo deje y cambie los dias.
                            MessageBox.Show("Ya existe una agenda en ese dia y horario. Por favor, elija otro dia u otro horario");
                        }

                        //2//Valido que su agenda no se encuentre dentro del horario de otra agenda
                        using (SqlCommand cmdRol3 = new SqlCommand("SELECT COUNT(*) from select_group.Agenda where Agenda.profesional_idProfesional = @matricula and Agenda.diaDisponible =@dia and Agenda.horaDesde >@desde and Agenda.horaHasta < @hasta", conexion))
                        {
                            cmdRol3.Parameters.AddWithValue("@matricula", homeProf.idProf);
                            cmdRol3.Parameters.AddWithValue("@dia", diaSemanaText.Text);
                            cmdRol3.Parameters.AddWithValue("@desde", horaDesdeText.Text);
                            cmdRol3.Parameters.AddWithValue("@hasta", horaHastaText.Text);

                            int userCount2 = (int)cmdRol3.ExecuteScalar();
                        }
                        //si no lo encontro en la base esa agenda igual, que lo inserte
                        if (userCount == 0)
                        {
                            SqlCommand cmdRol = new SqlCommand("insert into Select_group.Agenda (profesional_idProfesional, diaDisponible, horaDesde, horaHasta) values (@matricula, @dia, @desde, @hasta) ", conexion);
                            cmdRol.Parameters.AddWithValue("@matricula", homeProf.idProf);
                            cmdRol.Parameters.AddWithValue("@dia", diaSemanaText.Text);
                            cmdRol.Parameters.AddWithValue("@desde", horaDesdeText.Text);
                            cmdRol.Parameters.AddWithValue("@hasta", horaHastaText.Text);

                            cmdRol.ExecuteNonQuery();

                            MessageBox.Show("Nueva Agenda creada con exito");
                            Conexion.conexion.Close();
                        }

                        else
                        {
                            //si lo encontro, que no lo deje y cambie los dias.
                            MessageBox.Show("Ya existe una agenda en ese dia y horario. Por favor, elija otro dia u otro horario");
                        }

                    }

                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        }
           
      
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Home.Show();
            this.Close();
        }

        private void horaDesdeText_TextChanged(object sender, EventArgs e)
        {
            horaDesdeText.Text = horaDesdeText.Text.Trim();
            horaDesdeText.Text = horaDesdeText.Text.Replace(" ", "");
            horaDesdeText.SelectionStart = horaDesdeText.Text.Length;
        }
        private void horaDesdeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void horaHastaText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void horaHastaText_TextChanged(object sender, EventArgs e)
        {
            horaHastaText.Text = horaHastaText.Text.Trim();
            horaHastaText.Text = horaHastaText.Text.Replace(" ", "");
            horaHastaText.SelectionStart = horaHastaText.Text.Length;
        }
    }
}

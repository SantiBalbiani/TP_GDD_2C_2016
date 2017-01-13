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
        public DataTable horariosSemana = new DataTable();
        

        public FrmRegistroAgenda()
        {
            InitializeComponent();
           /* cargarHorariosDesdeDiaSemana(cmbLunesDesde);
            cargarHorariosDesdeDiaSemana(cmbMartesDesde);
            cargarHorariosDesdeDiaSemana(cmbMiercolesDesde);
            cargarHorariosDesdeDiaSemana(cmbJuevesDesde);
            cargarHorariosDesdeDiaSemana(cmbViernesDesde);

            cargarHorariosSabadoDesde(cmbSabadoDesde);
            
            cargarHorariosHastaDiaSemana(cmbLunesHasta);
            cargarHorariosHastaDiaSemana(cmbMartesHasta);
            cargarHorariosHastaDiaSemana(cmbMiercolesHasta);
            cargarHorariosHastaDiaSemana(cmbJuevesHasta);
            cargarHorariosHastaDiaSemana(cmbViernesHasta);

            cargarHorariosSabadoHasta(cmbSabadoHasta);*/
                        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //Cargo especialidades:
            DataTable especialidades = new DataTable();
            Object unItem = comboBox2.SelectedItem;
            ComboboxItem unItemCasteado = (ComboboxItem)unItem;

            ClinicaFrba.Menu_Principal.HomeProfesional homeProf = new Menu_Principal.HomeProfesional();
            homeProf = (ClinicaFrba.Menu_Principal.HomeProfesional)Home;

            string cadena = "SELECT E.descripcion ,[especialidad_idEspecialidad] FROM [SELECT_GROUP].[Profesional_Por_Especialidad] PE JOIN [SELECT_GROUP].[Especialidad] E ON E.idEspecialidad = PE.especialidad_idEspecialidad WHERE profesional_idProfesional = '"+homeProf.idProf.ToString().Trim()+"'";

            especialidades = Conexion.LeerTabla(cadena);


            foreach (DataRow especialidad in especialidades.Rows)
            {

                string desc = especialidad["descripcion"].ToString();
                ComboboxItem itemEsp = new ComboboxItem();

                itemEsp.Text = desc;
                itemEsp.Value = especialidad["especialidad_idEspecialidad"].ToString();

                comboBox1.Items.Add(itemEsp);
                comboBox2.Items.Add(itemEsp);
                comboBox3.Items.Add(itemEsp);
                comboBox4.Items.Add(itemEsp);
                comboBox5.Items.Add(itemEsp);
                comboBox6.Items.Add(itemEsp);

            }


            Conexion.conexion.Close();

            //Fin carga especialidades
            
            cmbLunesDesde.Enabled = false;
            cmbLunesHasta.Enabled = false;
            cmbMartesDesde.Enabled = false;
            cmbMartesHasta.Enabled = false;
            cmbMiercolesDesde.Enabled = false;
            cmbMiercolesHasta.Enabled = false;
            cmbJuevesDesde.Enabled = false;
            cmbJuevesHasta.Enabled = false;
            cmbViernesDesde.Enabled = false;
            cmbViernesHasta.Enabled = false;
            cmbSabadoDesde.Enabled = false;
            cmbSabadoHasta.Enabled = false;
          
        }
       
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int horaDesd = Convert.ToInt32(horaDesdeText.Text.ToString().Trim());
            //int horaHasta = Convert.ToInt32(horaHastaText.Text.ToString().Trim());
            
            Menu_Principal.HomeProfesional homeProf = new Menu_Principal.HomeProfesional();
            homeProf = (Menu_Principal.HomeProfesional)Home;

            if (seleccionVacia())
            {
                MessageBox.Show("Debe seleccionar algun día con su respectivo horario para armar la Agenda del Medico");
            }
            else{
                if(verificarHorariosIngresados()){
                    
                        DataColumn registroSemana =
                        horariosSemana.Columns.Add("profesional_IdProfesional", typeof(int));
                        horariosSemana.Columns.Add("diaDisponible", typeof(int));
                        horariosSemana.Columns.Add("horaDesde", typeof(int));
                        horariosSemana.Columns.Add("horaHasta", typeof(int));
    
                        horariosSemana = cargarEstructura(horariosSemana);

                
                        SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);

                        try
                            {
                                SqlCommand cmdAltaAgenda = new SqlCommand("Select_Group.AltaAgenda", cnx);
                                cmdAltaAgenda.CommandType = CommandType.StoredProcedure;
                                cmdAltaAgenda.Parameters.Add(new SqlParameter("@Agenda", SqlDbType.Structured));
                                cmdAltaAgenda.Parameters["@Agenda"].Value = horariosSemana;
                                cnx.Open();
                                cmdAltaAgenda.ExecuteNonQuery();
                                MessageBox.Show("Se han guardado correctamente los datos");

                                Home.Show();
                                this.Close();
                            }
                            catch (ApplicationException error)
                            {
                                string mensaje = "Se ha producido un error ";
                                ApplicationException excep = new ApplicationException(mensaje, error);
                                excep.Source = this.Text;
                            }
                
                /*
                
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

            }*/
        }
                MessageBox.Show("Verifique por favor los horarios ingresados");
                }
        }
           
      
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Home.Show();
            this.Close();
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
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxLunes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLunes.Checked == true)
            {
                cmbLunesHasta.Enabled = true;
                cmbLunesDesde.Enabled = true;
                comboBox1.Enabled = true;
            }
            else {
                cmbLunesDesde.Enabled = false;
                cmbLunesHasta.Enabled = false;
                comboBox1.Enabled = false;
            }
        }

        private void checkBoxMartes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMartes.Checked == true)
            {
                cmbMartesHasta.Enabled = true;
                cmbMartesDesde.Enabled = true;
                comboBox2.Enabled = true;
            }
            else
            {
                cmbMartesDesde.Enabled = false;
                cmbMartesHasta.Enabled = false;
                comboBox2.Enabled = false;
            }
        }

        private void checkBoxMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMiercoles.Checked == true)
            {
                cmbMiercolesHasta.Enabled = true;
                cmbMiercolesDesde.Enabled = true;
                comboBox3.Enabled = true;
            }
            else
            {
                cmbMiercolesDesde.Enabled = false;
                cmbMiercolesHasta.Enabled = false;
                comboBox3.Enabled = false;
            }
        }

        private void checkBoxJueves_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxJueves.Checked == true)
            {
                cmbJuevesHasta.Enabled = true;
                cmbJuevesDesde.Enabled = true;
                comboBox4.Enabled = true;
            }
            else
            {
                cmbJuevesDesde.Enabled = false;
                cmbJuevesHasta.Enabled = false;
                comboBox4.Enabled = false;
            }
        }

        private void checkBoxViernes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxViernes.Checked == true)
            {
                cmbViernesHasta.Enabled = true;
                cmbViernesDesde.Enabled = true;
                comboBox5.Enabled = true;
            }
            else
            {
                cmbViernesDesde.Enabled = false;
                cmbViernesHasta.Enabled = false;
                comboBox5.Enabled = false;
            }
        }

        private void checkBoxSabado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSabado.Checked == true)
            {
                cmbSabadoHasta.Enabled = true;
                cmbSabadoDesde.Enabled = true;
                comboBox6.Enabled = true;
            }
            else
            {
                cmbSabadoDesde.Enabled = false;
                cmbSabadoHasta.Enabled = false;
                comboBox6.Enabled = false;
            }
        }

        public void cargarHorariosDesdeDiaSemana(ComboBox combo) {

            combo.Items.Add("07:00");                
            combo.Items.Add("07:30");
            combo.Items.Add("08:00");
            combo.Items.Add("08:30");
            combo.Items.Add("09:00");
            combo.Items.Add("09:30");
            combo.Items.Add("10:00");
            combo.Items.Add("10:30");
            combo.Items.Add("11:00");
            combo.Items.Add("11:30");
            combo.Items.Add("12:00");
            combo.Items.Add("12:30");
            combo.Items.Add("13:00");
            combo.Items.Add("13:30");
            combo.Items.Add("14:00");
            combo.Items.Add("14:30");
            combo.Items.Add("15:00");
            combo.Items.Add("15:30");
            combo.Items.Add("16:00");
            combo.Items.Add("16:30");
            combo.Items.Add("17:00");
            combo.Items.Add("17:30");
            combo.Items.Add("18:00");
            combo.Items.Add("18:30");
            combo.Items.Add("19:00");
            combo.Items.Add("19:30");
            
            
            }
        public void cargarHorariosHastaDiaSemana(ComboBox combo) {
            
            cargarHorariosDesdeDiaSemana(combo);
            combo.Items.RemoveAt(0);
            combo.Items.Add("20:00");
        
        }

        public void cargarHorariosSabadoDesde(ComboBox combo){
            
            combo.Items.Add("10:00");
            combo.Items.Add("10:30");
            combo.Items.Add("11:00");
            combo.Items.Add("11:30");
            combo.Items.Add("12:00");
            combo.Items.Add("12:30");
            combo.Items.Add("13:00");
            combo.Items.Add("13:30");
            combo.Items.Add("14:00");
            combo.Items.Add("14:30");                   
        }

        public void cargarHorariosSabadoHasta(ComboBox combo) {

            cargarHorariosSabadoDesde(combo);
            combo.Items.RemoveAt(0);
            combo.Items.Add("15:00");        
        }

        public bool seleccionVacia() { 
            Boolean bandera;

            if(checkBoxJueves.Checked || checkBoxLunes.Checked || checkBoxMartes.Checked || checkBoxMiercoles.Checked || checkBoxSabado.Checked || checkBoxViernes.Checked){
                bandera = false;            
            }else{
                bandera = true;
            }

            return bandera;
        
        }

        public DataTable cargarEstructura(DataTable tablaAgenda) {

            Menu_Principal.HomeProfesional homeProf = new Menu_Principal.HomeProfesional();
            homeProf = (Menu_Principal.HomeProfesional)Home;

            if (checkBoxLunes.Checked) {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 1;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbLunesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbLunesHasta.Text));

                tablaAgenda.Rows.Add(unRegistro);
                }
            if (checkBoxMartes.Checked) {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 2;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbMartesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbMartesHasta.Text));
                
                tablaAgenda.Rows.Add(unRegistro);
            
            }
            if (checkBoxMiercoles.Checked)
            {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 3;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbMiercolesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbMiercolesHasta.Text));

                tablaAgenda.Rows.Add(unRegistro);
            }
            if (checkBoxJueves.Checked)
            {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 4;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbJuevesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbJuevesHasta.Text));

                tablaAgenda.Rows.Add(unRegistro);

            }
            if (checkBoxViernes.Checked)
            {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 5;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbViernesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbViernesHasta.Text));

                tablaAgenda.Rows.Add(unRegistro);

            }
            if (checkBoxSabado.Checked)
            {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 6;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbSabadoDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbSabadoHasta.Text));

                tablaAgenda.Rows.Add(unRegistro);

            }

            return tablaAgenda;
        
        
        }

        public string formatoHorario(string cadenaCombo) {

            return cadenaCombo = cadenaCombo.Replace(":", "");        
            
        }
        public Boolean verificarHorariosIngresados() {
            Boolean bandera = false;

            if (checkBoxLunes.Checked) {
                if (Convert.ToInt32(formatoHorario(cmbLunesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbLunesDesde.Text))) {
                    bandera = true;
                }            
            }
            if (checkBoxMartes.Checked)
            {
                if (Convert.ToInt32(formatoHorario(cmbMartesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbMartesDesde.Text)))
                {
                    bandera = true;
                }
            }
            if (checkBoxMiercoles.Checked)
            {
                if (Convert.ToInt32(formatoHorario(cmbMiercolesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbMiercolesDesde.Text)))
                {
                    bandera = true;
                }
            }
            if (checkBoxJueves.Checked)
            {
                if (Convert.ToInt32(formatoHorario(cmbJuevesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbJuevesDesde.Text)))
                {
                    bandera = true;
                }
            }
            if (checkBoxViernes.Checked)
            {
                if (Convert.ToInt32(formatoHorario(cmbViernesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbViernesDesde.Text)))
                {
                    bandera = true;
                }
            }
            if (checkBoxSabado.Checked)
            {
                if (Convert.ToInt32(formatoHorario(cmbSabadoHasta.Text)) > Convert.ToInt32(formatoHorario(cmbSabadoDesde.Text)))
                {
                    bandera = true;
                }
            }

            return bandera;
        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        
        }
        
    }


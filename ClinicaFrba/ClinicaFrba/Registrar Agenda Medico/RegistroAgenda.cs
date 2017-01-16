﻿using System;
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
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

        }
       
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                        
            Menu_Principal.HomeProfesional homeProf = new Menu_Principal.HomeProfesional();
            homeProf = (Menu_Principal.HomeProfesional)Home;

            if (seleccionVacia())
            {
                MessageBox.Show("Debe seleccionar algun día con su respectivo horario para armar la Agenda del Medico");
            }
            else{
                if(verificarHorariosIngresados(Convert.ToInt32(homeProf.idProf))){
                    if (especialidadElegida())
                    {
                        
                        DataColumn registroSemana =
                        horariosSemana.Columns.Add("profesional_IdProfesional", typeof(int));
                        horariosSemana.Columns.Add("diaDisponible", typeof(int));
                        horariosSemana.Columns.Add("horaDesde", typeof(int));
                        horariosSemana.Columns.Add("horaHasta", typeof(int));
                        horariosSemana.Columns.Add("especialidad",typeof(int));

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

                        
                    } else 
                        MessageBox.Show("No ha sido selecciona la Especialidad en un día Elegido");
        }
                else
                MessageBox.Show("Verifique por favor los horarios ingresados, puede que haya ingresado un horario que ya esta guardado o que el horario hasta sea menor que horario desde");
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
            int matricula = Convert.ToInt32(homeProf.idProf);
            ComboboxItem especialidad = new ComboboxItem();
            if (checkBoxLunes.Checked) {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 1;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbLunesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbLunesHasta.Text));
                especialidad = (ComboboxItem)comboBox1.SelectedItem;
                unRegistro["especialidad"] = especialidad.Value;

                tablaAgenda.Rows.Add(unRegistro);
                }
            if (checkBoxMartes.Checked) {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 2;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbMartesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbMartesHasta.Text));
                especialidad = (ComboboxItem)comboBox2.SelectedItem;
                unRegistro["especialidad"] = especialidad.Value;
                
                tablaAgenda.Rows.Add(unRegistro);
            
            }
            if (checkBoxMiercoles.Checked)
            {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 3;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbMiercolesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbMiercolesHasta.Text));
                especialidad = (ComboboxItem)comboBox3.SelectedItem;
                unRegistro["especialidad"] = especialidad.Value;

                tablaAgenda.Rows.Add(unRegistro);
            }
            if (checkBoxJueves.Checked)
            {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 4;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbJuevesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbJuevesHasta.Text));
                especialidad = (ComboboxItem)comboBox4.SelectedItem;
                unRegistro["especialidad"] = especialidad.Value;

                tablaAgenda.Rows.Add(unRegistro);

            }
            if (checkBoxViernes.Checked)
            {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = matricula;
                unRegistro["diaDisponible"] = 5;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbViernesDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbViernesHasta.Text));
                especialidad = (ComboboxItem)comboBox5.SelectedItem;
                unRegistro["especialidad"] = especialidad.Value;

                tablaAgenda.Rows.Add(unRegistro);

            }
            if (checkBoxSabado.Checked)
            {
                DataRow unRegistro = tablaAgenda.NewRow();
                unRegistro["profesional_IdProfesional"] = homeProf.idProf;
                unRegistro["diaDisponible"] = 6;
                unRegistro["horaDesde"] = Convert.ToInt32(formatoHorario(cmbSabadoDesde.Text));
                unRegistro["horaHasta"] = Convert.ToInt32(formatoHorario(cmbSabadoHasta.Text));
                especialidad = (ComboboxItem)comboBox6.SelectedItem;
                unRegistro["especialidad"] = especialidad.Value;

                tablaAgenda.Rows.Add(unRegistro);

            }

            return tablaAgenda;
        
        
        }

        public string formatoHorario(string cadenaCombo) {

            return cadenaCombo = cadenaCombo.Replace(":", "");        
            
        }
        public Boolean verificarHorariosIngresados(int idProfesional) {
            Boolean bandera = false;

            if (checkBoxLunes.Checked) {

                string cadena = "Select count(*) as Cantidad from SELECT_GROUP.Agenda where profesional_IdProfesional = " + idProfesional + " and diaDisponible = 1 group by profesional_IdProfesional ";
                DataTable query = Conexion.LeerTabla(cadena);
                //string valorColumna = query.Columns["Cantidad"].ToString();

                if (query.Rows.Count <= 0)
                {
                    if (/*valorColumna == "" &&*/ Convert.ToInt32(formatoHorario(cmbLunesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbLunesDesde.Text)))
                    {
                        bandera = true;
                    }
                }
            }
            if (checkBoxMartes.Checked)
            {
                
                string cadena = "Select count(*) as Cantidad from SELECT_GROUP.Agenda where profesional_idProfesional = '" + idProfesional + "' and diaDisponible = 2 group by profesional_idProfesional ";
                DataTable query = Conexion.LeerTabla(cadena);
               // string valorColumna = query.Columns["Cantidad"].ToString();
                if (query.Rows.Count <= 0)
                {
                    if (/*valorColumna == "" &&*/ Convert.ToInt32(formatoHorario(cmbMartesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbMartesDesde.Text)))
                    {
                        bandera = true;
                    }
                }
            }
            if (checkBoxMiercoles.Checked)
            {
                
                string cadena = "Select count(*) as Cantidad from SELECT_GROUP.Agenda where profesional_idProfesional = '" + idProfesional + "' and diaDisponible = 3 group by profesional_idProfesional ";
                DataTable query = Conexion.LeerTabla(cadena);
                //string valorColumna = query.Columns["Cantidad"].ToString();

                if (query.Rows.Count <= 0)
                {
                    if (/*valorColumna == "" &&*/ Convert.ToInt32(formatoHorario(cmbMiercolesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbMiercolesDesde.Text)))
                    {
                        bandera = true;
                    }
                }
            }
            if (checkBoxJueves.Checked)
            {
                
                string cadena = "Select count(*) as Cantidad from SELECT_GROUP.Agenda where profesional_idProfesional = '" + idProfesional + "' and diaDisponible = 4 group by profesional_idProfesional ";
                DataTable query = Conexion.LeerTabla(cadena);
                //string valorColumna = query.Columns["Cantidad"].ToString();
                if (query.Rows.Count <= 0)
                {
                    if (/*valorColumna == "" && */Convert.ToInt32(formatoHorario(cmbJuevesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbJuevesDesde.Text)))
                    {
                        bandera = true;
                    }
                }

            }
            if (checkBoxViernes.Checked)
            {
                
                string cadena = "Select count(*) as Cantidad from SELECT_GROUP.Agenda where profesional_idProfesional = '" + idProfesional + "' and diaDisponible = 5 group by profesional_idProfesional ";
                DataTable query = Conexion.LeerTabla(cadena);
                //string valorColumna = query.Columns["Cantidad"].ToString();
                if (query.Rows.Count <= 0)
                {
                    if (/*valorColumna == "" &&*/ Convert.ToInt32(formatoHorario(cmbViernesHasta.Text)) > Convert.ToInt32(formatoHorario(cmbViernesDesde.Text)))
                    {
                        bandera = true;
                    }
                }
            }
            if (checkBoxSabado.Checked)
            {
                
                string cadena = "Select count(*) as Cantidad from SELECT_GROUP.Agenda where profesional_idProfesional = '" + idProfesional + "' and diaDisponible = 6 group by profesional_idProfesional ";
                DataTable query = Conexion.LeerTabla(cadena);
                //string valorColumna = query.Columns["Cantidad"].ToString();
                if (query.Rows.Count <= 0)
                {
                    if (/*valorColumna == "" && */Convert.ToInt32(formatoHorario(cmbSabadoHasta.Text)) > Convert.ToInt32(formatoHorario(cmbSabadoDesde.Text)))
                    {
                        bandera = true;
                    }
                }

            }

            return bandera;
        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public Boolean especialidadElegida() {
            Boolean bandera = false;

            if(comboBox1.Enabled && comboBox1.SelectedIndex != -1){
                bandera = true;            
            }
            if (comboBox2.Enabled && comboBox2.SelectedIndex != -1)
            {
                bandera = true;
            }
            if (comboBox3.Enabled && comboBox3.SelectedIndex != -1)
            {
                bandera = true;
            }
            if (comboBox4.Enabled && comboBox4.SelectedIndex != -1)
            {
                bandera = true;
            }
            if (comboBox5.Enabled && comboBox5.SelectedIndex != -1)
            {
                bandera = true;
            }
            if (comboBox6.Enabled && comboBox6.SelectedIndex != -1)
            {
                bandera = true;
            }

            return bandera;
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        }
        
    }


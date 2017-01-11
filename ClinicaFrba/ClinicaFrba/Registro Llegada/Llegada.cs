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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Llegada : Form
    {
        public string unIdBono = "0";
        public string idTurno = "0";
        public string menuAnterior;
        public Form Home;

        public Llegada()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            comboBox2.ResetText(); ;
            comboBox2.Items.Clear();
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumeroAfiliado.Text.ToString()))
            {
                MessageBox.Show("Por favor complete el nro de Afiliado");
            }
            else
            {
                if (String.IsNullOrEmpty(txtProfesional.Text.ToString()))
                {
                    MessageBox.Show("Por favor ingrese Nombre aproximado del Profesional");
                }
                else
                {

                    string nombreProf = txtProfesional.Text.ToString();



                    string consultarTurnosParaProfYAfiliado = "SELECT P.matricula, P.nombre, P.apellido FROM Select_Group.Profesional P WHERE P.nombre LIKE '%" + nombreProf + "%' OR  P.apellido LIKE '%" + nombreProf + "%'";
                    Conexion.conectar();
                    DataTable Turnos = new DataTable();

                    try
                    {

                        Turnos = Conexion.LeerTabla(consultarTurnosParaProfYAfiliado);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Conexion.conexion.Close();



                        string ultimoProf = " ";

                        foreach (DataRow turno in Turnos.Rows)
                        {
                            ComboboxItem unItem = new ComboboxItem();

                            unItem.Text = turno["apellido"].ToString() + ", " + turno["nombre"].ToString();
                            unItem.Value = turno["matricula"].ToString();
                            ultimoProf = unItem.Text.ToString();
                            comboBox2.Items.Add(unItem);
                        }
                        if (ultimoProf == " ")
                        {
                            MessageBox.Show("No se encontraron profesionales");
                        }
                        else
                        {
                            comboBox2.Text = "Seleccione Profesional";
                            comboBox1.Text = " ";
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumeroAfiliado.Text.ToString()))
            {
                MessageBox.Show("Por favor complete el nro de Afiliado");
            }else{
            string nombreYApellido = comboBox2.Text;
            var nomYapSeparado = nombreYApellido.Split(',');
            string nombreProf = nomYapSeparado[0];
            string apellidoProf = nomYapSeparado[1];

            string consultarTurnosParaProfYAfiliado = "SELECT T.idTurno ,T.idAgenda ,T.fechaTurno ,T.afiliado_idAfiliado ,Afi.nombre ,Afi.apellido FROM Select_Group.Turno T JOIN Select_Group.Agenda A ON A.idAgenda = T.idAgenda JOIN Select_Group.Profesional P ON P.matricula = A.profesional_IdProfesional JOIN Select_Group.Afiliado Afi ON Afi.nroAfiliado = " + txtNumeroAfiliado.Text.ToString() + " WHERE (P.nombre = '" + apellidoProf.ToString().Trim() + "' OR P.nombre = '" + nombreProf.ToString().Trim() + "' AND P.apellido = '" + nombreProf.ToString().Trim() + "' OR P.apellido = '" + apellidoProf.ToString().Trim() + "') AND T.estado = 3";
            
                
             Conexion.conectar();
            DataTable Turnos = new DataTable();
            
            Turnos = Conexion.LeerTabla(consultarTurnosParaProfYAfiliado);

            foreach (DataRow turno in Turnos.Rows)
            {
                ComboboxItem unItem = new ComboboxItem();

                unItem.Text = turno["fechaTurno"].ToString();
                unItem.Value = turno["idTurno"].ToString();

                listBox1.Items.Add(unItem); 
            }

            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            //Al tocar este boton se chequea si posee bonos dispobibles para realizar la consulta, y si tiene se habilitan las opciones, sino, se informa. 

            if (String.IsNullOrEmpty(txtNumeroAfiliado.Text.ToString()))
            {
                MessageBox.Show("Por favor complete el nro de Afiliado");
            }
            else
            {
                

                string consultaBonosDisp = "SELECT B.idBono FROM SELECT_GROUP.Bono B JOIN SELECT_GROUP.Afiliado A ON B.idAfiliado = A.idAfiliado WHERE (A.nroAfiliado LIKE (left(" + txtNumeroAfiliado.Text.ToString() + ", LEN(" + txtNumeroAfiliado.Text.ToString() + ")-2)+'%') AND (LEN(" + txtNumeroAfiliado.Text.ToString() + ") = LEN(A.nroAfiliado))) AND (B.idPlan = (SELECT A2.plan_idPlan FROM SELECT_GROUP.Afiliado A2 WHERE nroAfiliado = " + txtNumeroAfiliado.Text.ToString() + ")) AND B.estado = 1";
                DataTable bonosDisponibles = new DataTable();

                Conexion.conectar();

                bonosDisponibles = Conexion.LeerTabla(consultaBonosDisp);
                unIdBono = "0";
                foreach (DataRow unBonoDisp in bonosDisponibles.Rows)
                {
                    unIdBono = unBonoDisp["idBono"].ToString();
                }

                Conexion.conexion.Close();

                if (unIdBono == "0")
                {
                    label4.Visible = false;
                    label5.Visible = true;
                    button2.Enabled = false;


                }
                else
                {
                    label4.Visible = true;
                    label5.Visible = false;
                    button2.Enabled = true;
                }



            }
     
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Llegada_Load(object sender, EventArgs e)
        {
            Conexion.conectar();
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            comboBox1.SelectedText = "Seleccione Especialidad";
            
            listBox1.ClearSelected();
            DataTable especialidades = new DataTable();
           
            string cadena = "select idEspecialidad, descripcion from SELECT_GROUP.Especialidad"; 

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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.ResetText();
            txtProfesional.Text = " ";
        }

        private void btnCargarProfesionales_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
            comboBox2.Items.Clear();
            comboBox2.ResetText();
            comboBox2.SelectedText = "Seleccione Profesional";
            
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


                    string profesional = filaNombreProf["nombre"].ToString() + "," + filaNombreProf["apellido"].ToString();
                    ComboboxItem itemProf = new ComboboxItem();

                    itemProf.Text = profesional;
                    itemProf.Value = filaNombreProf["matricula"].ToString();

                    comboBox2.Items.Add(itemProf);

                }

            }


            Conexion.conexion.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void txtNumeroAfiliado_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumeroAfiliado_TextChanged(object sender, EventArgs e)
        {
            txtNumeroAfiliado.Text = txtNumeroAfiliado.Text.Trim();
            txtNumeroAfiliado.Text = txtNumeroAfiliado.Text.Replace(" ", "");
            txtNumeroAfiliado.SelectionStart = txtNumeroAfiliado.Text.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdUsuario = new SqlCommand("Select_Group.sp_registrar_llegada", cnx);
            cmdUsuario.CommandType = CommandType.StoredProcedure;
            cmdUsuario.Parameters.Add("@idBono", SqlDbType.Int).Value = unIdBono;

            Object elItem = listBox1.SelectedItem;
            ComboboxItem itemElegido = new ComboboxItem();
            itemElegido = (ComboboxItem)elItem;

            idTurno = itemElegido.Value.ToString();

            cmdUsuario.Parameters.Add("@idTurno", SqlDbType.Int).Value = idTurno;

            try
            {

                cnx.Open();
                cmdUsuario.ExecuteNonQuery();
                MessageBox.Show("Se registró la recepción del Afiliado!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
                
                Home.Show();
                this.Close();
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
//          Globals.irAtras(menuAnterior, this);
            Home.Show();
            this.Close();
            //Menu_Principal.HomeAdmin frmMenu = new Menu_Principal.HomeAdmin();
            //frmMenu.Show();
            //this.Close();
        }
        
    }
}

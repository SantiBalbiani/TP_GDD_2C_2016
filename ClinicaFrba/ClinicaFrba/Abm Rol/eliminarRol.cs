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



namespace ClinicaFrba.AbmRol
{
    public partial class eliminarRol : Form
    {
        public Form frmAnterior;
        public eliminarRol()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void eliminarRol_Load_1(object sender, EventArgs e)
        {

            Conexion.conectar();
            DataTable roles = new DataTable();

            string consultaStr = "select idRol, nombre from SELECT_GROUP.Rol where rol.habilitado=1";

            roles = Conexion.LeerTabla(consultaStr);

            DataTable nombreRoles = new DataTable();


            foreach (DataRow idFunc in roles.Rows)
            {
                ComboboxItem unRol = new ComboboxItem();

                unRol.Text = idFunc["nombre"].ToString();
                unRol.Value = idFunc["idRol"].ToString();

                checkedListBox1.Items.Add(unRol);

            }
         

 
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
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

                    if (checkedListBox1.CheckedItems.Count > 0)
                    {
                     
                        foreach (Object item in checkedListBox1.CheckedItems)
                        {

                            ComboboxItem unItem = new ComboboxItem();

                            unItem = (ComboboxItem)item;

                            //le pone el valor 0 al rol eliminado 
                            SqlCommand cmdRol = new SqlCommand("update Select_group.Rol set habilitado=0 where nombre=@nombreRol", conexion); 
                            cmdRol.Parameters.AddWithValue("@nombreRol", unItem.Text);
                            cmdRol.ExecuteNonQuery();
                            MessageBox.Show("Rol ha sigo inhabilitado con exito ");
                            Conexion.conexion.Close();
                        }

                        //hago refresh
                        checkedListBox1.Items.Clear();
                        Conexion.conectar();
                        DataTable roles = new DataTable();

                        string consultaStr = "select idRol, nombre from SELECT_GROUP.Rol where rol.habilitado=1";

                        roles = Conexion.LeerTabla(consultaStr);

                        DataTable nombreRoles = new DataTable();


                        foreach (DataRow idFunc in roles.Rows)
                        {
                            ComboboxItem unRol = new ComboboxItem();

                            unRol.Text = idFunc["nombre"].ToString();
                            unRol.Value = idFunc["idRol"].ToString();

                            checkedListBox1.Items.Add(unRol);

                        }
                        

                        
                    }

                    else
                    {
                        MessageBox.Show("Porfavor seleccione al menos un Rol");
                    }

                    while (checkedListBox1.CheckedItems.Count > 0)
                    {
                        checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAnterior.Show();
            this.Close();
        }
        }
    }


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
    public partial class habilitarRol : Form
    {
        public Form frmAnterior;
        public habilitarRol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void habilitarRol_Load(object sender, EventArgs e)
        {
            Conexion.conectar();
            DataTable roles = new DataTable();

            string consultaStr = "select idRol, nombre from SELECT_GROUP.Rol where Rol.habilitado=0";

            roles = Conexion.LeerTabla(consultaStr);

            DataTable otrosRoles = new DataTable();


            foreach (DataRow idRol in roles.Rows)
            {
                ComboboxItem unRol = new ComboboxItem();

                unRol.Text = idRol["nombre"].ToString();
                unRol.Value = idRol["idRol"].ToString();

                checkedListBox2.Items.Add(unRol);

            }

           //validar si no hay roles a eliminar
            if (checkedListBox2.Items.Count < 1)
            {
                MessageBox.Show("No existen roles a eliminar");
            }


                
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

                    if (checkedListBox2.CheckedItems.Count > 0)
                    {

                        //le pone el valor 1 al rol habilitado 
                        foreach (Object item in checkedListBox2.CheckedItems)
                        {

                            ComboboxItem unItem = new ComboboxItem();

                            unItem = (ComboboxItem)item;

                            //le pone el valor 1 al rol habilitado 
                            SqlCommand cmdRol = new SqlCommand("update Select_group.Rol set habilitado=1 where nombre=@nombreRol;", conexion);
                            cmdRol.Parameters.AddWithValue("@nombreRol", unItem.Text);
                            cmdRol.ExecuteNonQuery();
                            MessageBox.Show("Rol ha sido habilitado con exito con las funcionalidades asignadas ");
                            Conexion.conexion.Close();
                        }

                    }

                    else
                    {
                        MessageBox.Show("Porfavor seleccione al menos un Rol");
                    }

                    while (checkedListBox2.CheckedItems.Count > 0)
                    {
                        checkedListBox2.SetItemChecked(checkedListBox2.CheckedIndices[0], false);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

           
                 
        }   

        private void button2_Click(object sender, EventArgs e)
        {
            frmAnterior.Show();
            this.Close();
        }
    }  
}

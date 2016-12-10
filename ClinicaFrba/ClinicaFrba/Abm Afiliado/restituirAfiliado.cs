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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class RestituirAfiliado : Form
    {
        public string menuAnterior;
        public Form Home;

        public RestituirAfiliado()
        {
            InitializeComponent();
        }

        private void RestituirAfiliado_Load(object sender, EventArgs e)
        {
            Conexion.conectar();
            DataTable afiliados = new DataTable();

            string consultaStr = "select idAfiliado, nombre, apellido from SELECT_GROUP.Afiliado where afiliado.habilitado=0";

            afiliados = Conexion.LeerTabla(consultaStr);

            DataTable nombreRoles = new DataTable();


            foreach (DataRow idAfi in afiliados.Rows)
            {
                ComboboxItem unAfiliado = new ComboboxItem();

                string nombre = idAfi["nombre"].ToString();
                string apellido = idAfi["apellido"].ToString();


                unAfiliado.Text = nombre + "," + apellido;

                unAfiliado.Value = idAfi["idAfiliado"].ToString();

                checkedListBox1.Items.Add(unAfiliado);

            }

            if (checkedListBox1.Items.Count < 1)
            {
                MessageBox.Show("No existen Afiliados a Rehabilitar");
            }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Globals.irAtras(menuAnterior, this);
            Home.Show();
            this.Close();
            
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

                    if (checkedListBox1.CheckedItems.Count > 0)
                    {

                        foreach (Object item in checkedListBox1.CheckedItems)
                        {

                            ComboboxItem unItem = new ComboboxItem();

                            unItem = (ComboboxItem)item;

                            //le pone el valor 0 al afiliado eliminado 
                            SqlCommand cmdRol = new SqlCommand("update Select_group.Afiliado set habilitado=0 where idAfiliado=@nombreAfiliado", conexion);
                            cmdRol.Parameters.AddWithValue("@nombreAfiliado", unItem.Value);
                            cmdRol.ExecuteNonQuery();
                            MessageBox.Show("Afiliado ha sigo restituido con exito ");
                            Conexion.conexion.Close();
                        }

                        //Hago refresh del reporte

                        checkedListBox1.Items.Clear();
                        Conexion.conectar();
                        DataTable afiliados = new DataTable();

                        string consultaStr = "select idAfiliado, nombre, apellido from SELECT_GROUP.Afiliado where afiliado.habilitado=0";

                        afiliados = Conexion.LeerTabla(consultaStr);

                        DataTable nombreRoles = new DataTable();


                        foreach (DataRow idAfi in afiliados.Rows)
                        {
                            ComboboxItem unAfiliado = new ComboboxItem();

                            string nombre = idAfi["nombre"].ToString();
                            string apellido = idAfi["apellido"].ToString();


                            unAfiliado.Text = nombre + "," + apellido;

                            unAfiliado.Value = idAfi["idAfiliado"].ToString();

                            checkedListBox1.Items.Add(unAfiliado);

                        }

                    }

                    else
                    {
                        MessageBox.Show("Porfavor seleccione al menos un Afiliado");
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
    }
}

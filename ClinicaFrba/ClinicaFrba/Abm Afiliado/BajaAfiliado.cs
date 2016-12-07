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
    public partial class BajaAfiliado : Form
    {
        public BajaAfiliado()
        {
            InitializeComponent();
        }

        private void BajaAfiliado_Load(object sender, EventArgs e)
        {

            Conexion.conectar();
            DataTable afiliados = new DataTable();

            string consultaStr = "select idAfiliado, nombre from SELECT_GROUP.Afiliado where afiliado.habilitado=1";

            afiliados = Conexion.LeerTabla(consultaStr);

            DataTable nombreRoles = new DataTable();


            foreach (DataRow idAfi in afiliados.Rows)
            {
                ComboboxItem unAfiliado = new ComboboxItem();

                unAfiliado.Text = idAfi["nombre"].ToString();
                unAfiliado.Value = idAfi["idAfiliado"].ToString();

                checkedListBox1.Items.Add(unAfiliado);

            }


        }

        private void btnActualizar_Click(object sender, EventArgs e)
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
                            SqlCommand cmdRol = new SqlCommand("update Select_group.Afiliado set habilitado=0 where nombre=@nombreAfiliado", conexion);
                            cmdRol.Parameters.AddWithValue("@nombreAfiliado", unItem.Text);
                            cmdRol.ExecuteNonQuery();
                            MessageBox.Show("Afiliado ha sigo inhabilitado con exito ");
                            Conexion.conexion.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Menu_Principal.HomeAdmin frmadmin = new Menu_Principal.HomeAdmin();
            frmadmin.Show();
            this.Close();
        }
    }
}

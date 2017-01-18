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
    public partial class crearRol : Form
    {
        public crearRol()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            Conexion.conectar();
            DataTable funcionalidades = new DataTable();

            string consultaStr = "select idFuncionalidad, descripcion from SELECT_GROUP.Funcionalidad";

            funcionalidades = Conexion.LeerTabla(consultaStr);

            DataTable nombreFuncionalidades = new DataTable();


            foreach (DataRow idFunc in funcionalidades.Rows)
            {
                ComboboxItem unaFuncionalidad = new ComboboxItem();

                unaFuncionalidad.Text = idFunc["descripcion"].ToString();
                unaFuncionalidad.Value = idFunc["idFuncionalidad"].ToString();

                checkedListBox1.Items.Add(unaFuncionalidad);

            }
        }

        private void label2_Click(object sender, EventArgs e)
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


            if (conectado == true) {

                try
                {
                    //string str[] = new string(checkedListBox1.CheckedItems.Count);
                    //Dim str(checkedListBox1.CheckedItems.Count) As string;
                    //string str[checkedListBox1.CheckedItems.Count] = new String(checkedListBox1.CheckedItems.Count);
                    if (checkedListBox1.CheckedItems.Count > 0)
                    {

                        //inserta rol nuevo en la tabla rol 
                        SqlCommand cmdRol = new SqlCommand("insert into Select_group.Rol (nombre,habilitado) values(@nombreRol,1)", conexion);
                        cmdRol.Parameters.AddWithValue("@nombreRol", nuevoRol.Text);
                        cmdRol.ExecuteNonQuery();

                        //Aca poner query que busque el Rol por la descripción y levantar el idRol

                        string buscaRol = "SELECT idRol FROM Select_Group.Rol WHERE nombre = '" + nuevoRol.Text.ToString() + "'";

                        DataTable elRolAgregado = new DataTable();
                        Conexion.conectar();
                        elRolAgregado = Conexion.LeerTabla(buscaRol);
                        string idRol = " ";
                        foreach (DataRow unRol in elRolAgregado.Rows)
                        {
                            idRol = unRol["idRol"].ToString();
                        }



                        foreach ( Object item  in checkedListBox1.CheckedItems){

                            ComboboxItem unItem = new ComboboxItem();

                            unItem = (ComboboxItem)item;

                            SqlCommand cmdFuncionalidad = new SqlCommand("insert into Select_group.Funcionalidad_Por_Rol (rol_idRol, funcionalidad_idFuncionalidad) values(@idRol,@idFunc)", conexion);
                            cmdFuncionalidad.Parameters.AddWithValue("@idRol", idRol);//Aca pasar el idRol recuperado previamente
                            cmdFuncionalidad.Parameters.AddWithValue("@idFunc", unItem.Value);
                            cmdFuncionalidad.ExecuteNonQuery();


                         }



                        MessageBox.Show("Rol creado con exito con las funcionalidades asignadas ");
                        Conexion.conexion.Close();
                    }

                    else
                    {
                        MessageBox.Show("Porfavor seleccione al menos una Funcionalidad");
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

       
         }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abmMenuRol frmMenu = new abmMenuRol();
            frmMenu.Show();
            this.Close();
        }
}

}
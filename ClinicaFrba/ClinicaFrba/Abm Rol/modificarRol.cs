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
    public partial class modificarRol : Form
    {
        public modificarRol()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void modificarRol_Load(object sender, EventArgs e)
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

                checkedListBox2.Items.Add(unaFuncionalidad);

            }
         
        }


        private void button1_Click_1(object sender, EventArgs e)
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

                        //Aca poner query que busque el Rol por la descripción y levantar el idRol

                        string buscaRol = "SELECT idRol FROM Select_Group.Rol WHERE nombre = '" + rolABuscar.Text.ToString() + "'";

                        DataTable elRolAgregado = new DataTable();
                        Conexion.conectar();
                        elRolAgregado = Conexion.LeerTabla(buscaRol);
                        string idRol = " ";
                        foreach (DataRow unRol in elRolAgregado.Rows)
                        {
                            idRol = unRol["idRol"].ToString();
                        }



                        foreach (Object item in checkedListBox1.CheckedItems)
                        {

                            ComboboxItem unItem = new ComboboxItem();

                            unItem = (ComboboxItem)item;

                            SqlCommand cmdFuncionalidad = new SqlCommand("delete from Select_group.Funcionalidad_Por_Rol (rol_idRol, funcionalidad_idFuncionalidad) where Funcionalidad_por_Rol.rol_idRol= @idRol and Funcionalidad_por_Rol.funcionalidad_idFuncionalidad = @idFunc)", conexion);
                            cmdFuncionalidad.Parameters.AddWithValue("@idRol", idRol);//Aca pasar el idRol recuperado previamente
                            cmdFuncionalidad.Parameters.AddWithValue("@idFunc", unItem.Value);
                            cmdFuncionalidad.ExecuteNonQuery();


                        }



                        MessageBox.Show("Bien! Rol con las nuevas funcionalidades asignadas ");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


           Conexion.conectar();
            DataTable roles = new DataTable();

            string consultaStr = "select idFuncionalidad, descripcion from  SELECT_GROUP.Funcionalidad_por_Rol inner join SELECT_GROUP.Rol on Funcionalidad_por_Rol.rol_idRol = rol.idRol and Rol.nombre='" + rolABuscar + " inner join Select_Group.Funcionalidad on  Funcionalidad_por_Rol=Funcionalidad.idFuncionalidad";

            roles = Conexion.LeerTabla(consultaStr);

           DataTable otrosRoles = new DataTable();


            foreach (DataRow idRol in otrosRoles.Rows)
            {
               ComboboxItem unRol = new ComboboxItem();

                unRol.Text = idRol["nombre"].ToString();
                unRol.Value = idRol["idRol"].ToString();

                checkedListBox1.Items.Add(unRol);



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
                    //string str[] = new string(checkedListBox1.CheckedItems.Count);
                    //Dim str(checkedListBox1.CheckedItems.Count) As string;
                    //string str[checkedListBox1.CheckedItems.Count] = new String(checkedListBox1.CheckedItems.Count);
                    if (checkedListBox2.CheckedItems.Count > 0)
                    {

                     

                        //Aca poner query que busque el Rol por la descripción y levantar el idRol

                        string buscaRol = "SELECT idRol FROM Select_Group.Rol WHERE nombre = '" + rolABuscar.Text.ToString() + "'";

                        DataTable elRolAgregado = new DataTable();
                        Conexion.conectar();
                        elRolAgregado = Conexion.LeerTabla(buscaRol);
                        string idRol = " ";
                        foreach (DataRow unRol in elRolAgregado.Rows)
                        {
                            idRol = unRol["idRol"].ToString();
                        }



                        foreach (Object item in checkedListBox2.CheckedItems)
                        {

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
    }
}

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

 namespace ClinicaFrba.AbmRol
{ 
    public partial class asignarRolUser : Form
    {
        public string menuAnterior;
        public Form formAnterior;
        public asignarRolUser()
        {
            InitializeComponent();
        }
        public string idUsuario = "0";
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdRol = new SqlCommand("Select_Group.asignarRol", cnx);
            cmdRol.CommandType = CommandType.StoredProcedure;
            cmdRol.Parameters.Add("@username", SqlDbType.VarChar).Value = username.Text;
            cmdRol.Parameters.Add("@ROL", SqlDbType.VarChar).Value = rolDesasignar.Text;

           

            try
            {

                cnx.Open();
                cmdRol.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
                HomeAfiliado home = new HomeAfiliado();
                home.Show();
                this.Close();
            }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            username.Text = username.Text.Trim();
            username.Text = username.Text.Replace(" ", "");
            username.SelectionStart = username.Text.Length;
        }
        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (Char.IsDigit(e.KeyChar))
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
            }*/
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void asignarRolUsuario_Load(object sender, EventArgs e)
        {
           
        }



        private void btnRolAsignar_Click(object sender, EventArgs e)
        {
           /* SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdRol = new SqlCommand("Select_Group.asignarRol", cnx);
            cmdRol.CommandType = CommandType.StoredProcedure;
            cmdRol.Parameters.Add("@username", SqlDbType.VarChar).Value = username.Text;
            cmdRol.Parameters.Add("@ROL", SqlDbType.VarChar).Value = rolAsignar.Text;
           

            try
            {

                cnx.Open();
                cmdRol.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
                HomeAfiliado home = new HomeAfiliado();
                home.Show();
                this.Close();
            }*/
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            formAnterior.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(username.Text))
            {//Cargo Roles
                checkedListBox1.ResetText();
                checkedListBox1.Items.Clear();

                Conexion.conectar();
                DataTable rolesDeUnuser = new DataTable();

                //valido que exista el usuario
                using (SqlCommand cmdUser = new SqlCommand("SELECT COUNT(*) from select_group.Usuario where Usuario.nombreUsuario = @username", Conexion.conexion))
                {
                    cmdUser.Parameters.AddWithValue("@username", username.Text);
                    int userCount = (int)cmdUser.ExecuteScalar();
                    //si el usuario existe, que le asigne el rol
                    if (userCount == 1)
                    {
                        string consultaRoles = "SELECT R.idRol, R.nombre, U.idUsuario FROM Select_Group.Usuario  U JOIN Select_Group.Usuario_Por_Rol UxR ON UxR.usuario_username = U.idUsuario JOIN Select_Group.Rol R ON R.idRol = UxR.rol_idRol WHERE R.habilitado = 1 AND nombreUsuario = '" + username.Text.ToString().Trim() + "'";
                        rolesDeUnuser = Conexion.LeerTabla(consultaRoles);
                        List<ComboboxItem> ListaRolesUsuario = new List<ComboboxItem>();
                        foreach (DataRow unRolDeUser in rolesDeUnuser.Rows)
                        {
                            ComboboxItem unItemRol = new ComboboxItem();
                            unItemRol.Value = unRolDeUser["idRol"].ToString().Trim();
                            unItemRol.Text = unRolDeUser["nombre"].ToString().Trim();
                            idUsuario = unRolDeUser["idUsuario"].ToString().Trim();
                            ListaRolesUsuario.Add(unItemRol);
                        }
                        string queryTodosLosRoles = "SELECT idRol, nombre FROM Select_Group.Rol WHERE habilitado = 1";
                        DataTable todosLosRoles = new DataTable();
                        todosLosRoles = Conexion.LeerTabla(queryTodosLosRoles);
                        foreach (DataRow unRol in todosLosRoles.Rows)
                        {
                            ComboboxItem itemRol = new ComboboxItem();
                            itemRol.Value = unRol["idRol"].ToString();
                            itemRol.Text = unRol["nombre"].ToString();
                            checkedListBox1.Items.Add(itemRol);
                        }
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            foreach (ComboboxItem unItemRol in ListaRolesUsuario)
                            {
                                ComboboxItem itemCheckList = new ComboboxItem();
                                itemCheckList = (ComboboxItem)checkedListBox1.Items[i];
                                if (unItemRol.Value.Equals(itemCheckList.Value))
                                {
                                    checkedListBox1.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario ingresado no existente");
                    }
                }
            }
            else 
            { 
                MessageBox.Show("Debe ingresar un Usuario"); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
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

                        string buscaRol = "SELECT idRol FROM Select_Group.Rol WHERE nombre = '' ";

                        DataTable elRolAgregado = new DataTable();
                        Conexion.conectar();
                        elRolAgregado = Conexion.LeerTabla(buscaRol); //Descomento esta linea, sino no lee nada (4/12)
                        string idRol = " ";
                        foreach (DataRow unRol in elRolAgregado.Rows)
                        {
                            idRol = unRol["idRol"].ToString();
                        }

    
                            SqlCommand cmdFuncionalidad = new SqlCommand("delete from Select_group.Usuario_Por_Rol  where usuario_username = @idUsuario ", conexion);
                            cmdFuncionalidad.Parameters.AddWithValue("@idUsuario", idUsuario);

                            cmdFuncionalidad.ExecuteNonQuery();

                        foreach (Object item in checkedListBox1.CheckedItems)
                        {

                            ComboboxItem unItem = new ComboboxItem();

                            unItem = (ComboboxItem)item;

                            cmdFuncionalidad = new SqlCommand("insert into Select_group.Usuario_Por_Rol (rol_idRol, usuario_username) values(@idRol,@idUsuario)", conexion);
                            cmdFuncionalidad.Parameters.AddWithValue("@idRol", unItem.Value.ToString().Trim());//Aca pasar el idRol recuperado previamente
                            cmdFuncionalidad.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdFuncionalidad.ExecuteNonQuery();

                        }


                        MessageBox.Show("Usuario actualizado ");
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
    }
}

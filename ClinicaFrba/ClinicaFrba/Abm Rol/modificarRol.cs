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
        public Form frmAnterior;
        public string unidRol = "0";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void modificarRol_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            //comboBox1.ResetText();


            //Cargo el rol
            Conexion.conectar();
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            comboBox1.SelectedText = "Seleccione Rol";
            DataTable Roles = new DataTable();
            string cadena = "select idRol, nombre from SELECT_GROUP.Rol";

            Roles = Conexion.LeerTabla(cadena);

            foreach (DataRow roles in Roles.Rows)
            {

                string desc = roles["nombre"].ToString();
                ComboboxItem itemRol = new ComboboxItem();

                itemRol.Text = roles["nombre"].ToString();
                itemRol.Value = roles["idRol"].ToString();

                comboBox1.Items.Add(itemRol);
            }
            Conexion.conexion.Close();

            //Fin de carga
   
        }


        private void button1_Click_1(object sender, EventArgs e)
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



                        foreach (Object item in checkedListBox1.CheckedItems)
                        {

                            ComboboxItem unItem = new ComboboxItem();

                            unItem = (ComboboxItem)item;

                            SqlCommand cmdFuncionalidad = new SqlCommand("delete from Select_group.Funcionalidad_Por_Rol  where Funcionalidad_por_Rol.rol_idRol= @idRol ", conexion);
                            cmdFuncionalidad.Parameters.AddWithValue("@idRol", unidRol);//Aca pasar el idRol recuperado previamente

                            cmdFuncionalidad.ExecuteNonQuery();


                        }

                        foreach (Object item in checkedListBox1.CheckedItems)
                        {

                            ComboboxItem unItem = new ComboboxItem();

                            unItem = (ComboboxItem)item;

                            SqlCommand cmdFuncionalidad = new SqlCommand("insert into Select_group.Funcionalidad_Por_Rol (rol_idRol, funcionalidad_idFuncionalidad) values(@idRol,@idFunc)", conexion);
                            cmdFuncionalidad.Parameters.AddWithValue("@idRol", unidRol);//Aca pasar el idRol recuperado previamente
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

        public void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            Object rolABuscar = comboBox1.SelectedItem;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            checkedListBox1.ResetText();
            checkedListBox1.Items.Clear();

            Conexion.conectar();
            DataTable roles = new DataTable();



            ComboboxItem rolelejido = (ComboboxItem)comboBox1.SelectedItem;

            string consultaStr = "SELECT R.idRol, F.descripcion, F.idFuncionalidad  FROM Select_Group.Rol R JOIN Select_Group.Funcionalidad_Por_Rol FR ON FR.rol_idRol = R.idRol JOIN Select_Group.Funcionalidad F ON F.idFuncionalidad = FR.funcionalidad_idFuncionalidad WHERE nombre = '" + rolelejido.Text.ToString() + "'";

            roles = Conexion.LeerTabla(consultaStr);

            List<ComboboxItem> funcdeunRol = new List<ComboboxItem>();


            foreach (DataRow idRol in roles.Rows)
            {
                ComboboxItem unRol = new ComboboxItem();
                unidRol = idRol["idRol"].ToString().Trim();
                unRol.Text = idRol["descripcion"].ToString().Trim();
                unRol.Value = idRol["idFuncionalidad"].ToString().Trim();

                funcdeunRol.Add(unRol);



            }

            string queryTodasLasFunc = "SELECT idFuncionalidad, descripcion FROM Select_Group.Funcionalidad";

            DataTable todaslasFunc = new DataTable();

            todaslasFunc = Conexion.LeerTabla(queryTodasLasFunc);

            foreach (DataRow unaFunc in todaslasFunc.Rows)
            {
                ComboboxItem Func = new ComboboxItem();

                Func.Value = unaFunc["idFuncionalidad"].ToString();
                Func.Text = unaFunc["descripcion"].ToString();

                checkedListBox1.Items.Add(Func);


            }


            for (int i = 0; i < checkedListBox1.Items.Count - 1; i++)
            {


                foreach (ComboboxItem unItem in funcdeunRol)
                {

                    ComboboxItem itemCheckList = new ComboboxItem();

                    itemCheckList = (ComboboxItem)checkedListBox1.Items[i];

                    if (unItem.Value.Equals(itemCheckList.Value))
                    {
                        checkedListBox1.SetItemChecked(i, true);

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            abmMenuRol frmMenu = new abmMenuRol();
            frmMenu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAnterior.Show();
            this.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnActualizar.Enabled = true;
        }

     
    }
}

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
           
        }


        private void button1_Click_1(object sender, EventArgs e)
        {

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
    }
}

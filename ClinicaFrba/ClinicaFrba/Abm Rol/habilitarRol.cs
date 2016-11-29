using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClinicaFrba.Base_de_Datos;
using System.Configuration;


namespace ClinicaFrba.AbmRol
{
    public partial class habilitarRol : Form
    {
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.conectar();
            DataTable roles = new DataTable();

            string consultaStr = "select idRol, nombre from SELECT_GROUP.Rol where rol.habilitado=0";

            roles = Conexion.LeerTabla(consultaStr);

            DataTable nombreFuncionalidades = new DataTable();


            foreach (DataRow idRol in roles.Rows)
            {
                ComboboxItem unRol = new ComboboxItem();

                unRol.Text = idRol["nombre"].ToString();
                unRol.Value = idRol["idRol"].ToString();

                checkedListBox1.Items.Add(unRol);
            }
        }

        private void habilitarRol_Load(object sender, EventArgs e)
        {
        
        }

       

      
        }
    
}

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

namespace ClinicaFrba.Abm_Rol
{
    public partial class habilitarRol : Form
    {
        public habilitarRol()
        {
            InitializeComponent();
        }

        private void habilitarRol_Load(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

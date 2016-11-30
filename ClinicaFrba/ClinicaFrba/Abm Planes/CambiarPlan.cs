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

namespace ClinicaFrba.Abm_Planes
{
    public partial class CambiarPlan : Form
    {
        public int idPlanMed = 0;
        public CambiarPlan(string strIdAfiliado)
        {
            InitializeComponent();
            textBox1.Text = strIdAfiliado;
        }

        private void CambiarPlan_Load(object sender, EventArgs e)
        {
            //Cargo el plan
            Conexion.conectar();
            cbmPlanMed.Items.Clear();
            cbmPlanMed.ResetText();
            cbmPlanMed.SelectedText = "Seleccione Nuevo Plan";
            DataTable Planes = new DataTable();
            string cadena = "select descripcion from SELECT_GROUP.Plan_Med";

            Planes = Conexion.LeerTabla(cadena);

            foreach (DataRow planes in Planes.Rows)
            {

                string desc = planes["descripcion"].ToString();
                ComboboxItem itemEsp = new ComboboxItem();

                itemEsp.Text = desc;
                itemEsp.Value = planes["descripcion"].ToString();

                cbmPlanMed.Items.Add(itemEsp);

            }
            Conexion.conexion.Close();
            // Fin de carga del plan

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbmPlanMed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

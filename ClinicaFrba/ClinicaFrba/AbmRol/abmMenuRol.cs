using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class abmMenuRol : Form
    {
        public abmMenuRol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //this.textBox1 = " ABM Rol ";

        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            eliminarRol.ActiveForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            crearRol.ActiveForm.Show();
        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {
            modificarRol.ActiveForm.Show();
        }

        private void btnAsignarDesRol_Click(object sender, EventArgs e)
        {
           // asignarRolUser.ActiveForm.Show();
        }
    }
}

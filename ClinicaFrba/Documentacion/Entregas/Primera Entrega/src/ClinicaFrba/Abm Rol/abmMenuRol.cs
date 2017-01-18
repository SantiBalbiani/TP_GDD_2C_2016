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
            eliminarRol frmeliminarRol = new eliminarRol();
            frmeliminarRol.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            crearRol frmCrearRol = new crearRol();
            frmCrearRol.Show();
            this.Close();

        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {
            modificarRol frmModificarRol = new modificarRol();
            frmModificarRol.Show();
            this.Close();
            
        }

        private void btnAsignarDesRol_Click(object sender, EventArgs e)
        {
            asignarRolUser frmAsignarRol = new asignarRolUser();
            frmAsignarRol.Show();
            this.Close();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            abmMenuRol frmABMRol = new abmMenuRol();
            frmABMRol.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            habilitarRol frmHabilitarRol = new habilitarRol();
            frmHabilitarRol.Show();
            this.Close();
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Menu_Principal.HomeAdmin frmMenu = new Menu_Principal.HomeAdmin();
            frmMenu.Show();
            this.Close();
        }
    }
}

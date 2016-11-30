using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Registro_Resultado;

namespace ClinicaFrba.Menu_Principal
{
    public partial class HomeProfesional : Form
    {
        public HomeProfesional()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Ver que tenga un turno en este horario
            
            RegistroResultado frmRegRes = new RegistroResultado();
            this.Hide();
            frmRegRes.Show();
        }

        private void HomeProfesional_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

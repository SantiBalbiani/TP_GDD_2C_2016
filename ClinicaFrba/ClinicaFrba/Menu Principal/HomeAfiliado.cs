using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Pedir_Turno;

namespace ClinicaFrba
{
    public partial class HomeAfiliado : Form
    {
        public HomeAfiliado()
        {
            InitializeComponent();
            this.txtBonosDisponibles.Enabled = false; 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //ClinicaFrba.Abm_Afiliado.frmAltaAfiliado frm = new Abm_Afiliado.frmAltaAfiliado();
            //ClinicaFrba.Abm_Afiliado.AltaPareja frmPareja = new Abm_Afiliado.AltaPareja();
           // frmPareja.Show();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void HomeAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmComprarBonos frmComprarBonos = new FrmComprarBonos();
            frmComprarBonos.Show();
        }

        private void txtBonosDisponibles_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSolTurno frmSolTurno = new FrmSolTurno();
            frmSolTurno.Show();
            
        }
    }
}

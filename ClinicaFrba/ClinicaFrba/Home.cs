using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ClinicaFrba.Abm_Afiliado.frmAltaAfiliado frm = new Abm_Afiliado.frmAltaAfiliado();
            frm.Show();
            
        }
    }
}

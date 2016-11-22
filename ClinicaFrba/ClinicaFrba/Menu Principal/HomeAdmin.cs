using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Menu_Principal
{
    public partial class HomeAdmin : Form
    {
        public HomeAdmin()
        {
            InitializeComponent();
        }

        private void HomeAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnAltaAfiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.frmAltaAfiliado frmAlta = new Abm_Afiliado.frmAltaAfiliado();
            frmAlta.Show();
       
        }

        private void btnAgregarParejaAfiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.AltaPareja frmAgregarPareja = new Abm_Afiliado.AltaPareja(); 
            frmAgregarPareja.Show();

        }

        private void btnAgregarFamiliar_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.AltaFamiliar frmAgregarFamiliar = new Abm_Afiliado.AltaFamiliar();
            frmAgregarFamiliar.Show();
        }

        private void btnRegistrarLlegada_Click(object sender, EventArgs e)
        {
            Registro_Llegada.Llegada frmRegistrar = new Registro_Llegada.Llegada();
            frmRegistrar.Show();
        }

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
           
        }
    }
}

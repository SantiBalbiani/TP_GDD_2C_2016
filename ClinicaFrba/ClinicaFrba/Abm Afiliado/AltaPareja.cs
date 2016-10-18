using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaPareja : Form
    {
        public AltaPareja()
        {
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            //Acá guardamos los datos de la pareja en una tabla temporal
            //o en alguna variable para despues poder persistirla en la BD
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e) //No hace nada, solo cierra.
        {
            this.Close();
        }
    }
}

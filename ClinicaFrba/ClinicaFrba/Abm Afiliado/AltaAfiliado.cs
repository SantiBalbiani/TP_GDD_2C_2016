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
    public partial class frmAltaAfiliado : Form
    {
        public frmAltaAfiliado()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHijos_CheckedChanged(object sender, EventArgs e){
            this.txtCantHijos.Enabled = true;
            this.btnCargaHijos.Enabled = true;
        }

        private void cmbEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcionDelCombo = cmbEstadoCivil.SelectedItem.ToString();

            switch (opcionDelCombo)
            {
              case "Casado/a":
                    this.btnCargaPareja.Enabled = true;
                 break;
              case "Concubinato":
                 this.btnCargaPareja.Enabled = true;
                break;
            default:
                this.btnCargaPareja.Enabled = false;
                break;
                    }
        }

        private void btnCargaPareja_Click(object sender, EventArgs e)
        {
            AltaPareja frm = new AltaPareja();
            frm.Show();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }
            
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
           /* if(is_validate())
            {
                epError.Clear();
                MessageBox.Show("Datos agregados correctamente","Validaciones");
            }
            */
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }         

    }
}

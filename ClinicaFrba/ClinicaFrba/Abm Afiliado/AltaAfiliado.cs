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
            if(is_validate())
            {
                epError.Clear();
                MessageBox.Show("Datos agregados correctamente","Validaciones");
            }

        }
        private bool is_validate()
        {
            bool no_error = true;

            if(txtNombre.Text == String.Empty){

                epError.SetError(txtNombre, "Ingrese su nombre");
                no_error = false;
            }
            else{
                try
                {
                    string apellido = txtApellido.Text;
                }
                catch
                {
                    epError.Clear();
                    epError.SetError(txtApellido,"Ingrese el Apellido");
                    return false;
                }
                try
                {
                    int i = Convert.ToInt32(txtNroDocumento.Text);

                }
                catch
                {
                    epError.Clear();
                    epError.SetError(txtNroDocumento, "Ingrese numero de DNI");
                    return false;
                }
                
                try{
                    string direccion = txtDireccion.Text;
                    }
                catch{
                    epError.Clear();
                    epError.SetError(txtDireccion, "Ingrese su Direccion");
                    return false;
                }
                try{
                    int telefono = Convert.ToInt32(txtTelefono.Text);
                    }
                catch{
                    epError.Clear();
                    epError.SetError(txtTelefono, "Ingrese su telefono");
                    return false;
                }
                try 
                {
                    DateTime fechaNac = Convert.ToDateTime(txtFechaNacimiento.Text);
                }
                catch{
                    epError.Clear();
                    epError.SetError(txtFechaNacimiento, "Ingrese su fecha de Nacimiento");
                    return false;
                }
                try
                {
                    string mail = txtMail.Text;
                }
                catch
                {
                    epError.Clear();
                    epError.SetError(txtMail,"Ingrese su Mail");
                    return false;
                }
                try 
                {
                    string sexo = cmbSexo.Text;
                }
                catch
                {
                    epError.Clear();
                    epError.SetError(cmbSexo, "Seleccione su Sexo");
                    return false;
                }
                try
                {
                    string estadoCivil = cmbEstadoCivil.Text;    
                }
                catch
                {
                    epError.Clear();
                    epError.SetError(cmbEstadoCivil, "Seleccione su estado civil");
                    return false;
                }
                //Falta ver los casos de familiares

                try
                {
                    int planMedico = Convert.ToInt32(txtPlanMedico.Text);
                }
                catch
                {
                    epError.Clear();
                    epError.SetError(txtPlanMedico, "Ingrese su plan Medico");
                    return false;
                }
            }
            return no_error;
        }         

    }
}

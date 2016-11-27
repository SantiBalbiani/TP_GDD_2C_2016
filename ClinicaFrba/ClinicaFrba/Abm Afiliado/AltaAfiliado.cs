using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria;
using System.Data.SqlClient;
using ClinicaFrba.Base_de_Datos;
using System.Configuration;


namespace ClinicaFrba.Abm_Afiliado
{
    public partial class frmAltaAfiliado : Form
    {
        public DataTable afiliadosTable = new DataTable("SELECT_GROUP.Afiliado");
        public Boolean tieneHijos = false;

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
            if (true)
            {
                tieneHijos = true;
            }            
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
            if (Utilidades.ValidarFormulario(this, errorTextBox) == false)
            {
                DataRow afiliado = afiliadosTable.NewRow();
                afiliado["Nombre"] = textNombre.Text;
                afiliado["Apellido"] = textApellido.Text;
                afiliado["TipoDoc"] = textTipoDoc;
                afiliado["Dni"] = Convert.ToInt32(textDni.Text);
                afiliado["Direccion"] = textDireccion.Text;
                afiliado["Telefono"] = textTelefono.Text;
                afiliado["FechaNac"] = textFechaNac.Text;
                afiliado["Mail"] = textMail.Text;
                afiliado["Sexo"] = cmbSexo.Text;
                afiliado["Estado Civil"] = cmbEstadoCivil.Text;
                afiliado["Plan Med"] = cbmPlanMed.Text;

                afiliadosTable.Rows.Add(afiliado);

                AltaPareja frm = new AltaPareja(afiliadosTable,afiliado,tieneHijos);
                frm.Show();
              }
            else {
                MessageBox.Show("Faltan Campos ingresar");
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }
            
        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
           
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }         
      

        private void cmbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAltaAfiliado_Load(object sender, EventArgs e)
        {
            
           
            string query = "select PM.descripcion from SELECT_GROUP.Plan_Med as PM";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                cbmPlanMed.Items.Add(Convert.ToString(fila["descripcion"]));
            }

            DataColumn nombre = afiliadosTable.Columns.Add("Nombre", typeof(String));
            afiliadosTable.Columns.Add("Apellido", typeof(String));
            afiliadosTable.Columns.Add("TipoDoc", typeof(String));
            afiliadosTable.Columns.Add("Dni", typeof(Int32));
            afiliadosTable.Columns.Add("Direccion", typeof(String));
            afiliadosTable.Columns.Add("Telefono", typeof(Int32));
            afiliadosTable.Columns.Add("FechaNac", typeof(DateTime));
            afiliadosTable.Columns.Add("Mail", typeof(String));
            afiliadosTable.Columns.Add("Sexo", typeof(String));
            afiliadosTable.Columns.Add("Estado Civil", typeof(String));
            afiliadosTable.Columns.Add("Plan Med", typeof(String));
        }

    }
}

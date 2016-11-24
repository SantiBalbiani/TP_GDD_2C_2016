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
            
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Utilidades.ValidarFormulario(this, errorTextBox) == false)
            {
                if (ingresarDatos(this))
                {
                    MessageBox.Show("Afiliado dado de alta correctamente");
                }
                else
                {
                    MessageBox.Show("Afiliado no ha podido ser dado de alta en este momento");
                }
            }
            else {
                MessageBox.Show("Ingrese todos los campos");
            }
           
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }         
        public static Boolean ingresarDatos(frmAltaAfiliado formulario){

            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.AltaAfiliado", cnx);
            cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_nombre", SqlDbType.VarChar).Value = formulario.textNombre.Text;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_Apellido", SqlDbType.VarChar).Value = formulario.textApellido.Text;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_tipoDni", SqlDbType.VarChar).Value = formulario.textTipoDoc.Text;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_numeroDni", SqlDbType.Int).Value = formulario.textDni.Text;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_telefono", SqlDbType.Int).Value = formulario.textTelefono.Text;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_mail", SqlDbType.VarChar).Value = formulario.textMail.Text;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_fechaNac", SqlDbType.DateTime).Value = formulario.textFechaNac.Text;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_Sexo", SqlDbType.VarChar).Value = formulario.cmbSexo.Text;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_EstadoCivil", SqlDbType.VarChar).Value = formulario.cmbEstadoCivil.Text;
            cmdAltaAfiliado.Parameters.Add("@Afiliado_Direccion", SqlDbType.VarChar).Value = formulario.textDireccion.Text;
            try
            {
                cnx.Open();
                cmdAltaAfiliado.ExecuteNonQuery();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
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
        }

    }
}

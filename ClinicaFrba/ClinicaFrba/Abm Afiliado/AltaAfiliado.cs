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
        public int idUsuario;
        public int idPlanMed = 0;
        public DataTable afiliadosTable = new DataTable();
        public Boolean tieneHijos = false;
        public Boolean nuevo = true;

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
                afiliado["nombre"] = textNombre.Text;
                afiliado["apellido"] = textApellido.Text;
                afiliado["tipoDni"] = textTipoDoc.Text;
                afiliado["numeroDni"] = Convert.ToInt32(textDni.Text);
                afiliado["telefono"] = Convert.ToInt32(textTelefono.Text);
                afiliado["mail"] = textMail.Text;
                afiliado["fechaNac"] = dateTimePicker1.Value.Date;
                    
                    //Convert.ToDateTime(textFechaNac.Text);
                afiliado["sexo"] = cmbSexo.Text;
                afiliado["estadoCivil"] = cmbEstadoCivil.Text;
                afiliado["direccion"] = textDireccion.Text;
                int usuarioIdAfiliado = registrarUsuario(Convert.ToInt32(textDni.Text));
                afiliado["usuarioId"] = usuarioIdAfiliado;
               
                string query = "select PM.idPlan from SELECT_GROUP.Plan_Med as PM where descripcion = ('" + cbmPlanMed.Text + "')";
                DataTable dt = Conexion.EjecutarComando(query);
                foreach (DataRow fila in dt.Rows)
                {
                    idPlanMed = Convert.ToInt32((fila["idPlan"]));
                    afiliado["planMed"] = idPlanMed;
                }

                

                afiliadosTable.Rows.Add(afiliado);

                AltaPareja frm = new AltaPareja(afiliadosTable,afiliado,tieneHijos,nuevo);
                frm.Show();
                this.Close();
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
            if (Utilidades.ValidarFormulario(this, errorTextBox) == false)
            {
                
                DataRow afiliado = afiliadosTable.NewRow();
                afiliado["nombre"] = textNombre.Text;
                afiliado["apellido"] = textApellido.Text;
                afiliado["tipoDni"] = textTipoDoc.Text;
                afiliado["numeroDni"] = Convert.ToInt32(textDni.Text);
                
                afiliado["telefono"] = Convert.ToInt32(textTelefono.Text);
                
                afiliado["mail"] = textMail.Text;
                afiliado["fechaNac"] = dateTimePicker1.Value.Date;
                    
                  //  Convert.ToDateTime(textFechaNac.Text);
                afiliado["sexo"] = cmbSexo.Text;
                afiliado["estadoCivil"] = cmbEstadoCivil.Text;
                afiliado["direccion"] = textDireccion.Text;
                int usuarioIdAfiliado = registrarUsuario(Convert.ToInt32(textDni.Text));
                afiliado["usuarioId"] = usuarioIdAfiliado;
                string query = "select PM.idPlan from SELECT_GROUP.Plan_Med as PM where descripcion = ('" + cbmPlanMed.Text.Trim() + "')";
                DataTable dt = Conexion.EjecutarComando(query);
                foreach (DataRow fila in dt.Rows)
                {
                    idPlanMed = Convert.ToInt32((fila["idPlan"]));
                    afiliado["PlanMed"] = idPlanMed;
                }

                

                afiliadosTable.Rows.Add(afiliado);

                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.sp_AltaAfiliado", cnx);
                cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                cmdAltaAfiliado.Parameters.Add("@Afiliados", SqlDbType.Structured).Value = afiliadosTable;
                try
                {
                 cnx.Open();
                 cmdAltaAfiliado.ExecuteNonQuery();
                 MessageBox.Show("Se han guardado correctamente los datos");
                 Menu_Principal.HomeAdmin frmAdmin = new Menu_Principal.HomeAdmin();
                 frmAdmin.Show();
                 this.Close();
                }
                catch (ApplicationException error)
                {
                  string mensaje = "Se ha producido un error ";
                  ApplicationException excep = new ApplicationException(mensaje, error);
                  excep.Source = this.Text;
                }
                }else
            {
                MessageBox.Show("Faltan Campos ingresar");
            }
           
        }

        public int registrarUsuario(int p)
        {

            string nroDocumento = textDni.Text.Trim();
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.sp_CrearUsuario", cnx);
            cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
            cmdAltaAfiliado.Parameters.Add("@Dni", SqlDbType.Int).Value = Convert.ToInt32(textDni.Text);
            try
            {
                cnx.Open();
                cmdAltaAfiliado.ExecuteNonQuery();
                string query = "select US.idUsuario from SELECT_GROUP.Usuario as US where nombreUsuario = ('" + nroDocumento + "')";
                DataTable dt = Conexion.EjecutarComando(query);
                foreach (DataRow fila in dt.Rows)
                {
                    idUsuario = Convert.ToInt32((fila["idUsuario"]));
                    
                }
            }
            catch (ApplicationException error)
            {
                string mensaje = "Se ha producido un error ";
                ApplicationException excep = new ApplicationException(mensaje, error);
                excep.Source = this.Text;
                idUsuario = -1;
                                
            }
            return idUsuario;

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

            DataColumn nombre = afiliadosTable.Columns.Add("nombre", typeof(String));
            afiliadosTable.Columns.Add("apellido", typeof(String));
            afiliadosTable.Columns.Add("tipoDni", typeof(String));
            afiliadosTable.Columns.Add("numeroDni", typeof(Int32));
            afiliadosTable.Columns.Add("telefono", typeof(Int32));
            afiliadosTable.Columns.Add("mail", typeof(String));
            afiliadosTable.Columns.Add("fechaNac", typeof(DateTime));
            afiliadosTable.Columns.Add("sexo", typeof(String));
            afiliadosTable.Columns.Add("estadoCivil", typeof(String));
            afiliadosTable.Columns.Add("direccion", typeof(String));
            afiliadosTable.Columns.Add("usuarioId", typeof(Int32));
            afiliadosTable.Columns.Add("planMed", typeof(Int32));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textFechaNac_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

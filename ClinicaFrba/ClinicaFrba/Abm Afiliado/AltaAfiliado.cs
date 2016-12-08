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
        public int cantidadHijos;
        public int nroAfiliado = 0;
        public int idPlanMed = 0;
        public DataTable afiliadosTable = new DataTable();
        public Boolean tieneHijos = false;
        public Boolean nuevo = true;
        public string menuAnterior;
        public Menu_Principal.HomeCustom Home;
        
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
            //Globals.irAtras(menuAnterior, this);
        }

        public int generarNumeroAfiliado()
        {
            
            string query = "select max(AF.idAfiliado) as idAfiliado from SELECT_GROUP.Afiliado as AF";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                nroAfiliado = (((Convert.ToInt32(fila["idAfiliado"]) + 1) * 100) + 1);
            }
            return nroAfiliado;
            
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
                cantidadHijos = Convert.ToInt32(textCantHijos.Text);
                nroAfiliado = generarNumeroAfiliado();
                
                afiliadosTable = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(afiliadosTable, nroAfiliado, textNombre.Text, textApellido.Text,
                                                                                    textTipoDoc.Text, Convert.ToInt32(textDni.Text),
                                                                                    Convert.ToInt32(textTelefono.Text), textMail.Text,
                                                                                    dateTimePicker1.Value.Date, cmbSexo.Text, cmbEstadoCivil.Text,
                                                                                    cantidadHijos,textDireccion.Text, cbmPlanMed.Text);

                DataRow afiliado = afiliadosTable.Rows[0];
                
                if(Convert.ToInt32(textCantHijos.Text) > 0)
                    {
                        tieneHijos = true;
                    }
                AltaPareja frm = new AltaPareja(afiliadosTable,afiliado,tieneHijos,nuevo,cantidadHijos);
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

                nroAfiliado = generarNumeroAfiliado();                

                afiliadosTable = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(afiliadosTable, nroAfiliado, textNombre.Text, textApellido.Text,
                                                                                   textTipoDoc.Text, Convert.ToInt32(textDni.Text),
                                                                                   Convert.ToInt32(textTelefono.Text), textMail.Text,
                                                                                   dateTimePicker1.Value.Date, cmbSexo.Text, cmbEstadoCivil.Text,
                                                                                   Convert.ToInt32(textCantHijos.Text), textDireccion.Text, cbmPlanMed.Text);


                DataRow afiliado = afiliadosTable.Rows[0];

                /*DataRow afiliado = afiliadosTable.NewRow();
                afiliado["nroAfiliado"] = 01;
                afiliado["nombre"] = textNombre.Text;
                afiliado["apellido"] = textApellido.Text;
                afiliado["tipoDoc"] = textTipoDoc.Text;
                afiliado["numeroDoc"] = Convert.ToInt32(textDni.Text);
                afiliado["telefono"] = Convert.ToInt32(textTelefono.Text);
                afiliado["mail"] = textMail.Text;
                afiliado["fechaNac"] = dateTimePicker1.Value.Date;
                  //  Convert.ToDateTime(textFechaNac.Text);
                afiliado["sexo"] = cmbSexo.Text;
                afiliado["estadoCivil"] = cmbEstadoCivil.Text;
                afiliado["direccion"] = textDireccion.Text;
                int usuarioIdAfiliado = estructuraBD.registrarUsuario(Convert.ToInt32(textDni.Text));
                afiliado["idUsuario"] = usuarioIdAfiliado;
                string query = "select PM.idPlan from SELECT_GROUP.Plan_Med as PM where descripcion = ('" + cbmPlanMed.Text.Trim() + "')";
                DataTable dt = Conexion.EjecutarComando(query);
                foreach (DataRow fila in dt.Rows)
                {
                    idPlanMed = Convert.ToInt32((fila["idPlan"]));
                    afiliado["plan_idPlan"] = idPlanMed;
                }*/
                //afiliadosTable.Rows.Add(afiliado);
                
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.AltaAfiliado", cnx);
                cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
               // cmdAltaAfiliado.Parameters.Add("@Afiliados", SqlDbType.Structured).Value = afiliadosTable;

                SqlParameter unParametro = cmdAltaAfiliado.Parameters.AddWithValue("@Afiliados", afiliadosTable);
                unParametro.SqlDbType = SqlDbType.Structured;
                unParametro.TypeName = "Select_Group.dt_Afiliados";
                
                try
                {
                 cnx.Open();
                 cmdAltaAfiliado.ExecuteNonQuery();
                 MessageBox.Show("Se han guardado correctamente los datos");
                 //Menu_Principal.HomeAdmin frmAdmin = new Menu_Principal.HomeAdmin();
                 //frmAdmin.Show();
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
            
            this.btnCargaPareja.Enabled = false;
            

            string query = "select PM.descripcion from SELECT_GROUP.Plan_Med as PM";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                cbmPlanMed.Items.Add(Convert.ToString(fila["descripcion"]));
            }

            afiliadosTable = Abm_Afiliado.estructuraBD.crearEstructuraAfiliado(afiliadosTable);

           /* DataColumn nombre = afiliadosTable.Columns.Add("nombre", typeof(String));
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
            afiliadosTable.Columns.Add("planMed", typeof(Int32));*/
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textFechaNac_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCargarHijos_Click(object sender, EventArgs e)
        {
            cantidadHijos = Convert.ToInt32(textCantHijos.Text);
            if(cantidadHijos > 0)
                {
                    if (Utilidades.ValidarFormulario(this, errorTextBox) == false)
                    {
                        
                        nroAfiliado = generarNumeroAfiliado();
                        afiliadosTable = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(afiliadosTable, nroAfiliado, textNombre.Text, textApellido.Text,
                                                                                            textTipoDoc.Text, Convert.ToInt32(textDni.Text),
                                                                                            Convert.ToInt32(textTelefono.Text), textMail.Text,
                                                                                            dateTimePicker1.Value.Date, cmbSexo.Text, cmbEstadoCivil.Text,
                                                                                            cantidadHijos, textDireccion.Text, cbmPlanMed.Text);

                        DataRow afiliado = afiliadosTable.Rows[0];

                        
                        AltaHijo frm = new AltaHijo(afiliadosTable, afiliado,cantidadHijos,nuevo);
                        frm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Faltan Campos ingresar");
                    }

                }
            else{
                MessageBox.Show("No ingreso una cantidad de hijos valida");                
            }
        }

    }
}

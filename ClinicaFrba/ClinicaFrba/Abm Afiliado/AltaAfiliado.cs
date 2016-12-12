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
        public int numeroDocumento;
        public int nroAfiliado;
        public int idPlanMed;
        public DataTable afiliadosTable = new DataTable();
        public Boolean tieneHijos;
        public Boolean afiliadoNuevo;
        public string menuAnterior;
        public Form Home;

        
        public frmAltaAfiliado()
        {
            InitializeComponent();
            afiliadoNuevo = true;
            tieneHijos = false;
            idPlanMed = 0;
            nroAfiliado = 0;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Globals.irAtras(menuAnterior, this);
            Home.Show();
            this.Hide();
        }

        public int generarNumeroAfiliado()
        {
            
            string query = "select max(AF.nroAfiliado) as nroAfiliado from SELECT_GROUP.Afiliado as AF";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                nroAfiliado = (((Convert.ToInt32(fila["nroAfiliado"]) /100) + 1));
                nroAfiliado = (nroAfiliado * 100) + 1;
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
            if (Utilidades.ValidarFormulario(this, errorTextBox) == false  & (cmbSexo.Text != "")) 
            {
                cantidadHijos = Convert.ToInt32(textCantHijos.Text);

                numeroDocumento = Convert.ToInt32(textDni.Text);

                nroAfiliado = generarNumeroAfiliado();

                if (Auxiliar.verificarDocumento(numeroDocumento))
                {
                    Globals.listaDni.Add(numeroDocumento);

                    if (cbmPlanMed.Text != "")
                    {

                        afiliadosTable = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(afiliadosTable, nroAfiliado, textNombre.Text, textApellido.Text,
                                                                                        textTipoDoc.Text, numeroDocumento,
                                                                                        Convert.ToInt32(textTelefono.Text), textMail.Text,
                                                                                        dateTimePicker1.Value.Date, cmbSexo.Text, cmbEstadoCivil.Text,
                                                                                        cantidadHijos, textDireccion.Text, cbmPlanMed.Text);

                        DataRow afiliado = afiliadosTable.Rows[0];

                        if (Convert.ToInt32(textCantHijos.Text) > 0)
                        {
                            tieneHijos = true;
                        }
                        AltaPareja frm = new AltaPareja(afiliadosTable, afiliado, tieneHijos, afiliadoNuevo, cantidadHijos);
                        frm.Show();
                        this.Close();
                    }
                    else {
                        MessageBox.Show("Debe seleccionar un plan Medico de la lista");                    
                    }
                }
                else
                {
                    MessageBox.Show("El documento ingresado ya existe. Por favor verificar numero");
                }
            }
            else
            {
                MessageBox.Show("Faltan Campos ingresar");
            }
         }
        

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }
            
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Utilidades.ValidarFormulario(this, errorTextBox) == false & (cmbSexo.Text != ""))
            {

                nroAfiliado = generarNumeroAfiliado();

                numeroDocumento = Convert.ToInt32(textDni.Text);

                if (Auxiliar.verificarDocumento(numeroDocumento))
                {
                    if (cbmPlanMed.Text != "")
                    {
                        if (cmbEstadoCivil.Text != "")
                        {

                            afiliadosTable = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(afiliadosTable, nroAfiliado, textNombre.Text, textApellido.Text,
                                                                                   textTipoDoc.Text, numeroDocumento,
                                                                                   Convert.ToInt32(textTelefono.Text), textMail.Text,
                                                                                   dateTimePicker1.Value.Date, cmbSexo.Text, cmbEstadoCivil.Text,
                                                                                   Convert.ToInt32(textCantHijos.Text), textDireccion.Text, cbmPlanMed.Text);



                            DataRow afiliado = afiliadosTable.Rows[0];


                            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);


                            try
                            {

                                Abm_Afiliado.estructuraBD.darAltaUsuarios(afiliadosTable);
                                SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.AltaAfiliado", cnx);
                                cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                                cmdAltaAfiliado.Parameters.Add(new SqlParameter("@Afiliados", SqlDbType.Structured));
                                cmdAltaAfiliado.Parameters["@Afiliados"].Value = afiliadosTable;
                                cnx.Open();
                                cmdAltaAfiliado.ExecuteNonQuery();
                                MessageBox.Show("Se han guardado correctamente los datos");

                                Home.Show();
                                this.Close();
                            }
                            catch (ApplicationException error)
                            {
                                string mensaje = "Se ha producido un error ";
                                ApplicationException excep = new ApplicationException(mensaje, error);
                                excep.Source = this.Text;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un Estado Civil de la lista");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un plan Medico de la lista");
                    }
                }
                else
                {
                    MessageBox.Show("El documento ingresado ya existe. Por favor verificar numero");
                }
            }
            else
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
            this.btnCargarHijos.Enabled = false;
            

            string query = "select PM.descripcion from SELECT_GROUP.Plan_Med as PM";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                cbmPlanMed.Items.Add(Convert.ToString(fila["descripcion"]));
            }

            afiliadosTable = Abm_Afiliado.estructuraBD.crearEstructuraAfiliado(afiliadosTable);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textFechaNac_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCargarHijos_Click(object sender, EventArgs e)
        {
            if (Utilidades.ValidarFormulario(this, errorTextBox) == false )
            {
            
                cantidadHijos = Convert.ToInt32(textCantHijos.Text);

                numeroDocumento = Convert.ToInt32(textDni.Text);
            

                if (Auxiliar.verificarDocumento(numeroDocumento))
                    {
                        if (cbmPlanMed.Text != "")
                        {

                            nroAfiliado = generarNumeroAfiliado();

                            Globals.listaDni.Add(numeroDocumento);

                            afiliadosTable = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(afiliadosTable, nroAfiliado, textNombre.Text, textApellido.Text,
                                                                                            textTipoDoc.Text, numeroDocumento,
                                                                                            Convert.ToInt32(textTelefono.Text), textMail.Text,
                                                                                            dateTimePicker1.Value.Date, cmbSexo.Text, cmbEstadoCivil.Text,
                                                                                            cantidadHijos, textDireccion.Text, cbmPlanMed.Text);

                            DataRow afiliado = afiliadosTable.Rows[0];


                            AltaHijo frm = new AltaHijo(afiliadosTable, afiliado, cantidadHijos, afiliadoNuevo);
                            frm.Show();
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("Debe seleccionar un plan Medico de la lista");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El documento ingresado ya existe. Por favor verificar numero");
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Campos ingresar");                
                }
                        
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCantHijos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textCantHijos_TextChanged(object sender, EventArgs e)
        {
            textCantHijos.Text = textCantHijos.Text.Trim();
            textCantHijos.Text = textCantHijos.Text.Replace(" ", "");
            textCantHijos.SelectionStart = textCantHijos.Text.Length;

            if (Utilidades.ValidarFormulario(this, errorTextBox) == false)
            {
                

                if ((Convert.ToInt32(textCantHijos.Text)) > 0)
                {
                    this.btnCargarHijos.Enabled = true;
                }
                else
                {
                    this.btnCargarHijos.Enabled = false;

                }
            }
        }
        

    }
}

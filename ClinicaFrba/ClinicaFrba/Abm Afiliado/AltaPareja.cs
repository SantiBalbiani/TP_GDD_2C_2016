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
    public partial class AltaPareja : Form
    {

        public DataTable afiliados;
        public DataRow afiliadoIngresado;
        public Boolean tieneHijos;

        public AltaPareja(DataTable afiliadoPrincipal,DataRow afiliado,Boolean hijos)
        {
            InitializeComponent();

            //afiliados = afiliadoPrincipal;
            afiliadoIngresado = afiliado;
           
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            if (Utilidades.ValidarFormulario(this, errorTextBoxPareja) == false)
            {
                DataRow afiliado = afiliados.NewRow();
                afiliado["Nombre"] = nombrePareja.Text;
                afiliado["Apellido"] = apellidoPareja.Text;
                afiliado["TipoDoc"] = tipoDocPareja.Text;
                afiliado["Dni"] = Convert.ToInt32(nroDocPareja.Text);
                afiliado["Direccion"] = direccionPareja.Text;
                afiliado["Telefono"] = telefonoPareja.Text;
                afiliado["FechaNac"] = fechaNacPareja.Text;
                afiliado["Mail"] = mailPareja.Text;
                afiliado["Sexo"] = cmbSexoPareja.Text;
                afiliado["Estado Civil"] = "Casado";
                afiliado["Plan Med"] = PlanMedPareja.Text;

                afiliados.Rows.Add(afiliado);

                if (tieneHijos)
                {
                    AltaHijo frmHijo = new AltaHijo(afiliados,afiliado);
                    frmHijo.Show();
                }
                else {
                    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                    SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.sp_AltaAfiliado", cnx);
                    cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                    cmdAltaAfiliado.Parameters.Add("@Afiliados", SqlDbType.Structured).Value = afiliados;
                    try
                    {
                        cnx.Open();
                        cmdAltaAfiliado.ExecuteNonQuery();
                        
                    }
                    catch (ApplicationException error)
                    {
                        string mensaje = "Se ha producido un error";
                        ApplicationException excep = new ApplicationException(mensaje, error);
                        excep.Source = this.Text;
                    }
                }
 
            }
            else
            {
                MessageBox.Show("Faltan Campos ingresar");
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void AltaPareja_Load(object sender, EventArgs e)
        {
            
            PlanMedPareja.Text = afiliadoIngresado[10].ToString();

        }
    }
}

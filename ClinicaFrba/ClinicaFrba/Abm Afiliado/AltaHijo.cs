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
    public partial class AltaHijo : Form
    {
        public DataRow afiliadosIngresados;
        public DataTable tablaAfiliados;
        public Boolean otroHijo = false;

        public AltaHijo(DataTable Afiliados,DataRow afiliado)
        {
            InitializeComponent();
            afiliadosIngresados = afiliado;
            tablaAfiliados = Afiliados;
        }

      
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void AltaHijo_Load(object sender, EventArgs e)
        {
            PlanMedHijo.Text = afiliadosIngresados[10].ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             if (Utilidades.ValidarFormulario(this, errorTextBoxHijo) == false)
            {
                DataRow afiliado = tablaAfiliados.NewRow();
                afiliado["Nombre"] = nombreHijo.Text;
                afiliado["Apellido"] = apellidoHijo.Text;
                afiliado["TipoDoc"] = tipoDocHijo.Text;
                afiliado["Dni"] = Convert.ToInt32(nroDocHijo.Text);
                afiliado["Direccion"] = direccionHijo.Text;
                afiliado["Telefono"] = telefonoHijo.Text;
                afiliado["FechaNac"] = fechaNacHijo.Text;
                afiliado["Mail"] = mailHijo.Text;
                afiliado["Sexo"] = cmbSexoHijo.Text;
                afiliado["Estado Civil"] = cmbEstadoCivilHijo.Text;
                afiliado["Plan Med"] = PlanMedHijo.Text;

                tablaAfiliados.Rows.Add(afiliado);
                 
                 if (otroHijo)
                {
                    this.Close();
                    AltaHijo frmHijo = new AltaHijo(tablaAfiliados,afiliadosIngresados);
                    frmHijo.Show();
                }
                else {
                    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                    SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.sp_AltaAfiliado", cnx);
                    cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                    cmdAltaAfiliado.Parameters.Add("@Afiliados", SqlDbType.Structured).Value = tablaAfiliados;
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

        private void otro_CheckedChanged(object sender, EventArgs e)
        {
            if(true){
                otroHijo = true;
            
            }
        
        }
        }

   }


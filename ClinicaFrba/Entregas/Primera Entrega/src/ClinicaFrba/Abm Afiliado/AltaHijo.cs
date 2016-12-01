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
        public DataTable tablaAfiliados = new DataTable();
        public Boolean otroHijo = false;
        public int idUsuario;

        public AltaHijo(DataTable Afiliados,DataRow afiliado)
        {
            InitializeComponent();
            afiliadosIngresados = afiliado;
            //tablaAfiliados = Afiliados;
        }

      
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Menu_Principal.HomeAdmin frmadmin = new Menu_Principal.HomeAdmin();
            frmadmin.Show();
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void AltaHijo_Load(object sender, EventArgs e)
        {
            string idPlan = afiliadosIngresados[11].ToString();

            string query = "select PM.descripcion from SELECT_GROUP.Plan_Med as PM where idPlan = ('" + idPlan + "')";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                PlanMedHijo.Text = ((fila["descripcion"]).ToString());

            }

            tablaAfiliados = Abm_Afiliado.estructuraBD.crearEstructuraAfiliado(tablaAfiliados);
            /*
            DataColumn nombre = tablaAfiliados.Columns.Add("nombre", typeof(String));
            tablaAfiliados.Columns.Add("apellido", typeof(String));
            tablaAfiliados.Columns.Add("tipoDni", typeof(String));
            tablaAfiliados.Columns.Add("numeroDni", typeof(Int32));
            tablaAfiliados.Columns.Add("telefono", typeof(Int32));
            tablaAfiliados.Columns.Add("mail", typeof(String));
            tablaAfiliados.Columns.Add("fechaNac", typeof(DateTime));
            tablaAfiliados.Columns.Add("sexo", typeof(String));
            tablaAfiliados.Columns.Add("estadoCivil", typeof(String));
            tablaAfiliados.Columns.Add("direccion", typeof(String));
            tablaAfiliados.Columns.Add("usuarioId", typeof(Int32));
            tablaAfiliados.Columns.Add("planMed", typeof(Int32));
         */
             
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             if (Utilidades.ValidarFormulario(this, errorTextBoxHijo) == false)
            {
                DataRow afiliado = tablaAfiliados.NewRow();
                afiliado["nombre"] = nombreHijo.Text;
                afiliado["apellido"] = apellidoHijo.Text;
                afiliado["tipoDni"] = tipoDocHijo.Text;
                afiliado["numeroDni"] = Convert.ToInt32(nroDocHijo.Text);
                afiliado["telefono"] = Convert.ToInt32(telefonoHijo.Text);
                afiliado["mail"] = mailHijo.Text;
                //afiliado["fechaNac"] = Convert.ToDateTime(fechaNacHijo.Text);
                afiliado["fechaNac"] = dateTimePicker1.Value.Date;
                afiliado["sexo"] = cmbSexoHijo.Text;
                afiliado["estadoCivil"] = cmbEstadoCivilHijo.Text;
                afiliado["direccion"] = direccionHijo.Text;
                int usuarioIdAfiliado = registrarUsuario(Convert.ToInt32(nroDocHijo.Text));
                afiliado["usuarioId"] = usuarioIdAfiliado;
                string query = "select PM.idPlan from SELECT_GROUP.Plan_Med as PM where descripcion = ('" + PlanMedHijo.Text.Trim() + "')";
                DataTable dt = Conexion.EjecutarComando(query);
                foreach (DataRow fila in dt.Rows)
                {
                    int idPlanMed = Convert.ToInt32((fila["idPlan"]));
                    afiliado["planMed"] = idPlanMed;
                }
                
                tablaAfiliados.Rows.Add(afiliado);
           
                 if (otroHijo)
                {
                    AltaHijo frmHijo = new AltaHijo(tablaAfiliados,afiliadosIngresados);
                    frmHijo.Show();
                    this.Close();
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
                        MessageBox.Show("Se han guardado correctamente los datos");
                        Menu_Principal.HomeAdmin frmAdmin = new Menu_Principal.HomeAdmin();
                        frmAdmin.Show();
                        this.Close();
                        
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

        public int registrarUsuario(int p)
        {

            string nroDocumento = nroDocHijo.Text.Trim();
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.sp_CrearUsuario", cnx);
            cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
            cmdAltaAfiliado.Parameters.Add("@Dni", SqlDbType.Int).Value = Convert.ToInt32(nroDocHijo.Text);
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

        private void otro_CheckedChanged(object sender, EventArgs e)
        {
            if(true){
                otroHijo = true;
            
            }
        
        }
        }

   }


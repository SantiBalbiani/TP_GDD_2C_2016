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
using ClinicaFrba.Abm_Afiliado;


namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaPareja : Form
    {
        public DataTable afiliados = new DataTable();
        public DataRow afiliadoIngresado;
        public int idUsuario;
        public Boolean tieneHijos;
        public Boolean nuevoAfiliado;
        public int nroAfiliado = 0;
        public string planMedPareja;
        public int hijosCant;
        public string menuAnterior;


        public AltaPareja(DataTable afiliadoPrincipal, DataRow afiliadoIngre, Boolean hijos,Boolean afiliadoPrincipalNuevo, int cantHijos)
        {
            InitializeComponent();
            tieneHijos = hijos;
            afiliadoIngresado = afiliadoIngre;
            afiliados = afiliadoPrincipal;
            nuevoAfiliado = afiliadoPrincipalNuevo;
            hijosCant = cantHijos;
         }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            if (Utilidades.ValidarFormulario(this, errorTextBoxPareja) == false)
            {
                hijosCant = Convert.ToInt32(textCantHijos.Text);
                string estadoCivilPareja = Convert.ToString(afiliadoIngresado["estadoCivil"]);
                nroAfiliado = Convert.ToInt32(afiliadoIngresado["nroAfiliado"]) + 1;
                

                afiliados = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(afiliados, nroAfiliado, nombrePareja.Text, apellidoPareja.Text,
                                                                                    tipoDocPareja.Text, Convert.ToInt32(nroDocPareja.Text),
                                                                                    Convert.ToInt32(telefonoPareja.Text), mailPareja.Text,
                                                                                    dateTimePicker1.Value.Date, cmbSexoPareja.Text, estadoCivilPareja,
                                                                                    hijosCant, direccionPareja.Text, planMedPareja);
                
                DataRow afiliado = afiliados.Rows[1];

                if (tieneHijos)
                {
                    AltaHijo frmHijo = new AltaHijo(afiliados,afiliado,hijosCant,nuevoAfiliado);
                    frmHijo.Show();
                    this.Close();
                }
                else {
                    
                    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                    
                    try
                    {
                        SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.AltaAfiliado", cnx);
                        cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                        cmdAltaAfiliado.Parameters.Add(new SqlParameter("@Afiliados", SqlDbType.Structured));
                        cmdAltaAfiliado.Parameters["@Afiliados"].Value = afiliados;
                   
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
            string nroDocumento = nroDocPareja.Text.Trim();
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.sp_CrearUsuario", cnx);
            cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
            cmdAltaAfiliado.Parameters.Add("@Dni", SqlDbType.Int).Value = Convert.ToInt32(nroDocPareja.Text);
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

        private void btnCancelar_Click(object sender, EventArgs e) 
        {
            Globals.irAtras(menuAnterior, this);
            
        }

        private void AltaPareja_Load(object sender, EventArgs e)
        {

            if (nuevoAfiliado)
            {
                string idPlan = afiliadoIngresado[14].ToString();

                string query = "select PM.descripcion from SELECT_GROUP.Plan_Med as PM where idPlan = ('" + idPlan + "')";
                DataTable dt = Conexion.EjecutarComando(query);
                foreach (DataRow fila in dt.Rows)
                {
                    planMedPareja = ((fila["descripcion"]).ToString());
                    PlanMedPareja.Text = planMedPareja;
                }
            }
            else {
                string query = "select PM.descripcion from SELECT_GROUP.Plan_Med as PM where idPlan = ('" + afiliadoIngresado[13] + "')";
                DataTable dt = Conexion.EjecutarComando(query);
                foreach (DataRow fila in dt.Rows)
                {
                    PlanMedPareja.Text = ((fila["descripcion"]).ToString());
                }
            }
            
            afiliados = Abm_Afiliado.estructuraBD.crearEstructuraAfiliado(afiliados);
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void mailPareja_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void telefonoPareja_TextChanged(object sender, EventArgs e)
        {

        }

        private void direccionPareja_TextChanged(object sender, EventArgs e)
        {

        }

        private void nroDocPareja_TextChanged(object sender, EventArgs e)
        {

        }

        private void tipoDocPareja_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void apellidoPareja_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombrePareja_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void PlanMedPareja_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cmbSexoPareja_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

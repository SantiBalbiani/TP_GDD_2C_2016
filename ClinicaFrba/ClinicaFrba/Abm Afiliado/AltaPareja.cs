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
        public int numeroDocumento;
        public Boolean tieneHijos;
        public Boolean nuevoAfiliado;
        public int nroAfiliado = 0;
        public string planMedPareja;
        public int hijosCant;
        public string menuAnterior;
        public Form MenuHome;


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

            if (Utilidades.ValidarFormulario(this, errorTextBoxPareja) == false & (cmbSexoPareja.Text != ""))
            {
                hijosCant = Convert.ToInt32(textCantHijos.Text);
                string estadoCivilPareja = Convert.ToString(afiliadoIngresado["estadoCivil"]);
                nroAfiliado = Convert.ToInt32(afiliadoIngresado["nroAfiliado"]) + 1;
                numeroDocumento = Convert.ToInt32(nroDocPareja.Text);

                if (!(Globals.listaDni.Any(x => x == numeroDocumento)) & Auxiliar.verificarDocumento(numeroDocumento))
                {

                    Globals.listaDni.Add(numeroDocumento);


                    afiliados = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(afiliados, nroAfiliado, nombrePareja.Text, apellidoPareja.Text,
                                                                                    tipoDocPareja.Text, numeroDocumento,
                                                                                    Convert.ToInt32(telefonoPareja.Text), mailPareja.Text,
                                                                                    dateTimePicker1.Value.Date, cmbSexoPareja.Text, estadoCivilPareja,
                                                                                    hijosCant, direccionPareja.Text, planMedPareja);


                    DataRow afiliado = afiliados.Rows[1];

                    if (tieneHijos)
                    {

                        AltaHijo frmHijo = new AltaHijo(afiliados, afiliado, hijosCant, nuevoAfiliado);
                        frmHijo.MenuHome = MenuHome;
                        frmHijo.Show();
                        this.Close();
                    }
                    else
                    {

                        DialogResult confirmaRegistro = MessageBox.Show("Se procederá a Registrar los datos ingresados. Confirma registro?", "Confirmación de Registro de Afiliado/s", MessageBoxButtons.YesNo);

                        if (confirmaRegistro == DialogResult.Yes)
                        {

                            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                            try
                            {
                                Abm_Afiliado.estructuraBD.darAltaUsuarios(afiliados);
                                SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.AltaAfiliado", cnx);
                                cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                                cmdAltaAfiliado.Parameters.Add(new SqlParameter("@Afiliados", SqlDbType.Structured));
                                cmdAltaAfiliado.Parameters["@Afiliados"].Value = afiliados;
                                cnx.Open();
                                cmdAltaAfiliado.ExecuteNonQuery();
                                MessageBox.Show("Se han guardado correctamente los datos");
                                MenuHome.Show();
                                this.Close();
                            }
                            catch (ApplicationException error)
                            {
                                string mensaje = "Se ha producido un error";
                                ApplicationException excep = new ApplicationException(mensaje, error);
                                excep.Source = this.Text;
                            }
                        }

                        if (confirmaRegistro == DialogResult.No)
                        {
                            MessageBox.Show("Se ha cancelado el registro");
                            Globals.listaDni.Clear();
                            MenuHome.Show();
                            this.Close();
                            
                        }



                    }
                }
                else
                {
                    MessageBox.Show("El documento ingresado ya existe. Por favor verificar numero");
                }
            }
            else
            {
                MessageBox.Show("Por favor completar todos los campos");
            }
            //this.Close();
        }
     
        private void btnCancelar_Click(object sender, EventArgs e) 
        {
            Globals.listaDni.Clear();
            MenuHome.Show();
            this.Close();
            
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.AbmRol;
using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Base_de_Datos;
using ClinicaFrba.Menu_Principal;
using System.Configuration;
using System.Data.SqlClient;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Registro_Resultado;


namespace ClinicaFrba.Menu_Principal
{
    public partial class HomeCustom : Form
    {
        //Para afiliado
        private string nombreAfil;
        private string apellidoAfil;
        public string strAfiliado = "0";     
        // En general
        public string rolActual;
        public string menuAnterior;
        //Para Profesional
        private string nombreProf;
        private string apellidoProf;
        private string idProf;
        

        public HomeCustom()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login frmNewLog = new Login();
            frmNewLog.Show();
            this.Close();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                MessageBox.Show("Por favor complete el nro de Afiliado");
            }
            else
            {
                string consultaUsername = "SELECT U.nombreUsuario FROM Select_Group.Usuario U JOIN Select_Group.Afiliado A ON A.idUsuario = U.idUsuario WHERE A.nroAfiliado = " + textBox1.Text.ToString().Trim();
                DataTable unUserName = new DataTable();
                Conexion.conectar();
                try
                {

                    unUserName = Conexion.LeerTabla(consultaUsername);

                    foreach (DataRow unUserN in unUserName.Rows)
                    {
                        Globals.userName = unUserN["nombreUsuario"].ToString();

                    }


                }

                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Conexion.conexion.Close();

                   // this.Hide();
                    FrmComprarBonos frmCompra = new FrmComprarBonos();
                    frmCompra.menuAnterior = "Custom";
                    frmCompra.Home = this; 
                    frmCompra.Show();


                }
            }
        }

        private void btnCambiarPlan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                MessageBox.Show("Por favor complete el nro de Afiliado");
            }
            else
            {
                Abm_Planes.CambiarPlan frmCambiarPlan = new Abm_Planes.CambiarPlan(textBox1.Text);
                frmCambiarPlan.menuAnterior = "Custom";
                frmCambiarPlan.Home = this; 
                frmCambiarPlan.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
            textBox1.Text = textBox1.Text.Replace(" ", "");
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
            abmMenuRol frmMenuRol = new abmMenuRol();
            frmMenuRol.menuAnterior = "Custom";
            frmMenuRol.Home = this; 
           // this.Hide();
            frmMenuRol.Show();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Listados.ListadoEstadistico frmListados = new Listados.ListadoEstadistico("Custom");
            frmListados.menuAnterior = "Custom";
            frmListados.Home = this; 
            frmListados.Show();
           // this.Close();
            
        }

        private void btnRegistrarLlegada_Click(object sender, EventArgs e)
        {
            Registro_Llegada.Llegada frmRegistrar = new Registro_Llegada.Llegada();
            frmRegistrar.menuAnterior = "Custom";
            frmRegistrar.Home = this; 
            frmRegistrar.Show();
            //this.Close();
        }

        private void btnAltaAfiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.frmAltaAfiliado frmAlta = new Abm_Afiliado.frmAltaAfiliado();
            frmAlta.menuAnterior = "Custom";
            frmAlta.Home = this; 
            frmAlta.Show();
            //this.Close();
        }

        private void btnAgregarFamiliar_Click(object sender, EventArgs e)
        {
            AltaFamiliar frmAltaFamiliarAfiliado = new AltaFamiliar();
            frmAltaFamiliarAfiliado.menuAnterior = "Custom";
            frmAltaFamiliarAfiliado.Home = this; 
            frmAltaFamiliarAfiliado.Show();
            //this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.CancelacionAfiliado frmCancel = new Cancelar_Atencion.CancelacionAfiliado(strAfiliado);
            //frmCancel.menuAnterior = "Custom";
            //frmCancel.Home = this; 
            frmCancel.Show();
           // this.Close();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ClinicaFrba.Pedir_Turno.FrmSolTurno frmSolTurno = new ClinicaFrba.Pedir_Turno.FrmSolTurno();
            frmSolTurno.menuAnterior = "Custom";
            frmSolTurno.Home = this; 
            frmSolTurno.Show();
        }

        private void HomeCustom_Load(object sender, EventArgs e)
        {
            //Cargar Botones a usar// Para eso, ver que funciones tiene el forro. 

           


            //Chequear si es profesional y hacer cosas de profesional
                       
            if (rolActual == "Profesional")
            {
                string queryDatosProf = "SELECT matricula ,nombre ,apellido FROM Select_Group.Profesional P JOIN Select_Group.Usuario U ON U.idUsuario = P.idUsuario AND U.nombreUsuario = '" + Globals.userName + "'";

                DataTable datosProf = new DataTable();

                Conexion.conectar();

                datosProf = Conexion.LeerTabla(queryDatosProf);

                foreach (DataRow datosUnProf in datosProf.Rows)
                {
                    idProf = datosUnProf["matricula"].ToString();
                    nombreProf = datosUnProf["nombre"].ToString();
                    apellidoProf = datosUnProf["apellido"].ToString();
                }

                label3.Text = apellidoProf + ", " + nombreProf;
                txtRolActual.Text = rolActual;


            }
            
            // Chequear Si es afiliado y hacer las cosas de abajo
            if (rolActual == "Afiliado")
            {

                string queryDatosAfil = "SELECT nombre ,apellido FROM SELECT_GROUP.Afiliado where numeroDoc = '" + Globals.userName + "'";

                DataTable datosAfil = new DataTable();

                Conexion.conectar();

                datosAfil = Conexion.LeerTabla(queryDatosAfil);

                foreach (DataRow datosUnProf in datosAfil.Rows)
                {
                    nombreAfil = datosUnProf["nombre"].ToString();
                    apellidoAfil = datosUnProf["apellido"].ToString();

                }

                label3.Text = nombreAfil + ", " + apellidoAfil;
                txtRolActual.Text = rolActual;

                // Andaba            
                DataTable idAfiliado = new DataTable();

                string consultaAfiliado = "SELECT A.idAfiliado FROM Select_Group.Usuario U JOIN Select_Group.Afiliado A ON A.idUsuario = U.idUsuario WHERE U.nombreUsuario = '" + Globals.userName + "'";

                Conexion.conectar();

                idAfiliado = Conexion.LeerTabla(consultaAfiliado);

                foreach (DataRow unAfi in idAfiliado.Rows)
                {
                    strAfiliado = unAfi["idAfiliado"].ToString();
                }

                Conexion.conexion.Close();
            }



            //Hacer Aca la carga si es Administrativo

            if (rolActual == "Administrativo")
            {
                txtRolActual.Text = rolActual;
                
            }
        }

        private void btnRegAtencion_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarDia_Click(object sender, EventArgs e)
        {

        }

        private void btnModifAfil_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.ModificarAfiliado frmMod = new Abm_Afiliado.ModificarAfiliado();
            frmMod.Show();
        }

        private void btnBajaAfil_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.BajaAfiliado frmBaja = new Abm_Afiliado.BajaAfiliado();
            frmBaja.Show();
        }
    }
}

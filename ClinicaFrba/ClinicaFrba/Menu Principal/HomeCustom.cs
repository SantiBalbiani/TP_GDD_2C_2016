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

namespace ClinicaFrba.Menu_Principal
{
    public partial class HomeCustom : Form
    {
        private string nombreAfil;
        private string apellidoAfil;
        public string strAfiliado = "0";


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

                    this.Hide();
                    FrmComprarBonos frmCompra = new FrmComprarBonos();
                    frmCompra.menuAnterior = "Admin";
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
                this.Hide();
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
            this.Hide();
            frmMenuRol.Show();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Listados.ListadoEstadistico frmListados = new Listados.ListadoEstadistico();
            this.Close();
            frmListados.Show();
        }

        private void btnRegistrarLlegada_Click(object sender, EventArgs e)
        {
            Registro_Llegada.Llegada frmRegistrar = new Registro_Llegada.Llegada();
            frmRegistrar.Show();
            this.Close();
        }

        private void btnAltaAfiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.frmAltaAfiliado frmAlta = new Abm_Afiliado.frmAltaAfiliado();
            frmAlta.Show();
            this.Close();
        }

        private void btnAgregarFamiliar_Click(object sender, EventArgs e)
        {
            AltaFamiliar frmAltaFamiliarAfiliado = new AltaFamiliar();
            frmAltaFamiliarAfiliado.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.CancelacionAfiliado frmCancel = new Cancelar_Atencion.CancelacionAfiliado(strAfiliado);
            frmCancel.Show();
            this.Close();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClinicaFrba.Pedir_Turno.FrmSolTurno frmSolTurno = new ClinicaFrba.Pedir_Turno.FrmSolTurno();
            frmSolTurno.Show();
        }

        private void HomeCustom_Load(object sender, EventArgs e)
        {
            string queryDatosProf = "SELECT nombre ,apellido FROM SELECT_GROUP.Afiliado where numeroDoc = '" + Globals.userName + "'";

            DataTable datosProf = new DataTable();

            Conexion.conectar();

            datosProf = Conexion.LeerTabla(queryDatosProf);

            foreach (DataRow datosUnProf in datosProf.Rows)
            {
                nombreAfil = datosUnProf["nombre"].ToString();
                apellidoAfil = datosUnProf["apellido"].ToString();

            }

            label3.Text = nombreAfil + ", " + apellidoAfil;


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

        private void btnRegAtencion_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarDia_Click(object sender, EventArgs e)
        {

        }

        private void btnModifAfil_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.Base_de_Datos;
using System.Configuration;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    public partial class HomeAfiliado : Form
    {

        private string nombreAfil;
        private string apellidoAfil;
        public string rolActual;

        public HomeAfiliado()
        {
            InitializeComponent();
            this.txtBonosDisponibles.Enabled = false; 
        }
        public string strAfiliado = "0";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //ClinicaFrba.Abm_Afiliado.frmAltaAfiliado frm = new Abm_Afiliado.frmAltaAfiliado();
            //ClinicaFrba.Abm_Afiliado.AltaPareja frmPareja = new Abm_Afiliado.AltaPareja();
           // frmPareja.Show();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void HomeAfiliado_Load(object sender, EventArgs e)
        {

            //txtRolActual.Text = Globals.rolId;

            List<string> listaFunc = Globals.listaFuncionalidades;
            //string mensajeParaNoe = " ";
            foreach (string func in listaFunc)
            {
                //mensajeParaNoe = mensajeParaNoe + " " +func + " ";

                if (func == "Comprar_Bono")
                {
                    btnComprar.Visible = true;
                    lblBonos.Visible = true;
                    txtBonosDisponibles.Visible = true;
                }
                if (func == "Cancelar_Turno")
                {
                    button2.Visible = true;
                }
                if (func == "Registrar_Llegada")
                {
                    btnRegistrarLlegada.Visible = true;
                }
                if (func == "ABM_Rol")
                {
                    btnAbmRol.Visible = true;
                }
                if (func == "Listado_Estadistico")
                {
                    btnEstadisticas.Visible = true;
                }
                if (func == "ABM_Afiliados")
                {
                    btnAltaAfiliado.Visible = true;
                    btnCambiarPlan.Visible = true;
                }
                if (func == "Solicitar_Turno")
                {
                    button1.Visible = true;
                }
                if (func == "Crear_Agenda")
                {
                    button3.Visible = true;
                }
                if (func == "Registrar_Diagnostico")
                {
                    //Falta el boton de registrar diagnostico
                }
                if (func == "Cancelar_Agenda")
                {
                    btnCancelarDia.Visible = true;
                }

            }
            
            
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
            
            string consultaAfiliado = "SELECT A.idAfiliado FROM Select_Group.Usuario U JOIN Select_Group.Afiliado A ON A.idUsuario = U.idUsuario WHERE U.nombreUsuario = '"+ Globals.userName + "'";
            
             Conexion.conectar();

             idAfiliado = Conexion.LeerTabla(consultaAfiliado);

             foreach (DataRow unAfi in idAfiliado.Rows)
            {
                strAfiliado = unAfi["idAfiliado"].ToString();
            }

            Conexion.conexion.Close();
            

            string consultaBonosDisp = "SELECT idBono  FROM Select_Group.Bono  WHERE idAfiliado = " + strAfiliado + "  AND estado = 1";

       
            DataTable bonosDisponibles = new DataTable();

            Conexion.conectar();

            bonosDisponibles = Conexion.LeerTabla(consultaBonosDisp);
            int cantBonos = 0;
            foreach (DataRow unBonoDisp in bonosDisponibles.Rows)
            {
                cantBonos++;
            }

            Conexion.conexion.Close();
            txtBonosDisponibles.Text = Convert.ToString(cantBonos);

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            FrmComprarBonos frmComprarBonos = new FrmComprarBonos();
            frmComprarBonos.Home = this;
            frmComprarBonos.Show();
            this.Hide();
        }

        private void txtBonosDisponibles_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FrmSolTurno frmSolTurno = new FrmSolTurno();
            //frmSolTurno.menuAnterior = "Afiliado";
            frmSolTurno.Home = this;
            frmSolTurno.Show();
            this.Hide();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.CancelacionAfiliado frmCancel = new Cancelar_Atencion.CancelacionAfiliado(strAfiliado);
            frmCancel.Home = this; 
            frmCancel.Show();
            this.Hide();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login frmNewLog = new Login();
            frmNewLog.Show();
            this.Close();
        }

        private void btnCambiarPlan_Click(object sender, EventArgs e)
        {
            
                Abm_Planes.CambiarPlan frmCambiarPlan = new Abm_Planes.CambiarPlan(strAfiliado);
                // frmCambiarPlan.menuAnterior = "Custom";
                frmCambiarPlan.Home = this;
                frmCambiarPlan.Show();
                this.Hide();
           
        }

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
            AbmRol.abmMenuRol frmMenuRol = new AbmRol.abmMenuRol();
            frmMenuRol.Home = this;
            frmMenuRol.Show();
            this.Hide();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Listados.ListadoEstadistico frmListados = new Listados.ListadoEstadistico("Custom");
            frmListados.menuAnterior = "Custom";
            frmListados.Home = this;
            frmListados.Show();
            this.Hide();
        }

        private void btnAltaAfiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.frmAltaAfiliado frmAlta = new Abm_Afiliado.frmAltaAfiliado();
            frmAlta.menuAnterior = "Custom";
            frmAlta.Home = this;
            frmAlta.Show();
            this.Hide();
        }

        private void btnModifAfil_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.ModificarAfiliado frmMod = new Abm_Afiliado.ModificarAfiliado();
            frmMod.Home = this;
            frmMod.Show();
            this.Hide();
        }

        private void btnBajaAfil_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.BajaAfiliado frmBaja = new Abm_Afiliado.BajaAfiliado();
            frmBaja.Home = this;
            frmBaja.Show();
            this.Hide();
        }

        private void btnRestituir_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.RestituirAfiliado frmRes = new Abm_Afiliado.RestituirAfiliado();
            frmRes.Home = this;
            frmRes.Show();
            this.Hide();
        }

        private void btnRegistrarLlegada_Click(object sender, EventArgs e)
        {
            Registro_Llegada.Llegada frmRegistrar = new Registro_Llegada.Llegada();
            frmRegistrar.Home = this;
            frmRegistrar.Show();
            this.Hide();
        }

        
        private void btnCancelarDia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se define fuera del alcance del Rol ya que el Afiliado no tiene matricula de profesional");
           
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se define fuera del alcance del Rol ya que el Afiliado no tiene matricula de profesional y turnos Asociados");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registrar_Agenta_Medico.FrmRegistroAgenda frmAgendaNueva = new Registrar_Agenta_Medico.FrmRegistroAgenda();
            frmAgendaNueva.Home = this;
            frmAgendaNueva.Show();
            this.Close();
        }
    }
}

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

                    FrmComprarBonos frmCompra = new FrmComprarBonos();
                    //frmCompra.menuAnterior = "Custom";
                    frmCompra.Home = this; 
                    frmCompra.Show();
                    this.Hide();


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
               // frmCambiarPlan.menuAnterior = "Custom";
                frmCambiarPlan.Home = this; 
                frmCambiarPlan.Show();
                this.Hide();
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
        {   abmMenuRol frmMenuRol = new abmMenuRol();
            //frmMenuRol.menuAnterior = "Custom";
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

        private void btnRegistrarLlegada_Click(object sender, EventArgs e)
        {
            Registro_Llegada.Llegada frmRegistrar = new Registro_Llegada.Llegada();
            frmRegistrar.Home = this; 
            frmRegistrar.Show();
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
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.CancelacionAfiliado frmCancel = new Cancelar_Atencion.CancelacionAfiliado(strAfiliado);
            //frmCancel.menuAnterior = "Custom";
            frmCancel.Home = this; 
            frmCancel.Show();
            this.Hide();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            ClinicaFrba.Pedir_Turno.FrmSolTurno frmSolTurno = new ClinicaFrba.Pedir_Turno.FrmSolTurno();
            //frmSolTurno.menuAnterior = "Custom";
            frmSolTurno.Home = this; 
            frmSolTurno.Show();
            this.Hide();
        }

        private void HomeCustom_Load(object sender, EventArgs e)
        {
            //Cargar Botones a usar// Para eso, ver que funciones tiene el forro. 

        /* Con esto carga
            select idFuncionalidad
            from SELECT_GROUP.Funcionalidad_Por_Rol 
            inner join SELECT_GROUP.Funcionalidad
            on SELECT_GROUP.Funcionalidad_Por_Rol.funcionalidad_idFuncionalidad =  SELECT_GROUP.Funcionalidad.idFuncionalidad
            where rol_idRol = 1
      */

            //+++++++++++++++MIRA ACA NOE++++++++++++++++++++

            txtRolActual.Text = Globals.rolId;

            List<string> listaFunc = Globals.listaFuncionalidades;
            //string mensajeParaNoe = " ";
            foreach (string func in listaFunc)
            {
                //mensajeParaNoe = mensajeParaNoe + " " +func + " ";

                if (func == "Comprar_Bono")
                {
                    btnComprar.Visible = true;
                    label4.Visible = true;
                    textBox1.Visible = true; 
                }
                if (func == "Cancelar_Turno" )
                {
                    btnCancelar.Visible = true;
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
                    label4.Visible = true;
                    textBox1.Visible = true;
                    btnCambiarPlan.Visible = true;
                    btnBajaAfil.Visible = true;
                    btnModifAfil.Visible = true;
                    btnRestituir.Visible = true;
                }
                if (func == "Solicitar_Turno")
                {
                    btnSolicitar.Visible = true; 
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

           // MessageBox.Show("Noe, estas son las func de este rol" + mensajeParaNoe);

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
            //Valido que tenga turno disponible:

            TimeSpan intervaloDeTurno = new TimeSpan(0, 30, 0);
            DateTime intervaloTurnoMax = Globals.getFechaActual() + intervaloDeTurno;
            DateTime intervaloTurnoMin = Globals.getFechaActual() - intervaloDeTurno;
            string estadoTurno = "0";
            string idAfiliado = "0";

            string consultaTurnoActual = "SELECT TOP 1 T.idTurno, T.afiliado_idAfiliado, T.estado FROM Select_Group.Turno T JOIN Select_Group.Agenda A ON A.idAgenda = T.idAgenda AND A.profesional_IdProfesional = " + idProf + " WHERE T.estado = 4 AND fechaTurno BETWEEN '" + intervaloTurnoMin.ToString("MM/dd/yyyy hh:mm tt") + "' AND '" + intervaloTurnoMax.ToString("MM/dd/yyyy hh:mm tt") + "' ORDER BY fechaTurno ASC";
            
            string idTurno = "0";
            Conexion.conectar();
            DataTable turnoActual = new DataTable();
            DataTable unAfiliado = new DataTable();

                turnoActual = Conexion.LeerTabla(consultaTurnoActual);

                foreach (DataRow unTurno in turnoActual.Rows)
                {
                    idTurno = unTurno["idTurno"].ToString();
                    idAfiliado = unTurno["afiliado_idAfiliado"].ToString();
                    estadoTurno = unTurno["estado"].ToString();

                }



                if (idTurno != "0")
                {


                    RegistroResultado frmRegRes = new RegistroResultado(idTurno, idProf,idAfiliado);
                    frmRegRes.Home = this;

                    this.Hide();
                    frmRegRes.Show();

                }
                else
                {
                    MessageBox.Show("No hay turnos disponibles en este horario");
                }
        }
           


        private void btnCancelarDia_Click(object sender, EventArgs e)
        {
            //Cancelar_Atencion.CancelacionProfesional frmCancelarDia = new Cancelar_Atencion.CancelacionProfesional(idProf);
            //frmCancelarDia.Home = this;
            //frmCancelarDia.Show();
            //this.Hide();
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

        private void txtRolActual_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarFamiliar_Click(object sender, EventArgs e)
        {

        }

        private void btnRestituir_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.RestituirAfiliado frmRes = new Abm_Afiliado.RestituirAfiliado();
            frmRes.Home = this;
            frmRes.Show();
            this.Hide();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Registro_Resultado.RegistroResultado frmDiagnos = new Registro_Resultado.RegistroResultado();
            //frmDiagnos.Home = this;
           // frmDiagnos.Show();
            //this.Hide();

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Registro_Resultado;
using ClinicaFrba.Base_de_Datos;
using System.Configuration;
using System.Data.SqlClient;
using ClinicaFrba.Compra_Bono;

namespace ClinicaFrba.Menu_Principal
{
    public partial class HomeProfesional : Form
    {
        private string nombreProf;
        private string apellidoProf;
        public string idProf;
        
        public HomeProfesional()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Ver que tenga un turno en este horario


            //Valido que tenga turno disponible:

            TimeSpan intervaloDeTurno = new TimeSpan(0, 30, 0);
            DateTime intervaloTurnoMax = Globals.getFechaActual() + intervaloDeTurno;
            DateTime intervaloTurnoMin = Globals.getFechaActual() - intervaloDeTurno;
            string estadoTurno = "0";
            string idAfiliado = "0";
            
            // Agregar SP que obtenga idAgenda

            //Agregarle al criterio idAgenda. No hace falta idAfiliado porque 
            // se presupone que un profesional no atiende mas de un Afiliado al mismo tiempo.
            string consultaTurnoActual = "SELECT TOP 1 T.idTurno, T.afiliado_idAfiliado, T.estado FROM Select_Group.Turno T JOIN Select_Group.Agenda A ON A.idAgenda = T.idAgenda AND A.profesional_IdProfesional = " + idProf + " WHERE T.estado = 4 AND fechaTurno BETWEEN '" + intervaloTurnoMin.ToString("yyyyMMdd HH:mm") + "' AND '" + intervaloTurnoMax.ToString("yyyyMMdd HH:mm") + "' ORDER BY fechaTurno ASC";
            
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

        private void HomeProfesional_Load(object sender, EventArgs e)
        {
            List<string> listaFunc = Globals.listaFuncionalidades;
            //string mensajeParaNoe = " ";
            foreach (string func in listaFunc)
            {
                //mensajeParaNoe = mensajeParaNoe + " " +func + " ";

                if (func == "Comprar_Bono")
                {
                    btnComprar.Visible = true;
                    label4.Visible = true;
                    txtAfiliado.Visible = true; 
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
                if (func == "Crear_Agenda")
                {
                    button3.Visible = true;
                }
             
                if (func == "ABM_Afiliados")
                {
                    btnAltaAfiliado.Visible = true;
                    label4.Visible = true;
                    txtAfiliado.Visible = true;
                    btnCambiarPlan.Visible = true;
                    btnBajaAfil.Visible = true;
                    btnModifAfil.Visible = true;
                    btnRestituir.Visible = true;
                }
                if (func == "Solicitar_Turno")
                {
                    button5.Visible = true;
                    label4.Visible = true;
                    txtAfiliado.Visible = true; 
                }
                if (func == "Registrar_Diagnostico")
                {
                    button1.Visible = true;
                }
                if (func == "Cancelar_Agenda")
                {
                    button2.Visible = true;
                    
                }

            }
            
            
            
            
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

            

        }


        




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.CancelacionProfesional frmCancelarDia = new Cancelar_Atencion.CancelacionProfesional(idProf);
            frmCancelarDia.Home = this;
            frmCancelarDia.Show();
            this.Hide();


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registrar_Agenta_Medico.FrmRegistroAgenda frmAgendaNueva = new Registrar_Agenta_Medico.FrmRegistroAgenda();
            frmAgendaNueva.Home = this;
            frmAgendaNueva.Show();
            this.Hide();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAfiliado.Text.ToString()))
            {
                MessageBox.Show("Por favor complete el nro de Afiliado");
            }
            else
            {
                string consultaUsername = "SELECT U.nombreUsuario FROM Select_Group.Usuario U JOIN Select_Group.Afiliado A ON A.idUsuario = U.idUsuario WHERE A.nroAfiliado = " + txtAfiliado.Text.ToString().Trim();
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

        private void btnRegistrarLlegada_Click(object sender, EventArgs e)
        {
            Registro_Llegada.Llegada frmRegistrar = new Registro_Llegada.Llegada();
            frmRegistrar.Home = this;
            frmRegistrar.Show();
            this.Hide();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Registro_Resultado.RegistroResultado frmDiagnos = new Registro_Resultado.RegistroResultado();
            //frmDiagnos.Home = this;
            // frmDiagnos.Show();
            //this.Hide();

        }

        private void btnCancelarDia_Click(object sender, EventArgs e)
        {

        }

        private void btnRegAtencion_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.CancelacionAfiliado frmCancel = new Cancelar_Atencion.CancelacionAfiliado(txtAfiliado.Text);
            frmCancel.Home = this;
            frmCancel.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pedir_Turno.FrmSolTurno frmSolTurno = new Pedir_Turno.FrmSolTurno();
            //frmSolTurno.menuAnterior = "Afiliado";
            frmSolTurno.Home = this;
            frmSolTurno.Show();
            this.Hide();
        }

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
            Pedir_Turno.FrmSolTurno frmSolTurno = new Pedir_Turno.FrmSolTurno();
            //frmSolTurno.menuAnterior = "Afiliado";
            frmSolTurno.Home = this;
            frmSolTurno.Show();
            this.Hide();
        }

        private void btnCambiarPlan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAfiliado.Text.ToString()))
            {
                MessageBox.Show("Por favor complete el nro de Afiliado");
            }
            else
            {
                Abm_Planes.CambiarPlan frmCambiarPlan = new Abm_Planes.CambiarPlan(txtAfiliado.Text);
                // frmCambiarPlan.menuAnterior = "Custom";
                frmCambiarPlan.Home = this;
                frmCambiarPlan.Show();
                this.Hide();
            }
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Listados.ListadoEstadistico frmListados = new Listados.ListadoEstadistico("Custom");
            //frmListados.menuAnterior = "Custom";
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
    }
}

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

namespace ClinicaFrba.Menu_Principal
{
    public partial class HomeProfesional : Form
    {
        private string nombreProf;
        private string apellidoProf;
        private string idProf;
        
        public HomeProfesional()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Ver que tenga un turno en este horario


            //Valido que tenga turno disponible:

            TimeSpan intervaloDeTurno = new TimeSpan(45, 30, 0);
            DateTime intervaloTurnoMax = DateTime.Now + intervaloDeTurno;
            DateTime intervaloTurnoMin = DateTime.Now - intervaloDeTurno;
            string estadoTurno = "0";
            string idAfiliado = "0";
            
            // Agregar SP que obtenga idAgenda

            //Agregarle al criterio idAgenda. No hace falta idAfiliado porque 
            // se presupone que un profesional no atiende mas de un Afiliado al mismo tiempo.
            string consultaTurnoActual = "SELECT TOP 1 T.idTurno, T.afiliado_idAfiliado, T.estado FROM Select_Group.Turno T JOIN Select_Group.Agenda A ON A.idAgenda = T.idAgenda AND A.profesional_IdProfesional = " + idProf + " WHERE fechaTurno BETWEEN '" + intervaloTurnoMin.ToString("MM/dd/yyyy hh:mm tt") + "' AND '" + intervaloTurnoMax.ToString("MM/dd/yyyy hh:mm tt") + "' ORDER BY fechaTurno ASC";
            
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

                    RegistroResultado frmRegRes = new RegistroResultado(idTurno, idProf);
                    frmRegRes.menuAnterior = "Profesional";
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
            this.Close();


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login frmNewLog = new Login();
            frmNewLog.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registrar_Agenta_Medico.FrmRegistroAgenda frmAgendaNueva = new Registrar_Agenta_Medico.FrmRegistroAgenda();
            frmAgendaNueva.Show();
            this.Close();
        }
    }
}

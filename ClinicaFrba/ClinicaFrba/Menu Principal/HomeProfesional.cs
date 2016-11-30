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
            
            RegistroResultado frmRegRes = new RegistroResultado();
            this.Hide();
            frmRegRes.Show();
        }

        private void HomeProfesional_Load(object sender, EventArgs e)
        {
            string queryDatosProf = "SELECT matricula ,nombre ,apellido FROM Select_Group.Profesional P JOIN Select_Group.Usuario U ON U.idUsuario = P.idUsuario AND U.nombreUsuario = '"+ Globals.userName+"'";

            DataTable datosProf = new DataTable();

            Conexion.conectar();

            datosProf = Conexion.LeerTabla(queryDatosProf);

            foreach (DataRow datosUnProf in datosProf.Rows)
            {
                idProf = datosUnProf["matricula"].ToString();
                 nombreProf = datosUnProf["nombre"].ToString();
                 apellidoProf= datosUnProf["apellido"].ToString();
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
            frmCancelarDia.Show();
            this.Close();


        }
    }
}

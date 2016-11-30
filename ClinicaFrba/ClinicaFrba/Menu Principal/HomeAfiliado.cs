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
        public HomeAfiliado()
        {
            InitializeComponent();
            this.txtBonosDisponibles.Enabled = false; 
        }

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

            DataTable idAfiliado = new DataTable();
            string strAfiliado = "0";
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
            this.Hide();
            FrmComprarBonos frmComprarBonos = new FrmComprarBonos();
            frmComprarBonos.Show();
        }

        private void txtBonosDisponibles_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSolTurno frmSolTurno = new FrmSolTurno();
            frmSolTurno.Show();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

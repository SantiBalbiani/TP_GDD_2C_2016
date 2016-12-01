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
    public partial class HomeAdmin : Form
    {
        int flag = 1;
        public HomeAdmin()
        {
            InitializeComponent();
        }

        private void HomeAdmin_Load(object sender, EventArgs e)
        {

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

        private void btnRegistrarLlegada_Click(object sender, EventArgs e)
        {
            Registro_Llegada.Llegada frmRegistrar = new Registro_Llegada.Llegada();
            frmRegistrar.Show();
            this.Close();
        }

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
            abmMenuRol frmMenuRol = new abmMenuRol();
            this.Hide();
            frmMenuRol.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                MessageBox.Show("Por favor complete el nro de Afiliado");
            }
            else
            {
                string consultaUsername = "SELECT U.nombreUsuario FROM Select_Group.Usuario U JOIN Select_Group.Afiliado A ON A.idUsuario = U.idUsuario WHERE A.idAfiliado = " + textBox1.Text.ToString();
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
                    frmCompra.Show();


                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Listados.ListadoEstadistico frmListados = new Listados.ListadoEstadistico();
            this.Close();
            frmListados.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login frmNewLog = new Login();
            frmNewLog.Show();
            this.Close();
        }
        }
}


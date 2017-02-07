using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Base_de_Datos;
using System.Data.SqlClient;
using System.Configuration;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class BusquedaAfiliado : Form
    {
        public Boolean tieneHijos = false;
        public int cantHijos = 0;

        public BusquedaAfiliado()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (Conexion.conectar())
            {
                DataTable afiliados = new DataTable();
                int Afiliado = Convert.ToInt32(nroAfiliadoPrincipal.Text);

                string cadena = "select * from SELECT_GROUP.Afiliado where nroAfiliado=('" + Afiliado + "')";

                afiliados = Conexion.LeerTabla(cadena);

                if (afiliados.Rows.Count == 0)
                {
                    MessageBox.Show("error: No se encuentra el afiliado Principal ingresado");

                    this.nroAfiliadoPrincipal.ResetText();
                }
                else
                {
                    foreach (DataRow fila in afiliados.Rows)
                    {
                        this.Hide();
                        MessageBox.Show("El afiliado es: " + fila["nombre"].ToString()+" " +fila["apellido"]);
                        cantHijos = Convert.ToInt32(fila["cantidadHijos"].ToString());
                        
                        AltaPareja frmPareja = new AltaPareja(afiliados,fila,tieneHijos,false,cantHijos);
                        frmPareja.Show();
                    }
                }
            }
        }

        private void checkHijos_CheckedChanged(object sender, EventArgs e)
        {
            if (true)
            {
                tieneHijos = true;
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Menu_Principal.HomeAdmin frmadmin = new Menu_Principal.HomeAdmin();
            //frmadmin.Show();
            this.Close();

        }

    }

}
    


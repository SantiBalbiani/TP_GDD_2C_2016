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
using System.Configuration;
using System.Data.SqlClient;
using Libreria;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class BajaAfiliado : Form
    {
        public string menuAnterior;
        public Form Home;
        public int nroAfiliado;

        public BajaAfiliado()
        {
            InitializeComponent();
        }

        private void BajaAfiliado_Load(object sender, EventArgs e)
        {

            
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            
            if (Utilidades.ValidarFormulario(this, errorTextBox) == false)
            {

                nroAfiliado = Convert.ToInt32(this.nroAfiliadoTxtBox.Text);

                string query = "SELECT AF.nombre, AF.apellido from SELECT_GROUP.Afiliado as AF where nroAfiliado =('" + nroAfiliado + "')";

                DataTable afiliado = Conexion.LeerTabla(query);
                if (afiliado.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado el número de Afiliado ingresado. Revisar e intentar nuevamente");
                }
                else
                {
                    foreach (DataRow fila in afiliado.Rows)
                        {
                            string nombre = fila["nombre"].ToString();
                            string apellido = fila["apellido"].ToString();

                            DialogResult confirmacion = MessageBox.Show("¿Estas seguro que desea dar de baja a '" + apellido + "', '" + nombre + "'?", "aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                            if (confirmacion == DialogResult.Yes)
                            {
                                DateTime fecha = Globals.getFechaActual();

                                string cadena = "update SELECT_GROUP.Afiliado set habilitado=0,fechaBaja = ('" + fecha + "') where nroAfiliado = ('" + nroAfiliado + "')";
                                Base_de_Datos.Conexion.EjecutarComando(cadena);

                                MessageBox.Show("El afiliado ha sido dado de baja con exito");

                                Home.Show();
                                this.Close();

                            }
                            else
                            {
                                this.Refresh();
                            }
                        }
                    }
                }
                else {
                MessageBox.Show("Debe ingresar un número de afiliado");
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            Home.Show();
            this.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

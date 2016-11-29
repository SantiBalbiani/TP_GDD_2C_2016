using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using ClinicaFrba.Base_de_Datos;
using Libreria;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaFamiliar : Form
    {
        public Boolean altaHijo = false;
        public Boolean nuevo = false;

        public AltaFamiliar()
        {
            InitializeComponent();
        }

        private void btnAltaHijo_Click(object sender, EventArgs e)
        {
            if (Utilidades.ValidarFormulario(this, errorAlta) == false)
            {
                if (Conexion.conectar())
                {
                    DataTable afiliados = new DataTable();
                    int afiliado = Convert.ToInt32(NroAfiliadoPrincipal.Text);

                    string cadena = "select * from SELECT_GROUP.Afiliado where idAfiliado=('" + afiliado + "')";

                    afiliados = Conexion.LeerTabla(cadena);

                    if (afiliados.Rows.Count == 0)
                    {
                        MessageBox.Show("error: No se encuentra el afiliado Principal ingresado");

                        this.NroAfiliadoPrincipal.ResetText();
                    }
                    else
                    {
                        foreach (DataRow fila in afiliados.Rows)
                        {
                            this.Hide();
                            MessageBox.Show("El afiliado es: " + fila["nombre"].ToString() + " " + fila["apellido"]);

                            AltaHijo frmHijo = new AltaHijo(afiliados, fila);
                            frmHijo.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falta ingresar numero de Afiliado");
                }
            }
        }

        private void btnAltaConyuge_Click(object sender, EventArgs e)
        {
            if (Utilidades.ValidarFormulario(this, errorAlta) == false)
            {
                if (Conexion.conectar())
                {
                    DataTable afiliados = new DataTable();
                    int afiliado = Convert.ToInt32(NroAfiliadoPrincipal.Text);

                    string cadena = "select nombre,apellido,tipoDni,numeroDni,telefono,mail,fechaNac,sexo,estadoCivil,direccion,idUsuario,plan_idPlan from SELECT_GROUP.Afiliado where idAfiliado=('" + afiliado + "')";

                    afiliados = Conexion.LeerTabla(cadena);

                    if (afiliados.Rows.Count == 0)
                    {
                        MessageBox.Show("error: No se encuentra el afiliado Principal ingresado");

                        this.NroAfiliadoPrincipal.ResetText();
                    }
                    else
                    {
                         foreach (DataRow fila in afiliados.Rows)
                        {
                            this.Hide();
                            MessageBox.Show("El afiliado es: " + fila["nombre"].ToString() + " " + fila["apellido"]);
                            
                            AltaPareja frmPareja = new AltaPareja(afiliados,fila,altaHijo,nuevo);
                            frmPareja.Show();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Falta ingresar numero de Afiliado");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (true)
            {
                altaHijo = true;
            }            
        }

        private void AltaFamiliar_Load(object sender, EventArgs e)
        {

        }

        private void NroAfiliadoPrincipal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

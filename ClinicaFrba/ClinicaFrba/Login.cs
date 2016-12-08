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

namespace ClinicaFrba
{

    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (Conexion.conectar())
            {
                DataTable users = new DataTable();
                string cod = txtUsuario.Text;
                string pass = txtContraseña.Text;
                string cadena = "select nombreUsuario,contraseña,intentosFallidos from SELECT_GROUP.Usuario where contraseña=HASHBYTES('SHA2_256','" + pass.Trim() + "') and nombreUsuario=('" + cod.Trim() + "')";
              
                users = Conexion.LeerTabla(cadena);
                if (users.Rows.Count == 0)
                {
                    MessageBox.Show("Error al ingresar usuario o contraseña");
                    cadena = "update SELECT_GROUP.Usuario set intentosFallidos=intentosFallidos+1 where nombreUsuario=upper('" + cod.Trim() + "')";
                    Conexion.EjecutarComando(cadena);
                    this.txtContraseña.ResetText();
                    this.txtUsuario.ResetText();
                }
                else
                {
                    foreach (DataRow fila in users.Rows)
                    {
                        if (int.Parse((fila["intentosFallidos"].ToString())) == 3)
                        {
                            MessageBox.Show("El usuario " + fila["nombreUsuario"].ToString() + " está bloqueado");
                            
                        }
                        else
                        {
                            this.Hide();
                            MessageBox.Show("Bienvenido " + fila["nombreUsuario"].ToString());
                            Globals.userName = cod.Trim();
                            cadena = "update SELECT_GROUP.Usuario set intentosFallidos= 0 where nombreUsuario=upper('" + cod.Trim() + "')";
                            Conexion.EjecutarComando(cadena);
                            ElegirRol frmRol = new ElegirRol(txtUsuario.Text);
                            frmRol.Show();
                        }
                    }

                }
            }

        }
    }
}

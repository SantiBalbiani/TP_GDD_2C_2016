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
            //bool bandera = Conexion.conectar();

            if (Conexion.conectar())
            {
                DataTable users = new DataTable();
                string cod = txtUsuario.Text;
                string pass = txtContraseña.Text;
                string cadena = "select nombreUsuario,contraseña,intentosFallidos from SELECT_GROUP.Usuario where contraseña=HASHBYTES('SHA2_256','" + pass.Trim() + "') and nombreUsuario=('" + cod.Trim() + "')";
                //select user_name,contraseña,login_fallidos,id_rol from prueba.usuarios where user_name=upper('" + cod.Trim() + "') and contraseña=prueba.psencriptar('"+pass.Trim()+"')";
                users = Conexion.LeerTabla(cadena);
                if (users.Rows.Count == 0)
                {
                    MessageBox.Show("Error al ingresar usuario o contraseña");
                    cadena = "update SELECT_GROUP.Usuario set intentosFallidos=intentosFallidos+1 where nombreUsuario=upper('" + cod.Trim() + "')";
                    this.txtContraseña.ResetText();
                    this.txtUsuario.ResetText();
                }
                else
                {
                    foreach (DataRow fila in users.Rows)
                    {
                        if (int.Parse((fila["intentosFallidos"].ToString())) < 3)
                        {
                            this.Hide();
                            MessageBox.Show("Bienvenido " + fila["nombreUsuario"].ToString());
                            Globals.userName = cod.Trim();
                            ElegirRol frmRol = new ElegirRol(txtUsuario.Text);
                            frmRol.Show();
                        }
                        else
                        {
                            MessageBox.Show("El usuario" + fila["nombreUsuario"].ToString() + " está bloqueado");

                        }
                    }

                }
            }

        }
    }
}

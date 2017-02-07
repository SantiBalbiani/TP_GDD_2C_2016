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
            DataRow filaUsuario;
            
            if (Conexion.conectar())
            {
                DataTable users = new DataTable();
                string cod = txtUsuario.Text;
                string pass = txtContraseña.Text;
                string cadena = "select nombreUsuario,contraseña,intentosFallidos from SELECT_GROUP.Usuario where contraseña=HASHBYTES('SHA2_256','" + pass.Trim() + "') and nombreUsuario=('" + cod.Trim() + "')";
              
                users = Conexion.LeerTabla(cadena);
                if (users.Rows.Count == 0)
                {
                    string cadenaFallidos = "select nombreUsuario,intentosFallidos from SELECT_GROUP.Usuario where nombreUsuario = ('" + cod.Trim() + "')";
                    DataTable tableUsuario = Conexion.LeerTabla(cadenaFallidos);
                    if (users.Rows.Count > 0)
                    {
                        filaUsuario = tableUsuario.Rows[0];
                        int cantFallido = int.Parse(filaUsuario["intentosFallidos"].ToString());
                        if (cantFallido >= 2)
                        {
                            MessageBox.Show("El usuario " + filaUsuario["nombreUsuario"].ToString() + " está bloqueado");
                            cadena = "update SELECT_GROUP.Usuario set intentosFallidos = intentosFallidos + 1 where nombreUsuario=upper('" + cod.Trim() + "')";
                            Conexion.EjecutarComando(cadena);
                            this.txtContraseña.ResetText();
                            this.txtUsuario.ResetText();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al ingresar usuario o contraseña");
                        cadena = "update SELECT_GROUP.Usuario set intentosFallidos = intentosFallidos + 1 where nombreUsuario=upper('" + cod.Trim() + "')";
                        Conexion.EjecutarComando(cadena);
                        this.txtContraseña.ResetText();
                        this.txtUsuario.ResetText();
                    }
                }
                else
                {
                   foreach (DataRow fila in users.Rows)
                    {
                        if (int.Parse((fila["intentosFallidos"].ToString())) >= 3)
                        {
                            MessageBox.Show("El usuario " + fila["nombreUsuario"].ToString() + " está bloqueado");
                            
                        }
                        else
                        {
                            this.Hide();
                            filaUsuario = users.Rows[0];

                            MessageBox.Show("Bienvenido Usuario " + filaUsuario["nombreUsuario"].ToString());
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


        private void btnFecha_Click(object sender, EventArgs e)
        {
            Fecha frmFecha = new Fecha();
            frmFecha.MenuAnt = this;
            frmFecha.Show();
            this.Enabled = false; 
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtUsuario.Text = txtUsuario.Text.Trim();
            txtUsuario.Text = txtUsuario.Text.Replace(" ", "");
            txtUsuario.SelectionStart = txtUsuario.Text.Length;
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            txtContraseña.Text = txtContraseña.Text.Trim();
            txtContraseña.Text = txtContraseña.Text.Replace(" ", "");
            txtContraseña.SelectionStart = txtContraseña.Text.Length;
        }
    }
}

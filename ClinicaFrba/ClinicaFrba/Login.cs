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
                string cadena = "select nombre as user_name,clave as contraseña ,loginfallidos as login_fallidos,IdRol as id_rol from NEPAirlines.Usuario where clave=HASHBYTES('SHA2_256','" + pass.Trim() + "') and Nombre=('" + cod.Trim() + "')" ;
                    //select user_name,contraseña,login_fallidos,id_rol from prueba.usuarios where user_name=upper('" + cod.Trim() + "') and contraseña=prueba.psencriptar('"+pass.Trim()+"')";
                users = Conexion.LeerTabla(cadena);
                if (users.Rows.Count == 0)
                {
                    MessageBox.Show("Error al ingresar el Usuario o Contraseña");
                    cadena = "update NEPAirlines.Usuario set LoginFallidos=LoginFallidos+1 where Nombre=upper('" + cod.Trim() + "')";                    
                    int resultado=Conexion.EjecutarComando(cadena);                                                            
                }
                else
                {
                    foreach (DataRow fila in users.Rows)
                    {
                        if (int.Parse((fila["login_fallidos"].ToString())) < 3) {
                            this.Hide();
                            MessageBox.Show("Bienvenido " + fila["user_name"].ToString());
                            AbmMenu menu = new AbmMenu();
                            menu.CargarMenu(fila["id_rol"].ToString());
                            menu.Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("El Usuario" + fila["user_name"].ToString()+" está Bloqueado");
                        }
                    }
                }                   
            }
        

            ElegirRol frm = new ElegirRol();
            frm.Show();
            this.Hide();
            
        }
    }
}

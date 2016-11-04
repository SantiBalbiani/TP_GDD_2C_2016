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
                users = conexion.leertabla(cadena);
                if (users.rows.count == 0)
                {
                    messagebox.show("error al ingresar el usuario o contraseña");
                    cadena = "update nepairlines.usuario set loginfallidos=loginfallidos+1 where nombre=upper('" + cod.trim() + "')";
                    int resultado = conexion.ejecutarcomando(cadena);
                }
                else
                {
                    foreach (datarow fila in users.rows)
                    {
                        if (int.parse((fila["login_fallidos"].tostring())) < 3)
                        {
                            this.hide();
                            messagebox.show("bienvenido " + fila["user_name"].tostring());
                            //abmmenu menu = new abmmenu();
                            //menu.cargarmenu(fila["id_rol"].tostring());
                            //menu.show();

                        }
                        else
                        {
                            messagebox.show("el usuario" + fila["user_name"].tostring() + " está bloqueado");
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

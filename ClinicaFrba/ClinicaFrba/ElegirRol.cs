using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClinicaFrba.Base_de_Datos;



namespace ClinicaFrba
{
    public partial class ElegirRol : Form
    {
        public string rolElegido;
        public string usuarioLogeado;
        public ElegirRol(string Usuario)
        {
            InitializeComponent();
            usuarioLogeado = Usuario;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
          //  if (this.comboRoles.SelectedIndex == -1)//Si no selecciono ROL
          //  {
                //No puedo seguir, mensaje avisando que debe seleccionar un rol
               // MsgBox("An exception occurred:");
          //      MessageBox.Show("Debe seleccionar un ROL para poder continuar");
          //  }
         //   else
          //  {
                rolElegido = comboBoxRoles.Text;//el index guarda un 0,1,2 en la variable
          //      MessageBox.Show("Rol Nro " + rolElegido);

                switch (rolElegido)
                {
                    case "Afiliado":
                    //Ejemplo:
                        HomeAfiliado frmAfiliado = new HomeAfiliado();
                        frmAfiliado.Show();
                        this.Close();
                        break;
                    case "Profesional":
                        //hacer algo
                        Menu_Principal.HomeProfesional frmProfesional= new Menu_Principal.HomeProfesional();
                        frmProfesional.Show();
                        this.Close();
                        break;
                    case "Administrativo":
                        Menu_Principal.HomeAdmin frmAdmin= new Menu_Principal.HomeAdmin();
                        frmAdmin.Show();
                        this.Close();
                        break;           
                    default:
                        MessageBox.Show("Debe Seleccionar un Rol para poder continuar");
                        break;
                }
         }

        private void comboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        private void ElegirRol_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = usuarioLogeado;
            string query = "select r.nombre,r.idRol from SELECT_GROUP.Usuario as u,SELECT_GROUP.Rol, SELECT_GROUP.Usuario_Por_Rol as UXR as r where u.nombreUsuario = '" + usuarioLogeado + "' and u.idUsuario = UXR.usuario_username and r.idRol = URX.rol_idRol";
             DataTable dt = Conexion.EjecutarComando(query);
            foreach(DataRow fila in dt.Rows){
                comboBoxRoles.Items.Add(Convert.ToString(fila["nombre"]));
            }  
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

    
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class ElegirRol : Form
    {
        public ElegirRol()
        {
            InitializeComponent();
        }

        int rolElegido;
       
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
                rolElegido = this.comboRoles.SelectedIndex;//el index guarda un 0,1,2 en la variable
          //      MessageBox.Show("Rol Nro " + rolElegido);

                switch (rolElegido)
                {
                    case 0:
                    //Ejemplo:
                        HomeAfiliado frmAfiliado = new HomeAfiliado();
                        frmAfiliado.Show();
                        this.Close();
                        break;
                    case 1:
                        //hacer algo
                        Menu_Principal.HomeProfesional frmProfesional= new Menu_Principal.HomeProfesional();
                        frmProfesional.Show();
                        this.Close();
                        break;
                    case 2:
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
            
         
        //}

    
    }
}

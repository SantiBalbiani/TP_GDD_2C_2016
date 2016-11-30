using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Menu_Principal.HomeAdmin frmHome = new Menu_Principal.HomeAdmin();
            frmHome.Show();

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            SELECT TOP 5 P.matricula, count(Af.plan_idPlan)
            FROM Select_Group.Profesional P
            JOIN Select_Group.Agenda Ag ON Ag.profesional_IdProfesional = P.matricula
            JOIN Select_Group.Turno T ON T.idAgenda = Ag.idAgenda
            JOIN Select_Group.Afiliado Af ON Af.idAfiliado = T.afiliado_idAfiliado
            GROUP BY P.matricula, Af.plan_idPlan
            ORDER BY count(Af.plan_idPlan)
             
        */
        }
    }
}

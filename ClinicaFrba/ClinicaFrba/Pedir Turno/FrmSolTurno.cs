using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class FrmSolTurno : Form
    {
        public FrmSolTurno()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            listView1.Clear();
            DateTime fechaElegida;
            fechaElegida = monthCalendar1.SelectionEnd;
            string[] arr = new string[2];
            ListViewItem itm;
            listView1.Columns.Add("Fecha", 100);
            listView1.Columns.Add("Hora Disponible", 150);
            
            //Llamar SP de hs disponibles

            arr[0] = fechaElegida.ToString();
            arr[1] = "16:00";
            

            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);

            

            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

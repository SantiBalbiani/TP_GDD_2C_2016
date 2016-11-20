using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelacionProfesional : Form
    {
        public CancelacionProfesional()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //Para usar en un período
            // C#
            //DateTime projectStart = new DateTime(2001, 2, 13);
            //DateTime projectEnd = new DateTime(2001, 2, 28);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

   }
}

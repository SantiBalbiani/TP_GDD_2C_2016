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
using System.Configuration;
using System.Data.SqlClient;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelacionProfesional : Form
    {
        public CancelacionProfesional()
        {
            InitializeComponent();
        }
        private bool eligioFecha = false;
        private bool eligioTipo = false;
        private bool escibioMotivo = false;

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            eligioFecha = true;

            if (eligioTipo && eligioFecha && escibioMotivo)
            {
                btnCancelar.Enabled = true;
            }
            DateTime periodoDesde = Calendar.SelectionStart;
            DateTime periodoHasta = Calendar.SelectionEnd;


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelacionProfesional_Load(object sender, EventArgs e)
        {
            btnCancelar.Enabled = false;
            string queryTiposCanc = "Select idTipoCanc, descripcion FROM Select_Group.Tipo_Cancelacion";
            DataTable tiposCancelacion = new DataTable();

            tiposCancelacion = Conexion.LeerTabla(queryTiposCanc);

            foreach (DataRow unTipoCanc in tiposCancelacion.Rows)
            {
                ComboboxItem unItem = new ComboboxItem();

                unItem.Text = unTipoCanc["descripcion"].ToString();
                unItem.Value = unTipoCanc["idTipoCanc"].ToString();

                cmbTipo.Items.Add(unItem);
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            eligioTipo = true;
            if (eligioTipo && eligioFecha && escibioMotivo)
            {
                btnCancelar.Enabled = true;
            }
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            escibioMotivo = true;
            if (eligioTipo && eligioFecha && escibioMotivo)
            {
                btnCancelar.Enabled = true;
            }
        }

   }
}

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
        public CancelacionProfesional(String matricula)
        {
            InitializeComponent();
            idProf = matricula;

        }
        private bool eligioFecha = false;
        private bool eligioTipo = false;
        private bool escibioMotivo = false;
        private string idProf;
        public string menuAnterior;

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

            DateTime UltFecha = Calendar.SelectionEnd;
            
       
            double diasAnticipacion = (UltFecha - DateTime.Now).TotalDays;
            if (diasAnticipacion < 1)
            {
                MessageBox.Show("Solo se pueden cancelar turnos con 1 día de anticipación");
            }
            else 
            {
                
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                SqlCommand cmdUsuario = new SqlCommand("Select_Group.sp_cancelacionProfesional", cnx);
                cmdUsuario.CommandType = CommandType.StoredProcedure;
                Object tipoMotivo = cmbTipo.SelectedItem;
                ComboboxItem tipoMotivoelegido = (ComboboxItem)tipoMotivo;

                cmdUsuario.Parameters.Add("@tipoMot", SqlDbType.Int).Value = tipoMotivoelegido.Value;
                cmdUsuario.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = txtMotivo.Text.ToString();
                cmdUsuario.Parameters.Add("@idProf", SqlDbType.Int).Value = idProf;
                cmdUsuario.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = Calendar.SelectionStart;
                cmdUsuario.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = UltFecha;

                try
                {

                    cnx.Open();
                    cmdUsuario.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cnx.Close();
                    MessageBox.Show("Se cancelaron todos los turnos pertenecientes a los días seleccionados");
                    Menu_Principal.HomeProfesional home = new Menu_Principal.HomeProfesional();
                    home.Show();
                    this.Close();
                }
            }
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

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Globals.irAtras(menuAnterior, this);
        }

   }
}

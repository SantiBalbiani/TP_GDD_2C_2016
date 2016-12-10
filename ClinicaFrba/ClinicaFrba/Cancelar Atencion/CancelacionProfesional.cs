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
        public Form Home;

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
            DateTime primerFecha = Calendar.SelectionStart;
            TimeSpan unDia = new TimeSpan(24,0,0);
            double diasAnticipacion = (primerFecha - Globals.getFechaActual()).TotalDays;
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
                    

                    //Generar Lista de Días a cancelar
                    List<DateTime> listaDiasACancelar = new List<DateTime>();

                    while (primerFecha != UltFecha)
                    {
                        listaDiasACancelar.Add(primerFecha);
                        primerFecha = primerFecha + unDia;
                    }
                    listaDiasACancelar.Add(UltFecha);


                    //Cancelar Días
                    foreach (DateTime unaFechaACancelar in listaDiasACancelar)
                    {
                            SqlConnection cnx2 = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                            SqlCommand cmdUsuario2 = new SqlCommand("Select_Group.sp_getDiasDisponibles", cnx2);
                            cmdUsuario2.CommandType = CommandType.StoredProcedure;
                            cmdUsuario2.Parameters.Add("@Dia", SqlDbType.Int).Value = unaFechaACancelar.DayOfWeek;
                            
                            cmdUsuario2.Parameters.Add("@idProfesional", SqlDbType.Int).Value = idProf;

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
                                string desde = "0";
                                string hasta = "0";
                                string idAgenda = "0";
                                DataTable diasDisponibles = new DataTable();
                                SqlDataAdapter adaptador = new SqlDataAdapter(cmdUsuario);
                                adaptador.Fill(diasDisponibles);
                                cnx.Close();
                                foreach (DataRow diaDisponible in diasDisponibles.Rows)
                                {
                                    desde = diaDisponible["horaDesde"].ToString();
                                    hasta = diaDisponible["horaHasta"].ToString();
                                    idAgenda = diaDisponible["idAgenda"].ToString();
                                }
                            }
                    }
                    
                    
                    
                    
                    
                    
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
           
            Home.Show();
            this.Close();
        }

   }
}

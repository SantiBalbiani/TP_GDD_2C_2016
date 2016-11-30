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
    public partial class CancelacionAfiliado : Form
    {
        public string idAfiliado;
        private bool eligioTurno = false;
        private bool eligioTipo = false;
        private bool escibioMotivo = false;

        public CancelacionAfiliado(string strAfiliado)
        {
            InitializeComponent();
            idAfiliado = strAfiliado;
        }
        
        private void CancelacionAfiliado_Load(object sender, EventArgs e)
        {
            string consultarTurnosParaProfYAfiliado = "SELECT T.idTurno ,T.idAgenda ,T.fechaTurno ,T.afiliado_idAfiliado  FROM Select_Group.Turno T WHERE T.estado = 3 AND T.afiliado_idAfiliado = " + idAfiliado;
            Conexion.conectar();
            btnCancelar.Enabled = false;
            
            DataTable Turnos = new DataTable();

            Turnos = Conexion.LeerTabla(consultarTurnosParaProfYAfiliado);

            foreach (DataRow turno in Turnos.Rows)
            {
                ComboboxItem unItem = new ComboboxItem();

                unItem.Text = turno["fechaTurno"].ToString();
                unItem.Value = turno["idTurno"].ToString();

                DateTime fecha = DateTime.Parse(unItem.Text.ToString());

                if (fecha > DateTime.Now)
                {
                    listBox1.Items.Add(unItem);
                }
            }

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


            Conexion.conexion.Close();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            eligioTipo = true;
            if (eligioTipo && eligioTurno && escibioMotivo)
            {
                btnCancelar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Object turno = listBox1.SelectedItem;
            ComboboxItem turnoElegido = (ComboboxItem)turno;
            DateTime fechTurno = DateTime.Parse(turnoElegido.Text.ToString());
            double diasAnticipacion = (fechTurno - DateTime.Now).TotalDays;
            if (diasAnticipacion < 1)
            {
                MessageBox.Show("Solo se pueden cancelar turnos con 1 día de anticipación");
            }
            else 
            {
                //Llamar SP que impacte en tabla Cancelacion y actualice Turno.estado y Turno.idCancelacion
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                SqlCommand cmdUsuario = new SqlCommand("Select_Group.sp_registrarCancelacion", cnx);
                cmdUsuario.CommandType = CommandType.StoredProcedure;
                Object tipoMotivo = cmbTipo.SelectedItem;
                ComboboxItem tipoMotivoelegido = (ComboboxItem)tipoMotivo;

                cmdUsuario.Parameters.Add("@idTipoCanc", SqlDbType.Int).Value = tipoMotivoelegido.Value;
                cmdUsuario.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = txtMotivo.Text.ToString();
                cmdUsuario.Parameters.Add("@idTurno", SqlDbType.Int).Value = turnoElegido.Value;

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
                    HomeAfiliado home = new HomeAfiliado();
                    home.Show();
                    this.Close();
                }
            }

             

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            eligioTurno = true;
            if (eligioTipo && eligioTurno && escibioMotivo)
            {
                btnCancelar.Enabled = true;

            }
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            escibioMotivo = true;

            if (eligioTipo && eligioTurno && escibioMotivo)
            {
                btnCancelar.Enabled = true;
            }
        }
    }
}

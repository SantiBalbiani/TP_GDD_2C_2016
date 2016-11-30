﻿using System;
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
        public CancelacionAfiliado(string strAfiliado)
        {
            InitializeComponent();
            idAfiliado = strAfiliado;
        }
        
        private void CancelacionAfiliado_Load(object sender, EventArgs e)
        {
            string consultarTurnosParaProfYAfiliado = "SELECT T.idTurno ,T.idAgenda ,T.fechaTurno ,T.afiliado_idAfiliado  FROM Select_Group.Turno T WHERE T.estado = 3 AND T.afiliado_idAfiliado = " + idAfiliado;
            Conexion.conectar();
            
            
            DataTable Turnos = new DataTable();

            Turnos = Conexion.LeerTabla(consultarTurnosParaProfYAfiliado);

            foreach (DataRow turno in Turnos.Rows)
            {
                ComboboxItem unItem = new ComboboxItem();

                unItem.Text = turno["fechaTurno"].ToString();
                unItem.Value = turno["idTurno"].ToString();

                listBox1.Items.Add(unItem);
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

        }
    }
}

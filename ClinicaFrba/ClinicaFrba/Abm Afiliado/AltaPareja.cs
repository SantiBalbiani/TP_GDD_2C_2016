﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria;
using System.Data.SqlClient;
using ClinicaFrba.Base_de_Datos;
using System.Configuration;



namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaPareja : Form
    {

        public DataTable afiliados;
        public DataRow afiliadoIngresado;
        public int idUsuario;
        public Boolean tieneHijos;

        public AltaPareja(DataTable afiliadoPrincipal,DataRow afiliadoIngre,Boolean hijos)
        {
            InitializeComponent();
            tieneHijos = hijos;
            afiliadoIngresado = afiliadoIngre;
            afiliados = afiliadoPrincipal;
         }
      

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            if (Utilidades.ValidarFormulario(this, errorTextBoxPareja) == false)
            {
                DataRow afiliado = afiliados.NewRow();
                afiliado["nombre"] = nombrePareja.Text;
                afiliado["apellido"] = apellidoPareja.Text;
                afiliado["tipoDni"] = tipoDocPareja.Text;
                afiliado["numeroDni"] = Convert.ToInt32(nroDocPareja.Text);
                afiliado["telefono"] = Convert.ToInt32(telefonoPareja.Text);
                afiliado["mail"] = mailPareja.Text;
                afiliado["fechaNac"] = Convert.ToDateTime(fechaNacPareja.Text);
                afiliado["sexo"] = cmbSexoPareja.Text;
                afiliado["estadoCivil"] = "Casado/a";
                afiliado["direccion"] = direccionPareja.Text;
                int usuarioIdAfiliado = registrarUsuario(Convert.ToInt32(nroDocPareja.Text));
                afiliado["usuarioId"] = usuarioIdAfiliado;
                string query = "select PM.idPlan from SELECT_GROUP.Plan_Med as PM where descripcion = ('" + PlanMedPareja.Text.Trim() + "')";
                DataTable dt = Conexion.EjecutarComando(query);
                foreach (DataRow fila in dt.Rows)
                {
                    int idPlanMed = Convert.ToInt32((fila["idPlan"]));
                    afiliado["planMed"] = idPlanMed;
                }
              
                

                afiliados.Rows.Add(afiliado);

                if (tieneHijos)
                {
                    AltaHijo frmHijo = new AltaHijo(afiliados,afiliado);
                    frmHijo.Show();
                    this.Close();
                }
                else {
                    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                    SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.sp_AltaAfiliado", cnx);
                    cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                    cmdAltaAfiliado.Parameters.Add("@Afiliados", SqlDbType.Structured).Value = afiliados;
                    try
                    {
                        cnx.Open();
                        cmdAltaAfiliado.ExecuteNonQuery();
                        MessageBox.Show("Se han guardado correctamente los datos");
                        Menu_Principal.HomeAdmin frmAdmin = new Menu_Principal.HomeAdmin();
                        frmAdmin.Show();
                        this.Close();
                        
                    }
                    catch (ApplicationException error)
                    {
                        string mensaje = "Se ha producido un error";
                        ApplicationException excep = new ApplicationException(mensaje, error);
                        excep.Source = this.Text;
                    }
                }
 
            }
            else
            {
                MessageBox.Show("Faltan Campos ingresar");
            }
            this.Close();
        }
        public int registrarUsuario(int p)
        {

            string nroDocumento = nroDocPareja.Text.Trim();
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.sp_CrearUsuario", cnx);
            cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
            cmdAltaAfiliado.Parameters.Add("@Dni", SqlDbType.Int).Value = Convert.ToInt32(nroDocPareja.Text);
            try
            {
                cnx.Open();
                cmdAltaAfiliado.ExecuteNonQuery();
                string query = "select US.idUsuario from SELECT_GROUP.Usuario as US where nombreUsuario = ('" + nroDocumento + "')";
                DataTable dt = Conexion.EjecutarComando(query);
                foreach (DataRow fila in dt.Rows)
                {
                    idUsuario = Convert.ToInt32((fila["idUsuario"]));

                }
            }
            catch (ApplicationException error)
            {
                string mensaje = "Se ha producido un error ";
                ApplicationException excep = new ApplicationException(mensaje, error);
                excep.Source = this.Text;
                idUsuario = -1;

            }
            return idUsuario;

        }

        private void btnCancelar_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void AltaPareja_Load(object sender, EventArgs e)
        {
            string idPlan = afiliadoIngresado[11].ToString();
            
            string query = "select PM.descripcion from SELECT_GROUP.Plan_Med as PM where idPlan = ('" + idPlan + "')";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                PlanMedPareja.Text = ((fila["descripcion"]).ToString());
                
            } 
            
             
        }
    }
}

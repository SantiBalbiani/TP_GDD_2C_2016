using System;
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
    public partial class AltaHijo : Form
    {
        public DataRow afiliadoIngresado;
        public DataTable tablaAfiliados = new DataTable();
        public Boolean otroHijo = false;
        public int idUsuario;
        public int hijos;
        public string planMedHijo;
        public int contador = 0;
        public int nroAfiliado;
        public Boolean nuevo;
        public string menuAnterior;
        

        public AltaHijo(DataTable Afiliados,DataRow afiliado,int cantHijos, bool esNuevo)
        {
            InitializeComponent();
            afiliadoIngresado = afiliado;
            tablaAfiliados = Afiliados;
            nuevo = esNuevo;
            hijos = cantHijos;
        }

      
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            //Globals.irAtras(menuAnterior, this);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void AltaHijo_Load(object sender, EventArgs e)
        {
            string idPlan = afiliadoIngresado[14].ToString();

            string query = "select PM.descripcion from SELECT_GROUP.Plan_Med as PM where idPlan = ('" + idPlan + "')";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                planMedHijo = ((fila["descripcion"]).ToString());
                PlanMedHijo.Text = planMedHijo;
            }

            //tablaAfiliados.Rows.Add(afiliadoIngresado);
            
            tablaAfiliados = Abm_Afiliado.estructuraBD.crearEstructuraAfiliado(tablaAfiliados);
                        
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             if (Utilidades.ValidarFormulario(this, errorTextBoxHijo) == false)
            {
                 
                int numeroFilas = tablaAfiliados.Rows.Count;
                int nroAfiliado = (Convert.ToInt32(afiliadoIngresado["nroAfiliado"]) + 1);
                
                 if(nuevo)
                 {
                     if(numeroFilas == 1)
               
                    {
                        contador++;
                        nroAfiliado++;

                        tablaAfiliados = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(tablaAfiliados, nroAfiliado, nombreHijo.Text, apellidoHijo.Text,
                                                                                       tipoDocHijo.Text, Convert.ToInt32(nroDocHijo.Text),
                                                                                       Convert.ToInt32(telefonoHijo.Text), mailHijo.Text,
                                                                                       dateTimePicker1.Value.Date, cmbSexoHijo.Text, cmbEstadoCivilHijo.Text,
                                                                                       0, direccionHijo.Text, planMedHijo);
                        int count = tablaAfiliados.Rows.Count;
                        afiliadoIngresado = tablaAfiliados.Rows[count - 1];

                        if (hijos > contador && otroHijo)
                        {

                            AltaHijo frmHijo = new AltaHijo(tablaAfiliados, afiliadoIngresado, (hijos - 1),nuevo);
                            frmHijo.Show();
                            this.Close();
                         }
                        else
                        {
                            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                            try
                            {
                                SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.AltaAfiliado", cnx);
                                cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                                cmdAltaAfiliado.Parameters.Add(new SqlParameter("@Afiliados", SqlDbType.Structured));
                                cmdAltaAfiliado.Parameters["@Afiliados"].Value = tablaAfiliados;
                     
                                cnx.Open();
                                cmdAltaAfiliado.ExecuteNonQuery();
                                MessageBox.Show("Se han guardado correctamente los datos");
                                Menu_Principal.HomeAdmin frmAdmin = new Menu_Principal.HomeAdmin();
                                frmAdmin.Show();
                                this.Close();
                            }
                                catch(ApplicationException error)
                            {
                                    string mensaje = "Se ha producido un error";
                                    ApplicationException excep = new ApplicationException(mensaje, error);
                                    excep.Source = this.Text;
                            }

                        }
                    }else
                     {

                         contador++;
                         tablaAfiliados = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(tablaAfiliados, nroAfiliado, nombreHijo.Text, apellidoHijo.Text,
                                                                                           tipoDocHijo.Text, Convert.ToInt32(nroDocHijo.Text),
                                                                                           Convert.ToInt32(telefonoHijo.Text), mailHijo.Text,
                                                                                           dateTimePicker1.Value.Date, cmbSexoHijo.Text, cmbEstadoCivilHijo.Text,
                                                                                           0, direccionHijo.Text, planMedHijo);

                        int count = tablaAfiliados.Rows.Count;
                        afiliadoIngresado = tablaAfiliados.Rows[count - 1];
                         
                         if(hijos > contador && otroHijo)
                         {

                             nroAfiliado++;
                             AltaHijo frmHijo = new AltaHijo(tablaAfiliados, afiliadoIngresado, hijos,nuevo);
                             frmHijo.Show();
                             this.Close();
                         }
                         else
                         {
                             SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                             
                             try
                             {
                                 SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.AltaAfiliado", cnx);
                                 cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                                 cmdAltaAfiliado.Parameters.Add(new SqlParameter("@Afiliados", SqlDbType.Structured));
                                 cmdAltaAfiliado.Parameters["@Afiliados"].Value = tablaAfiliados;

                                 cnx.Open();
                                 cmdAltaAfiliado.ExecuteNonQuery();
                                 MessageBox.Show("Se han guardado correctamente los datos");
                                 Menu_Principal.HomeAdmin frmAdmin = new Menu_Principal.HomeAdmin();
                                 frmAdmin.Show();
                                 this.Close();
                            }
                                 catch(ApplicationException error)
                             {
                                     string mensaje = "Se ha producido un error";
                                     ApplicationException excep = new ApplicationException(mensaje, error);
                                     excep.Source = this.Text;
                                 }
                       
                            }
                    }
                 }
                 else{

                     nroAfiliado++;

                     DataTable tablaAfiliados2 = new DataTable(); 

                     tablaAfiliados2 = Abm_Afiliado.estructuraBD.cargarEstructuraAfiliado(tablaAfiliados2, nroAfiliado, nombreHijo.Text, apellidoHijo.Text,
                                                                                   tipoDocHijo.Text, Convert.ToInt32(nroDocHijo.Text),
                                                                                   Convert.ToInt32(telefonoHijo.Text), mailHijo.Text,
                                                                                   dateTimePicker1.Value.Date, cmbSexoHijo.Text, cmbEstadoCivilHijo.Text,
                                                                                   0, direccionHijo.Text, planMedHijo);


                     int count = tablaAfiliados.Rows.Count;
                     afiliadoIngresado = tablaAfiliados.Rows[count - 1];
                     
                     if(hijos > contador && otroHijo)
                     {
                         nroAfiliado++;
                         AltaHijo frmHijo = new AltaHijo(tablaAfiliados, afiliadoIngresado, hijos,nuevo);
                         frmHijo.Show();
                         this.Close();                        
                    }
                     else
                     {
                         SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
                         try{
                             SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.AltaAfiliado", cnx);
                             cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
                             cmdAltaAfiliado.Parameters.Add(new SqlParameter("@Afiliados", SqlDbType.Structured));
                             cmdAltaAfiliado.Parameters["@Afiliados"].Value = tablaAfiliados;
                        
                             cnx.Open();
                             cmdAltaAfiliado.ExecuteNonQuery();
                             MessageBox.Show("Se han guardado correctamente los datos");
                             Menu_Principal.HomeAdmin frmAdmin = new Menu_Principal.HomeAdmin();
                             frmAdmin.Show();
                             this.Close();
                            }
                             catch(ApplicationException error)
                         {
                                 string mensaje = "Se ha producido un error";
                                 ApplicationException excep = new ApplicationException(mensaje, error);
                                 excep.Source = this.Text;
                        }

                    }
                 }
            }
             else
             {
                 MessageBox.Show("Faltan Campos ingresar");
             }
             
            this.Close();
            
        }

        private void otro_CheckedChanged(object sender, EventArgs e)
        {
            if(true){
                otroHijo = true;
            
            }
        
        }
        }

   }


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ClinicaFrba.Base_de_Datos;


namespace ClinicaFrba.Abm_Afiliado
{
    class estructuraBD
    {
        
        public static DataTable crearEstructuraAfiliado(DataTable afiliados)
        {
            DataColumn nroAfiliado =

            afiliados.Columns.Add("nombre", typeof(String));    
            afiliados.Columns.Add("nroAfiliado", typeof(Int32));
            afiliados.Columns.Add("apellido", typeof(String));
            afiliados.Columns.Add("tipoDoc", typeof(String));
            afiliados.Columns.Add("numeroDoc", typeof(Int32));
            afiliados.Columns.Add("telefono", typeof(Int32));
            afiliados.Columns.Add("mail", typeof(String));
            afiliados.Columns.Add("fechaNac", typeof(DateTime));
            afiliados.Columns.Add("sexo", typeof(String));
            afiliados.Columns.Add("estadoCivil", typeof(String));
            afiliados.Columns.Add("cantidadHijos", typeof(Int32));
            afiliados.Columns.Add("direccion", typeof(String));
            afiliados.Columns.Add("idUsuario", typeof(Int32));
            afiliados.Columns.Add("plan_idPlan", typeof(Int32));

            return afiliados;

        }
        
        public static DataTable cargarEstructuraAfiliado(DataTable afiliados, int nroAfiliado, string nombre, string apellido, string tipoDoc,
                                                        int numeroDoc, int telefono, string mail, DateTime fechaNac, string sexo,
                                                      string estadoCivil,int cantidadHijos ,string direccion,string planMed)
        {
            int idUsuario, plan_idPlan;

            DataRow afiliado = afiliados.NewRow();
            afiliado["nombre"] = nombre;
            afiliado["nroAfiliado"] = nroAfiliado;
            
            afiliado["apellido"] = apellido;
            afiliado["tipoDoc"] = tipoDoc;
            afiliado["numeroDoc"] = numeroDoc;
            afiliado["telefono"] = telefono;
            afiliado["mail"] = mail;
            afiliado["fechaNac"] = fechaNac;
            afiliado["sexo"] = sexo;
            afiliado["estadoCivil"] = estadoCivil;
            afiliado["cantidadHijos"] = cantidadHijos;
            afiliado["direccion"] = direccion;
            idUsuario = registrarUsuario(numeroDoc);
            afiliado["idUsuario"] = idUsuario;

            string query = "select PM.idPlan from SELECT_GROUP.Plan_Med as PM where descripcion = ('" + planMed + "')";
            DataTable dt = Conexion.EjecutarComando(query);
            foreach (DataRow fila in dt.Rows)
            {
                plan_idPlan = Convert.ToInt32((fila["idPlan"]));
                afiliado["plan_idPlan"] = plan_idPlan;
            }

            afiliados.Rows.Add(afiliado);

            return afiliados;

        }
        public static int registrarUsuario(int numeroDocumento)
        {

            int idUsuario = -1;
            string nroDocumento = Convert.ToString(numeroDocumento);
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString);
            SqlCommand cmdAltaAfiliado = new SqlCommand("Select_Group.sp_CrearUsuario", cnx);
            cmdAltaAfiliado.CommandType = CommandType.StoredProcedure;
            cmdAltaAfiliado.Parameters.Add("@Dni", SqlDbType.Int).Value = numeroDocumento;
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
                idUsuario = -1;
            }

            return idUsuario;
        }
    }

}

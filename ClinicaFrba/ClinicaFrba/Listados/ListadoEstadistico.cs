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

namespace ClinicaFrba.Listados
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Menu_Principal.HomeAdmin frmHome = new Menu_Principal.HomeAdmin();
            frmHome.Show();
            this.Close();

        }

        private void btnCancelaciones_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //Inicio Consulta
            Conexion.conectar();
            
            //string contador;

            DataTable Lista = new DataTable();
            string cadena = "SELECT TOP 5 P.matricula , P.apellido, P.nombre, E.descripcion FROM Select_Group.Profesional P JOIN Select_Group.Profesional_Por_Especialidad PE ON PE.profesional_idProfesional = P.matricula JOIN Select_Group.Especialidad E ON E.idEspecialidad = PE.especialidad_idEspecialidad JOIN Select_Group.Agenda Ag ON Ag.profesional_IdProfesional = P.matricula  JOIN Select_Group.Turno T ON T.idAgenda = Ag.idAgenda JOIN Select_Group.Afiliado Af ON Af.idAfiliado = T.afiliado_idAfiliado GROUP BY P.matricula, Af.plan_idPlan, E.descripcion, P.apellido, P.nombre  ORDER BY count(Af.plan_idPlan)";
            Lista = Conexion.LeerTabla(cadena);
            listView1.Clear();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Matricula", 100);
            listView1.Columns.Add("Apellido", 100);
            listView1.Columns.Add("Nombre", 100);
            listView1.Columns.Add("Descripcion", 200);
            // listView1.Columns.Add("Quantity", 70);
          
            foreach (DataRow listado in Lista.Rows)
            {

            string matricula = listado["matricula"].ToString();
            string apellido = listado["Apellido"].ToString();
            string nombre = listado["Nombre"].ToString();
            string descripcion = listado["Descripcion"].ToString();
            //Add items in the listview
            string[] arr = new string[4];
            ListViewItem itm ;

            //Add first item
            arr[0] = matricula;
            arr[1] = apellido;
            arr[2] = nombre;
            arr[3] = descripcion;
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
            }
            Conexion.conexion.Close();
            //Finalizo consulta
         

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}

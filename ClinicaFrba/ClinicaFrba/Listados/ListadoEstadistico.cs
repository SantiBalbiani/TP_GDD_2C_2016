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
        public string menuAnterior;
        public Menu_Principal.HomeCustom Home;

        public ListadoEstadistico(string unMenu)
        {
            InitializeComponent();
            menuAnterior = unMenu;
        
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //Globals.irAtras(menuAnterior, this);
            Home.Show();
            this.Close();

        }

        private void btnCancelaciones_Click(object sender, EventArgs e)
        {
            Conexion.conectar();

            //string contador;

            DataTable Lista = new DataTable();
            string cadena = "SELECT [especialidad] FROM [Select_Group].[V_Las5EspConMasCancelaciones]";
            Lista = Conexion.LeerTabla(cadena);
            listView1.Clear();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Especialidades", 200);
            //listView1.Columns.Add("Cantidad Veces", 100);
            // listView1.Columns.Add("Quantity", 70);

            foreach (DataRow listado in Lista.Rows)
            {

                string especialidad = listado["especialidad"].ToString();
                //string veces = listado["veces"].ToString();

                //Add items in the listview
                string[] arr = new string[1];
                ListViewItem itm;

                //Add first item
                arr[0] = especialidad;
                //arr[1] = veces;
                //arr[2] = "10";
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
            Conexion.conexion.Close();
            //Finalizo consulta
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //Inicio Consulta
            Conexion.conectar();
            
            //string contador;

            DataTable Lista = new DataTable();
            string cadena = "SELECT  matricula  ,apellido ,nombre ,descripcion FROM Select_Group.ProfMasConsultados";
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

        private void button3_Click(object sender, EventArgs e)
        {

            ComboboxItem planElegido = new ComboboxItem();
            ComboboxItem especialidadElegida = new ComboboxItem();

            planElegido = (ComboboxItem)cbmPlanMed.SelectedItem;
            especialidadElegida = (ComboboxItem)comboBox1.SelectedItem;
            string query3 = "SELECT TOP 5 Ag.profesional_IdProfesional, Pr.apellido, Pr.nombre   FROM Select_Group.Agenda_Detalle Ad  JOIN Select_Group.Agenda Ag ON Ag.idAgenda = Ad.idAgenda JOIN Select_Group.Profesional Pr ON Pr.matricula = Ag.profesional_IdProfesional  JOIN Select_Group.Profesional_Por_Especialidad Esp ON Esp.profesional_idProfesional = Ag.profesional_IdProfesional  JOIN Select_Group.Turno T ON T.fechaTurno = Ad.fecha_Hora_Turno AND T.idAgenda = Ad.idAgenda  JOIN Select_Group.Afiliado Af ON Af.idAfiliado = T.afiliado_idAfiliado  GROUP BY Ag.profesional_IdProfesional, Esp.especialidad_idEspecialidad, Af.plan_idPlan, Pr.apellido, Pr.nombre  HAVING Esp.especialidad_idEspecialidad = "+ especialidadElegida.Value.ToString() +" AND Af.plan_idPlan = "+ planElegido.Value.ToString() +"  ORDER BY count(Ad.fecha_Hora_Turno) asc ";

            Conexion.conectar();

            //string contador;

            DataTable Lista = new DataTable();
            
            Lista = Conexion.LeerTabla(query3);
            listView1.Clear();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Matricula", 100);
            listView1.Columns.Add("Apellido", 100);
            listView1.Columns.Add("Nombre", 100);
            
            // listView1.Columns.Add("Quantity", 70);

            foreach (DataRow listado in Lista.Rows)
            {

                string matricula = listado["profesional_IdProfesional"].ToString();
                string apellido = listado["Apellido"].ToString();
                string nombre = listado["Nombre"].ToString();
                
                //Add items in the listview
                string[] arr = new string[4];
                ListViewItem itm;

                //Add first item
                arr[0] = matricula;
                arr[1] = apellido;
                arr[2] = nombre;
                
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
           //Cargo Planes Medicos
            cbmPlanMed.Visible = true;
            comboBox1.Visible = true;
            Conexion.conectar();
            cbmPlanMed.Items.Clear();
            cbmPlanMed.ResetText();
            cbmPlanMed.SelectedText = "Seleccione Nuevo Plan";
            DataTable Planes = new DataTable();
            string cadena = "select  idPlan, descripcion from SELECT_GROUP.Plan_Med";

            Planes = Conexion.LeerTabla(cadena);

            foreach (DataRow planes in Planes.Rows)
            {

                string desc = planes["descripcion"].ToString();
                ComboboxItem itemPlan = new ComboboxItem();

                itemPlan.Text = planes["descripcion"].ToString();
                itemPlan.Value = planes["idPlan"].ToString();

                cbmPlanMed.Items.Add(itemPlan);

            }
            Conexion.conexion.Close();


            // Cargo especialidades
            Conexion.conectar();
            DataTable especialidades = new DataTable();
            string queryEsp = "select idEspecialidad, descripcion from SELECT_GROUP.Especialidad";

            especialidades = Conexion.LeerTabla(queryEsp);
            foreach (DataRow especialidad in especialidades.Rows)
            {

                string desc = especialidad["descripcion"].ToString();
                ComboboxItem itemEsp = new ComboboxItem();

                itemEsp.Text = desc;
                itemEsp.Value = especialidad["idEspecialidad"].ToString();

                comboBox1.Items.Add(itemEsp);

            }


            Conexion.conexion.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Inicio Consulta
            Conexion.conectar();

            //string contador;

            DataTable Lista = new DataTable();
            string cadena = "SELECT [nroAfiliado],[nombre] ,[apellido] ,[Cantidad Comprada]  FROM [Select_Group].[5AfiliadosConMasCompraDeBonos]";
            Lista = Conexion.LeerTabla(cadena);
            listView1.Clear();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Nro de Afiliado", 100);
            listView1.Columns.Add("Nombre", 200);
            listView1.Columns.Add("Apellido", 200);
            listView1.Columns.Add("Cantidad Comprada", 100);
            // listView1.Columns.Add("Quantity", 70);

            foreach (DataRow listado in Lista.Rows)
            {

                string matricula = listado["nroAfiliado"].ToString();
                string apellido = listado["nombre"].ToString();
                string nombre = listado["apellido"].ToString();
                string descripcion = listado["Cantidad Comprada"].ToString();
                //Add items in the listview
                string[] arr = new string[4];
                ListViewItem itm;

                //Add first item
                arr[0] = matricula;
                arr[1] = apellido;
                arr[2] = nombre;
                arr[3] = descripcion;
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
            Conexion.conexion.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Inicio Consulta
            Conexion.conectar();

            //string contador;

            DataTable Lista = new DataTable();
            string query4 = "SELECT [especialidad_idEspecialidad] ,[descripcion] FROM [Select_Group].[V_Las5EspConMasBonos]";
            Lista = Conexion.LeerTabla(query4);
            listView1.Clear();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("especialidad_idEspecialidad", 100);
            listView1.Columns.Add("descripcion", 100);
            // listView1.Columns.Add("Quantity", 70);

            foreach (DataRow listado in Lista.Rows)
            {

                string idEspecialidad = listado["especialidad_idEspecialidad"].ToString();
                string descripcion = listado["descripcion"].ToString();

                //Add items in the listview
                string[] arr = new string[4];
                ListViewItem itm;

                //Add first item
                arr[0] = idEspecialidad;
                arr[1] = descripcion;
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
            Conexion.conexion.Close();
            //Finalizo consulta
        }


    }
}

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
using System.Globalization;

namespace ClinicaFrba.Listados
{
    public partial class ListadoEstadistico : Form
    {
        public string menuAnterior;
        public Form Home;
        public bool usaMes = false;
        public int nroQueryElegido = 0;
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

            public static DateTime[] obtenerFechas(string anio, string semestre, bool mensual, string nroMes)
    {
        DateTime[] fechas = new DateTime[2];
        DateTime fechaDesde = new DateTime();
        DateTime fechaHasta = new DateTime();
        string strDesde;
        string strHasta;
        if (mensual)
        {
            if (nroMes == "todos" || nroMes == "0")
            {
                //Eligió anual
                    strDesde = "01/01/" + anio;
                    strHasta = "12/12/" + anio;
                    
                    fechaDesde = Convert.ToDateTime(strDesde);    
                    fechaHasta = Convert.ToDateTime(strHasta);
                    
                    fechas[0] = fechaDesde;
                    fechas[1] = fechaHasta;
                    
                    
                    return fechas;
            }
            else
            {
                strDesde = "01/" + nroMes + "/" + anio;
                fechaDesde = Convert.ToDateTime(strDesde);
                int ultimoDiaDelMes = DateTime.DaysInMonth((Convert.ToInt32(anio)), (Convert.ToInt32(nroMes)));
                strHasta = ultimoDiaDelMes.ToString() + "/" + nroMes + "/" + anio;
                fechaHasta = Convert.ToDateTime(strHasta);

                fechas[0] = fechaDesde;
                fechas[1] = fechaHasta;

                return fechas;
            }
        }else{
                switch (semestre)
                {
                    
                    case "0"://Eligió anual
                    strDesde = "01/01/" + anio;
                    strHasta = "12/12/" + anio;
                    
                    fechaDesde = Convert.ToDateTime(strDesde);    
                    fechaHasta = Convert.ToDateTime(strHasta);
                    
                    fechas[0] = fechaDesde;
                    fechas[1] = fechaHasta;
                    
                    
                    return fechas;
                    break;
                    
                    case "1"://Eligió el primer semestre
                    strDesde = "01/01/" + anio;
                    fechaDesde = Convert.ToDateTime(strDesde);    
                    fechaHasta = fechaDesde.AddMonths(6);
                    fechas[0] = fechaDesde;
                    fechas[1] = fechaHasta;
                    break;
                    
                    case "2"://Eligió el segundo semestre
                    strDesde = "01/01/" + anio;
                    fechaDesde = Convert.ToDateTime(strDesde);    
                    fechaDesde = fechaDesde.AddMonths(6);
                    fechaHasta = fechaDesde.AddMonths(6);
                    fechas[0] = fechaDesde;
                    fechas[1] = fechaHasta;
                    return fechas;
                    break;
                
                    default:
                    //Eligió anual
                    strDesde = "01/01/" + anio;
                    strHasta = "12/12/" + anio;

                    fechaDesde = Convert.ToDateTime(strDesde);
                    fechaHasta = Convert.ToDateTime(strHasta);

                    fechas[0] = fechaDesde;
                    fechas[1] = fechaHasta;


                    return fechas;
                    break;
                }
            }
        return fechas;
    }


        private void btnCancelaciones_Click(object sender, EventArgs e)
        {
            string anio = txboxanio.Text.ToString();
            string semestre = cmbsemestre.SelectedItem.ToString();
            string elMes = "00";
            ComboboxItem Mes = new ComboboxItem(); 
            Mes = (ComboboxItem)cmbmes.SelectedItem;

            if(Mes != null){
              elMes = Mes.Value.ToString();
            }
            

            DateTime[] fechas = obtenerFechas(anio, semestre, usaMes, elMes);

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
         

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            
            
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {

            string primerSemestre = "1";
            string segundoSemestre = "2";
            string todos = "todos";

            cmbsemestre.Items.Add(primerSemestre);
            cmbsemestre.Items.Add(segundoSemestre);
            cmbsemestre.Items.Add(todos);


            ComboboxItem todosMes = new ComboboxItem();
            todosMes.Text = "todos";
            todosMes.Value = 0;
            cmbmes.Items.Add(todosMes);

            for (int i = 1; i != 12; i++)
            {
                ComboboxItem unMes = new ComboboxItem();
                string mes = DateTimeFormatInfo.CurrentInfo.GetMonthName(i);
                unMes.Text = mes;
                unMes.Value = i;
                cmbmes.Items.Add(unMes);
            }




            
            //Cargo Planes Medicos
            
            comboBox1.Visible = false;
          
            


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
           
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbsemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string semest = cmbsemestre.SelectedItem.ToString();
            if (semest != "todos")
            {
                cmbmes.Enabled = false;
            }else{
                cmbmes.Enabled = true;
            }
        }

        private void cmbmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            usaMes = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            nroQueryElegido = 1;
            comboBox1.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            nroQueryElegido = 2;
            comboBox1.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            nroQueryElegido = 3;
            comboBox1.Visible = false;
        }

        private void txboxanio_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string anio = txboxanio.Text.ToString();
            string semestre = cmbsemestre.SelectedItem.ToString();
            string elMes = "todos";
            ComboboxItem Mes = new ComboboxItem();
            Mes = (ComboboxItem)cmbmes.SelectedItem;

            if (Mes != null)
            {
                elMes = Mes.Value.ToString();
            }


            DateTime[] fechas = obtenerFechas(anio, semestre, usaMes, elMes);

            DateTime fechaDesde = fechas[0];
            DateTime fechaHasta = fechas[1];

            DataTable Lista = new DataTable();
            switch (nroQueryElegido)
            {

                case 0:

                    MessageBox.Show("Por favor seleccione un reporte");
                    break;
                case 1:

                    string consultaMayCanc = "SELECT TOP 5 T.especialidad FROM Select_Group.Turno T WHERE T.cancelacion_idCancelacion is not null AND T.fechaTurno BETWEEN '" + fechaDesde.ToString("MM/dd/yyyy") + "' AND '" + fechaHasta.ToString("MM/dd/yyyy") + "' GROUP BY T.especialidad ORDER BY count(*) desc";
            
                    Conexion.conectar();

                    

                    
                    string cadena = "SELECT [especialidad] FROM [Select_Group].[V_Las5EspConMasCancelaciones]";
                    Lista = Conexion.LeerTabla(consultaMayCanc);
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

            break;
                case 2:
            Conexion.conectar();

            //string contador;

            
            string cadenaquery2 = "SELECT  matricula  ,apellido ,nombre ,descripcion FROM Select_Group.ProfMasConsultados";
            Lista = Conexion.LeerTabla(cadenaquery2);
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
                //Finalizo consulta

            break;

                case 3:
            //Inicio Consulta
            Conexion.conectar();

            //string contador;

            
            string cadenaquery3 = "SELECT [nroAfiliado],[nombre] ,[apellido] ,[Cantidad Comprada]  FROM [Select_Group].[5AfiliadosConMasCompraDeBonos]";
            Lista = Conexion.LeerTabla(cadenaquery3);
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
            break;

                case 4:

            //Inicio Consulta
            Conexion.conectar();

            //string contador;

            
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

            break;

                case 5:

                    ComboboxItem unaEsp = new ComboboxItem();
                    unaEsp = (ComboboxItem)comboBox1.SelectedItem;

                    if (unaEsp == null)
                    {

                        MessageBox.Show("Para poder ejecutar este reporte necesita seleccionar una especialidad");
                    }
                    else
                    {
                        ComboboxItem especialidadElegida = new ComboboxItem();


                        especialidadElegida = (ComboboxItem)comboBox1.SelectedItem;
                        string query3 = "SELECT TOP 5 Ag.profesional_IdProfesional, Pr.apellido, Pr.nombre   FROM Select_Group.Agenda_Detalle Ad  JOIN Select_Group.Agenda Ag ON Ag.idAgenda = Ad.idAgenda JOIN Select_Group.Profesional Pr ON Pr.matricula = Ag.profesional_IdProfesional  JOIN Select_Group.Profesional_Por_Especialidad Esp ON Esp.profesional_idProfesional = Ag.profesional_IdProfesional  JOIN Select_Group.Turno T ON T.fechaTurno = Ad.fecha_Hora_Turno AND T.idAgenda = Ad.idAgenda  JOIN Select_Group.Afiliado Af ON Af.idAfiliado = T.afiliado_idAfiliado  GROUP BY Ag.profesional_IdProfesional, Esp.especialidad_idEspecialidad, Af.plan_idPlan, Pr.apellido, Pr.nombre  HAVING Esp.especialidad_idEspecialidad = " + especialidadElegida.Value.ToString() + " ORDER BY count(Ad.fecha_Hora_Turno) asc ";

                        Conexion.conectar();

                        //string contador;



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
            break;

                default:
            break;


            }

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            nroQueryElegido = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            nroQueryElegido = 5;
            comboBox1.Visible = true;

        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            nroQueryElegido = 5;
            comboBox1.Visible = true;
        }


    }
}

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
                    strHasta = "31/12/" + anio;
                    
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
                    strHasta = "31/12/" + anio;
                    
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
                    strHasta = "31/12/" + anio;

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

            for (int i = 1; i != 13; i++)
            {
                ComboboxItem unMes = new ComboboxItem();
                string mes = DateTimeFormatInfo.CurrentInfo.GetMonthName(i);
                unMes.Text = mes;
                unMes.Value = i;
                cmbmes.Items.Add(unMes);
            }





            cmbEspQuery2.Visible = false;
            cmbPlanQuery2.Visible = false;
            comboBox1.Visible = false;


            //Cargo el plan
            Conexion.conectar();
           
            DataTable Planes = new DataTable();
            string cadena = "select  idPlan, descripcion from SELECT_GROUP.Plan_Med";

            Planes = Conexion.LeerTabla(cadena);

            foreach (DataRow planes in Planes.Rows)
            {

                string desc = planes["descripcion"].ToString();
                ComboboxItem itemPlan = new ComboboxItem();

                itemPlan.Text = planes["descripcion"].ToString();
                itemPlan.Value = planes["idPlan"].ToString();

                cmbPlanQuery2.Items.Add(itemPlan);

            }
            Conexion.conexion.Close();
            // Fin de carga del plan

            


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
                cmbEspQuery2.Items.Add(itemEsp);
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
            cmbEspQuery2.Visible = false;
            cmbPlanQuery2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            nroQueryElegido = 2;
            comboBox1.Visible = false;
            cmbEspQuery2.Visible = true;
            cmbPlanQuery2.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            nroQueryElegido = 3;
            comboBox1.Visible = false;
            cmbEspQuery2.Visible = false;
            cmbPlanQuery2.Visible = false;
        }

        private void txboxanio_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txboxanio.Text.ToString() == "")
            {
                MessageBox.Show("Por favor completar el año");
            }
            else
            {

                string anio = txboxanio.Text.ToString();

                string semestre = "todos";

                if (cmbsemestre.SelectedItem != null)
                {

                    semestre = cmbsemestre.SelectedItem.ToString();
                }
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

                        string consultaMayCanc = "SELECT TOP 5 T.especialidad FROM Select_Group.Turno T WHERE T.cancelacion_idCancelacion is not null AND T.fechaTurno BETWEEN '" + fechaDesde.ToString("yyyyMMdd") + "' AND '" + fechaHasta.ToString("yyyyMMdd") + "' GROUP BY T.especialidad ORDER BY count(*) desc";

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

                        if ((cmbPlanQuery2.SelectedItem == null) || (cmbEspQuery2.SelectedItem == null))
                        {
                            MessageBox.Show("Seleccionar Plan y Especialidad");

                        }
                        else
                        {
                            ComboboxItem unaEspecialidad = new ComboboxItem();
                            unaEspecialidad = (ComboboxItem)cmbEspQuery2.SelectedItem;

                            ComboboxItem unPlan = new ComboboxItem();
                            unPlan = (ComboboxItem)cmbPlanQuery2.SelectedItem;

                            Conexion.conectar();



                            string select = "SELECT  TOP (5) P.matricula, P.apellido, P.nombre, E.descripcion,E.idEspecialidad, Af.plan_idPlan, COUNT(Af.plan_idPlan) AS 'CantConsultas'";
                            string from = "FROM   Select_Group.Profesional AS P INNER JOIN Select_Group.Profesional_Por_Especialidad AS PE ON PE.profesional_idProfesional = P.matricula INNER JOIN Select_Group.Especialidad AS E ON E.idEspecialidad = PE.especialidad_idEspecialidad INNER JOIN Select_Group.Agenda AS Ag ON Ag.profesional_IdProfesional = P.matricula INNER JOIN Select_Group.Turno AS T ON T.idAgenda = Ag.idAgenda INNER JOIN Select_Group.Afiliado AS Af ON Af.idAfiliado = T.afiliado_idAfiliado ";


                            string where = "WHERE Af.plan_idPlan = " + unPlan.Value.ToString().Trim() + " AND E.idEspecialidad = " + unaEspecialidad.Value.ToString().Trim() + " AND T.fechaTurno BETWEEN '" + fechaDesde.ToString("yyyyMMdd") + "' AND '" + fechaHasta.ToString("yyyyMMdd") + "'";
                            string orderBy = "GROUP BY P.matricula, Af.plan_idPlan, E.descripcion, P.apellido, P.nombre, E.idEspecialidad ORDER BY COUNT(Af.plan_idPlan) desc";
                            string cadenaquery2 = select + from + where + orderBy;
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
                                string apellido = listado["apellido"].ToString();
                                string nombre = listado["nombre"].ToString();
                                string descripcion = listado["descripcion"].ToString();
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
                        }
                        break;

                    case 3:
                        //Inicio Consulta
                        Conexion.conectar();

                        //string contador;


                        string campos = "SELECT TOP 5 A.nroAfiliado, A.nombre, A.apellido, COUNT(*) AS 'Cantidad Comprada', (SELECT count(*) FROM SELECT_GROUP.Afiliado A2 WHERE A2.nroAfiliado LIKE (left(A.nroAfiliado, LEN(A.nroAfiliado)-2)+'%') AND (LEN(A.nroAfiliado) = LEN(A2.nroAfiliado))) AS 'CantFamiliares' ";
                        string desdeTabla = "FROM Select_Group.Afiliado A JOIN Select_Group.Bono B ON A.idAfiliado = B.idAfiliado ";
                        string condicion = "WHERE B.bonoConsulta_FechaImpresion BETWEEN '" + fechaDesde.ToString("yyyyMMdd") + "' AND '" + fechaHasta.ToString("yyyyMMdd") + "' GROUP BY A.nroAfiliado, A.nombre, A.apellido ORDER BY COUNT(*) DESC";
                        string cadenaquery3 = campos + desdeTabla + condicion;
                        Lista = Conexion.LeerTabla(cadenaquery3);
                        listView1.Clear();

                        listView1.View = View.Details;
                        listView1.GridLines = true;
                        listView1.FullRowSelect = true;

                        listView1.Columns.Add("Nro de Afiliado", 100);
                        listView1.Columns.Add("Nombre", 200);
                        listView1.Columns.Add("Apellido", 200);
                        listView1.Columns.Add("Cantidad Comprada", 100);
                        listView1.Columns.Add("Pertenece Grupo Familiar", 100);
                        listView1.Columns.Add("CantFamiliares", 100);
                        // listView1.Columns.Add("Quantity", 70);

                        foreach (DataRow listado in Lista.Rows)
                        {

                            string matricula = listado["nroAfiliado"].ToString();
                            string apellido = listado["nombre"].ToString();
                            string nombre = listado["apellido"].ToString();
                            string descripcion = listado["Cantidad Comprada"].ToString();
                            string CantFamiliar = listado["CantFamiliares"].ToString();
                            //Add items in the listview
                            string[] arr = new string[6];
                            ListViewItem itm;
                            int cantFam = 0;
                            if (CantFamiliar == "1")
                            {
                                arr[4] = "No";
                                arr[5] = "0";
                            }
                            else
                            {
                                arr[4] = "Si";
                                cantFam = Convert.ToInt32(CantFamiliar);
                                cantFam--;
                                arr[5] = cantFam.ToString();
                            }

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

                        string seleccion = "SELECT TOP 5 E.descripcion, T.especialidad, count(*) AS 'CantBonosUsados' ";
                        string desde = "FROM SELECT_GROUP.Bono B JOIN SELECT_GROUP.Turno T ON B.idAfiliado = T.afiliado_idAfiliado JOIN SELECT_GROUP.Especialidad E ON E.idEspecialidad = T.especialidad ";
                        string filtro = "WHERE B.estado = 0 AND T.fechaTurno BETWEEN '" + fechaDesde.ToString("yyyyMMdd") + "' AND '" + fechaHasta.ToString("yyyyMMdd") + "' ";
                        string agrupa = "GROUP BY T.especialidad, E.descripcion  ORDER BY count(*) DESC";
                        string query4 = seleccion + desde + filtro + agrupa;
                        Lista = Conexion.LeerTabla(query4);
                        listView1.Clear();

                        listView1.View = View.Details;
                        listView1.GridLines = true;
                        listView1.FullRowSelect = true;

                        listView1.Columns.Add("Especialidad", 250);
                        listView1.Columns.Add("Cantidad de Bonos Usados", 150);
                        // listView1.Columns.Add("Quantity", 70);

                        foreach (DataRow listado in Lista.Rows)
                        {

                            string idEspecialidad = listado["descripcion"].ToString();
                            string descripcion = listado["CantBonosUsados"].ToString();

                            //Add items in the listview
                            string[] arr = new string[2];
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
                            string query3 = "SELECT TOP 5 Ag.profesional_IdProfesional, Pr.apellido, Pr.nombre   FROM Select_Group.Agenda_Detalle Ad  JOIN Select_Group.Agenda Ag ON Ag.idAgenda = Ad.idAgenda JOIN Select_Group.Profesional Pr ON Pr.matricula = Ag.profesional_IdProfesional  JOIN Select_Group.Profesional_Por_Especialidad Esp ON Esp.profesional_idProfesional = Ag.profesional_IdProfesional  JOIN Select_Group.Turno T ON T.fechaTurno = Ad.fecha_Hora_Turno AND T.idAgenda = Ad.idAgenda  JOIN Select_Group.Afiliado Af ON Af.idAfiliado = T.afiliado_idAfiliado WHERE T.fechaTurno BETWEEN '" + fechaDesde.ToString("yyyyMMdd") + "' AND '" + fechaHasta.ToString("yyyyMMdd") + "'  GROUP BY Ag.profesional_IdProfesional, Esp.especialidad_idEspecialidad, Af.plan_idPlan, Pr.apellido, Pr.nombre  HAVING Esp.especialidad_idEspecialidad = " + especialidadElegida.Value.ToString() + " ORDER BY count(Ad.fecha_Hora_Turno) asc ";

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
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            nroQueryElegido = 4;
            comboBox1.Visible = false;
            cmbEspQuery2.Visible = false;
            cmbPlanQuery2.Visible = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            nroQueryElegido = 5;
            comboBox1.Visible = true;
            cmbEspQuery2.Visible = false;
            cmbPlanQuery2.Visible = false;

        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            nroQueryElegido = 5;
            comboBox1.Visible = true;
            cmbEspQuery2.Visible = false;
            cmbPlanQuery2.Visible = false;
        }


    }
}

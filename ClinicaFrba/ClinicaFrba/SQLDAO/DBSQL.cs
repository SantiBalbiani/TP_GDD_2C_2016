using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.SQL_DAO
{
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;

    public class DBSql
    {
        static public DataTable Query(String query)
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ClinicaFrba.Properties.Settings.GD2C2016ConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                DataSet dataSet = new DataSet();

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {

                    adapter.Fill(dataSet);
                }

                sqlConnection1.Close();

                return dataSet.Tables[0];
            }
        }

    }
}


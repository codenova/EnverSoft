using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

 
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //Please change connection string
        string connectionString = "Data Source=Server_Name;Initial Catalog=DB_Name;Integrated Security=True";

        [WebMethod]
        public void saveCompanyDetail(string name, string telephone)
        {
            
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("Save_CompanyDetail", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 0;

                command.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
                command.Parameters.AddWithValue("@telephone", SqlDbType.NVarChar).Value = telephone;
               
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        [WebMethod]
        public string Search(string name)
        {
            String telephone = "";
            using (var connection = new SqlConnection(connectionString))
            {
               
                var command = new SqlCommand("Search_CompanyDetail", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 0;

                command.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;

                connection.Open();
                IDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    telephone = reader.GetValue(0).ToString();
                }
                connection.Close();
            }
            return telephone;
        }
    }
}

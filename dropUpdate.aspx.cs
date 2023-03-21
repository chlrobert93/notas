using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Data;

namespace DropDownLis
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public string consulta { get;  set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string nombre = "Hongos";
            int id = 1;

            consulta = "UPDATE frutas SET nombre = @nombre "+ "WHERE id = @id;";

            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {

                /* try
                 {
                     connection.Open();

                    string  consulta = "select * from frutas";
                    SqlCommand cmd = new SqlCommand(consulta, connection);

                     using (var reader = cmd.ExecuteReader())
                     {
                         DropDownList1.DataSource = reader;
                         DropDownList1.DataValueField = "id";
                         DropDownList1.DataValueField = "nombre";
                         DropDownList1.DataBind();
                     }


                         Console.WriteLine("Conexión válida");
                 }*/

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(consulta, connection);


                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = id;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    Int32 rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }




                catch (Exception exeption)
                {

                    Console.WriteLine(exeption.Message);
                }



            }
        }
    }
}

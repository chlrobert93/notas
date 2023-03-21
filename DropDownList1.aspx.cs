using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


using System.Data.SqlClient;
using System.Reflection;

namespace DropDownLis
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

      //  public string consulta { get;  set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {

                try
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
                }



                
                catch (Exception exeption)
                {

                    Console.WriteLine(exeption.Message);
                }



            }
        }
    }
}

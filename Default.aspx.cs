using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CondominosAppWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object Login(string email, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CondominosDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TipoUsuario FROM Condominos WHERE Email = @Email AND Password = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int tipoUsuario = Convert.ToInt32(result);

                    HttpContext.Current.Session["TipoUsuario"] = tipoUsuario;

                    return new { success = true, tipoUsuario = tipoUsuario };
                }
                else
                {
                    return new { success = false };
                }
            }
        }
    }
}
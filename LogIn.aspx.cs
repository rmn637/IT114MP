using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;


            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmpPass"", ""EmpID"", ""EmpUser"" FROM ""EmployeeAccount"" WHERE ""EmpUser"" = @username", connection);
                    command.Parameters.AddWithValue("@Username", username);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string storedPassword = reader.GetString(0);
                        string storedEmpID = reader.GetString(1);
                        string storedEmpUser = reader.GetString(2);
                        if (password.Equals(storedPassword))
                        {
                            Session["EmpID"] = storedEmpID;
                            Response.Redirect("MyAccount.aspx");
                        }
                        else if (!password.Equals(storedPassword))
                        {
                            Response.Write("<script>alert('Access denied')</script>");

                        }
                        else
                        {
                            Response.Write("<script>alert('No User Found')</script>");
                        }
                    }
                    

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            
        }
    }
}
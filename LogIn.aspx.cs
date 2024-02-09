using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            string storedSupPass = "", storedSupID = "", storedSupUser = "", storedEmpID = "", storedPassword = "", storedEmpUser = "";

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""SupPass"", ""SupID"", ""SupUser"" FROM ""SupervisorAccount"" WHERE ""SupUser"" = @username", connection);
                    command.Parameters.AddWithValue("@Username", username);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        storedSupPass = reader.GetString(0);
                        storedSupID = reader.GetString(1);
                        storedSupUser = reader.GetString(2);
                    }
                    reader.Close();


                    command = new NpgsqlCommand(@"SELECT * FROM ""Supervisor"" INNER JOIN ""SupervisorAccount"" ON ""Supervisor"".""SupID"" = ""SupervisorAccount"".""SupID"" WHERE ""Supervisor"".""SupID"" = @supID", connection);
                    command.Parameters.AddWithValue("@SupID", storedSupID);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        storedEmpID = reader.GetString(1);
                    }
                    reader.Close();

                    if (password.Equals(storedSupPass))
                    {
                        Session["EmpID"] = storedEmpID;
                        Session["AccType"] = "Supervisor";
                        Response.Redirect("MyAccount.aspx");
                    }
                    else if (!password.Equals(storedSupPass))
                    {
                        Response.Write("<script>alert('Access denied')</script>");

                    }
                    else
                    {
                        Response.Write("<script>alert('No User Found')</script>");
                    }

                    command = new NpgsqlCommand(@"SELECT ""EmpPass"", ""EmpID"", ""EmpUser"" FROM ""EmployeeAccount"" WHERE ""EmpUser"" = @username", connection);
                    command.Parameters.AddWithValue("@Username", username);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        storedPassword = reader.GetString(0);
                        storedEmpID = reader.GetString(1);
                        storedEmpUser = reader.GetString(2); 
                    }

                    if (password.Equals(storedPassword))
                    {
                        Session["EmpID"] = storedEmpID;
                        Session["AccType"] = "Employee";
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
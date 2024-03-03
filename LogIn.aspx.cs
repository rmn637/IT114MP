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
            string storedSupPass = "", storedSupID = "", storedSupUser = "", storedEmpID = "", storedPassword = "", storedEmpUser = "", empType = "";

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmployeeAccount"".""EmpPass"", ""EmployeeAccount"".""EmpID"", ""EmployeeAccount"".""EmpUser"", ""Employee"".""EmpType"" FROM ""EmployeeAccount"" INNER JOIN ""Employee"" ON ""Employee"".""EmpID"" = ""EmployeeAccount"".""EmpID"" WHERE ""EmployeeAccount"".""EmpUser"" = @username", connection);
                    command.Parameters.AddWithValue("@Username", username);

                    NpgsqlDataReader reader = command.ExecuteReader();
    
                    while (reader.Read())
                    {
                        storedPassword = reader.GetString(0);
                        storedEmpID = reader.GetString(1);
                        storedEmpUser = reader.GetString(2);
                        empType = reader.GetString(3);
                    }
                    reader.Close();

                    command = new NpgsqlCommand(@"SELECT ""EmployeeAccount"".""EmpPass"", ""EmployeeAccount"".""EmpID"", ""EmployeeAccount"".""EmpUser"", ""Employee"".""EmpType"" FROM ""EmployeeAccount"" INNER JOIN ""Employee"" ON ""Employee"".""EmpID"" = ""EmployeeAccount"".""EmpID"" WHERE ""EmployeeAccount"".""EmpUser"" = @username", connection);
                    command.Parameters.AddWithValue("@Username", username);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        storedPassword = reader.GetString(0);
                        storedEmpID = reader.GetString(1);
                        storedEmpUser = reader.GetString(2);
                        empType = reader.GetString(3);
                    }

                    if (password.Equals(storedPassword))
                    {
                        Session["EmpID"] = storedEmpID;
                        Session["RateeID"] = storedEmpID;
                        Session["AccType"] = empType;
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
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class LogInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;
            string storedStatus = "", storedSupPass = "", storedSupID = "", storedSupUser = "", storedEmpID = "", storedPassword = "", storedEmpUser = "", empType = "";
            int subordinateCount = 0;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmployeeAccount"".""EmpPass"", ""EmployeeAccount"".""EmpID"", ""EmployeeAccount"".""EmpUser"", ""Employee"".""EmpType"", ""EmployeeAccount"".""Status"" FROM ""EmployeeAccount"" INNER JOIN ""Employee"" ON ""Employee"".""EmpID"" = ""EmployeeAccount"".""EmpID"" WHERE ""EmployeeAccount"".""EmpUser"" = @username", connection);
                    command.Parameters.AddWithValue("@Username", username);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        storedPassword = reader.GetString(0);
                        storedEmpID = reader.GetString(1);
                        storedEmpUser = reader.GetString(2);
                        empType = reader.GetString(3);
                        storedStatus = reader.GetString(4);

                    }
                    reader.Close();


                    if (password.Equals(storedPassword) && storedStatus == "Active")
                    {
                        Session["EmpID"] = storedEmpID;
                        Session["RateeID"] = storedEmpID;
                        Session["AccType"] = empType;


                        if (password.Equals(storedPassword))
                        {
                            Session["EmpID"] = storedEmpID;
                            Session["RateeID"] = storedEmpID;

                            command = new NpgsqlCommand(@"SELECT COUNT(*) FROM CheckSubordinates(@EmpID)", connection);
                            command.Parameters.AddWithValue("@EmpID", storedEmpID);
                            string sessionTemp = Session["AccType"].ToString();
                            subordinateCount = Convert.ToInt32(command.ExecuteScalar());

                            if (subordinateCount == 0)
                            {
                                if (sessionTemp != "Admin")
                                {
                                    Session["AccType"] = "Employee";
                                }
                            }
                            else
                            {
                                Session["AccType"] = "Supervisor";
                            }


                            Session["EmpType"] = empType;
                            Response.Redirect("MyAccount.aspx");
                            //Response.Write($"<script>alert('{Session["AccType"]}')</script>");
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
                        Response.Redirect("MyAccount.aspx");


                    }
                    if (password.Equals(storedPassword) && storedStatus != "Active")
                    {
                        Response.Write("<script>alert('Access denied')</script>");
                    }
                    else if (!password.Equals(storedPassword))
                    {
                        Response.Write("<script>alert('Incorrect Password or Username.')</script>");

                    }
                    else if (reader == null)
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

        protected void ForgetPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ForgetPass.aspx");
        }
    }
}
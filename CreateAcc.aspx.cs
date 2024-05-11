using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1
{
    public partial class CreateAcc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                    {
                        connection.Open();
                        string checkquery = @"SELECT e1.""EmpName"", e1.""EmpID"" FROM ""Employee"" e1 JOIN ""Employee"" e2 ON e1.""EmpID"" = e2.""SupID"" GROUP BY e1.""EmpName"",e1.""EmpID"" ORDER BY e1.""EmpName"";";
                        NpgsqlCommand command = new NpgsqlCommand(checkquery, connection);
                        command.ExecuteNonQuery();
                        NpgsqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ddlEmpSupID.Items.Add(new ListItem(reader.GetString(0), reader.GetString(1)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}')</script>");

                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string newEmpName = empName.Text;
            string newPosition = empPos.Text;
            string newEmpID = empID.Text;
            string newDept = empDept.Text;
            string newEmpType = ddlEmpType.SelectedValue.ToString();
            string newSupID = ddlEmpSupID.SelectedValue.ToString();
            string newEmpUser = empUser.Text;   
            string newEmpPass = empPassword.Text;
            
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    string checkquery = @"INSERT INTO ""Employee"" (""EmpID"", ""EmpName"", ""EmpPos"", ""EmpDept"", ""EmpType"", ""SupID"") VALUES (@empID, @empName, @empPos, @empDept, @empType, @supID);";
                    NpgsqlCommand command = new NpgsqlCommand(checkquery, connection);
                    command.Parameters.AddWithValue("@empID", newEmpID);
                    command.Parameters.AddWithValue("@empName", newEmpName);
                    command.Parameters.AddWithValue("@empPos", newPosition);
                    command.Parameters.AddWithValue("@empDept", newDept);
                    command.Parameters.AddWithValue("@empType", newEmpType);
                    command.Parameters.AddWithValue("@supID", newSupID);
                    command.ExecuteNonQuery();

                    checkquery = @"INSERT INTO ""EmployeeAccount""(""EmpUser"", ""EmpPass"", ""EmpID"", ""Status"")VALUES (@empUser, @empPass, @empID, 'Active');";
                    command = new NpgsqlCommand(checkquery, connection);
                    command.Parameters.AddWithValue("@empUser", newEmpUser);
                    command.Parameters.AddWithValue("@empPass", newEmpPass);
                    command.Parameters.AddWithValue("@empID", newEmpID);
                    command.ExecuteNonQuery();
                    connection.Close();

                    Response.Write("<script>alert('Account added!')</script>");
                }
                Response.Write("<script>location.href = 'MyAccount.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
            
        }

        protected void empID_TextChanged(object sender, EventArgs e)
        {
            int temp = 0; string storedEmpID = "";
            try
            {
                temp = int.Parse(empID.Text);
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    string checkquery = @"SELECT ""EmpID"" FROM ""Employee"" WHERE ""EmpID"" = @empID";
                    NpgsqlCommand command = new NpgsqlCommand(checkquery, connection);
                    command.Parameters.AddWithValue("@empID", temp.ToString());
                    command.ExecuteNonQuery();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0) == false)
                            storedEmpID = reader.GetString(0);
                    }
                    if (temp.ToString().Equals(storedEmpID))
                    {
                        Response.Write("<script>alert('Employee ID is already existing')</script>");
                        empID.Text = "";
                    }
                }
            }
            catch (Exception ex){

                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
            
        }


        protected void empUser_TextChanged(object sender, EventArgs e)
        {
            string storedUser = "";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    string checkquery = @"SELECT ""EmpUser"" FROM ""EmployeeAccount"" WHERE ""EmpUser"" = @EmpUser";
                    NpgsqlCommand command = new NpgsqlCommand(checkquery, connection);
                    command.Parameters.AddWithValue("@empID", empUser.Text);
                    command.ExecuteNonQuery();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0) == false)
                            storedUser = reader.GetString(0);
                    }
                    if (empUser.Text.Equals(storedUser))
                    {
                        Response.Write("<script>alert('Username is already existing')</script>");
                        empID.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
        }

        protected void showPass_CheckedChanged(object sender, EventArgs e)
        {
            string password = empPassword.Text;
            if (showPass.Checked)
            {
                empPassword.Text = password;
                empPassword.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                empPassword.TextMode = TextBoxMode.Password;
                empPassword.Attributes.Add("value", password);
            }
        }
    }
}
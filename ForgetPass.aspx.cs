using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ForgetPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string storedUser = "";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmpUser"" FROM ""EmployeeAccount"" WHERE ""EmpUser"" = @empUser;", connection);
                    command.Parameters.AddWithValue("@empUser", username);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0) == false)
                            storedUser = reader.GetString(0);
                    }
                    if (storedUser != "")
                    {
                        Response.Write("<script>alert('Username exist')</script>");
                        Panel2.Visible = true;
                        SetNew.Attributes.Remove("hidden");
                        newPass.Attributes.Remove("hidden");
                        rfvNewPassword.Visible = true;
                        newPasswordTxt.Visible = true;

                        confirmPass.Attributes.Remove("hidden");
                        rfvConfirmPassword.Visible = true;
                        confirmPasswordTxt.Visible = true;

                        CancelBtn1.Visible = true;
                        SubmitBtn.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Username does not exist')</script>");
                        Disable();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }


        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {

            string username = usernameTxt.Text;
            string storedpass = "";
            string newpass = newPasswordTxt.Text;
            string confirmpass = confirmPasswordTxt.Text;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmpPass"" FROM ""EmployeeAccount"" WHERE ""EmpUser"" = @empUser;", connection);
                    command.Parameters.AddWithValue("@empUser", username);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        storedpass = reader.GetString(0);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }

            if (newpass == confirmpass && newpass != storedpass)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                    {
                        connection.Open();

                        NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""EmployeeAccount"" SET ""EmpPass"" = @empPass WHERE ""EmpUser"" = @empUser;", connection);
                        command.Parameters.AddWithValue("@empPass", newpass);
                        command.Parameters.AddWithValue("@empUser", username);
                        command.ExecuteNonQuery();

                        Response.Write("<script>alert('New password has been set')</script>");
                        connection.Close();

                    }
                    Response.Write("<script>location.href = 'Login.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                }
            }
            else if (newpass == storedpass)
            {

                Response.Write("<script>alert('New Password cannot be the same as previous one')</script>");
                Disable();
            }
            else if (newpass != confirmpass)
            {
                Response.Write("<script>alert('New Password do not match with confirm pass')</script>");
                Disable();
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        public void Disable()
        {
            Panel2.Visible = false;
            rfvNewPassword.Visible = false;
            newPasswordTxt.Text = "";
            newPasswordTxt.Visible = false;

            rfvConfirmPassword.Visible = false;
            confirmPasswordTxt.Visible = false;
            confirmPasswordTxt.Text = "";

            CancelBtn1.Visible = false;
            SubmitBtn.Visible = false;

        }
    }
}
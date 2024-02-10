using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1
{
    public partial class Agreement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack) 
            {
                Initialize();
            }
        }

        protected void Initialize() 
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                int count = 0;
                string status = "To Be Checked";
                string sqlCode = @"SELECT COUNT(*) AS ""count"" FROM ""EmployeePerformance"" WHERE ""Status"" = @Status";
                NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@Status", status);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                reader.Close();
                Response.Write($"<script>alert('{count}')</script>");


                sqlCode = @"SELECT ""FormID"" FROM ""EmployeePerformance"" WHERE ""Status"" = @Status";
                command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@Status", status);

                string[] formIDArr = new string[count];
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int i = 0;
                    formIDArr[i] = reader.GetString(i);
                    i++;
                    Response.Write($"<script>alert('{i}{formIDArr[i]}')</script>");
                }
                reader.Close();
                
                //Button btnOption1 = new Button();
                //btnOption1.ID = "btnOption1";
                //btnOption1.Text = "Option 1";
                //btnOption1.Click += new EventHandler(btnOption_Click);

                //// Add the buttons to the placeholder or any other container
                //buttonContainer.Controls.Add(btnOption1);
                //buttonContainer.Controls.Add(btnOption2);
            }
        }

        protected void StaffClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/AgreementSection1Staff.aspx");
        }
    }
}
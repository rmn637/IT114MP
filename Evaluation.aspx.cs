using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Evaluation : System.Web.UI.Page
    {
        public bool staff1Enable { get { return staff.Enabled; } set { staff.Enabled = value; } }
        public bool staff2Enable { get { return staff2.Enabled; } set { staff2.Enabled = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Initialize();
        }

        protected void Initialize()
        {
            string status = "Approved";
            List<string> formIDList = new List<string>();

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                int count = 0;
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

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string formID = reader.GetString(0);
                    formIDList.Add(formID);
                }
                reader.Close();

            }

            foreach (string formID in formIDList)
            {
                Response.Write($"<script>alert('Form ID: {formID}')</script>");
            }

            staff1Enable = ShowButtons(staff.Text);
            staff2Enable = ShowButtons(staff2.Text);

        }

        protected bool ShowButtons(string name)
        {
            string status = "Approved";
            string formID = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();

                string sqlCode = @"SELECT ""EmployeePerformance"".""FormID"" FROM ""Employee"" INNER JOIN ""EmployeePerformance"" ON ""Employee"".""EmpID"" = ""EmployeePerformance"".""EmpID"" WHERE ""EmpName"" = @EmpName AND ""EmployeePerformance"".""Status"" = @Status";
                NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@EmpName", name);
                command.Parameters.AddWithValue("@Status", status);
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    formID = reader.GetString(0);
                }
                reader.Close();

            }

            if (formID != "")
            {
                return true;
            }
            return false;
        }


        protected void StaffClicked(object sender, EventArgs e)
        {
            Button staff = sender as Button;
            Response.Write($"<script>alert('EmpID:')</script>");

            SetSessionInfo(staff.Text);
            Response.Redirect("~/EvaluationSection1Staff.aspx");
        }

        protected void SetSessionInfo(string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                string storedEmpID = "", storedFormID = "", storedStaffFormID = "";
                string sqlCode = @"SELECT ""Employee"".""EmpID"", ""EmployeePerformance"".""FormID"", ""StaffFormID"" FROM ""Employee"" INNER JOIN ""EmployeePerformance"" ON ""Employee"".""EmpID"" = ""EmployeePerformance"".""EmpID"" INNER JOIN ""StaffForm"" ON ""EmployeePerformance"".""FormID"" = ""StaffForm"".""FormID"" WHERE ""Employee"".""EmpName"" = @empName";
                NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@empName", name);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    storedEmpID = reader.GetString(0);
                    storedFormID = reader.GetString(1);
                    storedStaffFormID = reader.GetString(2);


                    Session["EmpID"] = storedEmpID;
                    Session["FormID"] = storedFormID;
                    Session["StaffFormID"] = storedStaffFormID;
                }
                reader.Close();
                Response.Write($"<script>alert('EmpID:{Session["EmpID"].ToString()}FormID:{Session["FormID"].ToString()}StaffFormID:{Session["StaffFormID"].ToString()}')</script>");

            }
        }
    }
}
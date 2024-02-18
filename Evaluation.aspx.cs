﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Evaluation1 : System.Web.UI.Page
    {
        public bool staff1Enable { get { return staff.Enabled; } set { staff.Enabled = value; } }
        public bool staff2Enable { get { return staff2.Enabled; } set { staff2.Enabled = value; } }
        public bool faculty1Enable { get { return faculty1.Enabled; } set { faculty1.Enabled = value; } }
        public bool faculty2Enable { get { return faculty2.Enabled; } set { faculty2.Enabled = value; } }

        public bool officer1Enable { get { return officer1.Enabled; } set { officer1.Enabled = value; } }
        public bool officer2Enable { get { return officer2.Enabled; } set { officer2.Enabled = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt5class = "active";
            Initialize();
        }

        protected void Initialize()
        {
            string status = "Approved";
            List<string> formIDList = new List<string>();

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
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
            faculty1Enable = ShowButtons(faculty1.Text);
            faculty2Enable = ShowButtons(faculty2.Text);
            officer1Enable = ShowButtons(officer1.Text);
            officer2Enable = ShowButtons(officer2.Text);

        }

        protected bool ShowButtons(string name)
        {
            string status = "Approved";
            string formID = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
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

            SetStaffSessionInfo(staff.Text);
            Response.Redirect("~/EvaluationSection1Staff.aspx");
        }

        protected void SetStaffSessionInfo(string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
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


                    Session["RateeID"] = storedEmpID;
                    Session["FormID"] = storedFormID;
                    Session["StaffFormID"] = storedStaffFormID;
                }
                reader.Close();
                Response.Write($"<script>alert('EmpID:{Session["EmpID"].ToString()}FormID:{Session["FormID"].ToString()}StaffFormID:{Session["StaffFormID"].ToString()}')</script>");

            }
        }

        protected void FacultyClicked(object sender, EventArgs e)
        {
            Button faculty = sender as Button;
            Response.Write($"<script>alert('EmpID:')</script>");

            SetFacultySessionInfo(faculty.Text);
            Response.Redirect("~/EvaluationSection1Faculty.aspx");
        }

        protected void SetFacultySessionInfo(string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                string storedEmpID = "", storedFormID = "", storedFacultyFormID = "";
                string sqlCode = @"SELECT ""Employee"".""EmpID"", ""EmployeePerformance"".""FormID"", ""FacultyFormID"" FROM ""Employee"" INNER JOIN ""EmployeePerformance"" ON ""Employee"".""EmpID"" = ""EmployeePerformance"".""EmpID"" INNER JOIN ""FacultyForm"" ON ""EmployeePerformance"".""FormID"" = ""FacultyForm"".""FormID"" WHERE ""Employee"".""EmpName"" = @empName";
                NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@empName", name);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    storedEmpID = reader.GetString(0);
                    storedFormID = reader.GetString(1);
                    storedFacultyFormID = reader.GetString(2);


                    Session["RateeID"] = storedEmpID;
                    Session["FormID"] = storedFormID;
                    Session["FacultyFormID"] = storedFacultyFormID;
                }
                reader.Close();
                Response.Write($"<script>alert('EmpID:{Session["EmpID"].ToString()}FormID:{Session["FormID"].ToString()}FacultyFormID:{Session["FacultyFormID"].ToString()}')</script>");

            }
        }

        protected void OfficerClicked(object sender, EventArgs e)
        {
            Button officer = sender as Button;
            Response.Write($"<script>alert('EmpID:')</script>");

            SetOfficerSessionInfo(officer.Text);
            Response.Redirect("~/EvaluationSection1Officers.aspx");
        }

        protected void SetOfficerSessionInfo(string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                string storedEmpID = "", storedFormID = "", storedOfficerFormID = "";
                string sqlCode = @"SELECT ""Employee"".""EmpID"", ""EmployeePerformance"".""FormID"", ""OfficerFormID"" FROM ""Employee"" INNER JOIN ""EmployeePerformance"" ON ""Employee"".""EmpID"" = ""EmployeePerformance"".""EmpID"" INNER JOIN ""OfficerForm"" ON ""EmployeePerformance"".""FormID"" = ""OfficerForm"".""FormID"" WHERE ""Employee"".""EmpName"" = @empName";
                NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@empName", name);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    storedEmpID = reader.GetString(0);
                    storedFormID = reader.GetString(1);
                    storedOfficerFormID = reader.GetString(2);


                    Session["RateeID"] = storedEmpID;
                    Session["FormID"] = storedFormID;
                    Session["OfficerFormID"] = storedOfficerFormID;
                }
                reader.Close();
                Response.Write($"<script>alert('EmpID:{Session["EmpID"].ToString()}FormID:{Session["FormID"].ToString()}OfficerFormID:{Session["OfficerFormID"].ToString()}')</script>");

            }
        }
    }
}

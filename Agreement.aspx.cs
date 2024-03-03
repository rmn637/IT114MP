using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Agreement1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt4class = "active";
            Session["AccType"] = "Supervisor";
            Initialize();
            
        }

        protected void Initialize()
        {
            string SQLcmd, storedReportID = "";
            List<string> empIDList = new List<string>();
            NpgsqlCommand command;
            NpgsqlDataReader reader;

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            {
                connection.Open();
                SQLcmd = @"SELECT ""PASubmission"", ""StatusReport"".""EmpID"", ""ReportID"" FROM ""StatusReport"" INNER JOIN ""Employee"" ON ""StatusReport"".""EmpID"" = ""Employee"".""EmpID"" WHERE ""PASubmission"" IS NOT NULL AND ""PAValidation"" = @PAValidation AND ""SupID"" = @SupID";
                command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@SupID", Session["EmpID"].ToString());
                command.Parameters.AddWithValue("@PAValidation","0");

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0) != "0") 
                    {
                        empIDList.Add(reader.GetString(0));
                        storedReportID = reader.GetString(1);
                    }
                    
                }
                reader.Close();
            }
                
            //Session["ReportID"] = storedReportID;


            foreach (string empID in empIDList)
            {
                Response.Write($"<script>alert('Emp ID: {empID}')</script>");
                createTableRow(empID);
            }
        }

        protected void createTableRow(string empID)
        {
            string empName = "", empType = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            {
                connection.Open();
                string sqlCode = @"SELECT ""EmpName"", ""EmpType"" FROM ""Employee"" WHERE ""EmpID"" = @EmpID";
                NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@EmpID", empID);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    empName = reader.GetString(0);
                    empType = reader.GetString(1);
                }
                reader.Close();
                insertAgreementTable(empName, empType);
            }


        }

        protected void insertAgreementTable(string empName, string empType)
        {
            TableRow tr = new TableRow();
            TableCell empNameCell = new TableCell { Text = empName };
            TableCell empTypeCell = new TableCell { Text = empType };
            TableCell empBtnCell = new TableCell { };
            Button empAgreementbtn = new Button { ID = $"{empType}_{empName}", Text = empName };

            if (empType == "Faculty")
            {
                empAgreementbtn.Click += FacultyClicked;
            }
            else if (empType == "Staff")
            {
                empAgreementbtn.Click += StaffClicked;
            }
            else if (empType == "Officer")
            {
                empAgreementbtn.Click += OfficerClicked;
            }

            empBtnCell.Controls.Add(empAgreementbtn);


            tr.Cells.Add(empNameCell);
            tr.Cells.Add(empTypeCell);
            tr.Cells.Add(empBtnCell);

            agreementTable.Rows.Add(tr);
        }

        protected void StaffClicked(object sender, EventArgs e)
        {
            Button staff = sender as Button;

            SetStaffSessionInfo(staff.Text);
            Response.Redirect("~/AgreementSection1Staff.aspx");
        }

        protected void SetStaffSessionInfo(string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
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
                Response.Write($"<script>alert('EmpID:{Session["RateeID"].ToString()}FormID:{Session["FormID"].ToString()}StaffFormID:{Session["StaffFormID"].ToString()}')</script>");

            }
        }
        protected void FacultyClicked(object sender, EventArgs e)
        {
            Button faculty = sender as Button;
            SetFacultySessionInfo(faculty.Text);
            Response.Redirect("~/AgreementSection1Faculty.aspx");
        }

        protected void SetFacultySessionInfo(string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
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
                Response.Write($"<script>alert('EmpID:{Session["RateeID"].ToString()}FormID:{Session["FormID"].ToString()}FacultyFormID:{Session["FacultyFormID"].ToString()}')</script>");

            }
        }
        protected void OfficerClicked(object sender, EventArgs e)
        {
            Button officer = sender as Button;

            SetOfficerSessionInfo(officer.Text);
            Response.Redirect("AgreementSection1Officers.aspx");
        }

        protected void SetOfficerSessionInfo(string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
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
                Response.Write($"<script>alert('EmpID:{Session["RateeID"].ToString()}FormID:{Session["FormID"].ToString()}OfficerFormID:{Session["OfficerFormID"].ToString()}')</script>");

            }
        }
    }
}
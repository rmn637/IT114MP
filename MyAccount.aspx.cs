using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string lblEmpIDText { get { return lblEmpID.Text; } set { lblEmpID.Text = value; } }
        public string lblEmpNameText { get { return lblEmpName.Text; } set { lblEmpName.Text = value; } }
        public string lblEmpDeptText { get { return lblEmpDept.Text; } set { lblEmpDept.Text = value; } }
        public string lblEmpPosText { get { return lblEmpPos.Text; } set { lblEmpPos.Text = value; } }
        public string lblEmpSupervisorText { get { return lblEmpSupervisor.Text; } set { lblEmpSupervisor.Text = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt1class = "active";
            string storedEmpID = Session["EmpID"].ToString();
            string storedEmpName = "", storedEmpPos = "", storedEmpDept = "", storedEmpSupervisor = "";
            try
            {
                // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();
                    //NpgsqlCommand command = new NpgsqlCommand(@"SELECT * FROM ""Employee"" INNER JOIN ""EmployeeAccount"" ON ""Employee"".""EmpID"" = ""EmployeeAccount"".""EmpID"" WHERE ""Employee"".""EmpID"" = @empID", connection);
                    //command.Parameters.AddWithValue("@empID", storedEmpID);

                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT * FROM ""Employee"" WHERE ""Employee"".""EmpID"" = @empID", connection);
                    command.Parameters.AddWithValue("@empID", storedEmpID);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        storedEmpName = reader.GetString(1);
                        storedEmpPos = reader.GetString(2);
                        storedEmpDept = reader.GetString(3);
                        storedEmpSupervisor = reader.GetString(5);
                    }
                    reader.Close();

                    lblEmpIDText = "Employee ID: " + storedEmpID;
                    lblEmpNameText = "Employee Name: " + storedEmpName;
                    lblEmpDeptText = "Employee Department: " + storedEmpDept;
                    lblEmpPosText = "Employee Position: " + storedEmpPos;
                    lblEmpSupervisorText = "Employee Supervisor: " + storedEmpSupervisor;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}
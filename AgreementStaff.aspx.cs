using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void EvaluateBtn_Click(object sender, EventArgs e)
        {
            string sqlCode, storedSupID = "";
            string storedEmpID = Session["EmpID"].ToString();
            try
            {
                // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();
                    
                    // GETTING SUP ID TO PUT INTO EMP PERF
                    sqlCode = @"SELECT ""SupID"" FROM ""Employee"" WHERE ""Employee"".""EmpID"" = @empID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@EmpID", storedEmpID);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        storedSupID = reader.GetString(0);
                    }
                    reader.Close();

                    // INSERTING A ROW INTO EMP PERF TABLE
                    sqlCode = @"SELECT COUNT(*) FROM ""EmployeePerformance""";
                    command = new NpgsqlCommand(sqlCode, connection); 

                    object result = command.ExecuteScalar(); ;
                    int rowCount = Convert.ToInt32(result);
                    int intFormID = 200000000 + rowCount + 1;
                    string formID = intFormID.ToString();
                    Session["FormID"] = formID;

                    sqlCode = @"INSERT INTO ""EmployeePerformance"" (""FormID"", ""EmpID"", ""SupID"", ""PerfPts"") VALUES (@FormID , @EmpID , @SupID , 0)";
                    command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@FormID", formID);
                    command.Parameters.AddWithValue("@EmpID", storedEmpID);
                    command.Parameters.AddWithValue("@SupID", storedSupID);
                    command.ExecuteNonQuery();

                    
                    // INSERTING A ROW INTO STAFF FORM TABLE
                    sqlCode = @"SELECT COUNT(*) FROM ""StaffForm""";
                    command = new NpgsqlCommand(sqlCode, connection);
                    result = command.ExecuteScalar(); ;
                    rowCount = Convert.ToInt32(result);
                    int intStaffFormID = 300000000 + rowCount + 1;
                    string StaffFormID = intStaffFormID.ToString();
                    Session["StaffFormID"] = StaffFormID;

                    sqlCode = @"INSERT INTO ""StaffForm"" (""StaffFormID"" , ""FormID"", ""Section1CWR"", ""Section2CWR"", ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"") VALUES (@StaffFormID, @FormID , 0, 0, 0, 0, 0, 0)";
                    command = new NpgsqlCommand(sqlCode, connection);

                    command.Parameters.AddWithValue("@StaffFormID", StaffFormID);
                    command.Parameters.AddWithValue("@FormID", formID);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
            Response.Redirect("AgreementSection1Staff.aspx");
        }
    }
}
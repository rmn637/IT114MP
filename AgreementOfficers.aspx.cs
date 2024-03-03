using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementOfficers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt2class = "active"; Page.MaintainScrollPositionOnPostBack = true;
            Page.MaintainScrollPositionOnPostBack = true;

            string sqlCode, storedFormID = "", PAVal = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();

                sqlCode = @"SELECT ""FormID"", ""PAValidation"" FROM ""EmployeePerformance"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""EmployeePerformance"".""EmpID"" = @empID";
                NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@EmpID", Session["RateeID"].ToString());
                NpgsqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    Response.Write("<script>alert('No matching entry found for the provided RateeID')</script>");
                    return;
                }

                while (reader.Read())
                {
                    storedFormID = reader.GetString(0);
                    PAVal = reader.GetString(1);
                }
                reader.Close();

                bool PAValDone = PAVal != "0" && PAVal != null;
                Session["PAValDone"] = PAValDone.ToString();

                Response.Write($"<script>alert('Error: {PAValDone} and {PAVal}')</script>");
                sqlCode = @"SELECT ""OfficerFormID"" FROM ""OfficerForm"" WHERE ""FormID"" = @FormID";
                command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@FormID", storedFormID);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Session["OfficerFormID"] = reader.GetString(0);
                }
                reader.Close();
                Response.Redirect("AgreementSection1Officers.aspx");

            }
        }

        protected void EvaluateBtn_Click(object sender, EventArgs e)
        {
            string sqlCode, storedSupID = "";
            string storedEmpID = Session["RateeID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
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
                    int intFormID = 2000000000 + rowCount + 1;
                    string formID = intFormID.ToString();
                    string status = "In Progress";
                    Session["FormID"] = formID;

                    sqlCode = @"INSERT INTO ""EmployeePerformance"" VALUES (@FormID , @EmpID , @SupID , 0)";
                    command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@FormID", formID);
                    command.Parameters.AddWithValue("@EmpID", storedEmpID);
                    command.Parameters.AddWithValue("@SupID", storedSupID);
                    command.ExecuteNonQuery();


                    // INSERTING A ROW INTO STAFF FORM TABLE
                    sqlCode = @"SELECT COUNT(*) FROM ""OfficerForm""";
                    command = new NpgsqlCommand(sqlCode, connection);
                    result = command.ExecuteScalar();
                    rowCount = Convert.ToInt32(result);
                    long intOfficersFormID = 5000000000 + rowCount + 1;
                    string OfficersFormID = intOfficersFormID.ToString();
                    Session["OfficerFormID"] = OfficersFormID;

                    sqlCode = @"INSERT INTO ""OfficerForm"" VALUES (@OfficerFormID, @FormID, 0, 0, 0, 0, 0, 0, 0, 0)";
                    command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@OfficerFormID", OfficersFormID);
                    command.Parameters.AddWithValue("@FormID", formID);
                    command.ExecuteNonQuery();

                    sqlCode = @"SELECT COUNT(*) FROM ""StatusReport""";
                    command = new NpgsqlCommand(sqlCode, connection);
                    result = command.ExecuteScalar();
                    rowCount = Convert.ToInt32(result);
                    long intReportID = 6000000000 + rowCount + 1;
                    string ReportID = intReportID.ToString();
                    Session["ReportID"] = ReportID;

                    sqlCode = @"INSERT INTO ""StatusReport"" VALUES (@ReportID, @EmpID, 0, 0, 0, 0)";
                    command = new NpgsqlCommand(sqlCode, connection);

                    command.Parameters.AddWithValue("@ReportID", ReportID);
                    command.Parameters.AddWithValue("@EmpID", storedEmpID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
            Response.Redirect("AgreementSection1Officers.aspx");
        }
    }
}
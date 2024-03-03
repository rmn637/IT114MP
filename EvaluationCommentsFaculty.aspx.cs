using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationCommentsFaculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
                Initialize();

            if (Session["AccType"].ToString() == "Supervisor")
            {
                strength.Enabled = true;
                improvement.Enabled = true;
                development.Enabled = true;
                acknowledgement.Enabled = true;
            }
        }
        protected void Initialize()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            {
                connection.Open();
                string SQLcmd = @"SELECT ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"", ""ReportID"" FROM ""FacultyForm"" INNER JOIN ""EmployeePerformance"" ON ""FacultyForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""FacultyFormID"" = @FacultyFormID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@FacultyFormID", Session["FacultyFormID"].ToString());

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0) != "0")
                        strength.Text = reader.GetString(0);
                    if (reader.GetString(1) != "0")
                        improvement.Text = reader.GetString(1);
                    if (reader.GetString(2) != "0")
                        development.Text = reader.GetString(2);
                    if (reader.GetString(3) != "0")
                        acknowledgement.Text = reader.GetString(3);
                    //Session["ReportID"] = reader.GetString(4);
                }
                reader.Close();
            }
            Session["RateeID"] = Session["EmpID"].ToString();

        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            UpdateCWR();
            if (link.ID == "btnSection1")
                Response.Redirect("~/EvaluationSection1Faculty.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/EvaluationSection2Faculty.aspx");
            else if (link.ID == "btnSection3")
                Response.Redirect("~/EvaluationCommentsFaculty.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/EvaluationOverallFaculty.aspx");
        }
        protected void UpdateCWR()
        {
            string storedFacultyFormID = Session["FacultyFormID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""FacultyForm"" SET ""Strength"" = @Strength, ""Improvement"" = @Improvement, ""Development"" = @Development, ""Acknowledgement"" = @Acknowledgement WHERE ""FacultyFormID"" = @FacultyFormID", connection);
                    command.Parameters.AddWithValue("@Strength", strength.Text);
                    command.Parameters.AddWithValue("@Improvement", improvement.Text);
                    command.Parameters.AddWithValue("@Development", development.Text);
                    command.Parameters.AddWithValue("@Acknowledgement", acknowledgement.Text);
                    command.Parameters.AddWithValue("@FacultyFormID", storedFacultyFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
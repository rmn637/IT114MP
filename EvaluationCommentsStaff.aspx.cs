using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class EvaluationCommentsStaff : System.Web.UI.Page
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
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                string SQLcmd = @"SELECT ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"", ""ReportID"" FROM ""StaffForm"" INNER JOIN ""EmployeePerformance"" ON ""StaffForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""StaffFormID"" = @StaffFormID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@StaffFormID", Session["StaffFormID"].ToString());

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
            if (!bool.Parse(Session["PEValDone"].ToString()))
                UpdateCWR();

            if (link.ID == "btnSection1")
                Response.Redirect("~/EvaluationSection1Staff.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/EvaluationSection2Staff.aspx");
            else if (link.ID == "btnSection3")
                Response.Redirect("~/EvaluationCommentsStaff.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/EvaluationOverallStaff.aspx");
        }
        protected void UpdateCWR()
        {
            string storedStaffFormID = Session["StaffFormID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""StaffForm"" SET ""Strength"" = @Strength, ""Improvement"" = @Improvement, ""Development"" = @Development, ""Acknowledgement"" = @Acknowledgement WHERE ""StaffFormID"" = @StaffFormID", connection);
                    command.Parameters.AddWithValue("@Strength", strength.Text);
                    command.Parameters.AddWithValue("@Improvement", improvement.Text);
                    command.Parameters.AddWithValue("@Development", development.Text);
                    command.Parameters.AddWithValue("@Acknowledgement", acknowledgement.Text);
                    command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
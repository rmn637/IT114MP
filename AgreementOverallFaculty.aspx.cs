using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementOverallFaculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            Initialize();
        }
        protected void Initialize()
        {
            string SQLcmd, CWR1 = "", CWR2 = "", alert = "", PAVal = "";
            bool sec1Done, sec2Done, PAValDone;

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            {
                connection.Open();
                SQLcmd = @"SELECT ""Section1CWR"", ""Section2CWR"", ""ReportID"", ""PAValidation"" FROM ""FacultyForm"" INNER JOIN ""EmployeePerformance"" ON ""FacultyForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""FacultyFormID"" = @FacultyFormID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@FacultyFormID", Session["FacultyFormID"].ToString());

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CWR1 = reader.GetString(0);
                    CWR2 = reader.GetString(1);
                    //Session["ReportID"] = reader.GetString(2);
                    PAVal = reader.GetString(3);
                }
                reader.Close();
            }

            PAValDone = PAVal != "0" && PAVal != null;
            sec1Done = GetTotalWeight(CWR1) == 200;
            sec2Done = GetTotalWeight(CWR2) == 100;

            if (sec1Done == false && sec2Done == false)
                alert = "Sections 1, and 2 are incomplete.";
            else if (sec1Done == true && sec2Done == false)
                alert = "Section 2 is incomplete.";
            else if (sec1Done == false && sec2Done == true)
                alert = "Section 1 is incomplete.";

            //Response.Write($"<script>alert('{alert}')</script>");

            //Session["PAValDone"] = PAValDone.ToString();
            Submit.Enabled = alert == "" && !PAValDone;
            Submit.Visible = !PAValDone;
                
        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (!bool.Parse(Session["PAValDone"].ToString()))
                UpdateCWR();

            if (link.ID == "btnSection1")
                Response.Redirect("~/AgreementSection1Faculty.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/AgreementSection2Faculty.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/AgreementOverallFaculty.aspx");
        }

        protected void UpdateCWR()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            {
                connection.Open();
                string SQLcmnd = @"UPDATE ""FacultyForm"" SET ""OverallWR"" = @OverallWR WHERE ""FacultyFormID"" = @FacultyFormID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmnd, connection);
                command.Parameters.AddWithValue("@OverallWR", CompileAnswers());
                command.Parameters.AddWithValue("@FacultyFormID", Session["FacultyFormID"].ToString());
                command.ExecuteNonQuery();
            }
        }
        protected string CompileAnswers()
        {
            return $"1,{weight1_1.Text},0;"+
                $"2,{weight1_2.Text},0;"+
                $"1,{weight1_3.Text},0";
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            string field, SQLcmd;

            UpdateCWR();

            if (Session["AccType"].ToString() == "Supervisor")
                field = "PAValidation";
            else
                field = "PASubmission";

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            {
                connection.Open();
                SQLcmd = $@"UPDATE ""StatusReport"" SET ""{field}"" = @Time WHERE ""ReportID"" = @ReportID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@Time", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@ReportID", Session["ReportID"].ToString());
                command.ExecuteNonQuery();
            }
            Response.Redirect("MyAccount.aspx");

        }
        protected int GetTotalWeight(string text)
        {
            if (text != "0")
            {
                string[] textArr = text.Split(';'), textArr2;
                int weight = 0;         

                for (int i = 0; i < textArr.Length; i++)
                {
                    textArr2 = textArr[i].Split(',');
                    weight += int.Parse(textArr2[1]);
                }
                return weight;
            }
            return 0;
        }
    }
}
using Npgsql;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class EvaluationOverallFaculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
                Initialize();
        }
        protected void Initialize()
        {
            bool sec1Done, sec2Done, sec3Done;
            string SQLcmd, CWR1 = "", CWR2 = "", PEVal = "", strComment = "", impComment = "", devComment = "", ackComment = "", alert = "";

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            {
                connection.Open();
                SQLcmd = @"SELECT ""Section1CWR"", ""Section2CWR"", ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"", ""ReportID"", ""PEValidation"" FROM ""FacultyForm"" INNER JOIN ""EmployeePerformance"" ON ""FacultyForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""FacultyFormID"" = @FacultyFormID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@FacultyFormID", Session["FacultyFormID"].ToString());

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CWR1 = reader.GetString(0);
                    CWR2 = reader.GetString(1);
                    strComment = reader.GetString(2);
                    impComment = reader.GetString(3);
                    devComment = reader.GetString(4);
                    ackComment = reader.GetString(5);
                    Session["ReportID"] = reader.GetString(6);
                    PEVal = reader.GetString(7);
                }
                reader.Close();
            }

            bool PEValDone = PEVal != "0" && PEVal != null;
            Session["PEValDone"] = PEValDone.ToString();
            Submit.Visible = !PEValDone;

            string[] splitTotals = ComputeSectionABTotals(CWR1).Split(';');
            labelTotal1.Text = (double.Parse(splitTotals[0]) * .5 + double.Parse(splitTotals[1]) * .2 + double.Parse(ComputeSectionTotals(CWR2)) * .3).ToString("0.00");

            sec1Done = CheckSection(CWR1);
            sec2Done = CheckSection(CWR2);

            if (Session["AccType"].ToString() == "Supervisor")
                sec3Done = CheckComments(strComment, impComment, devComment, ackComment);
            else
                sec3Done = true;

            if (!sec1Done && !sec2Done && !sec3Done)
                alert = "Sections 1, 2, and 3 are incomplete.";
            else if (!sec1Done && !sec2Done && sec3Done)
                alert = "Sections 1 and 2 are incomplete.";
            else if (!sec1Done && sec2Done && !sec3Done)
                alert = "Sections 1 and 3 are incomplete.";
            else if (sec1Done && !sec2Done && !sec3Done)
                alert = "Sections 2 and 3 are incomplete.";
            else if (!sec1Done && sec2Done && sec3Done)
                alert = "Section 1 is incomplete.";
            else if (sec1Done && !sec2Done && sec3Done)
                alert = "Section 2 is incomplete.";
            else if (sec1Done && sec2Done && !sec3Done)
                alert = "Section 3 is incomplete.";

            if (alert != "") 
                Response.Write($"<script>alert('{alert}')</script>");
            else
                Submit.Enabled = !PEValDone;
            
        }

        protected string ComputeSectionTotals(string CWR)
        {
            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                string[] CWRArr2;
                double[] weightArr = new double[8];
                double[] ratingArr = new double[8];

                for (int i = 0; i < CWRArr.Length; i++)
                {
                    CWRArr2 = CWRArr[i].Split(',');
                    weightArr[i] = double.Parse(CWRArr2[1]);
                    ratingArr[i] = double.Parse(CWRArr2[2]);
                }

                double total = 0;

                for (int i = 0; i < weightArr.Length; i++)
                {
                    total += weightArr[i] * ratingArr[i] * .2;
                }
                total3.Text = total.ToString();
                return total.ToString();
            }
            return "0";
        }
        protected string ComputeSectionABTotals(string CWR)
        {
            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                string[] CWRArr2;
                double[] weightArr = new double[8];
                double[] ratingArr = new double[8];

                for (int i = 0; i < CWRArr.Length; i++)
                {
                    CWRArr2 = CWRArr[i].Split(',');
                    weightArr[i] = double.Parse(CWRArr2[1]);
                    ratingArr[i] = double.Parse(CWRArr2[2]);
                }

                double totalA = 0, totalB = 0;

                for (int i = 0; i < 3; i++)
                {
                    totalA += weightArr[i] * ratingArr[i] * .2;
                }

                for (int i = 3; i < 8; i++)
                {
                    totalB += weightArr[i] * ratingArr[i] * .2;
                }

                total1.Text = totalA.ToString();
                total2.Text = totalB.ToString();
                string totals = totalA.ToString() + ";" + totalB.ToString();

                return totals.ToString();
            }
            return "0";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string field;

            if (Session["AccType"].ToString() == "Supervisor")
                field = "PEValidation";
            else
                field = "PESubmission";

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            {
                connection.Open();
                string SQLcmd = $@"UPDATE ""StatusReport"" SET ""{field}"" = @Time WHERE ""ReportID"" = @ReportID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@Time", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@ReportID", Session["ReportID"].ToString());
                command.ExecuteNonQuery();
            }
            UpdateEmpPerf();
            Response.Redirect("MyAccount.aspx");
            
        }

        protected bool CheckSection(string CWR) 
        {
            string[] CWRArr = CWR.Split(';');
            string[] CWRArr2;

            for (int i = 0; i < CWRArr.Length; i++)
            {
                CWRArr2 = CWRArr[i].Split(',');
                if (CWRArr2[2] == "0") 
                    return false;
            }
            return true;
        }
        protected bool CheckComments(string com1, string com2, string com3, string com4)
        {
            if (com1 == "" || com2 == "" || com3 == "" || com4 == "")
                return false;
            return true;
        }

        protected void UpdateEmpPerf()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""EmployeePerformance"" SET ""PerfPts"" = @PerfPts, WHERE ""FormID"" = @FormID", connection);
                    command.Parameters.AddWithValue("@PerfPts", labelTotal1.Text);
                    command.Parameters.AddWithValue("@FormID", Session["FormID"].ToString());
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            UpdateEmpPerf();
            if (link.ID == "btnSection1")
                Response.Redirect("~/EvaluationSection1Faculty.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/EvaluationSection2Faculty.aspx");
            else if (link.ID == "btnSection3")
                Response.Redirect("~/EvaluationCommentsFaculty.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/EvaluationOverallFaculty.aspx");
        }
    }
}
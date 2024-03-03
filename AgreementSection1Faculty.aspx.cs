using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace WebApplication1
{
    public partial class AgreementSection1Faculty : System.Web.UI.Page
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
            string SQLcmd, CWR = "", PAVal = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                SQLcmd = @"SELECT ""Section1CWR"", ""ReportID"", ""PAValidation"" FROM ""FacultyForm"" INNER JOIN ""EmployeePerformance"" ON ""FacultyForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""FacultyFormID"" = @FacultyFormID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@FacultyFormID", Session["FacultyFormID"].ToString());

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CWR = reader.GetString(0);
                    Session["ReportID"] = reader.GetString(1);
                    PAVal = reader.GetString(2);
                }
                reader.Close();
            }

            List<TextBox> weightTextBoxes = new List<TextBox> {
                        weight1_A,
                        weight1_B,
                        weight1_C,
                        weight1_1,
                        weight1_2,
                        weight1_3,
                        weight1_4,
                        weight1_5
                };

            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                for (int i = 0; i < CWRArr.Length; i++)
                {
                    string[] CWRValues = CWRArr[i].Split(',');
                    weightTextBoxes[i].Text = CWRValues[1];
                }
            }
            ComputeTotalWeight();

            bool PAValDone = PAVal != "0" && PAVal != null;
            Session["PAValDone"] = PAValDone.ToString();
            foreach (var item in weightTextBoxes)
            {
                item.Enabled = !PAValDone;
            }

        }
        protected void weight_TextChanged(object sender, EventArgs e)
        {
            TextBox weight = sender as TextBox;
            try
            {
                if (double.Parse(weight.Text) > 100)
                    weight.Text = "100";
                else if (double.Parse(weight.Text) < 0)
                    weight.Text = "0";
                ComputeTotalWeight();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
                weight.Text = "0";
            }
        }

        protected void ComputeTotalWeight()
        {
            double weight1, weight2, weight3, weight4, weight5, weightA, weightB, weightC, total;
            weight1 = double.Parse(weight1_1.Text);
            weight2 = double.Parse(weight1_2.Text);
            weight3 = double.Parse(weight1_3.Text);
            weight4 = double.Parse(weight1_4.Text);
            weight5 = double.Parse(weight1_5.Text);
            weightA = double.Parse(weight1_A.Text);
            weightB = double.Parse(weight1_B.Text);
            weightC = double.Parse(weight1_C.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal1B.Text = total.ToString("0.00");
            total = 0 + weightA + weightB + weightC;
            labelTotal1A.Text = total.ToString("0.00");

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
            else if (link.ID == "btnSection3")
                Response.Redirect("~/AgreementCommentsFaculty.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/AgreementOverallFaculty.aspx");

        }

        protected string CompileAnswers()
        {
            return $"A,{weight1_A.Text},0;" +
                $"B,{weight1_B.Text},0;" +
                $"C,{weight1_C.Text},0;" +
                $"1,{weight1_1.Text},0;" +
                $"2,{weight1_2.Text},0;" +
                $"3,{weight1_3.Text},0;" +
                $"4,{weight1_4.Text},0;" +
                $"5,{weight1_5.Text},0";
        }

        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedFacultyFormID = Session["FacultyFormID"].ToString();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""FacultyForm"" SET ""Section1CWR"" = @Section1CWR WHERE ""FacultyFormID"" = @FacultyFormID", connection);
                    command.Parameters.AddWithValue("@Section1CWR", compiledCWR);
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
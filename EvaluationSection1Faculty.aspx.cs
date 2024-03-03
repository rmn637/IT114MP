using Microsoft.SqlServer.Server;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class EvaluationSection1Faculty : System.Web.UI.Page
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
            string CWR = "", SQLcmd, PEVal = "";
            string storedAccType = Session["AccType"].ToString();
            NpgsqlCommand command;
            NpgsqlDataReader reader;

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            {
                connection.Open();
                if (storedAccType == "Supervisor")
                {
                    SQLcmd = @"SELECT ""Section1CWR"", ""ReportID"", ""PEValidation"" FROM ""FacultyForm"" INNER JOIN ""EmployeePerformance"" ON ""FacultyForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""FacultyFormID"" = @FacultyFormID";
                    command = new NpgsqlCommand(SQLcmd, connection);
                    command.Parameters.AddWithValue("@FacultyFormID", Session["FacultyFormID"].ToString());
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CWR = reader.GetString(0);
                        Session["ReportID"] = reader.GetString(1);
                        PEVal = reader.GetString(2);
                    }
                    reader.Close();
                }
                else 
                {
                    SQLcmd = @"SELECT ""EmployeePerformance"".""FormID"", ""FacultyFormID"", ""Section1CWR"", ""ReportID"", ""PEValidation"" FROM ""FacultyForm"" INNER JOIN ""EmployeePerformance"" ON ""FacultyForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""EmployeePerformance"".""EmpID"" = @EmpID";
                    command = new NpgsqlCommand(SQLcmd, connection);
                    command.Parameters.AddWithValue("@EmpID", Session["EmpID"].ToString());

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Session["FormID"] = reader.GetString(0);
                        Session["FacultyFormID"] = reader.GetString(1);
                        CWR = reader.GetString(2);
                        Session["ReportID"] = reader.GetString(3);
                        PEVal = reader.GetString(4);
                    }
                    reader.Close();

                    Session["RateeID"] = Session["EmpID"].ToString();

                    List<TextBox> ratingTextBoxes = new List<TextBox> {
                            rating1_A,
                            rating1_B,
                            rating1_C,
                            rating1_1,
                            rating1_2,
                            rating1_3,
                            rating1_4,
                            rating1_5 
                    };
                    bool PEValDone = PEVal != "0" && PEVal != null;
                    Session["PEValDone"] = PEValDone.ToString();
                    foreach (var item in ratingTextBoxes)
                    {
                        item.Enabled = !PEValDone;
                    }
                }   
            }

            List<Label> weightLabels = new List<Label> { weight1_A, weight1_B, weight1_C, weight1_1, weight1_2, weight1_3, weight1_4, weight1_5 };
            List<TextBox> rateTextboxes = new List<TextBox> { rating1_A, rating1_B, rating1_C, rating1_1, rating1_2, rating1_3, rating1_4, rating1_5 };
            List<Label> scoreLabels= new List<Label> { label1_A, label1_B, label1_C, label1_1, label1_2, label1_3, label1_4, label1_5 };

            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                for (int i = 0; i < CWRArr.Length; i++)
                {
                    string[] CWRValues = CWRArr[i].Split(',');
                    weightLabels[i].Text = CWRValues[1];
                    rateTextboxes[i].Text = CWRValues[2];
                    scoreLabels[i].Text = (double.Parse(CWRValues[1]) * double.Parse(CWRValues[2]) * 0.2).ToString("0.00");
                }
            }
            computeTotal1A();
            computeTotal1B();
        }

        protected void rating1A_TextChanged(object sender, EventArgs e)
        {
            List<Label> weightLabels = new List<Label> { weight1_A, weight1_B, weight1_C };
            List<TextBox> rateTextboxes = new List<TextBox> { rating1_A, rating1_B, rating1_C };
            List<Label> scoreLabels = new List<Label> { label1_A, label1_B, label1_C };

            TextBox rating = sender as TextBox;
            try
            {
                for (int i = 0; i < rateTextboxes.Count; i++)
                {
                    if (rating.ID == rateTextboxes[i].ID)
                    {
                        if (double.Parse(rateTextboxes[i].Text) > 5)
                            rateTextboxes[i].Text = "5";
                        else if (double.Parse(rateTextboxes[i].Text) < 0)
                            rateTextboxes[i].Text = "0";
                        scoreLabels[i].Text = (double.Parse(rateTextboxes[i].Text) * double.Parse(weightLabels[i].Text) * 0.2).ToString("0.00");
                        computeTotal1A();
                        return;
                    }
                }
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
                rating.Text = "0";
            }
        }
        protected void computeTotal1A()
        {
            labelTotal1A.Text = (double.Parse(label1_A.Text) + double.Parse(label1_B.Text) + double.Parse(label1_C.Text)).ToString("0.00");
        }

        protected void rating1B_TextChanged(object sender, EventArgs e)
        {
            List<Label> weightLabels = new List<Label> { weight1_1, weight1_2, weight1_3, weight1_4, weight1_5 };
            List<TextBox> rateTextboxes = new List<TextBox> { rating1_1, rating1_2, rating1_3, rating1_4, rating1_5 };
            List<Label> scoreLabels = new List<Label> { label1_1, label1_2, label1_3, label1_4, label1_5 };

            try
            {
                TextBox rating = sender as TextBox;

                for (int i = 0; i < rateTextboxes.Count; i++)
                {
                    if (rating.ID == rateTextboxes[i].ID)
                    {
                        if (double.Parse(rateTextboxes[i].Text) > 5)
                            rateTextboxes[i].Text = "5";
                        else if (double.Parse(rateTextboxes[i].Text) < 0)
                            rateTextboxes[i].Text = "0";
                        scoreLabels[i].Text = (double.Parse(rateTextboxes[i].Text) * double.Parse(weightLabels[i].Text) * 0.2).ToString("0.00");
                        computeTotal1B();
                        return;
                    }
                }
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void computeTotal1B()
        {
            labelTotal1B.Text = (double.Parse(label1_1.Text) + double.Parse(label1_2.Text) + double.Parse(label1_3.Text) + double.Parse(label1_4.Text) + double.Parse(label1_5.Text)).ToString("0.00");
        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (!bool.Parse(Session["PEValDone"].ToString()))
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
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""FacultyForm"" SET ""Section1CWR"" = @Section1CWR WHERE ""FacultyFormID"" = @FacultyFormID", connection);
                    command.Parameters.AddWithValue("@Section1CWR", CompileAnswers());
                    command.Parameters.AddWithValue("@FacultyFormID", Session["FacultyFormID"].ToString());
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected string CompileAnswers()
        {
            return $"A,{weight1_A.Text},{rating1_A.Text};"+
                $"B,{weight1_B.Text},{rating1_B.Text};"+
                $"C,{weight1_C.Text},{rating1_C.Text};"+
                $"1,{weight1_1.Text},{rating1_1.Text};"+
                $"2,{weight1_2.Text},{rating1_2.Text};"+
                $"3,{weight1_3.Text},{rating1_3.Text};"+
                $"4,{weight1_4.Text},{rating1_4.Text};"+
                $"5,{weight1_5.Text},{rating1_5.Text}";
        }
    }
}
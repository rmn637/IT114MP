using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationSection2Staff : System.Web.UI.Page
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

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();

                if (storedAccType == "Supervisor")
                {
                    SQLcmd = @"SELECT ""Section2CWR"", ""ReportID"", ""PEValidation"" FROM ""StaffForm"" INNER JOIN ""EmployeePerformance"" ON ""StaffForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""StaffFormID"" = @StaffFormID";
                    command = new NpgsqlCommand(SQLcmd, connection);
                    command.Parameters.AddWithValue("@StaffFormID", Session["StaffFormID"].ToString());
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CWR = reader.GetString(0);
                        //Session["ReportID"] = reader.GetString(1);
                        PEVal = reader.GetString(2);
                    }
                    reader.Close();
                }
                else
                {
                    SQLcmd = @"SELECT ""EmployeePerformance"".""FormID"", ""StaffFormID"", ""Section2CWR"", ""ReportID"", ""PEValidation"" FROM ""StaffForm"" INNER JOIN ""EmployeePerformance"" ON ""StaffForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""EmployeePerformance"".""EmpID"" = @EmpID";
                    command = new NpgsqlCommand(SQLcmd, connection);
                    command.Parameters.AddWithValue("@EmpID", Session["EmpID"].ToString());

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //Session["FormID"] = reader.GetString(0);
                        //Session["StaffFormID"] = reader.GetString(1);
                        CWR = reader.GetString(2);
                        //Session["ReportID"] = reader.GetString(3);
                        PEVal = reader.GetString(4);
                    }
                    reader.Close();

                    //Session["RateeID"] = Session["EmpID"].ToString();

                    List<TextBox> weightTextBoxes = new List<TextBox> {
                        rating2_1,
                        rating2_2,
                        rating2_3,
                        rating2_4,
                        rating2_5,
                    };

                    bool PEValDone = PEVal != "0" && PEVal != null;
                    //Session["PEValDone"] = PEValDone.ToString();
                    foreach (var item in weightTextBoxes)
                    {
                        item.Enabled = !PEValDone;
                    }
                }
            }

            List<Label> weightLabels = new List<Label> { weight2_1, weight2_2, weight2_3, weight2_4, weight2_5 };
            List<TextBox> rateTextboxes = new List<TextBox> { rating2_1, rating2_2, rating2_3, rating2_4, rating2_5 };
            List<Label> scoreLabels = new List<Label> { label2_1, label2_2, label2_3, label2_4, label2_5 };

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
            computeTotalScore();
        }

        protected void rating2_TextChanged(object sender, EventArgs e)
        {
            List<Label> weightLabels = new List<Label> { weight2_1, weight2_2, weight2_3, weight2_4, weight2_5 };
            List<TextBox> rateTextboxes = new List<TextBox> { rating2_1, rating2_2, rating2_3, rating2_4, rating2_5 };
            List<Label> scoreLabels = new List<Label> { label2_1, label2_2, label2_3, label2_4, label2_5 };

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
                        computeTotalScore();
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

        protected void computeTotalScore()
        {
            labelTotal2.Text = (double.Parse(label2_1.Text) + double.Parse(label2_2.Text) + double.Parse(label2_3.Text) + double.Parse(label2_4.Text) + double.Parse(label2_5.Text)).ToString("0.00");
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
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""StaffForm"" SET ""Section2CWR"" = @Section2CWR WHERE ""StaffFormID"" = @StaffFormID", connection);
                    command.Parameters.AddWithValue("@Section2CWR", CompileAnswers());
                    command.Parameters.AddWithValue("@StaffFormID", Session["StaffFormID"].ToString());
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected string CompileAnswers()
        {
            return $"1,{weight2_1.Text},{rating2_1.Text};" +
            $"2,{weight2_2.Text},{rating2_2.Text};" +
            $"3,{weight2_3.Text},{rating2_3.Text};" +
            $"4,{weight2_4.Text},{rating2_4.Text};" +
            $"5,{weight2_5.Text},{rating2_5.Text}";
        }
    }
}
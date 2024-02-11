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
            {
                Initialize();
            }
            
        }

        protected void Initialize()
        {
            string CWR = "";

            if (!IsPostBack)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();
                    string storedStaffFormID = Session["StaffFormID"].ToString();

                    string sqlCode = @"SELECT ""Section2CWR"" FROM ""StaffForm"" WHERE ""StaffFormID"" = @StaffFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CWR = reader.GetString(0);
                    }
                    reader.Close();

                    if (CWR != "0")
                    {
                        string[] CWRArr = CWR.Split(';');
                        string[] CWRArr2 = new string[3];
                        string[] weightArr = new string[8];
                        string[] ratingArr = new string[8];

                        for (int i = 0; i < CWRArr.Length; i++)
                        {
                            CWRArr2 = CWRArr[i].Split(',');
                            weightArr[i] = CWRArr2[1];
                            ratingArr[i] = CWRArr2[2];
                        }

                        weight2_1.Text = weightArr[0];
                        weight2_2.Text = weightArr[1];
                        weight2_3.Text = weightArr[2];
                        weight2_4.Text = weightArr[3];
                        weight2_5.Text = weightArr[4];

                        rating2_1.Text = ratingArr[0];
                        rating2_2.Text = ratingArr[1];
                        rating2_3.Text = ratingArr[2];
                        rating2_4.Text = ratingArr[3];
                        rating2_5.Text = ratingArr[4];

                        label2_1.Text = (double.Parse(weight2_1.Text) * double.Parse(ratingComp(ratingArr[0])) * 0.01).ToString("0.00");
                        label2_2.Text = (double.Parse(weight2_2.Text) * double.Parse(ratingComp(ratingArr[1])) * 0.01).ToString("0.00");
                        label2_3.Text = (double.Parse(weight2_3.Text) * double.Parse(ratingComp(ratingArr[2])) * 0.01).ToString("0.00");
                        label2_4.Text = (double.Parse(weight2_4.Text) * double.Parse(ratingComp(ratingArr[3])) * 0.01).ToString("0.00");
                        label2_5.Text = (double.Parse(weight2_5.Text) * double.Parse(ratingComp(ratingArr[4])) * 0.01).ToString("0.00");

                    }
                }
                computeTotalScore();
            }
        }

        protected string ratingComp(string rating)
        {
            if (rating == "5")
            {
                return "100";
            }
            else if (rating == "4")
            {
                return "80";
            }
            else if (rating == "3")
            {
                return "60";
            }
            else if (rating == "2")
            {
                return "40";
            }
            else if (rating == "1")
            {
                return "20";
            }
            else
            {
                return "0";
            }
        }

        protected void rating2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                double weight = 0.2;
                double weightedScore;
                if (rating.ID == "rating2_1")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_1.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_1.Text)) * double.Parse(weight2_1.Text) * 0.01;
                    label2_1.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating2_2")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_2.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_2.Text)) * double.Parse(weight2_2.Text) * 0.01;
                    label2_2.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating2_3")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_3.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_3.Text)) * double.Parse(weight2_3.Text) * 0.01;
                    label2_3.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating2_4")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_4.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_4.Text)) * double.Parse(weight2_4.Text) * 0.01;
                    label2_4.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_5.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_5.Text)) * double.Parse(weight2_5.Text) * 0.01;
                    label2_5.Text = weightedScore.ToString("0.00");
                }
                computeTotalScore();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }

        protected double inputChecker(string weight)
        {
            if (weight != "0")
            {
                return double.Parse(weight);
            }
            else
            {
                return 0;
            }
        }
        protected void computeTotalScore()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, total = 0;
            weight1 = inputChecker(label2_1.Text);
            weight2 = inputChecker(label2_2.Text);
            weight3 = inputChecker(label2_3.Text);
            weight4 = inputChecker(label2_4.Text);
            weight5 = inputChecker(label2_5.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal2.Text = total.ToString("0.00");
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (rating2_1.Text == "0" || rating2_2.Text == "0" || rating2_3.Text == "0" || rating2_4.Text == "0" || rating2_5.Text == "0")
            {
                Response.Write("<script>alert('Please input a number from 1-5.')</script>");
            }
            else 
            {
                UpdateCWR();
                if (link.ID == "btnSection1")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection1Staff.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection2Staff.aspx");
                }
                else if (link.ID == "btnSection3")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationCommentsStaff.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationOverallStaff.aspx");
                }
            }
            
        }

        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedStaffFormID = Session["StaffFormID"].ToString();
            try
            {
                // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""StaffForm"" SET ""Section2CWR"" = @Section2CWR WHERE ""StaffFormID"" = @StaffFormID", connection);
                    command.Parameters.AddWithValue("@Section2CWR", compiledCWR);
                    command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected string CompileAnswers()
        {
            string text = "";

            text += $"1,{weight2_1.Text},{rating2_1.Text};";
            text += $"2,{weight2_2.Text},{rating2_2.Text};";
            text += $"3,{weight2_3.Text},{rating2_3.Text};";
            text += $"4,{weight2_4.Text},{rating2_4.Text};";
            text += $"5,{weight2_5.Text},{rating2_5.Text}";

            return text;
        }
    }
}
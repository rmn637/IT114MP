using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationSection1Officers : System.Web.UI.Page
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
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();
                    string storedOfficerFormID = Session["OfficerFormID"].ToString();

                    string sqlCode = @"SELECT ""Section1IOWR"" FROM ""OfficerForm"" WHERE ""OfficerFormID"" = @OfficerFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficerFormID);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CWR = reader.GetString(0);
                    }
                    reader.Close();

                    if (CWR != "0")
                    {
                        string[] CWRArr = CWR.Split(';');
                        string[] CWRArr2 = new string[5];
                        string[] weightArr = new string[6];
                        string[] ratingArr = new string[6];
                        string[] objectiveArr = new string[6];
                        string[] initiativeArr = new string[6];
                        

                        for (int i = 0; i < CWRArr.Length; i++)
                        {
                            CWRArr2 = CWRArr[i].Split('|');
                            initiativeArr[i] = CWRArr2[1];
                            objectiveArr[i] = CWRArr2[2];
                            weightArr[i] = CWRArr2[3];
                            ratingArr[i] = CWRArr2[4];
                                
                        }

                        weight1_1.Text = weightArr[0];
                        weight1_2.Text = weightArr[1];
                        weight1_3.Text = weightArr[2];
                        weight1_4.Text = weightArr[3];
                        weight1_5.Text = weightArr[4];
                        weight1_6.Text = weightArr[5];

                        rating1_1.Text = ratingArr[0];
                        rating1_2.Text = ratingArr[1];
                        rating1_3.Text = ratingArr[2];
                        rating1_4.Text = ratingArr[3];
                        rating1_5.Text = ratingArr[4];
                        rating1_6.Text = ratingArr[5];

                        initiative1.Text = initiativeArr[0];
                        initiative2.Text = initiativeArr[1];
                        initiative3.Text = initiativeArr[2];
                        initiative4.Text = initiativeArr[3];
                        initiative5.Text = initiativeArr[4];
                        initiative6.Text = initiativeArr[5];

                        objectives1.Text = objectiveArr[0];
                        objectives2.Text = objectiveArr[1];
                        objectives3.Text = objectiveArr[2];
                        objectives4.Text = objectiveArr[3];
                        objectives5.Text = objectiveArr[4];
                        objectives6.Text = objectiveArr[5];

                        label1_1.Text = (double.Parse(weight1_1.Text) * double.Parse(ratingComp(ratingArr[0])) * 0.01).ToString("0.00");
                        label1_2.Text = (double.Parse(weight1_2.Text) * double.Parse(ratingComp(ratingArr[1])) * 0.01).ToString("0.00");
                        label1_3.Text = (double.Parse(weight1_3.Text) * double.Parse(ratingComp(ratingArr[2])) * 0.01).ToString("0.00");
                        label1_4.Text = (double.Parse(weight1_4.Text) * double.Parse(ratingComp(ratingArr[3])) * 0.01).ToString("0.00");
                        label1_5.Text = (double.Parse(weight1_5.Text) * double.Parse(ratingComp(ratingArr[4])) * 0.01).ToString("0.00");
                        label1_6.Text = (double.Parse(weight1_6.Text) * double.Parse(ratingComp(ratingArr[5])) * 0.01).ToString("0.00");
                    }
                }
                computeTotalScore();
            }
        }
        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedStaffFormID = Session["OfficerFormID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""OfficerForm"" SET ""Section1IOWR"" = @Section1IOWR WHERE ""OfficerFormID"" = @OfficerFormID", connection);
                    command.Parameters.AddWithValue("@Section1IOWR", compiledCWR);
                    command.Parameters.AddWithValue("@OfficerFormID", storedStaffFormID);
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

            text += $"1|{initiative1.Text}|{objectives1.Text}|{weight1_1.Text}|{rating1_1.Text};";
            text += $"2|{initiative2.Text}|{objectives2.Text}|{weight1_2.Text}|{rating1_2.Text};";
            text += $"3|{initiative3.Text}|{objectives3.Text}|{weight1_3.Text}|{rating1_3.Text};";
            text += $"4|{initiative4.Text}|{objectives4.Text}|{weight1_4.Text}|{rating1_4.Text};";
            text += $"5|{initiative5.Text}|{objectives5.Text}|{weight1_5.Text}|{rating1_5.Text};";
            text += $"6|{initiative6.Text}|{objectives6.Text}|{weight1_6.Text}|{rating1_6.Text};";

            return text;
        }
        protected void computeTotalScore()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, weight6 = 0, total = 0;
            weight1 = inputChecker(label1_1.Text);
            weight2 = inputChecker(label1_2.Text);
            weight3 = inputChecker(label1_3.Text);
            weight4 = inputChecker(label1_4.Text);
            weight5 = inputChecker(label1_5.Text);
            weight6 = inputChecker(label1_6.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5 + weight6;
            labelTotal1.Text = total.ToString("0.00");
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
        protected void rating1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                double weight = 0;
                double weightedScore;
                if (rating.ID == "rating1_1")
                {
                    weight = 0.7;
                    if (double.Parse(rating1_1.Text) > 5)
                    {
                        rating1_1.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_1.Text)) * weight;
                    label1_1.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (rating.ID == "rating1_2")
                    {
                        weight = 0.15;
                        if (double.Parse(rating1_2.Text) > 5)
                        {
                            rating1_2.Text = "5";
                        }
                        weightedScore = double.Parse(ratingComp(rating1_2.Text)) * weight;
                        label1_2.Text = weightedScore.ToString("0.00");
                    }
                    else if(rating.ID == "rating1_3")
                    {
                        weight = 0.15;
                        if (double.Parse(rating1_3.Text) > 5)
                        {
                            rating1_3.Text = "5";
                        }
                        weightedScore = double.Parse(ratingComp(rating1_3.Text)) * weight;
                        label1_3.Text = weightedScore.ToString("0.00");
                    }
                    else if(rating.ID == "rating1_4")
                    {
                        weight = 0.15;
                        if (double.Parse(rating1_4.Text) > 5)
                        {
                            rating1_4.Text = "5";
                        }
                        weightedScore = double.Parse(ratingComp(rating1_4.Text)) * weight;
                        label1_4.Text = weightedScore.ToString("0.00");
                    }
                    else if(rating.ID == "rating1_5")
                    {
                        weight = 0.15;
                        if (double.Parse(rating1_5.Text) > 5)
                        {
                            rating1_5.Text = "5";
                        }
                        weightedScore = double.Parse(ratingComp(rating1_5.Text)) * weight;
                        label1_5.Text = weightedScore.ToString("0.00");
                    }
                    else
                    {
                        weight = 0.15;
                        if (double.Parse(rating1_6.Text) > 100)
                        {
                            rating1_6.Text = "100";
                        }
                        weightedScore = double.Parse(ratingComp(rating1_6.Text)) * weight;
                        label1_6.Text = weightedScore.ToString("0.00");
                    }
                }
                computeTotal1();
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
        protected void computeTotal1()
        {
            double weightedScore1 = 0, weightedScore2 = 0, weightedScore3 = 0, weightedScore4 = 0, weightedScore5 = 0, weightedScore6 = 0, total = 0;
            weightedScore1 = inputChecker(label1_1.Text);
            weightedScore2 = inputChecker(label1_2.Text);
            weightedScore3 = inputChecker(label1_3.Text);
            weightedScore4 = inputChecker(label1_4.Text);
            weightedScore5 = inputChecker(label1_5.Text);
            weightedScore6 = inputChecker(label1_6.Text);
            total = weightedScore1 + weightedScore2 + weightedScore3 + weightedScore4 + weightedScore5 + weightedScore6;
            labelTotal1.Text = total.ToString("0.00");
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (rating1_1.Text == "0" || rating1_2.Text == "0" || rating1_3.Text == "0" || rating1_4.Text == "0" || rating1_5.Text == "0")
            {
                Response.Write("<script>alert('Please input a number from 1-5.')</script>");
            }
            else
            {
                UpdateCWR();
                if (link.ID == "btnSection1")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection1Officers.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection2Officers.aspx");
                }
                else if (link.ID == "btnSection3")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection3Officers.aspx");
                }
                else if (link.ID == "btnSection4")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationCommentsOfficers.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~EvaluationOverallOfficers.aspx");
                }
            }
        }
    }
}
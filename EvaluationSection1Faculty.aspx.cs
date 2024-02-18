using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            {
                Initialize();
            }
        }
        protected void Initialize()
        {
            string CWR = "";

            if (!IsPostBack)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();
                    string storedFacultyFormID = Session["FacultyFormID"].ToString();

                    string sqlCode = @"SELECT ""Section1CWR"" FROM ""FacultyForm"" WHERE ""FacultyFormID"" = @FacultyFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@FacultyFormID", storedFacultyFormID);

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

                        weight1_A.Text = weightArr[0];
                        weight1_B.Text = weightArr[1];
                        weight1_C.Text = weightArr[2];
                        weight1_1.Text = weightArr[3];
                        weight1_2.Text = weightArr[4];
                        weight1_3.Text = weightArr[5];
                        weight1_4.Text = weightArr[6];
                        weight1_5.Text = weightArr[7];

                        rating1_A.Text = ratingArr[0];
                        rating1_B.Text = ratingArr[1];
                        rating1_C.Text = ratingArr[2];
                        rating1_1.Text = ratingArr[3];
                        rating1_2.Text = ratingArr[4];
                        rating1_3.Text = ratingArr[5];
                        rating1_4.Text = ratingArr[6];
                        rating1_5.Text = ratingArr[7];

                        label1_A.Text = (double.Parse(weight1_A.Text) * double.Parse(ratingComp(ratingArr[0])) * 0.01).ToString("0.00");
                        label1_B.Text = (double.Parse(weight1_B.Text) * double.Parse(ratingComp(ratingArr[1])) * 0.01).ToString("0.00");
                        label1_C.Text = (double.Parse(weight1_C.Text) * double.Parse(ratingComp(ratingArr[2])) * 0.01).ToString("0.00");
                        label1_1.Text = (double.Parse(weight1_1.Text) * double.Parse(ratingComp(ratingArr[3])) * 0.01).ToString("0.00");
                        label1_2.Text = (double.Parse(weight1_2.Text) * double.Parse(ratingComp(ratingArr[4])) * 0.01).ToString("0.00");
                        label1_3.Text = (double.Parse(weight1_3.Text) * double.Parse(ratingComp(ratingArr[5])) * 0.01).ToString("0.00");
                        label1_4.Text = (double.Parse(weight1_4.Text) * double.Parse(ratingComp(ratingArr[6])) * 0.01).ToString("0.00");
                        label1_5.Text = (double.Parse(weight1_5.Text) * double.Parse(ratingComp(ratingArr[7])) * 0.01).ToString("0.00");
                    }
                }
                computeTotal1A();
                computeTotal1B();
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
        protected void rating1A_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                double weightedScore;
                if (rating.ID == "rating1_A")
                {
                    if (double.Parse(rating1_A.Text) > 5)
                    {
                        rating1_A.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_A.Text)) * double.Parse(weight1_A.Text) * 0.01;
                    label1_A.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (rating.ID == "rating1_B")
                    {
                        if (double.Parse(rating1_B.Text) > 5)
                        {
                            rating1_B.Text = "5";
                        }
                        weightedScore = double.Parse(ratingComp(rating1_B.Text)) * double.Parse(weight1_B.Text) * 0.01;
                        label1_B.Text = weightedScore.ToString("0.00");
                    }
                    else
                    {
                        if (double.Parse(rating1_C.Text) > 100)
                        {
                            rating1_C.Text = "100";
                        }
                        weightedScore = double.Parse(ratingComp(rating1_C.Text)) * double.Parse(weight1_C.Text) * 0.01;
                        label1_C.Text = weightedScore.ToString("0.00");
                    }
                }
                computeTotal1A();
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
        protected void computeTotal1A()
        {
            double weightedScoreA = 0, weightedScoreB = 0, weightedScoreC = 0, total = 0;
            weightedScoreA = inputChecker(label1_A.Text);
            weightedScoreB = inputChecker(label1_B.Text);
            weightedScoreC = inputChecker(label1_C.Text);
            total = weightedScoreA + weightedScoreB + weightedScoreC;
            labelTotal1A.Text = total.ToString("0.00");
        }

        protected void rating1B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                double weightedScore;
                if (rating.ID == "rating1_1")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_1.Text = "5";
                    }
                    else if (double.Parse(rating.Text) < 0)
                    {
                        rating1_5.Text = "0";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_1.Text)) * double.Parse(weight1_1.Text) * 0.01;
                    label1_1.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_2")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_2.Text = "5";
                    }
                    else if (double.Parse(rating.Text) < 0)
                    {
                        rating1_5.Text = "0";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_2.Text)) * double.Parse(weight1_2.Text) * 0.01;
                    label1_2.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_3")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_3.Text = "5";
                    }
                    else if (double.Parse(rating.Text) < 0)
                    {
                        rating1_5.Text = "0";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_3.Text)) * double.Parse(weight1_3.Text) * 0.01;
                    label1_3.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_4")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_4.Text = "5";
                    }
                    else if (double.Parse(rating.Text) < 0)
                    {
                        rating1_4.Text = "0";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_4.Text)) * double.Parse(weight1_4.Text) * 0.01;
                    label1_4.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_5.Text = "5";
                    }
                    else if (double.Parse(rating.Text) < 0)
                    {
                        rating1_5.Text = "0";
                    }
                        weightedScore = double.Parse(ratingComp(rating1_5.Text)) * double.Parse(weight1_5.Text) * 0.01;
                    label1_5.Text = weightedScore.ToString("0.00");
                }
                computeTotal1B();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void computeTotal1B()
        {
            double weightedScore1 = 0, weightedScore2 = 0, weightedScore3 = 0, weightedScore4 = 0, weightedScore5 = 0, total = 0;
            if (label1_1.Text != "0")
            {
                weightedScore1 = double.Parse(label1_1.Text);
            }
            else
            {
                weightedScore1 = 0;
            }
            if (label1_2.Text != "0")
            {
                weightedScore2 = double.Parse(label1_2.Text);
            }
            else
            {
                weightedScore2 = 0;
            }
            if (label1_3.Text != "0")
            {
                weightedScore3 = double.Parse(label1_3.Text);
            }
            else
            {
                weightedScore3 = 0;
            }
            if (label1_4.Text != "0")
            {
                weightedScore4 = double.Parse(label1_4.Text);
            }
            else
            {
                weightedScore4 = 0;
            }
            if (label1_5.Text != "0")
            {
                weightedScore5 = double.Parse(label1_5.Text);
            }
            else
            {
                weightedScore5 = 0;
            }
            total = weightedScore1 + weightedScore2 + weightedScore3 + weightedScore4 + weightedScore5;
            labelTotal1B.Text = total.ToString("0.00");
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (label1_1.Text == "0" || label1_2.Text == "0" || label1_3.Text == "0" || label1_4.Text == "0" || label1_5.Text == "0")
            {
                Response.Write("<script>alert('Please input a number from 1-5.')</script>");
            }
            else
            {
                UpdateCWR();
                if (link.ID == "btnSection1")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection1Faculty.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection2Faculty.aspx");
                }
                else if (link.ID == "btnSection3")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationCommentsFaculty.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationOverallFaculty.aspx");
                }

            }


        }
        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedFacultyFormID = Session["FacultyFormID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
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
        protected string CompileAnswers()
        {
            string text = "";

            text += $"1,{weight1_A.Text},{rating1_A.Text};";
            text += $"2,{weight1_B.Text},{rating1_B.Text};";
            text += $"3,{weight1_C.Text},{rating1_C.Text};";
            text += $"4,{weight1_1.Text},{rating1_1.Text};";
            text += $"5,{weight1_2.Text},{rating1_2.Text};";
            text += $"6,{weight1_3.Text},{rating1_3.Text};";
            text += $"7,{weight1_4.Text},{rating1_4.Text};";
            text += $"8,{weight1_5.Text},{rating1_5.Text}";

            return text;
        }
    }
}
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationSection3Officers : System.Web.UI.Page
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
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();
                    string storedOfficersFormID = Session["OfficerFormID"].ToString();

                    string sqlCode = @"SELECT ""Section3CWR"" FROM ""OfficerForm"" WHERE ""OfficerFormID"" = @OfficerFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficersFormID);

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
                            CWRArr2 = CWRArr[i].Split('|');
                            weightArr[i] = CWRArr2[1];
                            ratingArr[i] = CWRArr2[2];
                        }

                        weight3_1.Text = weightArr[0];
                        weight3_2.Text = weightArr[1];
                        weight3_3.Text = weightArr[2];
                        weight3_4.Text = weightArr[3];
                        weight3_5.Text = weightArr[4];
                        weight3_6.Text = weightArr[5];
                        weight3_7.Text = weightArr[6];
                        weight3_8.Text = weightArr[7];

                        rating1_1.Text = ratingArr[0];
                        rating1_2.Text = ratingArr[1];
                        rating1_3.Text = ratingArr[2];
                        rating1_4.Text = ratingArr[3];
                        rating1_5.Text = ratingArr[4];
                        rating1_6.Text = ratingArr[5];
                        rating1_7.Text = ratingArr[6];
                        rating1_8.Text = ratingArr[7];

                        label1_1.Text = (double.Parse(weight3_1.Text) * double.Parse(ratingComp(ratingArr[0])) * 0.01).ToString("0.00");
                        label1_2.Text = (double.Parse(weight3_2.Text) * double.Parse(ratingComp(ratingArr[1])) * 0.01).ToString("0.00");
                        label1_3.Text = (double.Parse(weight3_3.Text) * double.Parse(ratingComp(ratingArr[2])) * 0.01).ToString("0.00");
                        label1_4.Text = (double.Parse(weight3_4.Text) * double.Parse(ratingComp(ratingArr[3])) * 0.01).ToString("0.00");
                        label1_5.Text = (double.Parse(weight3_5.Text) * double.Parse(ratingComp(ratingArr[4])) * 0.01).ToString("0.00");
                        label1_6.Text = (double.Parse(weight3_6.Text) * double.Parse(ratingComp(ratingArr[5])) * 0.01).ToString("0.00");
                        label1_7.Text = (double.Parse(weight3_7.Text) * double.Parse(ratingComp(ratingArr[6])) * 0.01).ToString("0.00");
                        label1_8.Text = (double.Parse(weight3_8.Text) * double.Parse(ratingComp(ratingArr[7])) * 0.01).ToString("0.00");
                    }
                }
                computeTotalScore();
            }
        }
        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedOfficersFormID = Session["OfficerFormID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=
                //;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""OfficerForm"" SET ""Section3CWR"" = @Section3CWR WHERE ""OfficerFormID"" = @OfficerFormID", connection);
                    command.Parameters.AddWithValue("@Section3CWR", compiledCWR);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficersFormID);
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

            text += $"1|{weight3_1.Text}|{rating1_1.Text};";
            text += $"2|{weight3_2.Text}|{rating1_2.Text};";
            text += $"3|{weight3_3.Text}|{rating1_3.Text};";
            text += $"4|{weight3_4.Text}|{rating1_4.Text};";
            text += $"5|{weight3_5.Text}|{rating1_5.Text};";
            text += $"6|{weight3_6.Text}|{rating1_6.Text};";
            text += $"7|{weight3_7.Text}|{rating1_7.Text};";
            text += $"8|{weight3_8.Text}|{rating1_8.Text}";

            return text;
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
                double weightedScore;
                if (rating.ID == "rating1_1")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_1.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_1.Text)) * double.Parse(weight3_1.Text) * 0.01;
                    label1_1.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_2")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_2.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_2.Text)) * double.Parse(weight3_2.Text) * 0.01;
                    label1_2.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_3")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_3.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_3.Text)) * double.Parse(weight3_3.Text) * 0.01;
                    label1_3.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_4")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_4.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_4.Text)) * double.Parse(weight3_4.Text) * 0.01;
                    label1_4.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_5")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_5.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_5.Text)) * double.Parse(weight3_5.Text) * 0.01;
                    label1_5.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_6")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_6.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_6.Text)) * double.Parse(weight3_6.Text) * 0.01;
                    label1_6.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_7")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_7.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_7.Text)) * double.Parse(weight3_7.Text) * 0.01;
                    label1_7.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_8.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_8.Text)) * double.Parse(weight3_8.Text) * 0.01;
                    label1_8.Text = weightedScore.ToString("0.00");
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
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, weight6 = 0, weight7 = 0, weight8 = 0, total = 0;
            weight1 = inputChecker(label1_1.Text);
            weight2 = inputChecker(label1_2.Text);
            weight3 = inputChecker(label1_3.Text);
            weight4 = inputChecker(label1_4.Text);
            weight5 = inputChecker(label1_5.Text);
            weight6 = inputChecker(label1_6.Text);
            weight7 = inputChecker(label1_7.Text);
            weight8 = inputChecker(label1_8.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5 + weight6 + weight7 + weight8;
            labelTotal1.Text = total.ToString("0.00");
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (label1_1.Text == "0" || label1_2.Text == "0" || label1_3.Text == "0" || label1_4.Text == "0" || label1_5.Text == "0" || label1_6.Text == "0" || label1_7.Text == "0" || label1_8.Text == "0")
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
                    Response.Redirect("~/EvaluationSection4Officers.aspx");
                }
                else if (link.ID == "btnSection5")
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
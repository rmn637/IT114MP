using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationSection2Officers : System.Web.UI.Page
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
                    string storedOfficerFormID = Session["OfficerFormID"].ToString();

                    string sqlCode = @"SELECT ""Section2CNWR"" FROM ""OfficerForm"" WHERE ""OfficerFormID"" = @OfficerFormID";
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
                        string[] weightArr = new string[4];
                        string[] ratingArr = new string[4];
                        string[] scopeArr = new string[4];
                        string[] notesArr = new string[4];


                        for (int i = 0; i < CWRArr.Length; i++)
                        {
                            CWRArr2 = CWRArr[i].Split('|');
                            scopeArr[i] = CWRArr2[1];
                            notesArr[i] = CWRArr2[2];
                            weightArr[i] = CWRArr2[3];
                            ratingArr[i] = CWRArr2[4];

                        }

                        weight2_1.Text = weightArr[0];
                        weight2_2.Text = weightArr[1];
                        weight2_3.Text = weightArr[2];
                        weight2_4.Text = weightArr[3];

                        rating2_1.Text = ratingArr[0];
                        rating2_2.Text = ratingArr[1];
                        rating2_3.Text = ratingArr[2];
                        rating2_4.Text = ratingArr[3];

                        scope1.Text = scopeArr[0];
                        scope2.Text = scopeArr[1];
                        scope3.Text = scopeArr[2];
                        scope4.Text = scopeArr[3];

                        notes1.Text = notesArr[0];
                        notes2.Text = notesArr[1];
                        notes3.Text = notesArr[2];
                        notes4.Text = notesArr[3];

                        label2_1.Text = (double.Parse(weight2_1.Text) * double.Parse(ratingComp(ratingArr[0])) * 0.01).ToString("0.00");
                        label2_2.Text = (double.Parse(weight2_2.Text) * double.Parse(ratingComp(ratingArr[1])) * 0.01).ToString("0.00");
                        label2_3.Text = (double.Parse(weight2_3.Text) * double.Parse(ratingComp(ratingArr[2])) * 0.01).ToString("0.00");
                        label2_4.Text = (double.Parse(weight2_4.Text) * double.Parse(ratingComp(ratingArr[3])) * 0.01).ToString("0.00");
                    }
                }
                computeTotal1();
            }
        }
        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedOfficerFormID = Session["OfficerFormID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=
                //;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""OfficerForm"" SET ""Section2CNWR"" = @Section2CNWR WHERE ""OfficerFormID"" = @OfficerFormID", connection);
                    command.Parameters.AddWithValue("@Section1IOWR", compiledCWR);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficerFormID);
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

            text += $"1|{scope1.Text}|{notes1.Text}|{weight2_1.Text}|{rating2_1.Text};";
            text += $"2|{scope2.Text}|{notes2.Text}|{weight2_2.Text}|{rating2_2.Text};";
            text += $"3|{scope3.Text}|{notes3.Text}|{weight2_3.Text}|{rating2_3.Text};";
            text += $"4|{scope4.Text}|{notes4.Text}|{weight2_4.Text}|{rating2_4.Text};";
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

        protected void rating1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                double weight = 0;
                double weightedScore;
                if (rating.ID == "rating2_1")
                {
                    weight = 0.7;
                    if (double.Parse(rating2_1.Text) > 5)
                    {
                        rating2_1.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_1.Text)) * weight;
                    label2_1.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (rating.ID == "rating2_2")
                    {
                        weight = 0.15;
                        if (double.Parse(rating2_2.Text) > 5)
                        {
                            rating2_2.Text = "5";
                        }
                        weightedScore = double.Parse(ratingComp(rating2_2.Text)) * weight;
                        label2_2.Text = weightedScore.ToString("0.00");
                    }
                    else if(rating.ID == "rating2_3")
                    {
                        weight = 0.15;
                        if (double.Parse(rating2_3.Text) > 5)
                        {
                            rating2_3.Text = "5";
                        }
                        weightedScore = double.Parse(ratingComp(rating2_3.Text)) * weight;
                        label2_3.Text = weightedScore.ToString("0.00");
                    }
                    else if(rating.ID == "rating2_4")
                    {
                        weight = 0.15;
                        if (double.Parse(rating2_4.Text) > 5)
                        {
                            rating2_4.Text = "5";
                        }
                        weightedScore = double.Parse(ratingComp(rating2_4.Text)) * weight;
                        label2_4.Text = weightedScore.ToString("0.00");
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
            double weightedScore1 = 0, weightedScore2 = 0, weightedScore3 = 0, weightedScore4 = 0, total = 0;
            weightedScore1 = inputChecker(label2_1.Text);
            weightedScore2 = inputChecker(label2_2.Text);
            weightedScore3 = inputChecker(label2_3.Text);
            weightedScore4 = inputChecker(label2_4.Text);
            total = weightedScore1 + weightedScore2 + weightedScore3 + weightedScore4;
            labelTotal2.Text = total.ToString("0.00");
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
                    weightedScore = double.Parse(ratingComp(rating2_1.Text)) * weight;
                    label2_1.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating2_2")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_2.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_2.Text)) * weight;
                    label2_2.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating2_3")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_3.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_3.Text)) * weight;
                    label2_3.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_4.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_4.Text)) * weight;
                    rating2_4.Text = weightedScore.ToString("0.00");
                }
                computeTotal1();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (labelTotal2.Text != "100.00")
            {
                Response.Write("<script>alert('Please input a number from 1-100.')</script>");
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
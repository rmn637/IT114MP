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
            ((Site1)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
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
            if (rating1_1.Text == "0" || rating1_2.Text == "0" || rating1_3.Text == "0" || rating1_4.Text == "0" || rating1_5.Text == "0" || rating2_1.Text == "0" || rating2_2.Text == "0" || rating2_3.Text == "0" || rating2_4.Text == "0")
            {
                Response.Write("<script>alert('Please input a number from 1-5.')</script>");
            }
            else
            {
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
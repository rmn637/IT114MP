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
                if (rating.ID == "rating1_1")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_1.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_1.Text)) * weight;
                    label1_1.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_2")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_2.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_2.Text)) * weight;
                    label1_2.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_3")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_3.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_3.Text)) * weight;
                    label1_3.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_4")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_4.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_4.Text)) * weight;
                    label1_4.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_5")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_5.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_5.Text)) * weight;
                    label1_5.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_6")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_6.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_6.Text)) * weight;
                    label1_6.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_7")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_7.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_7.Text)) * weight;
                    label1_7.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating1_8.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating1_8.Text)) * weight;
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
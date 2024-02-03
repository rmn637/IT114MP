using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt1class = "active";
        }
        protected void rating1A_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                double weight = 0;
                double weightedScore;
                if (rating.ID == "rating1_A")
                {
                    weight = 0.7;
                    if (double.Parse(rating1_A.Text) > 100)
                    {
                        rating1_A.Text = "100";
                    }
                    weightedScore = double.Parse(rating1_A.Text) * weight;
                    label1_A.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (rating.ID == "rating1_B")
                    {
                        weight = 0.15;
                        if (double.Parse(rating1_B.Text) > 100)
                        {
                            rating1_B.Text = "100";
                        }
                        weightedScore = double.Parse(rating1_B.Text) * weight;
                        label1_B.Text = weightedScore.ToString("0.00");
                    }
                    else
                    {
                        weight = 0.15;
                        if (double.Parse(rating1_C.Text) > 100)
                        {
                            rating1_C.Text = "100";
                        }
                        weightedScore = double.Parse(rating1_C.Text) * weight;
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
        protected void computeTotal1A()
        {
            double weightedScoreA = 0, weightedScoreB = 0, weightedScoreC = 0, total = 0;
            if (label1_A.Text != "0")
            {
                weightedScoreA = double.Parse(label1_A.Text);
            }
            else
            {
                weightedScoreA = 0;
            }
            if (label1_B.Text != "0")
            {
                weightedScoreB = double.Parse(label1_B.Text);
            }
            else
            {
                weightedScoreB = 0;
            }
            if (label1_C.Text != "0")
            {
                weightedScoreC = double.Parse(label1_C.Text);
            }
            else
            {
                weightedScoreC = 0;
            }
            total = weightedScoreA + weightedScoreB + weightedScoreC;
            labelTotal1A.Text = total.ToString("0.00");
        }

        protected void rating1B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                double weight = 0.2;
                double weightedScore;
                if (rating.ID == "rating1_1")
                {
                    if (double.Parse(rating.Text) > 100)
                    {
                        rating1_1.Text = "100";
                    }
                    weightedScore = double.Parse(rating1_1.Text) * weight;
                    label1_1.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_2")
                {
                    if (double.Parse(rating.Text) > 100)
                    {
                        rating1_2.Text = "100";
                    }
                    weightedScore = double.Parse(rating1_2.Text) * weight;
                    label1_2.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_3")
                {
                    if (double.Parse(rating.Text) > 100)
                    {
                        rating1_3.Text = "100";
                    }
                    weightedScore = double.Parse(rating1_3.Text) * weight;
                    label1_3.Text = weightedScore.ToString("0.00");
                }
                else if (rating.ID == "rating1_4")
                {
                    if (double.Parse(rating.Text) > 100)
                    {
                        rating1_4.Text = "100";
                    }
                    weightedScore = double.Parse(rating1_4.Text) * weight;
                    label1_4.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (double.Parse(rating.Text) > 100)
                    {
                        rating1_5.Text = "100";
                    }
                    weightedScore = double.Parse(rating1_5.Text) * weight;
                    label1_5.Text = weightedScore.ToString("0.00");
                }
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm5 : System.Web.UI.Page
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
                else if (rating.ID == "rating2_4")
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_4.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_4.Text)) * weight;
                    label2_4.Text = weightedScore.ToString("0.00");
                }
                else
                {
                    if (double.Parse(rating.Text) > 5)
                    {
                        rating2_5.Text = "5";
                    }
                    weightedScore = double.Parse(ratingComp(rating2_5.Text)) * weight;
                    label2_5.Text = weightedScore.ToString("0.00");
                }
                computeTotal2();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void computeTotal2()
        {
            double weightedScore1 = 0, weightedScore2 = 0, weightedScore3 = 0, weightedScore4 = 0, weightedScore5 = 0, total = 0;
            if (label2_1.Text != "0")
            {
                weightedScore1 = double.Parse(label2_1.Text);
            }
            else
            {
                weightedScore1 = 0;
            }
            if (label2_2.Text != "0")
            {
                weightedScore2 = double.Parse(label2_2.Text);
            }
            else
            {
                weightedScore2 = 0;
            }
            if (label2_3.Text != "0")
            {
                weightedScore3 = double.Parse(label2_3.Text);
            }
            else
            {
                weightedScore3 = 0;
            }
            if (label2_4.Text != "0")
            {
                weightedScore4 = double.Parse(label2_4.Text);
            }
            else
            {
                weightedScore4 = 0;
            }
            if (label2_5.Text != "0")
            {
                weightedScore5 = double.Parse(label2_5.Text);
            }
            else
            {
                weightedScore5 = 0;
            }
            total = weightedScore1 + weightedScore2 + weightedScore3 + weightedScore4 + weightedScore5;
            double sectionTotal = total * 0.2;
            labelTotal2.Text = total.ToString("0.00");
            sectionTotal_2.Text = sectionTotal.ToString("0.00");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementSection1Faculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
        }
        protected void weight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox weight = sender as TextBox;
                double weightedScore;
                if (weight.ID == "weight1_1")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_1.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_1.Text);
                }
                else if (weight.ID == "weight1_2")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_2.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_2.Text);
                }
                else if (weight.ID == "weight1_3")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_3.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_3.Text);
                }
                else if (weight.ID == "weight1_4")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_4.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_4.Text);
                }
                else if (weight.ID == "weight1_5")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_5.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_5.Text);
                }
                else if (weight.ID == "weight1_A")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_A.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_A.Text);
                }
                else if (weight.ID == "weight1_B")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_B.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_B.Text);
                }
                else
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_C.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_C.Text);
                }
                computeTotalWeight1();
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
                Response.Write("<script>alert('Please input a number from 1-100.')</script>");
                return 0;
            }
        }
        protected void computeTotalWeight1()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, weightA = 0, weightB = 0, weightC = 0, total = 0;
            weight1 = inputChecker(weight1_1.Text);
            weight2 = inputChecker(weight1_2.Text);
            weight3 = inputChecker(weight1_3.Text);
            weight4 = inputChecker(weight1_4.Text);
            weight5 = inputChecker(weight1_5.Text);
            weightA = inputChecker(weight1_A.Text);
            weightB = inputChecker(weight1_B.Text);
            weightC = inputChecker(weight1_C.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal1B.Text = total.ToString("0.00");
            total = 0 + weightA + weightB + weightC;
            labelTotal1A.Text = total.ToString("0.00");

        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (labelTotal1A.Text != "100.00" && labelTotal1B.Text != "100.00")
            {
                Response.Write("<script>alert('Your total weight is not 100.')</script>");
            }
            else
            {
                if (link.ID == "btnSection1")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection1Faculty.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection2Faculty.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementOverallFaculty.aspx");
                }
            }
        }
    }
}
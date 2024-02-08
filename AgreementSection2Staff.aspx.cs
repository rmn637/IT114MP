﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementSection2Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //write form id
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
        }
        //protected string ratingComp(string rating)
        //{
        //    if (rating == "5")
        //    {
        //        return "100";
        //    }
        //    else if (rating == "4")
        //    {
        //        return "80";
        //    }
        //    else if (rating == "3")
        //    {
        //        return "60";
        //    }
        //    else if (rating == "2")
        //    {
        //        return "40";
        //    }
        //    else if (rating == "1")
        //    {
        //        return "20";
        //    }
        //    else
        //    {
        //        return "0";
        //    }
        //}

        protected void weight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox weight = sender as TextBox;
                double weightedScore;
                if (weight.ID == "weight2_1")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_1.Text = "5";
                    }
                    weightedScore = double.Parse(weight2_1.Text);
                }
                else if (weight.ID == "weight2_2")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_2.Text = "100";
                    }
                    weightedScore = double.Parse(weight2_2.Text);
                }
                else if (weight.ID == "weight2_3")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_3.Text = "100";
                    }
                    weightedScore = double.Parse(weight2_3.Text);
                }
                else if (weight.ID == "weight2_4")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_4.Text = "100";
                    }
                    weightedScore = double.Parse(weight2_4.Text);
                }
                else
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_5.Text = "100";
                    }
                    weightedScore = double.Parse(weight2_5.Text);
                }
                computeTotalWeight2();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }

        public static double inputChecker(string weight)
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
        protected void computeTotalWeight2()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, total = 0;
            weight1 = inputChecker(weight2_1.Text);
            weight2 = inputChecker(weight2_2.Text);
            weight3 = inputChecker(weight2_3.Text);
            weight4 = inputChecker(weight2_4.Text);
            weight5 = inputChecker(weight2_5.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal2.Text = total.ToString("0.00");
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (labelTotal2.Text != "100.00")
            {
                Response.Write("<script>alert('Your total weight is not 100.')</script>");
            }
            else
            {
                if (link.ID == "btnSection1")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection1Staff.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection2Staff.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementOverallStaff.aspx");
                }
            }
        }
    }
}
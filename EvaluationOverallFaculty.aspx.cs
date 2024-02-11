using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationOverallFaculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (total1.Text == "0" || total2.Text == "0")
            {
                Response.Write("<script>alert('Please input a number from 1-100.')</script>");
            }
            else if (labelTotal1.Text != "100.00")
            {
                Response.Write("<script>alert('Your total weight is not 100.')</script>");
            }
            else
            {
                Response.Redirect("MyAccount.aspx");
            }
        }

        protected void total_TextChanged(object sender, EventArgs e)
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, total = 0;
            weight1 = double.Parse(total1.Text);
            weight2 = double.Parse(total2.Text);
            weight3 = double.Parse(total3.Text);
            total = weight1 + weight2 + weight3;
            labelTotal1.Text = total.ToString("0.00");
            Submit.Enabled = true;
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
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
}
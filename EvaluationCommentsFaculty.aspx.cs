using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationCommentsFaculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (strength.Text == "" || development.Text == "" || improvement.Text == "" || acknowledgement.Text == "")
            {
                Response.Write("<script>alert('Please Type Comments.')</script>");
            }
            else if (link.ID == "btnSection1")
            {
                //insert database commands here
                Response.Redirect("~/EvaluationSection1Staff.aspx");
            }
            else if (link.ID == "btnSection2")
            {
                //insert database commands here
                Response.Redirect("~/EvaluationSection2Staff.aspx");
            }
            else if (link.ID == "btnSection3")
            {
                //insert database commands here
                Response.Redirect("~/EvaluationCommentsStaff.aspx");
            }
            else if (link.ID == "btnOverall")
            {
                //insert database commands here
                Response.Redirect("~/EvaluationOverallStaff.aspx");
            }
        }
    }
}
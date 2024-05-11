using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationOverallOfficers : System.Web.UI.Page
    {
        string OfficerFormID, empType, process, reportID, fields = @"""Section1IOWR"", ""Section2CNWR"", ""Section3CWR"", ""Section4CWR""";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            OfficerFormID = Session["OfficerFormID"].ToString();
            process = Session["Process"].ToString();
            if (process == "Validation")
                empType = Session["RateeEmpType"].ToString();
            else
                empType = Session["EmpType"].ToString();
            reportID = Session["ReportID"].ToString();

            if (!IsPostBack)
            {
                Initialize();
            }

        }

        protected void Initialize()
        {
            Label[] weightedScoreArr = { total1, total2, total3, total4, labelTotal1 };
            double[] percentages = { .3, .2, .3, .2 };
            string[] sessionInfo = Child.InitializeEvaluationOverall(ref weightedScoreArr, percentages, OfficerFormID, empType, fields, process);

            string alert = sessionInfo[0];
            bool PASubDone = bool.Parse(sessionInfo[1]);

            if (alert != "")
                Response.Write($"<script>alert('{alert}')</script>");


            if (process == "Submission")
            {
                Submit.Enabled = alert == "" && !PASubDone;
                Submit.Visible = !PASubDone;
            }
            else if (process == "Validation")
            {
                Submit.Visible = true;
                Submit.Enabled = alert == "";
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Child.UpdateStatRep(process, reportID, "PE");
            Session["Process"] = null;
            Response.Redirect("MyAccount.aspx");
        }

        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (link.ID == "btnSection1")
            {
                //insert database commands here
                Response.Redirect("~/OES1.aspx");
            }
            else if (link.ID == "btnSection2")
            {
                //insert database commands here
                Response.Redirect("~/OES2.aspx");
            }
            else if (link.ID == "btnSection3")
            {
                //insert database commands here
                Response.Redirect("~/OES3.aspx");
            }
            else if (link.ID == "btnSection4")
            {
                //insert database commands here
                Response.Redirect("~/OES4.aspx");
            }
            else if (link.ID == "btnSection5")
            {
                //insert database commands here
                Response.Redirect("~/OEC.aspx");
            }
            else if (link.ID == "btnOverall")
            {
                //insert database commands here
                Response.Redirect("~/OEO.aspx");
            }
        }
    }
}
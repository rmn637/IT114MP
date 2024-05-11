using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementOverallFaculty : System.Web.UI.Page
    {
        string facultyFormID, empType, process, reportID, fields = @"""Section1CWR"", ""Section2CWR""";

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            facultyFormID = Session["FacultyFormID"].ToString();
            process = Session["Process"].ToString();
            if (process == "Validation")
                empType = Session["RateeEmpType"].ToString();
            else
                empType = Session["EmpType"].ToString();
            reportID = Session["ReportID"].ToString();

            if (!IsPostBack)
                Initialize();
        }
        protected void Initialize()
        {
            string[] sessionInfo = Child.InitializeAgreementOverall(facultyFormID, empType, fields);

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
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (link.ID == "btnSection1")
                Response.Redirect("~/FAS1.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/FAS2.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/FAO.aspx");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Child.UpdateStatRep(process, reportID, "PA");
            Session["Process"] = null;
            Response.Redirect("MyAccount.aspx");
        }
    }
}
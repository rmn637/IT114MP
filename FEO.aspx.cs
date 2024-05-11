using Npgsql;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using static iTextSharp.text.pdf.AcroFields;

namespace WebApplication1
{
    public partial class EvaluationOverallFaculty : System.Web.UI.Page
    {
        string FacultyFormID, empType, process, reportID, fields = @"""Section1CWR"", ""Section2CWR""";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            FacultyFormID = Session["FacultyFormID"].ToString();
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
            Label[] weightedScoreArr = {total1, total2, total3, labelTotal1 };
            double[] percentages = {.5, .2, .3};
            string[] sessionInfo = Child.InitializeEvaluationOverall(ref weightedScoreArr, percentages, FacultyFormID, empType, fields, process);

            string alert = sessionInfo[0];
            bool PESubDone = bool.Parse(sessionInfo[1]);

            string test = sessionInfo[3];

            //Response.Write($"<script>alert('{FacultyFormID}+{empType}+{fields}+{process}+{sessionInfo[2]}+{alert}+{test}')</script>");
            //Response.Write($"<script>alert('{Session["Process"]}')</script>");

            if (alert != "")
                Response.Write($"<script>alert('{alert}')</script>");

            if (process == "Submission")
            {
                Submit.Enabled = alert == "" && !PESubDone;
                Submit.Visible = !PESubDone;
            }
            else if (process == "Validation")
            {
                Submit.Enabled = alert == "";
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Child.UpdateStatRep(process, reportID, "PE");
            if ((process == "Submission" && bool.Parse(Session["PEValDone"].ToString())) != true)
                Child.UpdateDatabase(labelTotal1.Text, empType, Session["FacultyFormID"].ToString());
            Session["Process"] = null;
            Response.Redirect("MyAccount.aspx");
        }

        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if ((process == "Submission" && bool.Parse(Session["PEValDone"].ToString())) != true)
                Child.UpdateDatabase(labelTotal1.Text, empType, Session["FacultyFormID"].ToString());

            if (link.ID == "btnSection1")
                Response.Redirect("~/FES1.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/FES2.aspx");
            else if (link.ID == "btnSection3")
                Response.Redirect("~/FEC.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/FEO.aspx");
        }
    }
}
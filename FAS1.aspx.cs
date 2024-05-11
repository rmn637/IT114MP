using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace WebApplication1
{
    public partial class AgreementSection1Faculty : System.Web.UI.Page
    {
        TextBox[] weightArr, weightArr2, weightArrCombined;
        string facultyFormID, empType, process, field = "Section1CWR";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            weightArr = new TextBox[] {
                    weight1_A,
                    weight1_B,
                    weight1_C,
            };

            weightArr2 = new TextBox[] {
                    weight1_1,
                    weight1_2,
                    weight1_3,
                    weight1_4,
                    weight1_5
            };

            weightArrCombined = weightArr.Concat(weightArr2).ToArray();

            facultyFormID = Session["FacultyFormID"].ToString();

            process = Session["Process"].ToString();

            if (process == "Validation")
                empType = Session["RateeEmpType"].ToString();
            else
                empType = Session["EmpType"].ToString();

            if (!IsPostBack)
                Initialize();
        }

        protected void Initialize()
        {
            string[] sessionInfo = Child.InitializeAgreementSection(ref weightArr, ref weightArr2, ref weightArrCombined, ref labelTotal1A, ref labelTotal1B, facultyFormID, field, empType, process);
            Session["ReportID"] = sessionInfo[0];
            Session["PAValDone"] = sessionInfo[1];
        }
        protected void weight_TextChanged(object sender, EventArgs e)
        {
            TextBox weight = sender as TextBox;
            try
            {
                if (weightArr.Contains(weight))
                    Child.AdjustWeight(ref weightArr, weight, ref labelTotal1A);
                else
                    Child.AdjustWeight(ref weightArr2, weight, ref labelTotal1B);
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
                weight.Text = "0";
            }
        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if ((process == "Submission" && bool.Parse(Session["PAValDone"].ToString())) != true)
                Child.UpdateDatabase(ref weightArrCombined, facultyFormID, empType, field);

            if (link.ID == "btnSection1")
                Response.Redirect("~/FAS1.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/FAS2.aspx");
            else if (link.ID == "btnSection3")
                Response.Redirect("~/FAS3.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/FAO.aspx");
        }
    }
}
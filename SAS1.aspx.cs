using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1
{
    public partial class AgreementSection1Staff : System.Web.UI.Page
    {
        TextBox[] weightArr;
        string staffFormID, empType, process, field = "Section1CWR";

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            weightArr = new TextBox[] {
                    weight1_1,
                    weight1_2,
                    weight1_3,
                    weight1_4,
                    weight1_5,
                    weight1_6,
                    weight1_7,
                    weight1_8
            };

            
            staffFormID = Session["StaffFormID"].ToString();

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
            string[] sessionInfo = Child.InitializeAgreementSection(ref weightArr, ref labelTotal1, staffFormID, field, empType, process);
            Session["ReportID"] = sessionInfo[0];
            Session["PAValDone"] = sessionInfo[1];
        }


        protected void weight_TextChanged(object sender, EventArgs e)
        {
            TextBox weight = sender as TextBox;
            try
            {
                Child.AdjustWeight(ref weightArr, weight, ref labelTotal1);
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
                Child.UpdateDatabase(ref weightArr, staffFormID, empType, field);

            if (link.ID == "btnSection1")
                Response.Redirect("~/SAS1.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/SAS2.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/SAO.aspx");
        }
    }
}
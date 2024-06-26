﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementSection2Faculty : System.Web.UI.Page
    {
        TextBox[] weightArr;
        string facultyFormID, empType, process, field = "Section2CWR";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            weightArr = new TextBox[] {
                    weight2_1,
                    weight2_2,
                    weight2_3,
                    weight2_4,
                    weight2_5
            };

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
            string[] sessionInfo = Child.InitializeAgreementSection(ref weightArr, ref labelTotal2, facultyFormID, field, empType, process);
            Session["ReportID"] = sessionInfo[0];
            Session["PAValDone"] = sessionInfo[1];
        }
        protected void weight_TextChanged(object sender, EventArgs e)
        {
            TextBox weight = sender as TextBox;
            try
            {
                Child.AdjustWeight(ref weightArr, weight, ref labelTotal2);
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
                Child.UpdateDatabase(ref weightArr, facultyFormID, empType, field);

            if (link.ID == "btnSection1")
                Response.Redirect("~/FAS1.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/FAS2.aspx");
            else if (link.ID == "btnSection3")
                Response.Redirect("~/FAC.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/FAO.aspx");
        }
    }
}
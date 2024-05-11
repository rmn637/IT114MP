﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class EvaluationCommentsStaff : System.Web.UI.Page
    {
        TextBox[] commentArr;
        string staffFormID, empType, process;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;


            commentArr = new TextBox[] { strength, improvement, development, acknowledgement };

            staffFormID = Session["StaffFormID"].ToString();

            process = Session["Process"].ToString();

            if (Session["Process"].ToString() == "Validation")
                empType = Session["RateeEmpType"].ToString();
            else
                empType = Session["EmpType"].ToString();

            if (!IsPostBack)
                Initialize();

            if (Session["Process"].ToString() == "Validation")
            {
                foreach (TextBox comment in commentArr)
                {
                    comment.Enabled = true;
                }
            }
        }

        protected void Initialize()
        {
            Child.InitializeComments(staffFormID, empType, ref commentArr);
            //Response.Write($"<script>alert('{Session["Process"]}')</script>");
        }

        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if ((process == "Submission" && bool.Parse(Session["PEValDone"].ToString())) != true)
                Child.UpdateDatabase(commentArr, empType, staffFormID);

            if (link.ID == "btnSection1")
                Response.Redirect("~/SES1.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/SES2.aspx");
            else if (link.ID == "btnSection3")
                Response.Redirect("~/SEC.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/SEO.aspx");
        }
    }
}
using Microsoft.SqlServer.Server;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaaluationSection1Staff : System.Web.UI.Page
    {
        TextBox[] ratingArr;
        Label[] weightArr, scoreArr;
        string empID, empType, process, field = "Section1CWR";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            weightArr = new Label[] { weight1_1, weight1_2, weight1_3, weight1_4, weight1_5, weight1_6, weight1_7, weight1_8 };
            scoreArr = new Label[] { label1_1, label1_2, label1_3, label1_4, label1_5, label1_6, label1_7, label1_8 };
            ratingArr = new TextBox[] { rating1_1, rating1_2, rating1_3, rating1_4, rating1_5, rating1_6, rating1_7, rating1_8 };

            if (Session["Process"] is null)
                Session["Process"] = "Submission";

            

            process = Session["Process"].ToString();

            if (Session["Process"].ToString() == "Validation")
                empType = Session["RateeEmpType"].ToString();
            else
                empType = Session["EmpType"].ToString();

            if (!IsPostBack) 
                Initialize();
               
        }

        protected void Initialize()
        {
            string CWR, PEVal;
            bool PESubDone;
            string[] sessionInfo;

            empID = Session["RateeID"].ToString(); 


            sessionInfo = Child.EmpInitEvalSec(empType, empID, field);

            Session["FormID"] = sessionInfo[0];
            Session["StaffFormID"] = sessionInfo[1];
            Session["ReportID"] = sessionInfo[2];
            //Session["RateeID"] = sessionInfo[3]; 
            CWR = sessionInfo[4];
            PESubDone = bool.Parse(sessionInfo[5]);
            

            //Response.Write($"<script>alert('{Session["Process"]}+{Session["EmpType"]}+{empID}+{field}+{CWR}')</script>");

            Session["PEValDone"] = PESubDone.ToString();

            if (process == "Submission")
            {
                foreach (var item in ratingArr)
                {
                    item.Enabled = !PESubDone;
                }
            }

            Child.SetPageInfo(ref ratingArr, ref weightArr, ref scoreArr, CWR);
            Child.ComputeTotalScore(scoreArr, ref labelTotal1);
        }
        protected void rating2_TextChanged(object sender, EventArgs e)
        {
            TextBox rating = sender as TextBox;
            try
            {
                Child.AdjustRating(ref ratingArr, ref weightArr, ref scoreArr, rating, ref labelTotal1);
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
                rating.Text = "0";
            }
        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if ((process == "Submission" && bool.Parse(Session["PEValDone"].ToString())) != true)
                Child.UpdateDatabase(ref weightArr, ref ratingArr, Session["StaffFormID"].ToString(), empType, field);

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
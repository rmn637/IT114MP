using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationSection3Officers : System.Web.UI.Page
    {
        TextBox[] ratingArr;
        Label[] weightArr, scoreArr;
        string empID, empType, process, field = "Section3CWR";

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            weightArr = new Label[] { weight3_1, weight3_2, weight3_3, weight3_4, weight3_5, weight3_6, weight3_7, weight3_8 };
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
            bool PEValDone;
            string[] sessionInfo;

            empID = Session["RateeID"].ToString();


            sessionInfo = Child.EmpInitEvalSec(empType, empID, field);

            Session["FormID"] = sessionInfo[0];
            Session["OfficerFormID"] = sessionInfo[1];
            Session["ReportID"] = sessionInfo[2];
            //Session["RateeID"] = sessionInfo[3]; 
            CWR = sessionInfo[4];
            PEValDone = bool.Parse(sessionInfo[5]);


            //Response.Write($"<script>alert('{Session["Process"]}+{Session["EmpType"]}+{empID}+{field}+{CWR}')</script>");

            Session["PEValDone"] = PEValDone.ToString();

            foreach (var item in weightArr)
            {
                item.Enabled = !PEValDone;
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
            if((process == "Submission" && bool.Parse(Session["PEValDone"].ToString())) != true)
                Child.UpdateDatabase(ref weightArr, ref ratingArr, Session["OfficerFormID"].ToString(), empType, field);
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
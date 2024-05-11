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
    public partial class EvaluationSection2Staff : System.Web.UI.Page
    {
        TextBox[] ratingArr;
        Label[] weightArr, scoreArr;
        string staffFormID, process, empID, empType, field = "Section2CWR";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;


            weightArr = new Label[] { weight2_1, weight2_2, weight2_3, weight2_4, weight2_5 };
            scoreArr = new Label[] { label2_1, label2_2, label2_3, label2_4, label2_5 };
            ratingArr = new TextBox[] { rating2_1, rating2_2, rating2_3, rating2_4, rating2_5 };

            staffFormID = Session["StaffFormID"].ToString();

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
            string CWR;
            bool PESubDone;
            string[] sessionInfo;

            empID = Session["RateeID"].ToString();
            sessionInfo = Child.EmpInitEvalSec(empType, empID, field);

            CWR = sessionInfo[4];
            PESubDone = bool.Parse(sessionInfo[5]);


            //Response.Write($"<script>alert('{Session["Process"]}+{empType}+{empID}+{field}+{CWR}')</script>");
            if (process == "Submission")
            {
                foreach (var item in ratingArr)
                {
                    item.Enabled = !PESubDone;
                }
            }

            Child.SetPageInfo(ref ratingArr, ref weightArr, ref scoreArr, CWR);
            Child.ComputeTotalScore(scoreArr, ref labelTotal2);
        }

        protected void rating2_TextChanged(object sender, EventArgs e)
        {
            TextBox rating = sender as TextBox;
            try
            {
                Child.AdjustRating(ref ratingArr, ref weightArr, ref scoreArr, rating, ref labelTotal2);
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

            //Response.Write($"<script>alert('{Session["PEValDone"]}+{Session["Process"]}+{Session["StaffFormID"]}+{Session["EmpType"]}+{field}')</script>");

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
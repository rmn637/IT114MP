using Microsoft.SqlServer.Server;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class EvaluationSection1Faculty : System.Web.UI.Page
    {
        TextBox[] ratingArr;
        Label[] weightArr, scoreArr;
        string empID, empType, process, field = "Section1CWR";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            weightArr = new Label[] { weight1_A, weight1_B, weight1_C, weight1_1, weight1_2, weight1_3, weight1_4, weight1_5 };
            ratingArr = new TextBox[] { rating1_A, rating1_B, rating1_C, rating1_1, rating1_2, rating1_3, rating1_4, rating1_5 };
            scoreArr = new Label[] { label1_A, label1_B, label1_C, label1_1, label1_2, label1_3, label1_4, label1_5 };

            if (Session["Process"] is null)
                Session["Process"] = "Submission";

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
            string CWR;
            bool PESubDone;
            string[] sessionInfo;

            empID = Session["RateeID"].ToString();  
            sessionInfo = Child.EmpInitEvalSec(empType, empID, field);

            Session["FormID"] = sessionInfo[0];
            Session["FacultyFormID"] = sessionInfo[1];
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

            computeTotal1A();
            computeTotal1B();
        }

        protected void rating1A_TextChanged(object sender, EventArgs e)
        {
            List<Label> weightLabels = new List<Label> { weight1_A, weight1_B, weight1_C };
            List<TextBox> rateTextboxes = new List<TextBox> { rating1_A, rating1_B, rating1_C };
            List<Label> scoreLabels = new List<Label> { label1_A, label1_B, label1_C };

            TextBox rating = sender as TextBox;
            try
            {
                for (int i = 0; i < rateTextboxes.Count; i++)
                {
                    if (rating.ID == rateTextboxes[i].ID)
                    {
                        if (double.Parse(rateTextboxes[i].Text) > 5)
                            rateTextboxes[i].Text = "5";
                        else if (double.Parse(rateTextboxes[i].Text) < 0)
                            rateTextboxes[i].Text = "0";
                        scoreLabels[i].Text = (double.Parse(rateTextboxes[i].Text) * double.Parse(weightLabels[i].Text) * 0.2).ToString("0.00");
                        computeTotal1A();
                        return;
                    }
                }
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
                rating.Text = "0";
            }
        }
        protected void computeTotal1A()
        {
            labelTotal1A.Text = (double.Parse(label1_A.Text) + double.Parse(label1_B.Text) + double.Parse(label1_C.Text)).ToString("0.00");
        }

        protected void rating1B_TextChanged(object sender, EventArgs e)
        {
            List<Label> weightLabels = new List<Label> { weight1_1, weight1_2, weight1_3, weight1_4, weight1_5 };
            List<TextBox> rateTextboxes = new List<TextBox> { rating1_1, rating1_2, rating1_3, rating1_4, rating1_5 };
            List<Label> scoreLabels = new List<Label> { label1_1, label1_2, label1_3, label1_4, label1_5 };

            try
            {
                TextBox rating = sender as TextBox;

                for (int i = 0; i < rateTextboxes.Count; i++)
                {
                    if (rating.ID == rateTextboxes[i].ID)
                    {
                        if (double.Parse(rateTextboxes[i].Text) > 5)
                            rateTextboxes[i].Text = "5";
                        else if (double.Parse(rateTextboxes[i].Text) < 0)
                            rateTextboxes[i].Text = "0";
                        scoreLabels[i].Text = (double.Parse(rateTextboxes[i].Text) * double.Parse(weightLabels[i].Text) * 0.2).ToString("0.00");
                        computeTotal1B();
                        return;
                    }
                }
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void computeTotal1B()
        {
            labelTotal1B.Text = (double.Parse(label1_1.Text) + double.Parse(label1_2.Text) + double.Parse(label1_3.Text) + double.Parse(label1_4.Text) + double.Parse(label1_5.Text)).ToString("0.00");
        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if ((process == "Submission" && bool.Parse(Session["PEValDone"].ToString())) != true)
                Child.UpdateDatabase(ref weightArr, ref ratingArr, Session["FacultyFormID"].ToString(), empType, field);

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
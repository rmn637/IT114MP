using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationSection4Officers : System.Web.UI.Page
    {
        TextBox[] ratingArr;
        Label[] weightArr, scoreArr;
        string empID, empType, process, field = "Section4CWR";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            weightArr = new Label[] { weight1_1, weight1_2, weight1_3, weight1_4, weight1_5};
            scoreArr = new Label[] { label2_1, label2_2, label2_3, label2_4, label2_5 };
            ratingArr = new TextBox[] { rating2_1, rating2_2, rating2_3, rating2_4, rating2_5 };

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
            Child.ComputeTotalScore(scoreArr, ref labelTotal2);
        }
        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedOfficersFormID = Session["OfficerFormID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""OfficerForm"" SET ""Section4CWR"" = @Section4CWR WHERE ""OfficerFormID"" = @OfficerFormID", connection);
                    command.Parameters.AddWithValue("@Section4CWR", compiledCWR);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficersFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected string CompileAnswers()
        {
            string text = "";

            text += $"1|{weight1_1.Text}|{rating2_1.Text};";
            text += $"2|{weight1_2.Text}|{rating2_2.Text};";
            text += $"3|{weight1_3.Text}|{rating2_3.Text};";
            text += $"4|{weight1_4.Text}|{rating2_4.Text};";
            text += $"5|{weight1_5.Text}|{rating2_5.Text};";

            return text;
        }

        protected string ratingComp(string rating)
        {
            if (rating == "5")
            {
                return "100";
            }
            else if (rating == "4")
            {
                return "80";
            }
            else if (rating == "3")
            {
                return "60";
            }
            else if (rating == "2")
            {
                return "40";
            }
            else if (rating == "1")
            {
                return "20";
            }
            else
            {
                return "0";
            }
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

        protected double inputChecker(string weight)
        {
            if (weight != "0")
            {
                return double.Parse(weight);
            }
            else
            {
                return 0;
            }
        }
        protected void computeTotalScore()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, total = 0;
            weight1 = inputChecker(label2_1.Text);
            weight2 = inputChecker(label2_2.Text);
            weight3 = inputChecker(label2_3.Text);
            weight4 = inputChecker(label2_4.Text);
            weight5 = inputChecker(label2_5.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal2.Text = total.ToString("0.00");
        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if ((process == "Submission" && bool.Parse(Session["PEValDone"].ToString())) != true)
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

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
    public partial class EvaluationCommentsOfficers : System.Web.UI.Page
    {
        string empID, empType, process, field = "Section1IOWR";
        TextBox[] commentArr;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            commentArr = new TextBox[] { strength, improvement, development, acknowledgement };

            if (Session["Process"] is null)
                Session["Process"] = "Submission";

            process = Session["Process"].ToString();

            if (Session["Process"].ToString() == "Validation")
                empType = Session["RateeEmpType"].ToString();
            else
                empType = Session["EmpType"].ToString();

            if (Session["Process"].ToString() == "Validation")
            {
                foreach (TextBox comment in commentArr)
                {
                    comment.Enabled = true;
                }
            }

            if (!IsPostBack)
            {
                Initialize();
            }
        }

        protected void Initialize()
        {
            string strComment = "", impComment = "", devComment = "", ackComment = "";

            if (!IsPostBack)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    string storedOfficerFormID = Session["OfficerFormID"].ToString();

                    string sqlCode = @"SELECT ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"" FROM ""OfficerForm"" WHERE ""OfficerFormID"" = @OfficerFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficerFormID);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) != "0")
                            strComment = reader.GetString(0);
                        if (reader.GetString(1) != "0")
                            impComment = reader.GetString(1);
                        if (reader.GetString(2) != "0")
                            devComment = reader.GetString(2);
                        if (reader.GetString(3) != "0")
                            ackComment = reader.GetString(3);
                    }
                    reader.Close();

                    strength.Text = strComment;
                    improvement.Text = impComment;
                    development.Text = devComment;
                    acknowledgement.Text = ackComment;
                }
            }
        }

        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;

            if ((process == "Submission" && bool.Parse(Session["PEValDone"].ToString())) != true)
                Child.UpdateDatabase(commentArr, empType, Session["OfficerFormID"].ToString());

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
        protected void UpdateCWR()
        {
            string storedStaffFormID = Session["OfficerFormID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""OfficerForm"" SET ""Strength"" = @Strength, ""Improvement"" = @Improvement, ""Development"" = @Development, ""Acknowledgement"" = @Acknowledgement WHERE ""OfficerFormID"" = @OfficerFormID", connection);
                    command.Parameters.AddWithValue("@Strength", strength.Text);
                    command.Parameters.AddWithValue("@Improvement", improvement.Text);
                    command.Parameters.AddWithValue("@Development", development.Text);
                    command.Parameters.AddWithValue("@Acknowledgement", acknowledgement.Text);
                    command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}